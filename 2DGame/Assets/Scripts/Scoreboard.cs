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

    // Update is called once per frame
    void Update()
    {
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
}
