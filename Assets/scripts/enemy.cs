using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [Header("score")]
    [SerializeField] private int_Event send_score;
    [Header("damage")]
    [SerializeField] private int_Event attack_;
    [Header("damage from player")]
    [SerializeField] private int_Event damage_;
    
    private bool is_colliding=false;
    private bool plyr_colliding = false;
    [SerializeField] private enemy_scriptable enemy_Data;
    [SerializeField]private int health;
    private void OnEnable()
    {
        damage_.RegisterListener(Take_Damage);
        health = enemy_Data.health;

    }
    private void OnDisable()
    {
        damage_.UnregisterListener(Take_Damage);
        
    }
    void Start()
    {
        health = enemy_Data.health;
        
    }
    private void Update()
    {
       transform.Translate(Vector3.right * enemy_Data.speed * Time.deltaTime * this.transform.localScale.x);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attack_.Raise(enemy_Data.damage);
            Destroy(gameObject);
            
            

        }
        else if(collision.gameObject.CompareTag("Projectile"))
        {
            is_colliding = true;
        }
        
        
    }
    private void Take_Damage(int obj)
    {
        if (is_colliding==true)
        {
            health -= obj;
            if (health <= 0)
            {
                Destroy(gameObject);
                send_score.Raise(enemy_Data.score);

            }

        }
        
        
    }
}
