using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();

    public static event Action OnAnimationWon;
    public static event Action OnAnimationLost;



    void Update()
    {
        
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }
}
