using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BingoPlacer : MonoBehaviour
{
    [SerializeField]BingoCard cardPref;
    [SerializeField]GameData data;

    void Awake()
    {
        PlaceCard();
    }
    public void PlaceCard(){
        var card = Instantiate(cardPref,transform);
        card.InitCard(data);
    }
}
