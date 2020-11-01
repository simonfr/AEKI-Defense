using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRegionBehavior : MonoBehaviour
{
    [SerializeField] private DirectionEnum target_direction = DirectionEnum.RIGHT;

    void OnTriggerEnter2D(Collider2D col){
        EnemyBehavior enemy = col.gameObject.GetComponent<EnemyBehavior>();

        if(enemy == null)
            return;

        enemy.ChangeDirection(target_direction);
    }
}
