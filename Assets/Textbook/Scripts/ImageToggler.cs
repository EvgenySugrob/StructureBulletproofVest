using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace it_theor_idss
{
    [Serializable]
    public class ImageInfo
    {
        public Sprite sprite; public string title;
    }
    public class ImageToggler : MonoBehaviour
    {
        [SerializeField] Button buttonPrev;
        [SerializeField] Button buttonNext;
        [SerializeField] GameObject imageTogglesPanel;
        [SerializeField] Image image;
        [SerializeField] TextMeshProUGUI titleImage;

        int currentSpriteIndex;

        List<ImageInfo> images = new List<ImageInfo>();
        public List<ImageInfo> Images { get => images; set => images = value; }

        void Start()
        {
            if (Images.Count != 0)
            {
                image.sprite = Images[0].sprite;
                SetTitleText(Images[0].title);
                currentSpriteIndex = 0;
                buttonPrev.interactable = false;
            }
            if (Images.Count == 1) { imageTogglesPanel.SetActive(false); }

        }

        public void LoadImages(List<ImageInfo> imageInfo)
        {
            Images = imageInfo;
            if (Images.Count != 0)
            {
                image.sprite = Images[0].sprite;
                SetTitleText(Images[0].title);
                currentSpriteIndex = 0;
                buttonPrev.interactable = false;
                buttonNext.interactable = true;
            }
            if (Images.Count == 1) { imageTogglesPanel.SetActive(false); }
            else if (!imageTogglesPanel.activeSelf) { imageTogglesPanel.SetActive(true);}
        }

        public void NextImage()
        {
            if (image.sprite != Images[Images.Count - 1].sprite)
            {
                currentSpriteIndex++;
                image.sprite = Images[currentSpriteIndex].sprite;
                SetTitleText(Images[currentSpriteIndex].title);
                if (image.sprite == Images[Images.Count - 1].sprite)
                {
                    buttonNext.interactable = false;
                }

                if (currentSpriteIndex > 0 && !buttonPrev.interactable)
                {
                    buttonPrev.interactable = true;
                }
            }
        }
        public void PreviousImage()
        {
            if (image.sprite != Images[0].sprite)
            {
                currentSpriteIndex--;
                image.sprite = Images[currentSpriteIndex].sprite;
                SetTitleText(Images[currentSpriteIndex].title);
                if (image.sprite == Images[0].sprite)
                {
                    buttonPrev.interactable = false;
                }

                if (currentSpriteIndex < Images.Count - 1 && !buttonNext.interactable)
                {
                    buttonNext.interactable = true;
                }
            }
        }

        void SetTitleText(string text)
        {
            titleImage.text = text;
            //Vector2 textSize = titleImage.GetPreferredValues(titleImage.text);
            //titleImage.rectTransform.sizeDelta = textSize;
        }
    }
}