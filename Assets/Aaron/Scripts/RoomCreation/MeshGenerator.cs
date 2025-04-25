// Written by Aaron Williams

using System;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGenerator
{
    public static GameObject GenerateFlatMesh(List<Vector3> vertices, Material material, string name)
    {
        GameObject flatObject = new GameObject(name);
        flatObject.layer = LayerMask.NameToLayer("Floor");

        MeshFilter meshFilter = flatObject.AddComponent<MeshFilter>();
        MeshCollider meshCollider = flatObject.AddComponent<MeshCollider>();
        MeshRenderer meshRenderer = flatObject.AddComponent<MeshRenderer>();

        meshRenderer.material = material;

        Mesh mesh = new();

        int[] triangles = new int[(vertices.Count - 2) * 3];
        for (int i = 0; i < vertices.Count - 2; i++)
        {
            // Magic
            if (name.Equals(RoomGenerator.CEILING_MESH_NAME, StringComparison.OrdinalIgnoreCase))
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 2;
                triangles[i * 3 + 2] = i + 1;
            }
            else
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
            // End Magic
        }

        Vector2[] uv = new Vector2[vertices.Count];
        for (int i = 0; i < vertices.Count; i++)
        {
            uv[i] = new Vector2(vertices[i].x, vertices[i].z);
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles;
        mesh.uv = uv;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;

        return flatObject;

       
    }

    public static GameObject GenerateWallMeshes(List<Vector3> floorPoints, Material wallMaterial, float wallHeight)
    {
        GameObject wallGameObjectParent = new GameObject("Walls");

        int wallsCount = floorPoints.Count;

        for (int i = 0; i < wallsCount; i++)
        {
            int next = (i + 1) % wallsCount;
            Vector3 floorPointA = floorPoints[i];
            Vector3 floorPointB = floorPoints[next];

            GameObject wallObject = new GameObject("Wall");
            wallObject.layer = LayerMask.NameToLayer("Walls");
            wallObject.transform.SetParent(wallGameObjectParent.transform);

            MeshFilter meshFilter = wallObject.AddComponent<MeshFilter>();
            MeshCollider meshCollider = wallObject.AddComponent<MeshCollider>();
            MeshRenderer meshRenderer = wallObject.AddComponent<MeshRenderer>();

            meshRenderer.material = wallMaterial;

            Mesh mesh = new();

            // Magic
            Vector3[] vertices = new Vector3[4]
            {
                new(floorPointA.x, 0, floorPointA.z), // Bottom-left
                new(floorPointB.x, 0, floorPointB.z), // Bottom-right
                new(floorPointB.x, wallHeight, floorPointB.z), // Top-right
                new(floorPointA.x, wallHeight, floorPointA.z)  // Top-left
            };

            int[] triangles = new int[6] { 0, 2, 1, 0, 3, 2 };

            float wallLength = Vector3.Distance(floorPointA, floorPointB);

            Vector2[] uv = new Vector2[4]
            {
                new(0, 0),
                new(wallLength, 0),
                new(wallLength, 1),
                new(0, 1)
            };
            // End Magic

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.uv = uv;

            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            meshFilter.mesh = mesh;
            meshCollider.sharedMesh = mesh;
        }

        return wallGameObjectParent;
    }
}