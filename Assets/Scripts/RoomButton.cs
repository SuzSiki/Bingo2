using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RoomButton : MonoBehaviour
{
    Text Name;
    Text Member;
    RectTransform rectTransform;
    Button button;

    void Awake()
    {
        Name = transform.Find("Name").GetComponent<Text>();
        Member = transform.Find("Member").GetComponent<Text>();
        rectTransform = GetComponent<RectTransform>();
        button = GetComponent<Button>();
    }

    public void Initialize(Vector2 position,string member,string name,UnityAction func)
    {
        rectTransform.anchoredPosition = position;
        Member.text = member;
        Name.text = name;
        SetFunction(func);
    }

    public void SetFunction(UnityAction func)
    {
        button.onClick.AddListener(func);
    }
}
