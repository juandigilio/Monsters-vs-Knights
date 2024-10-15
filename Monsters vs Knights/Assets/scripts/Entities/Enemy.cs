using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    //[SerializeField] private LevelController level;

    private bool isLongRange;
    private bool isShortRange;

    public void Start()
    {
        maxHealth = 100;
        shortRangeDamage = 100;
        longRangeDamage = 1000;
        defense = 5;
        extraDefense = 0;
        speed = 5f;

        currentHealth = maxHealth;
    }

    public void Update()
    {
        GetInput();
    }

    public override void Walk()
    {
        //isWalking = true;

        //if (Input.mousePosition.x > 150.0f)
        //{
        //    transform.localScale = new Vector3(1, 1, 1);
        //}
        //else
        //{
        //    transform.localScale = new Vector3(-1, 1, 1);
        //}
    }

    public void GetInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    //public (Entity closestEnemy, float minDistance) GetClosestEnemy()
    //{
    //    float minDistance = longAttackRange;
    //    Entity closestEnemy = null;

    //    foreach (Entity enemy in level.GetEnemies())
    //    {
    //        float distance = Vector3.Distance(transform.position, enemy.transform.position);

    //        if (distance < minDistance)
    //        {
    //            minDistance = distance;
    //            closestEnemy = enemy;
    //        }
    //    }

    //    return (closestEnemy, minDistance);
    //}
}

