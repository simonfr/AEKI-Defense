using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject {
    public int life;
    public Sprite sprite;
    public Color color;
    public float size;
    public float move_speed;
    public int gold;
    public int value;
}
