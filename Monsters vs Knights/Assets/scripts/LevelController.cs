using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();
    [SerializeField] private Player player;

    public static event Action OnPlayerWon;


    void Update()
    {
        CheckEnemiesStatus();
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }

    public Vector3 GetPlayerPosition()
    {
        return player.GetPosition();
    }

    private void CheckEnemiesStatus()
    {
        bool allEnemiesDead = true;

        foreach (Enemy enemy in enemies)
        {
            if (!enemy.IsDead())
            {
                allEnemiesDead = false;

                enemy.SetPlayerDistance(Vector3.Distance(enemy.GetPosition(), player.GetPosition()));
            }
            else
            {
                enemies.Remove(enemy);
            }
        }

        if (allEnemiesDead)
        {
            OnPlayerWon?.Invoke(); 
        }
        else
        {
            return;
        }
    }
}
