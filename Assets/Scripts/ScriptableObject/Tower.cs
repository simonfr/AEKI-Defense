using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Tower : ScriptableObject {
    
    public bool placed;
    public float range;
    public int damage;
    public float attack_speed;
    public float ready_time;
    public int cost;

    public Color base_color;

    public Sprite turret_sprite;
    public Sprite base_sprite;

    public Color turret_color;

    public Projectile projectile;
    public ProjectileBehavior projectile_template;

    public bool freeze_rotation = false;

}
