using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TempWorldSpaceUIClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if we hit a UI element
                if (hit.collider.gameObject.GetComponent<CanvasRenderer>() != null)
                {
                    // Simulate a UI click
                    PointerEventData pointer = new PointerEventData(EventSystem.current);
                    pointer.position = Input.mousePosition;

                    List<RaycastResult> results = new List<RaycastResult>();
                    EventSystem.current.RaycastAll(pointer, results);

                    foreach (var result in results)
                    {
                        ExecuteEvents.Execute(result.gameObject, pointer, ExecuteEvents.pointerClickHandler);
                    }
                }
            }
        }
    }
}