using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedHashtableManager : MonoBehaviour
{
    public static SharedHashtableManager instance = null;
    public ExitGames.Client.Photon.Hashtable roomHash = new ExitGames.Client.Photon.Hashtable();


    void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    
}

public enum Keys{

}