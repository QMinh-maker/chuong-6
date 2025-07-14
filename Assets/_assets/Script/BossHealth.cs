using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : Health
{
    [SerializeField] private BattleFlow battleFlow;
    [SerializeField] private string enemyTag = "Enemy";


    [SerializeField] private float gameOverTimeScale = 0f;

    private void Awake()
    {        
        battleFlow = BattleFlow.Instance;
    }


    protected override void Die()
    {
        base.Die();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag(enemyTag))
        {
            Destroy(enemy);
        }


        Time.timeScale = gameOverTimeScale;

        if (battleFlow != null)
            battleFlow.ShowWin();           
        else
            Debug.LogWarning("BattleFlow reference missing on Boss!");
    }
}

