using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrefabModelsOpen : MonoBehaviour
{
    [SerializeField] Transform startPointPrefab;
    [SerializeField] RotationObject rotationObject;

    [SerializeField] List<GameObject> interactiveGroupItems;
    [SerializeField] GameObject hideShowPanelButtons;

    [SerializeField] List<GameObject> uiPanels;

    //[SerializeField] List<PanelDescriptionOn3DModel> panelDescriptionOn3DModels;
    private int prevIndexGroup = 0;
    private int prevChildIndex = 0;

    public void OpenInteractiveGroupItems(int index)
    {
        interactiveGroupItems[prevIndexGroup].SetActive(false);
        interactiveGroupItems[index].SetActive(true);

        prevIndexGroup= index;

        if (index == 1)
        {
            hideShowPanelButtons.SetActive(true);
        }
        else
        {
            hideShowPanelButtons.SetActive(false);
        }
    }

    public void CildInteractiveGroupOpen(int indexChild)
    {
        interactiveGroupItems[prevIndexGroup].transform.GetChild(prevChildIndex).gameObject.SetActive(false);
        interactiveGroupItems[prevIndexGroup].transform.GetChild(indexChild).gameObject.SetActive(true);

        prevChildIndex= indexChild;

        rotationObject.SetRotationGroup(interactiveGroupItems[prevIndexGroup].gameObject);
        rotationObject.ResetRotation();

        //DiactivatePanel();
    }
    public void CloseInteractGroup()
    {
        interactiveGroupItems[prevIndexGroup].transform.GetChild(prevChildIndex).gameObject.SetActive(false);
        interactiveGroupItems[prevIndexGroup].gameObject.SetActive(false);

        GameObject panel = uiPanels.First(obj => obj.activeSelf);
        panel.SetActive(false);

        hideShowPanelButtons.SetActive(false);
        //DiactivatePanel();
    }

    //private void DiactivatePanel()
    //{
    //    foreach (PanelDescriptionOn3DModel panel in panelDescriptionOn3DModels)
    //    {
    //        if (panel.IsActivePanel())
    //        {
    //            panel.PanelsState(false);
    //        }
    //    }
    //}
}
