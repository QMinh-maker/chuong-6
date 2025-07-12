using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private string enemyTag = "Enemy";


    [SerializeField] private float gameOverTimeScale = 0f;

    protected override void Die()
    {

        base.Die();


        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag(enemyTag))
        {
            Destroy(enemy);
        }


        Time.timeScale = gameOverTimeScale;
        Debug.Log("Player died");
    }
}



