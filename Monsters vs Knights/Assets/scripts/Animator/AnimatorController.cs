using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private List<Animator> animations;
    [SerializeField] private Entity character;


    private void Awake()
    {
    }

    void Update()
    {
        foreach (Animator anim in animations)
        {
            UpdateParameters(anim);
        }
    }

    private void UpdateParameters(Animator anim)
    {

        anim.SetBool("isWalking", character.IsWalking());

        anim.SetBool("isShortRange", character.IsShortRange());

        anim.SetBool("isLongRange", character.IsLongRange());

        CheckStatus();
    }

    private void CheckStatus()
    {
        if (character.HasWon())
        {
            SetWiningAnimation();
        }
        if (character.IsDead())
        {
            SetDeathAnimation();
        }
    }

    private void SetWiningAnimation()
    {
        foreach (Animator anim in animations)
        {
            anim.SetTrigger("hasWon");
        }
    }

    private void SetDeathAnimation()
    {
        foreach (Animator anim in animations)
        {
            anim.SetTrigger("isDead");
        }
    }

    private void OnDestroy()
    {
        //LevelController.OnAnimationWon -= SetWiningAnimation;
    }
}
