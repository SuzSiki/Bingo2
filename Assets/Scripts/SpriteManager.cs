using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static Dictionary<SName,string> SpriteDictionary = new Dictionary<SName, string>{
        {SName.WhiteCircle,"Images/白円"},
        {SName.Hanabi,"Images/Hanabi"}
    };

    public static Sprite GetSprite(SName name){
        Sprite sprite = Resources.Load(SpriteDictionary[name]) as Sprite;
        return sprite;
    }
}

public enum SName{
    WhiteCircle,
    Hanabi
}