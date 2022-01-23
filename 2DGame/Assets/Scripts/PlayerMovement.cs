using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public Rigidbody2D camrb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    Player player;
    public Text playerName;
    public int playerMaxHealth = 100;
    public int playerHealth;

    public HealthBar healthbar;
    public GameObject ExitPanelUI;
    private bool touchingExit;

    public Scoreboard WinCheck;

    void Start()
    {
        playerHealth = playerMaxHealth;
        healthbar.SetMaxHealth(playerMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        playerName.text = PhotonNetwork.NickName;
        if (playerName.text.Length > 20)
        {
            string sub = playerName.text.Substring(0, 17);
            playerName.text = sub + "...";
        }

        // Get methods for coordinates
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Method to find where on the screen the mouse is
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


        // Code to test taking damage
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerTakeDamage(25);
        }

        if (touchingExit && Input.GetKeyDown(KeyCode.Space) && WinCheck.isGameWon())
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene("Menu");
        }

    }

    void FixedUpdate()
    {
        // Player movement
        // Moves the rigid body on the character using inbuilt unity functions
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Makes the player look at the camera 
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; //+ 13.5f; // Test to see whether changing the rotation to match gun tip looked better or not (Decided Against)
        rb.rotation = angle;

        // Moves the camera to wherever the player is
        camrb.MovePosition(rb.position);
    }

    public void PlayerTakeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
        healthbar.SetHealth(playerHealth);

        if (playerHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
        EndGame();
    }

    void EndGame()
    {
        Debug.Log("Game should end");
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        /* Debugging code to make sure the bullets actually collide with the enemy.
        Debug.Log(hitInfo.name);*/

        Door door = hitInfo.GetComponent<Door>();
        if (door != null)
        {
            touchingExit = true;
            ExitPanelUI.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D hitInfo)
    {
        /* Debugging code to make sure the bullets actually collide with the enemy.
        Debug.Log(hitInfo.name);*/

        Door door = hitInfo.GetComponent<Door>();
        if (door != null)
        {
            touchingExit = false;
            ExitPanelUI.SetActive(false);
        }
    }
}
