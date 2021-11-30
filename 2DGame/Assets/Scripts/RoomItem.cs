using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomItem : MonoBehaviour
{
    public Text roomName;
    public Text roomName1;
    LobbyManager manager;

    private void Start()
    {
        manager = FindObjectOfType<LobbyManager>();
    }

    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName;
        roomName1.text = _roomName;
    }

    public void OnClickItem()
    {
        manager.JoinRoom(roomName.text);
    }

}
