using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float enemy_interval = 0f;
    [SerializeField] private DirectionEnum start_direction = DirectionEnum.RIGHT;
    [SerializeField] private GameObject spawnButton;

    private List<GameObject> enemys = new List<GameObject>();
    private float current_interval;
    private int enemyLeftToSpawn = 0;
    private List<int> wavesNb = new List<int>();

    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        current_interval += Time.deltaTime;

        if(current_interval >= enemy_interval && enemyLeftToSpawn != 0){
            SpawnEnemy();
            current_interval = current_interval - enemy_interval;
            spawnButton.SetActive(false);
        } else if (enemyLeftToSpawn == 0 && GameObject.Find("Termite(Clone)") == null) {
           spawnButton.SetActive(true);
           current_interval = 0;
        }
    }

    public void launchWave(){
        ResetCountEnemy(wavesNb[0]);
        wavesNb.RemoveAt(0);
    }

    public void launchWaves(string waves)
    {
        string[] split = waves.Split(","[0]);
        foreach (string waveNb in split)
        {
            wavesNb.Add(int.Parse(waveNb));
        }
        launchWave();
    }

    private void ResetCountEnemy(int enemyToSpawn){
        enemyLeftToSpawn = enemyToSpawn;
    }

    private void SpawnEnemy(){
        GameObject obj = GameObject.Instantiate(enemy);
        enemys.Add(obj);
        obj.transform.position = transform.position;
        obj.GetComponent<EnemyBehavior>().ChangeDirection(start_direction);
        --enemyLeftToSpawn;
    }
}
