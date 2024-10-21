using Paroxe.PdfRenderer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace it_theor_idss
{
    public class SectionsData : MonoBehaviour
    {
        public List<Section> sections;
    }

    [Serializable]
    public class Section
    {
        [SerializeField] private List<Subsection> subsections;

        public List<Subsection> Subsections { get => subsections; }
    }

    [Serializable]
    public class Subsection
    {
        [SerializeField] private string shortName;
        [SerializeField] private PDFAsset m_PDFAsset;
        [SerializeField] private List<ImageInfo> images;

        public string ShortName { get => shortName; }
        public PDFAsset PDFAsset { get => m_PDFAsset; }
        public List<ImageInfo> Images { get => images; }

    }

}