using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneGame(string sceneName){
         Debug.Log("Changement de scene de " + gameObject.name + " à " + sceneName);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}
