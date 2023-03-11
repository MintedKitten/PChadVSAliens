using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    
    public LayerMask enemyLayerMask;
    private GameObject currentEnemy;
    void Start()
    {
        
    }

  
     void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, enemyLayerMask))
        {
            
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                
                if (currentEnemy != hit.transform.gameObject)
                {
                    // if (currentEnemy != null)
                    // {
                    //     currentEnemy.SetActive(false);
                    // }
                    hit.transform.gameObject.SetActive(true);
                    currentEnemy = hit.transform.gameObject;
                }
            }
        }
       
    }
  
}
