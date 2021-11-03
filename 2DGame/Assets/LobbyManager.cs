using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;



public class LobbyManager : MonoBehaviourPunCallbacks
{

    public InputField roomInputField;
    public GameObject lobbyMenu;
    public GameObject roomMenu;
    public Text roomName;

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void OnClickCreate()
    {
        if (roomInputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions() { MaxPlayers = 10 });
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyMenu.SetActive(false);
        roomMenu.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
    }
}
