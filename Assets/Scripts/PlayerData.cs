using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level = 1;
    public int exp = 0;

    public PlayerData(Player player){
        level = player.level;
        exp = player.exp;
    }
}
