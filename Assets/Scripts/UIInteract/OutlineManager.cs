using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineManager : MonoBehaviour
{
    [SerializeField] List<GameObject> pointsAndPanel;
    [SerializeField] Outline outline;

    public void EnableOutline(bool isActive)
    {
        outline.enabled = isActive;
        foreach (GameObject item in pointsAndPanel)
        {
            item.SetActive(isActive);
        }
    }
}
