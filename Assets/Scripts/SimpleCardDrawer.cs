using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCardDrawer : MonoBehaviour
{
    public static GameData Data;
    Vector2Int Center = new Vector2Int();
    [SerializeField] float FlameWidth = 70;
    [SerializeField] SimpleNumber numberPref;
    Vector2 LeftTop;
    Vector2 Gap;


    public void DrawCard(Number[,] numbers)
    {
        Data = BingoCard.Data;
        Center.Set((Data.SheetSize.x - 1) / 2, (Data.SheetSize.y - 1) / 2);


        if (Data.SheetSize.x * Data.SheetSize.y > Data.NumberUse)
        {
            Data.NumberUse = Data.SheetSize.x * Data.SheetSize.y;
        }
        InitSpace();
        InitNumbers(numbers);


    }

    void InitSpace()
    {
        var SizeDelta = GetComponent<RectTransform>().sizeDelta;
        LeftTop.x = -SizeDelta.x / 2 + FlameWidth;
        LeftTop.y = -SizeDelta.y / 2 + FlameWidth;
        Gap.x = (SizeDelta.x - 2 * FlameWidth) / (Data.SheetSize.x - 1);
        Gap.y = (SizeDelta.y - 2 * FlameWidth) / (Data.SheetSize.y - 1);
        numberPref.GetComponent<RectTransform>().sizeDelta = Gap;
    }

    void InitNumbers(Number[,] numbers)
    {
        Vector2Int Size = Data.SheetSize;
        Vector2Int place = new Vector2Int();
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                place.x = x;
                place.y = y;
                SetNum(numbers[x,y],place);
            }
        }

    }

    void SetNum(Number number,Vector2Int place)
    {
        SimpleNumber NowNum = Instantiate(numberPref, transform);
        bool freeSpace = false;
        if (Data.FreeSpace && place == Center)
        {
            freeSpace = true;
        }
        NowNum.Initialize(number.num, LeftTop + place * Gap, freeSpace,number.IsOpen);
    }

}
