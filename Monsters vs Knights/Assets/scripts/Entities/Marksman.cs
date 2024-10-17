using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marksman : MonoBehaviour
{
    public static event Action OnMarksmanAttacked;
    public static event Action OnMarksmanKillThemAll;

    [SerializeField] private float attackPosition;
    [SerializeField] private float spitPosition;
    [SerializeField] private float speed;
    [SerializeField] private float spitSpeed;
    [SerializeField] private GameObject spit;

    private bool isAttacking;
    private bool hasAttacked;


    public void Start()
    {
        isAttacking = false;
        hasAttacked = false;

        StartCoroutine(GotoAttackPosition());
    }

    void Update()
    {
        
    }

    public IEnumerator StartAttack()
    {
        spit.gameObject.SetActive(true);

        while (spit.transform.position.x < spitPosition)
        {
            spit.transform.position += Vector3.right * spitSpeed * Time.deltaTime;
            yield return null;
        }
        
    }

    public IEnumerator GotoAttackPosition()
    {
        while (transform.position.y < attackPosition)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            yield return null;
        }
        isAttacking = true;
        OnMarksmanAttacked?.Invoke();

        StartCoroutine(StartAttack());
    }

    public bool IsAttacking()
    {
        return isAttacking;
    }

    public bool HasAttacked()
    {
        return hasAttacked;
    }
}
