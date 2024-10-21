using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace it_theor_idss
{
    public class SceneManager : MonoBehaviour
    {
        public void ToggleObject(GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        public void AppQuit()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}