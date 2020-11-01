using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private Transform target;
    private Vector3 dead_target;
    private float speed = 10f;

    public void Init(Transform target){
        this.target = target;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + 
        ((target==null ? dead_target : target.position)- transform.position) * Time.deltaTime * speed;
    }

    void OnColliderEnter2D(Collider2D col){
        if(col.gameObject.tag != "Enemy"){
            return;
        } 
    }
}
