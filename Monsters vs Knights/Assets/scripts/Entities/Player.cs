using System.Collections;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private LevelController level;


    public void Awake()
    {
        canAttack = true;
        LevelController.OnPlayerWon += Won;
    }

    public override void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    public void Update()
    {
        GetInput();
        GetClosestEnemy();

        //Debug.Log($"player position: {transform.position}");
    }

    public override void Walk()
    {
        isWalking = true;

        if (Input.mousePosition.x > 150.0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void GetClosestEnemy()
    {
        float minDistance = longAttackRange;
        Enemy closestEnemy = null;

        foreach (Enemy enemy in level.GetEnemies())
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            //Debug.Log($"distance: {distance}");
            //Debug.Log($"minDistance: {minDistance}");

            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemy;

                //Debug.Log($"Closest enemy: {closestEnemy.name}, distance: {minDistance}");
            }
        }

        Attack(closestEnemy, minDistance);
    }

    public void Attack(Entity enemy, float distance)
    {
        Debug.Log($"Can attack: {canAttack}");
        if (enemy && canAttack)
        {
            //Debug.Log($"distance: {distance}");
            isAttacking = true;
            Debug.Log("Player is attacking");

            if (distance < shortAttackRange)
            {
                enemy.ReceiveDamage(shortRangeDamage);
                isShortRange = true;
                isLongRange = false;

                //Debug.Log("Short range attack");
            }
            else if (distance < longAttackRange)
            {
                enemy.ReceiveDamage(longRangeDamage);
                isLongRange = true;
                isShortRange = false;

                //Debug.Log("Long range attack");
            }

            StartCoroutine(AttackCooldown());
        }
        else
        {
            isAttacking = false;
            isLongRange = false;
            isShortRange = false;
        }
    }

    public void Won()
    {
        hasWon = true;
    }

    public override void Die()
    {
        
    }

    public void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            Walk();
        }
        else
        {
            isWalking = false;
        }
    }
}
