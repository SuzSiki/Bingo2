using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoulletteRouter : MonoBehaviour
{
    static public RoulletteRouter instance = null;
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

    public void DebugChangeNownum(int num){
        NowNum = num;
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
