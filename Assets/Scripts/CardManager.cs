using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance = null;
        BingoCard[] cards;


    void Awake()
    {
        Singleton();
    }


    void Singleton()
    {
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(this.gameObject);
        }
    }


    public IEnumerator SetCardAndWaitUntilSet(){
        yield return null;
    }
}
