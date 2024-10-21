using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace it_theor_idss
{
    public class DictionaryDefinition : MonoBehaviour
    {
        [NonSerialized] public GameObject definitionObj;
        [NonSerialized] public GameObject stubObj;
        [NonSerialized] public string definitionText;

        public void ToggleDefinition()
        {
            if (definitionObj.transform.parent != gameObject.transform)
            {
                definitionObj.transform.parent = gameObject.transform;
                definitionObj.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                definitionObj.SetActive(true);
                definitionObj.GetComponentInChildren<TextMeshProUGUI>().text = definitionText;
                stubObj.SetActive(true);
            }
            else
            {
                definitionObj.SetActive(!definitionObj.activeSelf);
                if (!definitionObj.activeSelf && stubObj.activeSelf) { stubObj.SetActive(false); }
                else { stubObj.SetActive(true); }
            }

        }
    }
}