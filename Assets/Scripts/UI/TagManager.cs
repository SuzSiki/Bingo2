using System.Collections.Generic;

public class TagManager
{

    static Dictionary<Actions,string> TagDictionary = new Dictionary<Actions, string>{
        {Actions.Pressed,"Pressed"},
        {Actions.MoveOut,"MoveOut"},
        {Actions.MoveIn,"MoveIn"},
        {Actions.Undo,"Undo"},
        {Actions.Flip,"Flip"}
    };


    public static string GetTag(Actions act){
        return TagDictionary[act];
    }
}

public enum Actions{
    Pressed,
    MoveIn,
    MoveOut,
    Undo,
    Flip
}