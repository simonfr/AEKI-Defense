﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape")){
            if (EditorApplication.isPlaying){
                EditorApplication.isPlaying = false;
            }else{
                Application.Quit();
            }
        }
    }

    public void Quit(){
        if (EditorApplication.isPlaying){
            EditorApplication.isPlaying = false;
        }else{
            Application.Quit();
        }
    }
}
