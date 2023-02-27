using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{   
   
    private Button button;
    
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(RunStart);
        
    }
    private void RunStart()
    {
        AudioManager.instance.PlayClick();
        StartCoroutine(CompleteLevel());
        


    }
     IEnumerator CompleteLevel()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}

