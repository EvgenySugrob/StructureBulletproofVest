using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseInteractiveSection : MonoBehaviour
{
    [SerializeField] List<GameObject> needOff;
    [SerializeField] List<GameObject> needOn;

    public void SwitchOnInteractiveSection(bool isOn)
    {
        if(isOn)
        {
            foreach(GameObject gameObject in needOff)
            {
                gameObject.SetActive(false);
            }
            foreach(GameObject gameObject in needOn)
            {
                gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject gameObject in needOff)
            {
                gameObject.SetActive(true);
            }
            foreach (GameObject gameObject in needOn)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
