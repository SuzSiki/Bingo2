using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public State NowState = State.GameInitialize;
    CardManager cardManager;
    [SerializeField] int PlayerNum;


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

    void Start()
    {
        cardManager = CardManager.instance;
        StartCoroutine(SetAndWaitForPlayers());
    }

    IEnumerator SetAndWaitForPlayers(){
        yield return StartCoroutine(cardManager.SetCardAndWaitUntilSet());
        StartGame();
    }

    void StartGame(){

    }
}


public enum State{
    GameInitialize,
    NumberSelect,
    CheckNumber
}