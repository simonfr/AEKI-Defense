using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExperienceUpdater : MonoBehaviour
{
    public TextMeshProUGUI levelNumber;

    // Start is called before the first frame update
    void Start()
    {
        levelNumber = GetComponent<TextMeshProUGUI>();
        if(SaveSystem.LoadPlayer()!=null){
            levelNumber.text = SaveSystem.LoadPlayer().exp.ToString();
        }else{
            levelNumber.text = "10000";
        }
    }
}
