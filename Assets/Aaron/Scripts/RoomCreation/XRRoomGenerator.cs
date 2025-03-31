// Written by Aaron Williams

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRRoomGenerator : MonoBehaviour
{
    [Header("Is In Virtual Reality")]
    [SerializeField] private bool isVR;

    [Header("Floor Point Settings")]
    [SerializeField] private GameObject floorPointPrefab;

    [Header("Controller Settings")]
    [SerializeField] private Transform controllerTransform;
    [SerializeField] private OVRInput.Controller ovrController = OVRInput.Controller.RTouch;
    [SerializeField] private OVRInput.Button targetLineActivationButton = OVRInput.Button.PrimaryHandTrigger;
    [SerializeField] private OVRInput.Button placeFloorPointButton = OVRInput.Button.PrimaryIndexTrigger;
    [SerializeField] private OVRInput.Button generateRoomButton = OVRInput.Button.One;

    [Header("Target LineRenderer Settings")]
    [SerializeField] private float maxTargetLineDistanceNoPointSelected = 10f;
    [SerializeField] private float maxTargetLineDistancePointSelected = 100f;
    [SerializeField] private float targetLineWidth = 0.01f;
    [SerializeField] private Color validTargetPlacementColor = Color.green;
    [SerializeField] private Color invalidTargetColor = Color.red;
    [SerializeField] private Color validTargetSelectionColor = Color.yellow;

    [Header("Edge LineRenderer Settings")]
    [SerializeField] private Color edgeLineColor = Color.blue;
    [SerializeField] private float edgeLineWidth = 0.03f;

    [Header("Selection Padding")]
    [SerializeField] private float floorPointSelectionPadding = 0.2f;
    [SerializeField] private float edgeSelectionPadding = 0.2f;

    [Header("Mesh Generation Settings")]
    [SerializeField] private float wallHeight = 2.5f;
    [SerializeField] private Material floorMaterial;
    [SerializeField] private Material wallMaterial;
    [SerializeField] private Material ceilingMaterial;

    private const string EDGE_LINE_RENDERER_NAME = "Edge LineRenderer";
    [SerializeField] private LineRenderer targetLineRenderer;
    private LineRenderer edgeLineRenderer;
    private Color currentTargetLineColor;

    private List<Vector3> floorPoints = new();
    private List<GameObject> floorPointPrefabs = new();

    public const string FLOOR_MESH_NAME = "Floor Mesh";
    public const string CEILING_MESH_NAME = "Ceiling Mesh";

    private GameObject floorGameObject;
    private List<GameObject> wallGameObjects = new();
    private GameObject ceilingGameObject;

    private bool isTargetValid = false;
    private Vector3 targetHitPoint = Vector3.zero;

    private int selectedPointIndex = -1;
    private GameObject selectedSphere = null;

    private bool isTargetOnEdge = false;
    private int edgeStartIndex = -1;
    private int edgeEndIndex = -1;
    private Vector3 edgeStartPoint;
    private Vector3 edgeEndPoint;

    private int movingPointLayerMask;
    private bool isTargetLineVisible = false;

    private void Start()
    {
        if (targetLineRenderer == null)
        {
            targetLineRenderer = InitializeLineRenderer(targetLineWidth, invalidTargetColor, false);
        }
        else
        {
            targetLineRenderer = InitializeLineRenderer(targetLineWidth, invalidTargetColor, false, null, targetLineRenderer);
        }

        edgeLineRenderer = InitializeLineRenderer(edgeLineWidth, edgeLineColor, true, EDGE_LINE_RENDERER_NAME);
        movingPointLayerMask = ~(LayerMask.GetMask("Floor", "Walls"));
    }

    private void Update()
    {
        if (isTargetLineVisible)
        {
            UpdateTargetLine();
        }
        else
        {
            DeactivateTargetLine();
        }

        // TODO: Update VR Input to use new system
        //if (OVRInput.GetDown(placeFloorPointButton, ovrController))
        //{
        //    HandlePlaceSelectPoint();
        //}
        //if (OVRInput.GetUp(placeFloorPointButton, ovrController))
        //{
        //    if(selectedPointIndex >= 0)
        //    {
        //        DeselectPoint();
        //    }
        //}
        //if (OVRInput.GetDown(generateRoomButton, ovrController))
        //{
        //    GenerateRoom();
        //}
        
        if (selectedPointIndex >= 0)
        {
            UpdateSelectedPointPosition();
        }
    }
    public void HandleToggleTargetLineInoutKBM(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isTargetLineVisible = true;
        }
        if (context.canceled)
        {
            isTargetLineVisible = false;
        }
    }

    public void HandlePlaceFloorButtonInputKBM(InputAction.CallbackContext context)
    {
        if (context.started && isTargetLineVisible)
        {
            HandlePlaceSelectPoint();
        }
        else if (context.canceled)
        {
            if (selectedPointIndex >= 0)
            {
                DeselectPoint();
            }
        }     
    }

    public void HandleGenerateRoomButtonInputKBM(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            GenerateRoom();
        }
    }

    private LineRenderer InitializeLineRenderer(float width, Color color, bool isDistinctGameObject, string gameObjectName = null, LineRenderer lineRenderer = null)
    {
        if(lineRenderer == null)
        {
            lineRenderer = isDistinctGameObject ? new GameObject(gameObjectName).AddComponent<LineRenderer>() : gameObject.AddComponent<LineRenderer>();
            if (isDistinctGameObject) { lineRenderer.transform.parent = transform; }
        }

        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        lineRenderer.material.color = color;
        lineRenderer.enabled = false;

        return lineRenderer;
    }

    private void UpdateTargetLine()
    {
        targetLineRenderer.enabled = true;
        edgeLineRenderer.enabled = false;
        isTargetValid = false;

        bool isPointNearby = false;

        Vector3 targetLineOrigin = controllerTransform.position;
        Vector3 targetLineDirection = controllerTransform.forward;

        int layerMask;
        float maxTargetDistance;
        if (selectedPointIndex >= 0)
        {
            maxTargetDistance = maxTargetLineDistancePointSelected;
            layerMask = movingPointLayerMask;
        }
        else
        {
            maxTargetDistance = maxTargetLineDistanceNoPointSelected;
            layerMask = -1;
        }

        targetHitPoint = targetLineOrigin + targetLineDirection * maxTargetDistance;

        if (Physics.Raycast(targetLineOrigin, targetLineDirection, out RaycastHit hit, maxTargetDistance, layerMask))
        {
            targetHitPoint = hit.point;

            isTargetValid = hit.point.y < 0.01f;

            if (selectedPointIndex < 0 && floorGameObject != null && floorPoints.Count >= 3)
            {
                isPointNearby = IsFloorPointNearHit(targetHitPoint);
                if (!isPointNearby) { CheckForEdgeHit(targetHitPoint); }
            }
        }

        currentTargetLineColor = (isPointNearby || selectedPointIndex >= 0) ? validTargetSelectionColor : (isTargetValid ? validTargetPlacementColor : invalidTargetColor);
        UpdateLineRenderer(targetLineRenderer, targetLineOrigin, targetHitPoint, currentTargetLineColor);
    }

    private void DeactivateTargetLine()
    {
        targetLineRenderer.enabled = false;
        edgeLineRenderer.enabled = false;
        DeselectPoint();
    }

    private void UpdateSelectedPointPosition()
    {
        if (isTargetValid)
        {
            floorPoints[selectedPointIndex] = new Vector3(targetHitPoint.x, 0, targetHitPoint.z);
            selectedSphere.transform.position = targetHitPoint;

            RegenerateRoom();
        }
    }

    private void HandlePlaceSelectPoint()
    {
        selectedPointIndex = TrySelectClosestPoint();

        if (selectedPointIndex >= 0)
        {
            selectedSphere = floorPointPrefabs[selectedPointIndex];
        }
        else if (isTargetOnEdge)
        {
            InsertFloorPointOnEdge();
        }
        else if (isTargetValid)
        {
            CreateFloorPoint();
        }
    }

    private int TrySelectClosestPoint()
    {
        int closestIndex = -1;
        float closestDistance = floorPointSelectionPadding;

        for (int i = 0; i < floorPoints.Count; i++)
        {
            float distanceToHit = Vector3.Distance(floorPoints[i], targetHitPoint);
            if (distanceToHit < closestDistance)
            {
                closestDistance = distanceToHit;
                closestIndex = i;
            }
        }

        return closestIndex;
    }

    private void DeselectPoint()
    {
        selectedPointIndex = -1;
        selectedSphere = null;
    }

    private void RegenerateRoom()
    {
        if (floorGameObject != null && wallGameObjects != null && floorPoints.Count >= 3)
        {
            GenerateRoom();
        }
    }

    private void GenerateRoom()
    {
        if (floorPoints.Count >= 3)
        {
            if (floorGameObject != null) { Destroy(floorGameObject); }
            if (ceilingGameObject != null) { Destroy(ceilingGameObject); }

            if (wallGameObjects != null)
            {
                foreach (GameObject wall in wallGameObjects)
                {
                    if (wall != null) { Destroy(wall); }
                }
            }

            List<Vector3> ceilingVertices = new();
            foreach (Vector3 point in floorPoints)
            {
                ceilingVertices.Add(new Vector3(point.x, wallHeight, point.z));
            }

            ceilingGameObject = MeshGenerator.GenerateFlatMesh(ceilingVertices, ceilingMaterial, CEILING_MESH_NAME);
            floorGameObject = MeshGenerator.GenerateFlatMesh(floorPoints, floorMaterial, FLOOR_MESH_NAME);
            wallGameObjects = MeshGenerator.GenerateWallMeshes(floorPoints, wallMaterial, wallHeight);
        }
    }

    private bool IsFloorPointNearHit(Vector3 hitPoint)
    {
        foreach (Vector3 floorPoint in floorPoints)
        {
            if (Vector3.Distance(floorPoint, hitPoint) < floorPointSelectionPadding) { return true; }
        }
        return false;
    }

    private void UpdateLineRenderer(LineRenderer lineRenderer, Vector3 start, Vector3 end, Color color)
    {
        lineRenderer.SetPositions(new Vector3[] { start, end });
        lineRenderer.material.color = color;
    }
    private void CreateFloorPoint()
    {
        floorPoints.Add(targetHitPoint);
        floorPointPrefabs.Add(Instantiate(floorPointPrefab, targetHitPoint, Quaternion.identity));
    }

    private void CheckForEdgeHit(Vector3 hitPoint)
    {
        edgeLineRenderer.enabled = false;
        isTargetOnEdge = false;
        edgeStartIndex = -1;
        edgeEndIndex = -1;

        float closestDistance = edgeSelectionPadding;

        for (int i = 0; i < floorPoints.Count; i++)
        {
            int nextIndex = (i + 1) % floorPoints.Count;

            Vector3 edgeStartPoint = floorPoints[i];
            Vector3 edgeEndPoint = floorPoints[nextIndex];
            Vector3 edge = edgeEndPoint - edgeStartPoint;
            Vector3 edgeDirection = edge / edge.magnitude;

            // Magic
            Vector3 edgeStartPointToHitPoint = hitPoint - edgeStartPoint;
            float projection = Vector3.Dot(edgeStartPointToHitPoint, edgeDirection);
            if (projection < 0 || projection > edge.magnitude) { continue; }
            Vector3 closestPoint = edgeStartPoint + edgeDirection * projection;
            // End Magic

            float distance = Vector3.Distance(hitPoint, closestPoint);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                edgeStartIndex = i;
                edgeEndIndex = nextIndex;
                isTargetOnEdge = true;

                this.edgeStartPoint = edgeStartPoint;
                this.edgeEndPoint = edgeEndPoint;

                edgeLineRenderer.enabled = true;
                UpdateLineRenderer(edgeLineRenderer, new Vector3(edgeStartPoint.x, 0.01f, edgeStartPoint.z), new Vector3(edgeEndPoint.x, 0.01f, edgeEndPoint.z), edgeLineColor);
            }
        }
    }

    private void InsertFloorPointOnEdge()
    {
        Vector3 edgeStartPoint = floorPoints[edgeStartIndex];
        Vector3 edgeEndPoint = floorPoints[edgeEndIndex];
        Vector3 edge = edgeEndPoint - edgeStartPoint;
        Vector3 edgeDirection = edge / edge.magnitude;

        // Magic
        float projection = Vector3.Dot(targetHitPoint - edgeStartPoint, edgeDirection);
        Vector3 pointPosition = edgeStartPoint + edgeDirection * projection;
        int insertIndex = (edgeStartIndex < edgeEndIndex) ? edgeEndIndex : (edgeEndIndex == 0) ? floorPoints.Count : edgeEndIndex;
        // End Magic

        floorPoints.Insert(insertIndex, new Vector3(pointPosition.x, 0, pointPosition.z));
        floorPointPrefabs.Insert(insertIndex, Instantiate(floorPointPrefab, pointPosition, Quaternion.identity));

        RegenerateRoom();

        edgeStartIndex = -1;
        edgeEndIndex = -1;
    }
}
