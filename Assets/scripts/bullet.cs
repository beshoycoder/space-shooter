using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject hit_effect;
    public GameObject firing_ship;
    private Rigidbody2D rb2d;
    [SerializeField] private gun_scriptable gun;
    [SerializeField] private int_Event enemy_damage;
    [SerializeField] private float shot_speed;



    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(transform.up * shot_speed);
        

        Destroy(gameObject, 5f);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject != firing_ship)
        {
            enemy_damage.Raise(gun.damage);
            Instantiate(hit_effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
    
