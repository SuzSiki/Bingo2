using UnityEngine;


[System.Serializable]
public class ActionCommand{
    [SerializeField] Actions action;
    [SerializeField] UIAction UI;

    public void Execute(){
        UI.Action(action); 
    }
}