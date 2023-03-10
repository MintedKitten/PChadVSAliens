using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScrip : MonoBehaviour
{
    public int hp_gain = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement.instance.AddHP(hp_gain);
            gameObject.SetActive(false);
        }
    }
}



