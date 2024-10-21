using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OutlineDetected : MonoBehaviour
{
    [SerializeField] GameObject currentObject;
    [SerializeField] OutlineManager currentOutlineManager;

    [SerializeField] float distanceRay;
    [SerializeField] LayerMask layerMask;

    private OutlineManager prevOutlineManager;
    private Camera mainCamera;
    private bool isDetectedActive;

    private void Start()
    {
        mainCamera= GetComponent<Camera>();
    }

    private void Update()
    {
        if(isDetectedActive)
        {
            Detected();
        }
    }

    private void Detected()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanceRay, layerMask))
        {
            currentObject = hit.collider.gameObject;

            if(currentObject.GetComponent<Outline>())
            {
                currentOutlineManager = currentObject.GetComponent<OutlineManager>();

                if(prevOutlineManager == null)
                {
                    prevOutlineManager = currentOutlineManager;
                }
                if(prevOutlineManager != currentOutlineManager)
                {
                    prevOutlineManager.EnableOutline(false);
                    prevOutlineManager = currentOutlineManager;
                }
            }

            if(currentOutlineManager != null && currentObject.GetComponent<OutlineManager>())
            {
                currentOutlineManager.EnableOutline(true);
            }
            else if(currentOutlineManager !=null && currentObject.GetComponent<OutlineManager>()==false)
            {
                currentOutlineManager.EnableOutline(false);
            }
        }
        else
        {
            if(currentOutlineManager != null)
            {
                currentOutlineManager.EnableOutline(false);
                currentOutlineManager = null;
                currentObject= null;
            }
        }
    }

    public void DetectedActive()
    {
        isDetectedActive = !isDetectedActive;
        if(!isDetectedActive ==false)
        {
            if(currentOutlineManager != null)
            {
                currentOutlineManager.EnableOutline(false);
            }
        }
    }
}
