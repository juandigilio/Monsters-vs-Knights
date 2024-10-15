using UnityEngine;

public class Player : Entity
{
    [SerializeField] private LevelController level;

    private bool isLongRange;
    private bool isShortRange;


    public void Start()
    {
        maxHealth = 100;
        longAttackRange = 2;
        shortAttackRange = 1;
        shortRangeDamage = 10;
        longRangeDamage = 7;
        defense = 5;
        extraDefense = 0;
        speed = 5f;

        currentHealth = maxHealth;
    }

    public void Update()
    {
        GetInput();
        GetClosestEnemy();
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
            Debug.Log($"distance: {distance}");
            Debug.Log($"minDistance: {minDistance}");


            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemy;

                Debug.Log($"Closest enemy: {closestEnemy.name}, distance: {minDistance}");
            }
        }

        Attack(closestEnemy, minDistance);
    }

    public void Attack(Enemy enemy, float distance)
    {
        if (enemy != null)
        {
            Debug.Log($"distance: {distance}");
            isAttacking = true;

            if (distance < shortAttackRange)
            {
                enemy.ReceiveDamage(shortRangeDamage);
                isShortRange = true;

                Debug.Log("Short range attack");
            }
            else if (distance < longAttackRange)
            {
                enemy.ReceiveDamage(longRangeDamage);
                isLongRange = true;

                Debug.Log("Long range attack");
            }

        }
        else
        {
            isAttacking = false;
            isLongRange = false;
            isShortRange = false;
        }
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
