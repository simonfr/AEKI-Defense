using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyBehavior : MonoBehaviour
{
    private Vector3 direction;

    private float max_life;
    private float current_life;
    private float speed;
    [NonSerialized] public int gold; 

    [NonSerialized] public int value; 

    public void Init(Enemy enemy){
        transform.localScale = new Vector3(enemy.size, enemy.size, 1f);

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = enemy.sprite;
        renderer.color = enemy.color;
        //renderer.color.a = 1f;

        max_life = enemy.life;
        current_life = max_life;
        speed = enemy.move_speed;
        gold = enemy.gold;
        value = enemy.value;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + direction * speed * Time.deltaTime;
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

        void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag != "Projectile"){
            return;
        } 
        GameObject.Destroy(col.gameObject);
    }
}
