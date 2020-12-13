using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomButton : MonoBehaviour
{
    Text RoomName;
    Button button;
    void Awake()
    {
        button = GetComponentInChildren<Button>();
        RoomName = transform.Find("InputField").Find("RoomName").GetComponent<Text>();
    }

    public void CreateAndJoinRoom(){
        string name = RoomName.text;
        NetworkManager.instance.CreateAndJoinRoom(name);
    }
}
