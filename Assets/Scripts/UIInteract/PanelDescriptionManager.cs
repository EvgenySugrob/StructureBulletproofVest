using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelDescriptionManager : MonoBehaviour
{
    [SerializeField] List<PanelDescriptionOn3DModel> panelDescriptionOn3DModels;

    [SerializeField] List<Sprite> imagesButtonsSwap;
    [SerializeField] Image imageButtons;
    [SerializeField] List<GameObject> collidersView;
    private string cashNamePanel;
    private bool isAllPanelDeactivated = false;

    private void CheckPanelActive()
    {
        foreach (PanelDescriptionOn3DModel panel in panelDescriptionOn3DModels)
        {
            if (panel.IsActivePanel())
            {
                panel.PanelsState(false);
            }
        }
    }
    private void NeedPanelsActive(string name)
    {
        foreach (PanelDescriptionOn3DModel panel in panelDescriptionOn3DModels)
        {
            if (name == panel.GetNamePanel())
            {
                panel.PanelsState(true);
            }
        }
    }    

    public void ActiveNeedsPanel(string name)
    {
        cashNamePanel = name;
        if (isAllPanelDeactivated == false)
        {
            CheckPanelActive();
            NeedPanelsActive(cashNamePanel);
        }
    }

    public void HideShowNeedsPanel()
    {
        isAllPanelDeactivated = !isAllPanelDeactivated;
        if (isAllPanelDeactivated)
        {
            CheckPanelActive();
            foreach (GameObject item in collidersView)
            {
                item.SetActive(false);
            }
            imageButtons.sprite = imagesButtonsSwap[1];
        }
        else
        {
            NeedPanelsActive(cashNamePanel);
            foreach (GameObject item in collidersView)
            {
                item.SetActive(true);
            }
            imageButtons.sprite = imagesButtonsSwap[0];
        }
    }
}
