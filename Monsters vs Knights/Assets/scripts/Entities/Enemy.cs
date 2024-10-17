using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    //[SerializeField] private LevelController level;
    private Vector3 playerPosition;

    public void Awake()
    {
        maxHealth = 100;
        longAttackRange = 1.5f;
        shortAttackRange = 0.7f;
        shortRangeDamage = 15;
        longRangeDamage = 8;
        defense = 5;
        extraDefense = 0;
        speed = 200f;

        attackCooldown = 0.9f;

        currentHealth = maxHealth;
    }

    public void Update()
    {
        GetInput();
    }

    public override void Walk()
    {
        if (Mathf.Abs(playerDistance) > longAttackRange)
        {
            if ()
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            isWalking = false;
        }
        isWalking = true;
    }

    public void Attack(Vector3 playerPos)
    {
        if (!isWalking)
        {

        }
    }

    public void GetInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    public void SetPlayerPosition(Vector3 playerPos)
    {
        playerPosition = playerPos;
    }
}

