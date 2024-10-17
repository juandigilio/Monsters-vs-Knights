using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();
    [SerializeField] private Player player;

    public static event Action OnPlayerWon;

    private void Start()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.SetPlayer(player);
        }
    }

    void Update()
    {
        CheckEnemiesStatus();
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }

    private void CheckEnemiesStatus()
    {
        bool allEnemiesDead = true;

        foreach (Enemy enemy in enemies)
        {
            if (!enemy.IsDead())
            {
                allEnemiesDead = false;
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

    public Player GetPlayer()
    {
        return player;
    }

    private void OnDestroy()
    {

    }
}
