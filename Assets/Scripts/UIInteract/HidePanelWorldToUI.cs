using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanelWorldToUI : MonoBehaviour
{
    [SerializeField] RectTransform uiPanel;
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform pointForUI;

    private void Update()
    {
        WorldToUI();
    }
    private void WorldToUI()
    {
        uiPanel.position = mainCamera.WorldToScreenPoint(pointForUI.position);
    }
}
