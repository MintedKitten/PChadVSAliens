using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject paused_UI;
    void Start()
    {
        paused_UI.SetActive(false);
        Time.timeScale = 1;
    }
     void Update()
    {
        pauseMenu();
    }
    public void showMenu()
    {
        paused_UI.SetActive(true);
        Time.timeScale = 0;
    }
    public void hideMenu()
    {
        AudioManager.instance.PlayClick();
        paused_UI.SetActive(false);
        Time.timeScale = 1;
    }
    public void pauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {  
            showMenu();
        }
    }
}
