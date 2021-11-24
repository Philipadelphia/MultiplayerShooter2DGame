using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerItem : MonoBehaviourPunCallbacks
{


    public Text playerName;

    public GameObject leftArrowButton;
    public GameObject rightArrowButton;

    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    public Text playerClassText;
    // Add in class for Player classes when added (If added)
    // public Sprite[] avatars; // Add this back in when the models for the different classes is made

    Player player;

    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;
        UpdatePlayerItem(player);
    }

    public void ApplyLocalChanges()
    {
        leftArrowButton.SetActive(true);
        rightArrowButton.SetActive(true);
    }

    public void OnClickLeftArrow()
    {
        /* Comment this in when the classes have been made
        if ((int)playerProperties["playerClass"] == 0)
        {
            playerProperties["playerClass"] = avatars.Length - 1;
        }
        else
        {
            playerProperties["playerClass"] = (int)playerProperties["playerClass"] - 1;
        }
        */
        playerProperties["playerClassText"] = "left";
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public void OnClickRightArrow()
    {
        /* Comment this in when the classes have been made
        if ((int)playerProperties["playerClass"] == avatars.Length - 1)
        {
            playerProperties["playerClass"] = 0;
        }
        else
        {
            playerProperties["playerClass"] = (int)playerProperties["playerClass"] + 1;
        }
        */
        playerProperties["playerClassText.text"] = "RIGHT";
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable playerProperties)
    {
        if (player == targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
        }
    }

    void UpdatePlayerItem(Player player)
    {
        if (player.CustomProperties.ContainsKey("playerClass"))
        {
            // playerAvatar = avatars[(int)player.CustomProperties["playerClass"]];
            playerProperties["playerClass"] = (int)player.CustomProperties["playerClass"];
        }
        else
        {
            playerProperties["playerClass"] = 0;
        }
    }
    
}
