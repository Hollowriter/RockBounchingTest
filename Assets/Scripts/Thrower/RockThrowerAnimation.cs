using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrowerAnimation : MonoBehaviour
{
    Animator rockThrowerAnimator;
    public float animationEndLimit;

    private void Awake()
    {
        rockThrowerAnimator = this.gameObject.GetComponent<Animator>();
    }

    public void ThrowAnimation() 
    {
        rockThrowerAnimator.SetBool("Throwing", true);
    }

    void CheckAnimation() 
    {
        if (rockThrowerAnimator.GetBool("Throwing"))
        {
            if (rockThrowerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 < animationEndLimit)
            {
                return;
            }
            rockThrowerAnimator.SetBool("Throwing", false);
        }
    }

    void Behave() 
    {
        CheckAnimation();
    }

    private void Update()
    {
        Behave();
    }
}
