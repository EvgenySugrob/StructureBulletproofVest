using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotationObject : MonoBehaviour
{
    [SerializeField] private GameObject pointForSpawn;
    [SerializeField] private float mouseSpeed, zoomSpeed;
    private float mouseXCoordinate;
    private float mouseYCoordinate;
    private Quaternion pointStartRotation;

    private void Start()
    {
        pointStartRotation = pointForSpawn.transform.rotation;
    }

    private void Update()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            RotateObject();
        }
    }

    private void RotateObject()
    {
        if (Input.GetMouseButton(0)) //holding the right mouse button is rotate object (camera): left/right, up/down
        {
            mouseXCoordinate = Input.GetAxis("Mouse X") * mouseSpeed;
            mouseYCoordinate = Input.GetAxis("Mouse Y") * mouseSpeed;
            pointForSpawn.transform.Rotate(Vector3.left, -mouseYCoordinate, Space.World);
            pointForSpawn.transform.Rotate(Vector3.up, -mouseXCoordinate, Space.World);
        }
    }
    public void ResetRotation()
    {
        pointForSpawn.transform.rotation = pointStartRotation;
    }

    public void SetRotationGroup(GameObject pointRotation)
    {
        pointForSpawn = pointRotation;
    }
}
