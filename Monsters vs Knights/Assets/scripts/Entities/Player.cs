using UnityEngine;

public class Player : Entity
{
    [SerializeField] Parallax parallax;


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
    public override void Walk()
    {
        if (Input.mousePosition.x > transform.position.x)
        {
            parallax.UpdatePositions(speed);
        }
        else
        {
            parallax.UpdatePositions(-speed);
        }

        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    // Sobrescribir el método Attack para personalizar el ataque del jugador
    public override void Attack()
    {

    }

    public override void Die()
    {

    }

    public void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Walk();
        }
    }
}
