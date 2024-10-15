using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int damage;
    [SerializeField] protected int extraDamage;
    [SerializeField] protected int defense;
    [SerializeField] protected int extraDefense;
    [SerializeField] protected float speed;

    protected int currentHealth;

    protected bool isWalking;
    protected bool isAttacking;



    public virtual void Walk()
    {
    }

    public virtual void Attack()
    {
    }

    public void ReceiveDamage(int damage)
    {
        currentHealth -= (damage - (damage * defense / 100)); //mitigo dano usando la defensa como un porcentaje, defensa 5 quita el 5% del ataque
    }

    public void CheckState()
    {
        if (currentHealth < 1)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log($"{gameObject.name} ha muerto.");
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
}
