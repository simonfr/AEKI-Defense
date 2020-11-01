using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehavior : MonoBehaviour
{
    [SerializeField] private Waves[] waves;
    [SerializeField] private DirectionEnum start_direction = DirectionEnum.RIGHT;

    private int current_waves;
    private int current_count;
    private float current_interval;

    private bool active;



    void Start() {
        current_waves = 0;
        current_count=0;
        current_interval=0;
        active=true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(active);
        if (active){

            if(current_count > waves.Length || current_count==waves[current_waves].enemy_count){
                active=false;
            }
            
            current_interval += Time.deltaTime;

            if(current_interval >= waves[current_waves].enemy_interval){
                SpawnEnemy();
                ++current_count;
                current_interval = current_interval - waves[current_waves].enemy_interval;
            }
        }else{
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemies.Length == 0 && current_waves < waves.Length){
                current_waves+=1;
                active = true;
                current_count=0;
                current_interval=0;
            }
        }

    }

    private void SpawnEnemy(){
        GameObject obj = GameObject.Instantiate(waves[current_waves].enemy_template.gameObject);
        obj.transform.position = transform.position;
        EnemyBehavior behavior = obj.GetComponent<EnemyBehavior>();
        behavior.Init(waves[current_waves].enemy);
        behavior.ChangeDirection(start_direction);
    }
}
