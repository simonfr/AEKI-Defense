using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private Transform turret;
    private Transform target;
    //CONSTANTE
    [SerializeField]  private float TURRENT_ROTATION_SPEED;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void GetEnemyInRange(){
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, range);

        if(enemy!=target){
            if(target!=null) {
                target.GetComponent<SpriteRenderer>().color = Color.magenta;
            }
        }
        target = enemy == null ? null : enemy.transform;
        if(target!=null)
            target.GetComponent<SpriteRenderer>().color=Color.cyan;
        else
            ResetTurretRotation();
        
    }

    private void ResetTurretRotation(){
        turret.rotation = Quaternion.Slerp(turret.rotation, Quaternion.identity, 2f);
    }

    private void FollowTarget(){
        Vector3 dir = target.position - transform.position;
        Debug.DrawRay(transform.position, dir, Color.red);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        turret.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private bool IsInRange(Transform point){
        return Vector3.Distance(transform.position, point.position) <= range;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null || !IsInRange(target)){
            GetEnemyInRange();
        }
        
        if(target != null){
            FollowTarget();
        }
    }
}
