using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class WindowPositionToWorld : MonoBehaviour
{
    [SerializeField] List<Transform> pointObject;
    [SerializeField] Transform pointUILine;
    [SerializeField] Transform pointForUI;
    [SerializeField] RectTransform uiPanel;
    [SerializeField] Camera mainCamera;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] LayerMask layerMask;

    [SerializeField] float offset = 0.25f;

    private void WorldToUI()
    {
        uiPanel.position = mainCamera.WorldToScreenPoint(pointForUI.position); 
    }

    private void CheckVisibility()
    {
        foreach (Transform point in pointObject)
        {
            point.LookAt(mainCamera.transform);

            
            Debug.DrawRay(point.transform.position, point.transform.forward * 15f, Color.red);

            RaycastHit hit;

            if(Physics.Raycast(point.transform.position,point.transform.forward, out hit,15f,layerMask))
            {

                if(hit.transform.gameObject != mainCamera.gameObject)
                {
                    uiPanel.gameObject.SetActive(false);
                    lineRenderer.enabled= false;
                }
                else
                {
                    uiPanel.gameObject.SetActive(true);
                    lineRenderer.enabled= true;
                }
                break;
            }
        }
    }
    private void LineRendererUIToObject()
    {
        Vector3 offsetVector = new Vector3(pointObject[0].position.x, pointObject[0].position.y, pointObject[0].position.z + offset);

        lineRenderer.SetPosition(0, offsetVector);
        lineRenderer.SetPosition(1, mainCamera.ScreenToWorldPoint(pointUILine.position));

    }

    private void Update()
    {
        WorldToUI();
        CheckVisibility();
        LineRendererUIToObject();
    }
}
