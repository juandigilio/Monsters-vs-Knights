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

    public void Update()
    {
        GetInput();
    }

    public override void Walk()
    {
        if (Input.mousePosition.x > 150.0f)
        {
            parallax.UpdatePositions(speed);
            transform.localScale = new Vector3(1, 1, 1);
            //Debug.Log("pos:" + transform.position.x);
            //Debug.Log("mouse:" + Input.mousePosition.x)
        }
        else
        {
            parallax.UpdatePositions(-speed);
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
    }
}
