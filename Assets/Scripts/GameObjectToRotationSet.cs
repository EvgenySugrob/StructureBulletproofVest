using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectToRotationSet : MonoBehaviour
{
    [SerializeField] RotationObject rotationObject;

    public void GetObjectToRotate(GameObject rotateObject)
    {
        rotationObject.SetRotationGroup(rotateObject);
    }
}
