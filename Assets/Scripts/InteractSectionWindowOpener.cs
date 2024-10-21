using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSectionWindowOpener : MonoBehaviour
{
    [SerializeField] List<GameObject> windowsList;

    public void OpenWindow (int indexWindow)
    {
        CheckAllredyOpenWindow();
        windowsList[indexWindow].SetActive(true);
    }

    public void CheckAllredyOpenWindow()
    {
        foreach (GameObject item in windowsList)
        {
            if (item.activeSelf)
            {
                item.SetActive(false);
                break;
            }
        }
    }
}
