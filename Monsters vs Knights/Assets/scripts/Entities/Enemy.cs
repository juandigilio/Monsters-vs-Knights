using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Entity
{
    private Player player;

    public void Awake()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    public void Update()
    {
        GetInput();
        Walk();
    }

    public override void Walk()
    {
        isWalking = false;
        isAttacking = false;
        isLongRange = false;
        isShortRange = false;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > longAttackRange)
        {
            if (player.transform.position.x > transform.position.x)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                transform.localScale = new Vector3(-1, 1, 1);
            }

            isWalking = true;
        }
        else
        {
            Attack(distance);
        }
    }

    public void Attack(float distance)
    {
        if (canAttack)
        {
            if (distance > shortAttackRange)
            {
                player.ReceiveDamage(longRangeDamage);
                isShortRange = false;
                isLongRange = true;
            }
            else
            {
                player.ReceiveDamage(shortRangeDamage);
                isLongRange = false;
                isShortRange = true;
            }

            Debug.Log("Enemy is attacking");

            StartCoroutine(AttackCooldown());
        }
        
    }

    public void GetInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
}

