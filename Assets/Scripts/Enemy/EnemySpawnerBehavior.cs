using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int enemy_count = 0;
    [SerializeField] private float enemy_interval = 0f;
    [SerializeField] private DirectionEnum start_direction = DirectionEnum.RIGHT;

    private int current_count;
    private float current_interval;

    // Update is called once per frame
    void Update()
    {
        if(current_count == enemy_count)
            gameObject.SetActive(false); //TOMODIFY : à modifier pour le système de vagues
        
        current_interval += Time.deltaTime;

        if(current_interval >= enemy_interval){
            SpawnEnemy();
            ++current_count;
            current_interval = current_interval - enemy_interval;
        }
    }

    private void SpawnEnemy(){
        GameObject obj = GameObject.Instantiate(enemy);
        obj.transform.position = transform.position;
        obj.GetComponent<EnemyBehavior>().ChangeDirection(start_direction);
    }
}
