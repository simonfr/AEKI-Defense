using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnerBehavior : MonoBehaviour
{
    [SerializeField] private Waves[] waves;
    [SerializeField] private DirectionEnum start_direction = DirectionEnum.RIGHT;
    [SerializeField] private Text waves_text;
    [SerializeField] public Button start;

    private int current_waves;
    private int current_enemy;
    private int current_count;
    private float current_interval;
    private bool active;
    private bool startWave = false;


    void Start() {
		start.onClick.AddListener(setStartWave);

        current_waves = 0;
        current_enemy=0;
        current_count=0;
        current_interval=0;
        active=true;
        updateWaveText();
    }

    // Update is called once per frame
    void Update()
    {
        if(startWave)
            if (active){
                if(current_enemy == waves[current_waves].enemies.Length){
                    active=false;
                }
                current_interval += Time.deltaTime;
                if(current_interval >= waves[current_waves].enemies[current_enemy].enemy_interval){
                    SpawnEnemy();
                    ++current_count;
                    current_interval = current_interval - waves[current_waves].enemies[current_enemy].enemy_interval;
                    if(current_count==waves[current_waves].enemies[current_enemy].enemy_count){
                        current_enemy++;
                        current_count=0;
                    }
                }   
            }else{
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                if(enemies.Length == 0 && current_waves < waves.Length){
                    current_enemy=0;
                    current_waves+=1;
                    current_count=0;
                    current_interval=0;
                    active = true;
                    startWave=false;
                    start.gameObject.SetActive(!startWave);

                    updateWaveText();
                } 
            }
    }

    private void SpawnEnemy(){
        GameObject obj = GameObject.Instantiate(waves[current_waves].enemies[current_enemy].enemy_template.gameObject);
        obj.transform.position = transform.position;
        EnemyBehavior behavior = obj.GetComponent<EnemyBehavior>();
        behavior.Init(waves[current_waves].enemies[current_enemy].enemy);
        behavior.ChangeDirection(start_direction);
    }

    private void updateWaveText(){
        waves_text.text = "Wave: " + (current_waves+1);
    }

    void setStartWave(){
        startWave=true;
        start.gameObject.SetActive(!startWave);
    }
}
