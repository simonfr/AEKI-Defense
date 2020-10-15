using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    public GameManager gameManager;

    void Update()
    {
        if(isAvailable()) {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        } else {
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f, .5f);
        }
    }

    bool isAvailable() {
        return true;
        //return this.transform.parent.GetComponent<Dashboard>().startButtonAvailable;
    }

    public void OnMouseDown()
    {
        gameManager.LaunchGame();
    }
}
