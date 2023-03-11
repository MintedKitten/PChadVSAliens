using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    // Start is called before the first frame update
   void Destroy()
    {
        Destroy(gameObject);
    }
}
