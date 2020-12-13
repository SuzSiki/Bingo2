using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class Number : MonoBehaviour
{
    Text text;
    public Vector2 positionLocal { get; private set; }
    RectTransform rectTransform;
    bool IsFreeSpace = false;
    Animator animator;

    void Awake()
    {
        text = GetComponentInChildren<Text>();
        rectTransform = GetComponent<RectTransform>();
        animator = GetComponentInChildren<Animator>();
        positionLocal = new Vector2();
        StartCoroutine(WaitForOpen());

    }

    public int num
    {
        get; private set;
    }

    public bool IsOpen = false;

    public void Initialize(int Num, Color col, Vector2 Position)
    {
        text.color = col;
        Initialize(Num, Position);
    }

    public void Initialize(int Num, Vector2 position, bool freeSpace = false)
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

        positionLocal = position;
        rectTransform.anchoredPosition = positionLocal;
    }

    public bool CheckNum(int Num)
    {
        IsOpen = num == Num;
        return IsOpen;
    }

    IEnumerator WaitForOpen()
    {
        while (true)
        {
            if (IsOpen)
            {
                animator.SetTrigger(TagManager.GetTag(Actions.Flip));
                break;
            }
            yield return null;
        }
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
