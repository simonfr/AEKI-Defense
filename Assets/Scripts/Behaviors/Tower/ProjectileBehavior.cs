using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private Transform target;
    private Vector3 dead_target;
    private float speed = 5f;
    public int damage;

    public void Init(Projectile projectile, Transform target, int damage){
        if (projectile!=null){
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            speed=projectile.speed;
            renderer.color = projectile.color;
            transform.localScale = new Vector3(projectile.size, projectile.size, 0f);
            speed = projectile.speed;
            this.target = target;
            this.damage= damage;
        }
        else
        {
             this.target = target;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null){
			GameObject.Destroy(this.gameObject);
        }else{
            if (target != null){
                dead_target = target.position;
            }
            transform.position = transform.position + 
            ((target==null ? dead_target : target.position)- transform.position) * Time.deltaTime * speed;

            transform.position= new Vector3(transform.position.x, transform.position.y, 10f);
        }
    }

    
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Enemy"){
            GameObject.Destroy(this.gameObject);
        } 
    }

}
