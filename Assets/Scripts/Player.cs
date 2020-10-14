using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int level = 1;
    public int exp = 0;

    public void changeExp(int amount){
        exp += amount;
    }
    
    public void SavePlayer(){
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer(){
        PlayerData data = SaveSystem.LoadPlayer();
        if(data!=null){
            level = data.level;
            exp = data.exp;
        }
    }
}
