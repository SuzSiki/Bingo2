using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Roulette : MonoBehaviour
{
    public static Roulette instance = null;

    List<int> remaining = new List<int>();
    Animator animator;
    [SerializeField] GameData data;
    Text numTex;

    void Awake()
    {
        Singleton();
        InitRemaining();
        animator = GetComponentInChildren<Animator>();
        numTex = transform.Find("NumberCircle").GetComponentInChildren<Text>();
    }

    void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void InitRemaining(){
        for(int i = 1; i < data.NumberUse + 1;i++){
            remaining.Add(i);
        }
    }

    public void Roll(){
        Debug.Log("Rolled");
        int num = GetNum();
        NetworkManager.instance.SendNumber(GetNum());
        StartCoroutine(RollMove(num));
    }

    IEnumerator RollMove(int num){
        animator.SetTrigger("Toss");
        yield return new WaitForSeconds(0.5f);
        numTex.text = num.ToString();
    }

    int GetNum(){
        int index = Random.Range(0,remaining.Count);
        int num = remaining[index];
        remaining.RemoveAt(index);

        return num;
    }
}

