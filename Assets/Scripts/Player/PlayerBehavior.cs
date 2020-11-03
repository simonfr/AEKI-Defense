using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    [NonSerialized] public int gold;
    [NonSerialized] public int lives;

    [SerializeField] private int start_gold; 
    [SerializeField] private int start_lives;
    [SerializeField] private Text gold_text; 
    [SerializeField] private Text lives_text; 
    [SerializeField] private Text waves_text; 

    private TowerBehavior selected_tower;

    // Start is called before the first frame update
    void Start()
    {
        gold = start_gold;
        lives = start_lives;
        UpdateGoldText();
        UpdateLivesText();
    }
    private void UpdateGoldText()
    {
        gold_text.text = "Gold: " + gold;
    }
    private void UpdateLivesText()
    {
        lives_text.text = "Lives: " + lives;
    }
    public void AddGold(int amount)
    {
        gold += amount;
        UpdateGoldText();
    }
    public void RemoveGold(int amount)
    {
        AddGold(-amount);
    }
    public void AddLives(int amount)
    {
        lives += amount;
        UpdateLivesText();
    }
    public void RemoveLives(int amount)
    {
        AddLives(-amount);
    }

    public void SetSelectedTower(TowerBehavior tower)
    {
        if(tower == null && selected_tower!=null){
            GameObject.Destroy(selected_tower.gameObject);
        }
        selected_tower = tower;
    }

    void Update()
    {
        if(selected_tower!=null) {
            Vector3 mouse = GameObject.FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition);
			selected_tower.transform.position = new Vector3(mouse.x, mouse.y, 0f);

			if (Input.GetMouseButtonDown(0)) {

			}
			if (Input.GetMouseButtonDown(1)) {
				GameObject.Destroy(selected_tower.gameObject);
				selected_tower = null;
			}        
        }
    }

}
