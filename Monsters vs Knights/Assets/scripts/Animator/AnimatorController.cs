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

        anim.SetBool("isDead", character.IsDead());

        anim.SetBool("hasWon", character.HasWon());

        if (character.WasHitted())
        {
            anim.SetTrigger("wasHitted");
        }
    }

    private void OnDestroy()
    {
        //LevelController.OnAnimationWon -= SetWiningAnimation;
    }
}
