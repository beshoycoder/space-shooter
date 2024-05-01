using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="scriptable/enemy")]
public class enemy_scriptable : ScriptableObject
{
    public GameObject prefab;
    public int health;
    public int damage;
    public int score;
    public float speed;

 
}
