using it_theor_idss;
using Paroxe.PdfRenderer;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vmaya.UI.UIModern;

namespace it_theor_idss
{
    public class SectionsManager : MonoBehaviour
    {
        [SerializeField] SectionsData sectionsData;
        [SerializeField] PDFViewer pdfViewer;
        [SerializeField] ImageToggler imageToggler;
        [SerializeField] Button buttonNext, buttonPrev;
        [SerializeField] VUIM_Dropdown dropdown;

        int currentSection;
        int currentSubsection;
        int subsectionsCount;

        private void Awake()
        {

            LoadSection(PlayerPrefs.GetInt("Section"));
        }

        public void LoadSection(int section)
        {
            currentSection = section;
            currentSubsection = 0;
            pdfViewer.LoadDocumentFromAsset(sectionsData.sections[currentSection].Subsections[currentSubsection].PDFAsset);
            imageToggler.LoadImages(sectionsData.sections[currentSection].Subsections[currentSubsection].Images);

            buttonPrev.interactable = false;
            buttonNext.interactable = true;

            subsectionsCount = sectionsData.sections[currentSection].Subsections.Count;


            dropdown.ClearOptions();
            List<string> subsectionsName = new List<string>();
            foreach (var subsection in sectionsData.sections[currentSection].Subsections)
            {
                subsectionsName.Add(subsection.ShortName);
            }
            dropdown.AddOptions(subsectionsName);
            dropdown.value = currentSubsection;
        }

        void LoadSubsection(int currentSection, int currentSubsection)
        {
            float currentZoom = pdfViewer.ZoomFactor;
            pdfViewer.LoadDocumentFromAsset(sectionsData.sections[currentSection].Subsections[currentSubsection].PDFAsset);
            pdfViewer.ZoomFactor = currentZoom;
            imageToggler.LoadImages(sectionsData.sections[currentSection].Subsections[currentSubsection].Images);

            dropdown.value = currentSubsection;
        }

        public void NextSubsection()
        {
            if (currentSubsection != subsectionsCount - 1)
            {
                currentSubsection++;
                LoadSubsection(currentSection, currentSubsection);
                
                if (currentSubsection == subsectionsCount - 1) 
                { buttonNext.interactable = false; }
                if (currentSubsection > 0 && !buttonPrev.interactable) { buttonPrev.interactable = true; }
            }
        }

        public void PrevSubsection()
        {
            if (currentSubsection != 0)
            {
                currentSubsection--;
                LoadSubsection(currentSection, currentSubsection);

                if (currentSubsection == 0) { buttonPrev.interactable = false; }
                if (currentSubsection < subsectionsCount - 1 && !buttonNext.interactable) 
                { buttonNext.interactable = true; }
            }
        }

        public void ChooseSection()
        {
            currentSubsection = dropdown.value;
            LoadSubsection(currentSection, currentSubsection);

            if (currentSubsection == 0)                                     { buttonPrev.interactable = false; buttonNext.interactable = true; }
            else if (currentSubsection == subsectionsCount - 1)             { buttonPrev.interactable = true; buttonNext.interactable = false; }
            else if (!buttonPrev.interactable || !buttonNext.interactable)  { buttonPrev.interactable = true; buttonNext.interactable = true; }
            
        }
    }
}