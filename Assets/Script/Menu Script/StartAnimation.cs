using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayClothRip()
    {
        AudioManager.instance.PlayClothRip();
    }
}
