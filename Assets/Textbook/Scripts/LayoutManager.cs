using Paroxe.PdfRenderer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vmaya.UI.Components;
using Vmaya.UI.UIModern;

namespace it_theor_idss
{
    public class LayoutManager : MonoBehaviour
    {
        [SerializeField] RectTransform pdfViewer;
        [SerializeField] RectTransform dictionary;
        [SerializeField] RectTransform image;
        [SerializeField] RectTransform titleImage;
        [SerializeField] RectTransform mainPanel;
        [SerializeField] VUIM_Dropdown dropdown;
        float bufferSizeXLeft, bufferSizeXRight;

        private void Start()
        {
            bufferSizeXLeft = pdfViewer.sizeDelta.x;
            bufferSizeXRight = image.sizeDelta.x;
        }

        public void ToggleDictionary()
        {
            if (!dictionary.gameObject.activeSelf)
            {
                dictionary.gameObject.SetActive(true);
                pdfViewer.sizeDelta = new Vector2(pdfViewer.sizeDelta.x, pdfViewer.sizeDelta.y - dictionary.sizeDelta.y);
            }
            else
            {
                dictionary.gameObject.SetActive(false);
                pdfViewer.sizeDelta = new Vector2(pdfViewer.sizeDelta.x, pdfViewer.sizeDelta.y + dictionary.sizeDelta.y);
            }
        }

        public void Preset1()
        {
            pdfViewer.sizeDelta = new Vector2(bufferSizeXLeft, pdfViewer.sizeDelta.y);
            pdfViewer.GetComponent<PDFViewer>().ZoomFactor = 1f;
            dictionary.sizeDelta = new Vector2(bufferSizeXLeft, dictionary.sizeDelta.y);

            image.sizeDelta = new Vector2(bufferSizeXRight, image.sizeDelta.y);
            titleImage.sizeDelta = new Vector2(bufferSizeXRight, titleImage.sizeDelta.y);

        }
        public void Preset2()
        {
            pdfViewer.sizeDelta = new Vector2(bufferSizeXRight, pdfViewer.sizeDelta.y);
            pdfViewer.GetComponent<PDFViewer>().ZoomFactor = 2f;
            dictionary.sizeDelta = new Vector2(bufferSizeXRight, dictionary.sizeDelta.y);

            image.sizeDelta = new Vector2(bufferSizeXLeft, image.sizeDelta.y);
            titleImage.sizeDelta = new Vector2(bufferSizeXLeft, titleImage.sizeDelta.y);
        }
        public void Preset3()
        {
            float bufferSizeX = pdfViewer.sizeDelta.x;
            pdfViewer.sizeDelta = new Vector2((bufferSizeXLeft + bufferSizeXRight) / 2, pdfViewer.sizeDelta.y);
            pdfViewer.GetComponent<PDFViewer>().ZoomFactor = 1.5f;
            dictionary.sizeDelta = new Vector2((bufferSizeXLeft + bufferSizeXRight) / 2, dictionary.sizeDelta.y);

            image.sizeDelta = new Vector2((bufferSizeXLeft + bufferSizeXRight) / 2, image.sizeDelta.y);
            titleImage.sizeDelta = new Vector2((bufferSizeXLeft + bufferSizeXRight) / 2, titleImage.sizeDelta.y);
        }

        public void SetLayout()
        {
            switch (dropdown.value)
            {
                case 0:
                    Preset1();
                    break;
                case 1:
                    Preset2();
                    break;
                case 2:
                    Preset3();
                    break;
                default:
                    break;
            }
            StartCoroutine(UpdateScrollRect());
        }
        public void UpdateScroll()
        {
            pdfViewer.GetComponentInChildren<ScrollRect>().verticalNormalizedPosition = 1f;
        }
        IEnumerator UpdateScrollRect()
        {
            //TODO
            yield return new WaitForSeconds(0.3f);
            pdfViewer.GetComponentInChildren<ScrollRect>().verticalNormalizedPosition = 1f;
        }
        ////Backup
        //public void Preset1()
        //{
        //    float bufferSizeX = pdfViewer.sizeDelta.x;
        //    pdfViewer.sizeDelta = new Vector2(image.sizeDelta.x, pdfViewer.sizeDelta.y);
        //    pdfViewer.GetComponent<PDFViewer>().ZoomFactor = 1f;
        //    dictionary.sizeDelta = new Vector2(image.sizeDelta.x, dictionary.sizeDelta.y);

        //    image.sizeDelta = new Vector2(bufferSizeX, image.sizeDelta.y);
        //    titleImage.sizeDelta = new Vector2(bufferSizeX, titleImage.sizeDelta.y);

        //}
        //public void Preset2()
        //{
        //    float bufferSizeX = pdfViewer.sizeDelta.x;
        //    pdfViewer.sizeDelta = new Vector2(image.sizeDelta.x, pdfViewer.sizeDelta.y);
        //    pdfViewer.GetComponent<PDFViewer>().ZoomFactor = 2f;
        //    dictionary.sizeDelta = new Vector2(image.sizeDelta.x, dictionary.sizeDelta.y);

        //    image.sizeDelta = new Vector2(bufferSizeX, image.sizeDelta.y);
        //    titleImage.sizeDelta = new Vector2(bufferSizeX, titleImage.sizeDelta.y);
        //}
    }
}