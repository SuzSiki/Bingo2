using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoulletteRouter : MonoBehaviour
{
    static public RoulletteRouter instance = null;
    ExitGames.Client.Photon.Hashtable roomHash;
    public bool Pulse = false;
    BingoCard card = null;
    int _NowNum = 0;
    bool _Trigger;

    public int NowNum
    {
        get { return _NowNum; }
        set
        {
            if (_NowNum != value)
            {
                _Trigger = true;
                _NowNum = value;
            }
        }
    }
    private bool InputTrigger
    {
        get
        {
            if (_Trigger)
            {
                _Trigger = false;
                return true;
            }
            return false;
        }
    }

    void Awake()
    {
        instance = this;
        StartCoroutine(TriggerListener());
    }

    void Update()
    {
        if (card == null)
        {
            card = BingoCard.instance;
        }
        NowNum = (int)roomHash["NextNum"];
    }

    IEnumerator TriggerListener()
    {
        while (true)
        {
            if(InputTrigger){
                card.CheckAllNum(NowNum);
                Pulse = true;
            }
            else{
                Pulse = false;
            }
            yield return null;
        }
    }
}
