using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal_up : MonoBehaviour
{
    [SerializeField] float amount;
    [SerializeField] float_event heal_channel;
    

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            heal_channel.Raise(amount);
            Destroy(gameObject);
        }
    }
}
