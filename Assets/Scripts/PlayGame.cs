using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
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
        Debug.Log("Changement de scene de " + SceneManager.GetActiveScene().name + " à " + sceneName);
        if(SaveSystem.LoadPlayer()==null){
            SaveSystem.SavePlayer(new Player());
            Debug.Log("Enregistrement du jeu");
        }
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}
