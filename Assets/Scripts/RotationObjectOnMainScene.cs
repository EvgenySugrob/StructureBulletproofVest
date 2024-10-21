using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObjectOnMainScene : MonoBehaviour
{
    [SerializeField] int speedRotation = 15;

    void Update()
    {
        transform.Rotate(new Vector3(0,15f,0) * Time.deltaTime);
    }
}
