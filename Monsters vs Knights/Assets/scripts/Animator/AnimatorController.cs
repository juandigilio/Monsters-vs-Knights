using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private List<Animator> animations;
    [SerializeField] private Entity character;


    private void Awake()
    {
        LevelController.OnAnimationWon += SetWiningAnimation;
        LevelController.OnAnimationLost += SetDeathAnimation;
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

        anim.SetBool("isAttaking", character.IsAttacking());

    }

    private void SetDeathAnimation()
    {
        foreach (Animator anim in animations)
        {
            anim.SetTrigger("isDead");
        }
    }

    private void SetWiningAnimation()
    {
        foreach (Animator anim in animations)
        {
            anim.SetTrigger("hasWon");
        }
    }

    private void OnDestroy()
    {
        LevelController.OnAnimationLost -= SetWiningAnimation;
        LevelController.OnAnimationWon -= SetDeathAnimation;
    }
}
