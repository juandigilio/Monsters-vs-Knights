using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MarksmanAnimatorController : MonoBehaviour
{
    [SerializeField] private List<Animator> animators;
    [SerializeField] private Animator spit;
    [SerializeField] private Marksman marksman;

    private bool hasWon;


    void Start()
    {
        spit.gameObject.SetActive(false);
        Marksman.OnMarksmanAttacked += ShowAttack;
        LevelController.OnPlayerWon += Won;
    }

    void Update()
    {
        foreach (Animator anim in animators)
        {
            UpdateParameters(anim);
        }
    }

    private void UpdateParameters(Animator anim)
    {
        anim.SetBool("hasAttacked", marksman.HasAttacked());
        anim.SetBool("hasWon", hasWon);
    }

    private void ShowAttack()
    {
        foreach (Animator anim in animators)
        {
            anim.SetTrigger("isAttacking");
        }
    }

    private void Won()
    {
        hasWon = true;
    }

    private void OnDestroy()
    {
        Marksman.OnMarksmanAttacked -= ShowAttack;
        LevelController.OnPlayerWon -= Won;
    }
}
