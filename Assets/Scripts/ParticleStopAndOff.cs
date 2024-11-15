using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParticleStopAndOff : MonoBehaviour
{
    [SerializeField] ParticleSystem bulletParticle;
    [SerializeField] ParticleSystem backBulletParticle;
    [SerializeField] List<ParticleSystem> gasParticleList;

    public void StopAndOff()
    {
        bulletParticle.Stop();
    }
    public void BackParticleStop()
    {
        backBulletParticle.Stop();
    }
    public void StopGas()
    {
        ParticleSystem currentGasParticle = gasParticleList.FirstOrDefault(obj => obj.gameObject.activeSelf);
        currentGasParticle.Stop();
    }
}
