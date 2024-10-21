using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace it_theor_idss
{
    public class UILayoutRebuild : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine(FixUI());
        }
        public IEnumerator FixUI()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
            yield return null;
            LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
        }

        public void CallFixUI()
        {
            if (gameObject.activeSelf)
            {
                StartCoroutine(FixUI());
            }
        }
    }
}