using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    Enemy enemy;
    public bool isEnemyDead;

    public Collider[] enemyCol;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    public void DeductHealth(float deductHealth)
    {
        if(!isEnemyDead)
        {
            enemyHealth -= deductHealth;
            if (enemyHealth <= 0)
            {
                EnemyDead();
            }

        }
    }
    void EnemyDead()
    {
        isEnemyDead = true;
        enemy.EnemyDeathAnim();
        enemy.agent.speed = 0f;
        enemy.damageAmount = 0f;
        foreach (var col in enemyCol)
        {
            col.enabled = false;
        }
        enemyHealth = 0f;
        KillCount.instance.killCount++;
        KillCount.instance.UpdateKillCounterUI();
        Destroy(gameObject,10);
    }
    
}
