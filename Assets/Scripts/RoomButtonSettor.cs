using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Realtime;

public class RoomButtonSettor : MonoBehaviour
{
    public static RoomButtonSettor instance = null;
    private List<RoomInfo> _nowRoomList = new List<RoomInfo>();
    List<RoomButton> roomButtons = new List<RoomButton>();
    public List<RoomInfo> nowRoomList{
        get{return _nowRoomList;}
        private set{_nowRoomList = value;}
    }
    RectTransform rectRans;
    float Gap = 200;
    float NowPlace = 0;

    [SerializeField] RoomButton roomPref;

    void Awake()
    {
        rectRans = GetComponent<RectTransform>();
        instance = this;
    }

    public RoomButton SetRoomButton(RoomInfo info,UnityAction action)
    {
        NowPlace -= Gap;
        RoomButton roomClone = Instantiate(roomPref, transform);
        nowRoomList.Add(info);
        roomButtons.Add(roomClone);
        roomClone.Initialize(new Vector2(0,NowPlace),info.PlayerCount + "/" + info.MaxPlayers,info.Name,action);
        return roomClone;
    }

}
