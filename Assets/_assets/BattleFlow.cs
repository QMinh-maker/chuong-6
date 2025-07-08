using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleFlow : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public PlayerHealth playerHealth;
    public GameObject bgMusic;



    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }

    private void OnGameOver()
    {
        gameOverUI.SetActive(true);
        bgMusic.SetActive(false);
    }


    private void Start()
    {
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
        playerHealth.onDead += OnGameOver;
    }

    private void Update()
    {
        if (EnemyHealth.LivingEnemyCount<=0 && playerHealth != null)
        {
            OnGameWin();
        }
    }
    private void OnGameWin()
    {
        gameWinUI.SetActive(true);
        bgMusic.SetActive(false );
        playerHealth.gameObject.SetActive(false);
    }

}

