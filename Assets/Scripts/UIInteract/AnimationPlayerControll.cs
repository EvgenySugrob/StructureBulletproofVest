using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationPlayerControll : MonoBehaviour
{
    [SerializeField] Animator textilBulletAnimator;
    [SerializeField] bool animationIsPlay = true;
    [SerializeField] Slider progressBar;
    [Header("Animation list")]
    [SerializeField] List<string> titleAnimation;

    private float _defaultSpeed;
    private float _prevTime;

    private void Start()
    {
        textilBulletAnimator = transform.GetComponent<Animator>();
        _defaultSpeed = textilBulletAnimator.speed;
    }

    private float CurrentAnimationTime()
    {
        AnimatorStateInfo stateInfo = textilBulletAnimator.GetCurrentAnimatorStateInfo(0);

        float progress = stateInfo.normalizedTime%1;

        if(progress<_prevTime)
        {
            progress=0;
        }
        _prevTime= progress;
        return progress;
    }

    private void Update()
    {
        progressBar.value = CurrentAnimationTime();
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

    public void StartAnimation(int iAnimation)
    {
        Debug.Log(iAnimation + " " + titleAnimation[iAnimation]);
        textilBulletAnimator.Play(titleAnimation[iAnimation],-1,0.0f);
    }
}
