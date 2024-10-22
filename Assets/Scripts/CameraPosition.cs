using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] Transform animationWathPositiion;

    private Vector3 _startCameraPosition;
    private Quaternion _startCameraRotation;

    private void Start()
    {
        _startCameraPosition = transform.position;
        _startCameraRotation = transform.rotation;
    }

    public void AnimationWatchPosition()
    {
        transform.position = animationWathPositiion.position;
        transform.rotation = animationWathPositiion.rotation;
    }
    public void CameraStartPosition()
    {
        transform.position = _startCameraPosition;
        transform.rotation = _startCameraRotation;
    }
}
