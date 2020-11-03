using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRegionBehaviour : MonoBehaviour
{
    private PlayerBehavior player;
    void Start() {
        player = GameObject.FindObjectOfType<PlayerBehavior>();
    }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        EnemyBehavior enemy = col.gameObject.GetComponent<EnemyBehavior>();
        if (enemy == null)
            return;

        //TODO : Enlever une vie
        player.RemoveLives(enemy.value);
        GameObject.Destroy(col.gameObject);
    }

}
