using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class SimpleNumber : MonoBehaviour
{
    Text text;
    public Vector2 positionLocal { get; private set; }
    Image image;
    RectTransform rectTransform;
    bool IsFreeSpace = false;

    void Awake()
    {
        text = GetComponentInChildren<Text>();
        rectTransform = GetComponent<RectTransform>();
        image = GetComponentInChildren<Image>();
        positionLocal = new Vector2();
        RandomOpener();
    }

    public int num
    {
        get; private set;
    }
    public bool IsOpen = false;
    
    public void Initialize(int Num, Vector2 position, bool freeSpace = false,bool open = false)
    {
        num = Num;
        gameObject.name = "" + Num;
        IsFreeSpace = freeSpace;
        if (freeSpace)
        {
            text.text = "F";
        }
        else
        {
            text.text = num.ToString();
        }
        IsOpen = open;

        positionLocal = position;
        rectTransform.anchoredPosition = positionLocal;
    }

    void Draw(){
        Sprite sprite;
        if(IsOpen){
            sprite = SpriteManager.GetSprite(SName.Hanabi);
        }
        else
        {
            sprite = SpriteManager.GetSprite(SName.WhiteCircle);
        }

        image.sprite = sprite;
    }

    void RandomOpener()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            IsOpen = false;
        }
        else{
            IsOpen = true;
        }
    }

}
