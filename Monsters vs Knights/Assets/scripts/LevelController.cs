using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();

    public static event Action OnPlayerWon;


    void Update()
    {
        CheckWiningCondition();
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }

    private void CheckWiningCondition()
    {
        foreach (Enemy enemy in enemies)
        {
            if (!enemy.IsDead())
            {
                return;
            }
        }

        OnPlayerWon?.Invoke();
    }
}
