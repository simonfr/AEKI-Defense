using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButtonBehavior : MonoBehaviour{
    [SerializeField] private Tower tower;
    [SerializeField] private Transform infos;
    [SerializeField] private TowerBehavior select_tower;

    private PlayerBehavior player;
    private Text text;
    private Button button;

    public bool mouse_in;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerBehavior>();
        button = GetComponent<Button>();
        text = GetComponent<Text>();
        infos.gameObject.SetActive(false);

        button.onClick.AddListener(OnClick);
        
    }

    void Update()
    {
		if (mouse_in) {
			infos.transform.position = Input.mousePosition;
		}
    }
    
    void OnClick(){
        TowerBehavior t = GameObject.Instantiate(select_tower);

        t.Init(tower, true);
        player.SetSelectedTower(null);
        player.SetSelectedTower(t);
    }

    public void OnPointerEnter(){
        mouse_in=true;

        GameObject.Find("TowerNameText").GetComponent<Text>().text = "";
		GameObject.Find("costText").GetComponent<Text>().text = "Cost: " + tower.cost;
		GameObject.Find("damageText").GetComponent<Text>().text = "Damage: " + tower.damage;
		GameObject.Find("attackSpeedText").GetComponent<Text>().text = "Attack Speed: " + tower.attack_speed;
		GameObject.Find("descriptionText").GetComponent<Text>().text = "Info: \n";
    }

    public void OnPointerExit(){
        mouse_in=false;
    }


}
