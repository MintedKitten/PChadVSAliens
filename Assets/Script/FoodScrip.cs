using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScrip : MonoBehaviour
{
private void OnTriggerEnter2D(Collider2D collider)
{
    if(collision.CompareTag("Player"))
    {
        PlayerMovement.instance.AddHP;
        Destroy(gameObject);
    }
}
}



