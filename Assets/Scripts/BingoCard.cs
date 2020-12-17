using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BingoCard : MonoBehaviour
{
    public static BingoCard instance = null;
    

    Number[,] Numbers;
    public static GameData Data;
    static PointCalclator calc = new PointCalclator();
    Vector2Int Center = new Vector2Int();
    [SerializeField] float FlameWidth = 70;
    [SerializeField] Number numberPref;
    Vector2 LeftTop;
    Vector2 Gap;
    List<int> NumberRemaining = new List<int>();

    ///<summary>
    ///最新の情報を取得できる。それなりに重いので繰り返しは呼ばないように
    ///</summary>
    public PointCalclator NewCalc{
        get{
            UpdateCalclator();
            return calc;
        }
    }


    public void InitCard(GameData data)
    {
        Data = data;
        Center.Set((Data.SheetSize.x - 1) / 2, (Data.SheetSize.y - 1) / 2);

        instance = this;

        if (Data.SheetSize.x * Data.SheetSize.y > Data.NumberUse)
        {
            Data.NumberUse = Data.SheetSize.x * Data.SheetSize.y;
        }
        InitNumberUse();
        InitSpace();
        StartCoroutine(InitNumbers());


    }

    void InitNumberUse()
    {
        for (int i = 1; i <= Data.NumberUse; i++)
        {
            NumberRemaining.Add(i);
        }
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

    IEnumerator InitNumbers()
    {
        Vector2Int Size = Data.SheetSize;
        Numbers = new Number[Size.x, Size.y];
        Vector2Int Place = new Vector2Int();

        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                Place.x = x;
                Place.y = y;
                SetNum(Place);
                yield return null;
            }
        }

    }

    void SetNum(Vector2Int place)
    {
        Number NowNum = Instantiate(numberPref, transform);
        bool freeSpace = false;
        if (Data.FreeSpace && place == Center)
        {
            freeSpace = true;
        }
        NowNum.Initialize(GetNum(), LeftTop + place * Gap, freeSpace);
        Numbers[place.x, place.y] = NowNum;
    }

    int GetNum()
    {
        int Num;
        if (Data.Dupe)
        {
            return Random.Range(1, Data.NumberUse + 1);
        }
        else
        {

            int index = Random.Range(0, NumberRemaining.Count);
            Num = NumberRemaining[index];
            NumberRemaining.RemoveAt(index);
        }
        return Num;
    }

    public bool CheckAllNum(int num)
    {
        bool Opened = false;
        foreach (Number number in Numbers)
        {
            bool tmp;
            tmp = number.CheckNum(num);
            if (tmp == true)
            {
                Opened = true;
            }
        }
        
        return Opened;
    }

    void  UpdateCalclator()
    {
        calc.Calclator(Numbers);
        Debug.Log("shanten:" + calc.Shanten + "MaxRowNum:" + calc.MaxRowNum + "MaxInARow" + calc.MaxInARow);
    }

}
