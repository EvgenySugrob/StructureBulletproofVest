using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] Transform animationWathPositiion;
    [SerializeField] GameObject textilPlate;
    [SerializeField] Transform cameraMain;

    private Vector3 _startCameraPosition;
    private Quaternion _startCameraRotation;

    private void Start()
    {
        _startCameraPosition = cameraMain.position;
        _startCameraRotation = cameraMain.rotation;
    }

    public void AnimationWatchPosition()
    {
        textilPlate.SetActive(true);
        cameraMain.position = animationWathPositiion.position;
        cameraMain.rotation = animationWathPositiion.rotation;
    }
    public void CameraStartPosition()
    {
        textilPlate.SetActive(false);
        cameraMain.position = _startCameraPosition;
        cameraMain.rotation = _startCameraRotation;
    }
}
