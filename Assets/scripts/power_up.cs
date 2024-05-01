using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_up : MonoBehaviour
{
    [SerializeField] private gun_scriptable gun_;
    [SerializeField] private weapons_event Event;
    

    
    void Update()
    {
        transform.Translate(Vector3.right * 2f * Time.deltaTime * this.transform.localScale.x);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Event.Raise(gun_);
            Destroy(gameObject);
        }
    }
}
