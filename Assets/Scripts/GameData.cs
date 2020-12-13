using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    [SerializeField] public Vector2Int SheetSize = new Vector2Int(5,5);
    [SerializeField] public int NumberUse = 100;
    [SerializeField] public bool Dupe = false;
    [SerializeField] public bool FreeSpace = true;
    [SerializeField] public int Framerate = 60;


    void OnEnable()
    {
        Application.targetFrameRate = Framerate;
    }


}
