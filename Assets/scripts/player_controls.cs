using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class player_controls : MonoBehaviour
{
    private Vector2 m_Position;
    private Vector2 Mouse_Position;
    [SerializeField] private Rigidbody2D m_Rigidbody;
    private Vector3 target;
    [Header("damage form enemy")]
    [SerializeField] private int_Event enemy;
    [Header("health_ui")]
    [SerializeField] private float_event health_ui;
    [Header("current_gun_UI")]
    [SerializeField] private UI_event_scriptable current_gun_ui;
    [Header("change_gun")]
    [SerializeField] private weapons_event gun_event;
    [Header("heal")]
    [SerializeField] private float_event HeaL;
    [Header("audio")]
    [SerializeField] private audio_event audio;

    [SerializeField] private gun_scriptable current_gun;
    [SerializeField] private gun_scriptable default_gun;
    [SerializeField] SpriteRenderer gun_pos;
    [SerializeField] private Camera m_Camera;
    [SerializeField] private float m_Speed;
    [SerializeField] private Image image;
    [SerializeField] private float max_health;
    [SerializeField] private float current_health;
    private float fill;
    private void OnEnable()
    {
        enemy.RegisterListener(take_damage);
        gun_event.RegisterListener(changeGun);
        HeaL.RegisterListener(heaL);
    }
    private void OnDisable()
    {
        enemy.UnregisterListener(take_damage);
        gun_event.UnregisterListener(changeGun);
        HeaL.UnregisterListener(heaL);
    }



    void Start()
    {

        current_health = max_health;
        Cursor.visible = false;
        current_gun = default_gun;
        gun_pos.sprite = current_gun.gun;
        current_gun_ui.Raise(current_gun.gun_icon);
        current_gun.bullet.GetComponent<bullet>().firing_ship = transform.gameObject;
    }
    private void Update()
    {

        fill = (current_health / max_health);
        Debug.Log(fill);
        health_ui.Raise(fill);
    }

    private void FixedUpdate()
    {
        if (m_Position != Vector2.zero)
        {
            m_Rigidbody.velocity = m_Position * m_Speed;
        }
        else
        {
            m_Rigidbody.velocity = Vector2.zero;
        }
    }
    void OnMovement(InputValue inputValue)
    {
        m_Position = inputValue.Get<Vector2>();

    }
    private void OnLookat(InputValue inputValue)
    {
        Mouse_Position = inputValue.Get<Vector2>();


        image.rectTransform.position = Mouse_Position;
        target = m_Camera.ScreenToWorldPoint(Mouse_Position) - transform.position;
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;


    }
    private void OnFire(InputValue inputValue)
    {
        Instantiate(current_gun.bullet, gun_pos.transform.position, gun_pos.transform.rotation);
        audio.Raise(current_gun.sound_effect);

    }
    private void take_damage(int amount)
    {
        current_health -= amount;


        if (current_health == 0)
        {
            Debug.Log("dead");
        }
    }
    private void heaL(float amount)
    {
        current_health+= amount;
    }
    private void changeGun(gun_scriptable scriptable)
    {
        current_gun = scriptable;
        current_gun_ui.Raise(current_gun.gun_icon);
        gun_pos.sprite = current_gun.gun;
        current_gun.bullet.GetComponent<bullet>().firing_ship = transform.gameObject;
        StartCoroutine(ReturnOrignalGun());
        
    }
    IEnumerator ReturnOrignalGun()
    {
        yield return new WaitForSeconds(10);
        current_gun = default_gun;
        current_gun_ui.Raise(current_gun.gun_icon);
        gun_pos.sprite = current_gun.gun;
        current_gun.bullet.GetComponent<bullet>().firing_ship = transform.gameObject;
    }
    
      
}
