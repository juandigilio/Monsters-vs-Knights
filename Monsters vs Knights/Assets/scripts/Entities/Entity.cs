using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int shortRangeDamage;
    [SerializeField] protected int longRangeDamage;
    [SerializeField] protected int defense;
    [SerializeField] protected int extraDefense;
    [SerializeField] protected float speed;

    [SerializeField] protected float shortAttackRange;
    [SerializeField] protected float longAttackRange;

    protected int currentHealth;

    protected bool isWalking;
    protected bool isAttacking;
    protected bool isLongRange;
    protected bool isShortRange;
    protected bool wasHitted;
    protected bool hasWon;


    public virtual void Start()
    {
        currentHealth = maxHealth;

        isWalking = false;
        isAttacking = false;
        isLongRange = false;
        isShortRange = false;
        wasHitted = false;
        hasWon = false;
    }

    public virtual void Walk()
    {
    }

    //public virtual void Attack()
    //{
    //}

    public void ReceiveDamage(int damage)
    {
        currentHealth -= (damage - (damage * defense / 100)); //mitigo dano usando la defensa como un porcentaje, defensa 5 quita el 5% del ataque
    }

    public virtual void Die()
    {
    }

    public bool IsDead()
    {
        return currentHealth < 1 ? true : false;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    public bool IsAttacking()
    {
        return isAttacking;
    }

    public bool IsLongRange()
    {
        return isLongRange;
    }

    public bool IsShortRange() 
    {
        return isShortRange;
    }

    public bool WasHitted()
    {
        return wasHitted;
    }

    public bool HasWon()
    {
        return hasWon;
    }
}
