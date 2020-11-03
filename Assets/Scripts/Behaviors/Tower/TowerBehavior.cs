using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TowerBehavior : MonoBehaviour
{
    private int damage;
    private float range;
    private float attack_speed;
    private float ready_time;
    [NonSerialized] private int cost;
    [SerializeField] private GameObject tower_base;
    [SerializeField] private GameObject tower_turret;
    [SerializeField] private GameObject tower_range;

    private Projectile projectile;
    private ProjectileBehavior projectile_template;
    private bool placing;
    private bool selected;
    private Collider2D target;
    private float current_time;
    //CONSTANTE
    [SerializeField]  private float TURRENT_ROTATION_SPEED = 1f;


    // Start is called before the first frame update
    void Start()
    {
        current_time=0f;
        selected=false;
        placing=false;
    }

    public void Init(Tower tower, bool placing = false){
        
        damage = tower.damage;
        range = tower.range;
        attack_speed = tower.attack_speed;
        ready_time = tower.ready_time;
        cost = tower.cost;

        SpriteRenderer base_renderer = tower_base.GetComponent<SpriteRenderer>();
        base_renderer.sprite=tower.base_sprite;
        base_renderer.color=tower.base_color;

        SpriteRenderer turret_renderer = tower_turret.GetComponent<SpriteRenderer>();
        turret_renderer.sprite=tower.turret_sprite;
        turret_renderer.color = tower.turret_color;

        projectile = tower.projectile;
        projectile_template = tower.projectile_template;

        tower_range.transform.localScale = new Vector3(tower.range+1, tower.range+1, 10f);
        tower_range.SetActive(placing);

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
        if (tower_turret.transform.rotation.z>0.02f)
            tower_turret.transform.rotation = Quaternion.Slerp(tower_turret.transform.rotation, Quaternion.identity, 2f * Time.deltaTime);
        else 
            tower_turret.transform.rotation = Quaternion.Slerp(tower_turret.transform.rotation, Quaternion.identity, 2f);
    }

    private void FollowTarget(){
        Vector3 dir = target.transform.position - transform.position;
        Debug.DrawRay(transform.position, dir, Color.red);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        tower_turret.transform.rotation = Quaternion.Lerp(tower_turret.transform.rotation, 
        Quaternion.AngleAxis(angle, Vector3.forward), 0.1f);
    }

    private bool IsInRange(Transform point){
        return Vector3.Distance(transform.position, point.position) <= range;
    }

    private void Fire(){
        current_time = current_time - attack_speed;
        ProjectileBehavior bullet = GameObject.Instantiate(projectile_template);
		bullet.transform.position = tower_turret.transform.position;
        bullet.Init(projectile, target.transform, damage);
    }

    // Update is called once per frame
    void Update()
    {
		if (!placing) {
			if (target == null || !IsInRange(target.transform))
				GetEnemyInRange();

			current_time += Time.deltaTime;

			if (target != null) {
				FollowTarget();
				if (current_time >= attack_speed)
					Fire();
			} else if (current_time >= attack_speed) {
				current_time = attack_speed - ready_time;
			}

			if (Input.GetMouseButtonDown(0)) {
				if (!selected) {
					selected = true;
					tower_range.SetActive(true);
				} else if (selected) {
					selected = false;
					tower_range.SetActive(false);
				}
			}
		}
    }

	public void Place() {
		placing = false;
		selected = false;
		tower_range.SetActive(false);
	}
}
