using UnityEngine;
using System.Collections.Generic;

public class UIAction : MonoBehaviour
{
    Animator animator;
    string LastMotion = null;
    List<Actions> ActionLog = new List<Actions>();


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Action(Actions action)
    {
        /*
        if (action == Actions.Undo)
        {
            Undo();
        }
        else*/
        {
            if(action != Actions.Undo){
                animator.ResetTrigger(TagManager.GetTag (Actions.Undo));
            }
            animator.SetFloat("Speed",1.0f);
            ActionLog.Add(action);
            PlayAction(action);
        }
    }

    void Undo(){
        if(ActionLog.Count != 0)
        {
            int LastIndex = ActionLog.Count - 1;
            animator.SetFloat("Speed",-1.0f);
            PlayAction(ActionLog[LastIndex]);
            ActionLog.RemoveAt(LastIndex);
        }
    }

    void PlayAction(Actions action){
        string trigger = TagManager.GetTag(action);
        animator.SetTrigger(trigger);
    }


}


