using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private Transform target;
    private Vector3 dead_target;
    private float speed;
    public int damage;

    public void Init(Projectile projectile, Transform target, int damage){
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        speed=projectile.speed;
        renderer.color = projectile.color;
        transform.localScale = new Vector3(projectile.size, projectile.size, 1f);
        speed = projectile.speed;
        this.target = target;
        this.damage= damage;
    }


    // Update is called once per frame
    void Update()
    {
        if (target != null){
            dead_target = target.position;
        }

        transform.position = transform.position + 
        ((target==null ? dead_target : target.position)- transform.position) * Time.deltaTime * speed;
    }

    void OnColliderEnter2D(Collider2D col){
        if(col.gameObject.tag != "Enemy"){
            return;
        } 
        GameObject.Destroy(this.gameObject);
        GameObject.Destroy(col.gameObject);

    }
}
