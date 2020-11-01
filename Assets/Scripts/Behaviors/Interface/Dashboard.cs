using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashboard : MonoBehaviour
{

    public bool startButtonAvailable;
    public GameObject cases;
    public List<GameObject> towers;

    void Start()
    { }

    bool AllTowersPlaced() {
        foreach(GameObject tower in towers) {

        }

        return true;
    }

}
