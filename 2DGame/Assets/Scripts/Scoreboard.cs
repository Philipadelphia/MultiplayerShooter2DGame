using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scoreboard : MonoBehaviour
{

    public GameObject ScoreboardUI;
    public Text CompletedText;
    private bool ScoreboardActive = false;
    private bool gameWon = false;

    public Text RedEnemyText;
    public Text BlueEnemyText;
    public Text PinkEnemyText;
    public Text TotalEnemyText;

    public int totalEnemiesAlive;

    public SpawnEnemies SpawnEnemies;


    // Update is called once per frame
    void Update()
    {
        UpdateTotalEnemyStats();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!PauseMenu.GamePaused)
            {
                if (!ScoreboardActive)
                {
                    Show();
                }
                else
                {
                    Hide();
                }
            }
        }

        if (gameWon)
        {
            CompletedText.color = Color.green;
            CompletedText.text = "COMPLETED";
        }
        else
        {
            CompletedText.color = Color.red;
            CompletedText.text = "NOT COMPLETED";
        }

        /* // Code to test if text changing works
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameWon = true;
        }*/
    }

    void Show()
    {
        ScoreboardUI.SetActive(true);
        ScoreboardActive = true;
    }

    void Hide()
    {
        ScoreboardUI.SetActive(false);
        ScoreboardActive = false;
    }

    void UpdateTotalEnemyStats()
    {
        int totalRedEnemies = SpawnEnemies.RedEnemiesAmount;
        int redEnemiesAlive = GameObject.FindGameObjectsWithTag("Red Enemy").Length;
        RedEnemyText.text = "Red: " + redEnemiesAlive.ToString() + "/" + totalRedEnemies.ToString();

        int totalBlueEnemies = SpawnEnemies.BlueEnemiesAmount;
        int BlueEnemiesAlive = GameObject.FindGameObjectsWithTag("Blue Enemy").Length;
        BlueEnemyText.text = "Blue: " + BlueEnemiesAlive.ToString() + "/" + totalBlueEnemies.ToString();

        int totalPinkEnemies = SpawnEnemies.PinkEnemiesAmount;
        int PinkEnemiesAlive = GameObject.FindGameObjectsWithTag("Pink Enemy").Length;
        PinkEnemyText.text = "Pink: " + PinkEnemiesAlive.ToString() + "/" + totalPinkEnemies.ToString();

        int totalEnemies = totalBlueEnemies + totalPinkEnemies + totalRedEnemies;
        totalEnemiesAlive = redEnemiesAlive + BlueEnemiesAlive + PinkEnemiesAlive;
        TotalEnemyText.text = "Total: " + totalEnemiesAlive.ToString() + "/" + totalEnemies.ToString();

        if (totalEnemiesAlive == 0)
        {
            gameWon = true;
        }
    }

    public bool isGameWon()
    {
        return gameWon;
    }
}
