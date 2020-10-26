using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private Transform turret;
    private Collider2D target;
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
        target = Physics2D.OverlapCircle(transform.position, range);
        if(target==null)
            ResetTurretRotation();       
    }

    private void ResetTurretRotation(){
        if (turret.rotation.z>0.02f)
            turret.rotation = Quaternion.Slerp(turret.rotation, Quaternion.identity, 2f * Time.deltaTime);
        else 
            turret.rotation = Quaternion.Slerp(turret.rotation, Quaternion.identity, 2f);
    }

    private void FollowTarget(){
        Vector3 dir = target.transform.position - transform.position;
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
        if(target == null || !IsInRange(target.transform)){
            GetEnemyInRange();
        }
        
        if(target != null){
            FollowTarget();
        }
    }
}
