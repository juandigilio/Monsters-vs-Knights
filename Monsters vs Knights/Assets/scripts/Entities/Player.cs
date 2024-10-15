using UnityEngine;

public class Player : Entity
{
    public void Start()
    {
        maxHealth = 100;
        damage = 10;
        extraDamage = 0;
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

    public override void Attack()
    {

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
