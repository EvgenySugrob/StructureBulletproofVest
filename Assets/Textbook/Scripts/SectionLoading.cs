using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace it_theor_idss
{
    public class SectionLoading : MonoBehaviour
    {
        [SerializeField] int mainSceneID;
        public void SectionLoad(int section)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(mainSceneID);
            PlayerPrefs.SetInt("Section", section);
        }
    }
}