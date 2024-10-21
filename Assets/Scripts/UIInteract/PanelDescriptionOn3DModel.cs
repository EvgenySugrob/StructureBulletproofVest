using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDescriptionOn3DModel : MonoBehaviour
{
    [SerializeField] GameObject panelOnUI;
    [SerializeField] List<GameObject> pointsOnModel;
    [SerializeField] string namePanel;

    private bool isActive;

    public void PanelsState(bool state)
    {
        panelOnUI.SetActive(state);
        isActive= state;
        foreach (GameObject item in pointsOnModel)
        {
            item.SetActive(state);
        }
    }

    public bool IsActivePanel()
    {
        return isActive;
    }

    public string GetNamePanel()
    {
        return namePanel;
    }
}
