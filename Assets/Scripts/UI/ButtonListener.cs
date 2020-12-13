using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonListener : MonoBehaviour
{
    [SerializeField]ButtonActionInfomation[] ButtonsToListen;


    void Awake()
    {
        foreach(ButtonActionInfomation info in ButtonsToListen){
            info.SetAction();
        }
    }



    [System.Serializable]
    class ButtonActionInfomation{
        [SerializeField]Button button;
        [SerializeField]ActionCommand[] actionCommands;

        public void SetAction(){
            foreach(ActionCommand command in actionCommands){
                button.onClick.AddListener(command.Execute);
            }
        }
    }

}

