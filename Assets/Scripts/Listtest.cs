using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listtest : MonoBehaviour
{
    List<int> List;

    public void StartTest(){
        List = new List<int>();
        List<int> a = List;
        a.Add(13);
        Debug.Log(List[0]);
    }
}
