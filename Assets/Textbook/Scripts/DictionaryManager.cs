using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace it_theor_idss
{
    [Serializable]
    class Term
    {
        public string name;
        [Multiline] public string definition;
    }

    public class DictionaryManager : MonoBehaviour
    {
        [SerializeField] GameObject termButtonPrefab;
        [SerializeField] GameObject definitionPrefab;
        [SerializeField] GameObject termsPanel;
        [SerializeField] GameObject stubObj;
        [SerializeField] UILayoutRebuild layoutRebuild;

        [SerializeField] List<Term> terms;
        List<GameObject> buttonsTerms = new List<GameObject>();

        GameObject definitionObj;

        private void Start()
        {
            GameObject currentButton;
            definitionObj = Instantiate(definitionPrefab, termsPanel.transform);
            definitionObj.SetActive(false);
            stubObj.SetActive(false);

            foreach (Term term in terms)
            {
                currentButton = Instantiate(termButtonPrefab, termsPanel.transform);
                currentButton.GetComponentInChildren<TextMeshProUGUI>().text = term.name;
                currentButton.GetComponent<DictionaryDefinition>().definitionObj = definitionObj;
                currentButton.GetComponent<DictionaryDefinition>().definitionText = term.definition;
                currentButton.GetComponent<DictionaryDefinition>().stubObj = stubObj;
                currentButton.GetComponentInChildren<Button>().onClick.AddListener(definitionObj.GetComponent<UILayoutRebuild>().CallFixUI);
                currentButton.GetComponentInChildren<Button>().onClick.AddListener(layoutRebuild.CallFixUI);

                buttonsTerms.Add(currentButton);
            }

            stubObj.transform.SetAsLastSibling();

        }

        public void FindTerm(TMP_InputField inputField)
        {
            string currentText = inputField.text.ToLower();

            //StartCoroutine(FixAllUI());
            if (definitionObj.activeSelf)
            {
                definitionObj.SetActive(false);
                stubObj.SetActive(false);
            }

            if (currentText != "")
            {
                for (int i = 0; i < buttonsTerms.Count; i++)
                {
                    if (buttonsTerms[i].GetComponentInChildren<TextMeshProUGUI>().text.ToLower().Contains(currentText))
                    {
                        buttonsTerms[i].SetActive(true);
                    }
                    else { buttonsTerms[i].SetActive(false); }
                }
            }
            else
            {
                for (int i = 0; i < buttonsTerms.Count; i++)
                {
                    buttonsTerms[i].SetActive(true);
                }
            }
            layoutRebuild.CallFixUI();
        }

    }
}