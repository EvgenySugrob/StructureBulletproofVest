using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStopAndOff : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;

    public void StopAndOff()
    {
        particle.Stop();
    }
}
