using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName ="scriptable/gun")]
public class gun_scriptable : ScriptableObject
{
    public Sprite gun;
    public Sprite gun_icon;
    public GameObject bullet;
    public int damage;
    public ParticleSystem explode;
    public AudioClip sound_effect;

}
