using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public List<Level> levels;
    public GameObject simpleEmployee;
    public GameObject experimentedEmployee;

    void Start()
    {
        levels = new List<Level>(){
            //
            // Level 1
            //
            new Level(1, new List<LevelTower>() {
                new LevelTower(2, simpleEmployee)
            }),
            //
            // Level 2
            //
            new Level(2, new List<LevelTower>() {
                new LevelTower(3, simpleEmployee), 
                new LevelTower(1, experimentedEmployee)
            })
        };
        
        
    }

    public Level GetLevel(int levelNb) {
        return levels[levelNb-1];
    }
}

public struct Level
{
    public Level(int levelNb, List<LevelTower> towers) {
        LevelNb = levelNb;
        Towers = towers;
    }
    public int LevelNb { get; }
    public List<LevelTower> Towers { get; }
}

public struct LevelTower {
    public LevelTower(int number, GameObject person) {
        Number = number;
        Person = person;
    }
    public int Number { get; }
    public GameObject Person { get; }
}