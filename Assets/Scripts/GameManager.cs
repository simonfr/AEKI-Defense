using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool inParty = false;
    private List<GameObject> objectsInGame;
    private List<GameObject> objectsInInventory;

    public bool startButtonAvailable = true;

    public LevelManager levelManager;

    private Level level;

    void Start()
    {
        this.level = levelManager.GetLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.level.Towers[0].Number);
    }

    public void LaunchGame() {
        Debug.Log("Game launched !");
    }
}