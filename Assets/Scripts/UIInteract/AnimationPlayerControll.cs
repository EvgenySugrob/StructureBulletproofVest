using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationPlayerControll : MonoBehaviour
{
    [SerializeField] Animator textilBulletAnimator;
    [SerializeField] bool animationIsPlay = true;
    [SerializeField] Slider progressBar;

    private float _defaultSpeed;

    private void Start()
    {
        textilBulletAnimator = transform.GetComponent<Animator>();
        _defaultSpeed = textilBulletAnimator.speed;
    }


    public void PlayAnimation()
    {
        if(animationIsPlay)
        {
            textilBulletAnimator.speed = 0f;
        }
        else
        {
            textilBulletAnimator.speed = _defaultSpeed;
        }
        animationIsPlay = !animationIsPlay;
    }
    public void SlowAnimation()
    {
        textilBulletAnimator.speed = _defaultSpeed * 0.5f;
    }
    public void FastAnimation()
    {
        textilBulletAnimator.speed = _defaultSpeed * 2f;
    }
}
