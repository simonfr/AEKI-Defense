using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    [SerializeField] private int sante = 100;
    
    private Vector3 direction; 

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + direction * speed;
    }

    public void ChangeDirection(DirectionEnum dir){
        switch (dir) {
            case DirectionEnum.UP:
                direction = Vector3.up;
                break;
            case DirectionEnum.DOWN:
                direction = Vector3.down;
                break;
            case DirectionEnum.LEFT:
                direction = Vector3.left;                
                break;
            case DirectionEnum.RIGHT:
                direction = Vector3.right;
                break;
        }    
    }
}
