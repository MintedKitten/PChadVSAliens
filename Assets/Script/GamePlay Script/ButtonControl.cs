using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    private string previousSceneName;
    private string currentSceneName;
    public static ButtonControl instance;
    void Start()
    {
        instance = this;
        previousSceneName = PlayerPrefs.GetString("PreviousScene");
    }
    
    public void FinishGame()
    {   
        Time.timeScale = 1;
        AudioManager.instance.PlayClick();
        StartCoroutine(ToTitle());
    }

    IEnumerator ToTitle()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(0);

    }

    public void QuitGame()
    {
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    public void Retry()
    {   
        AudioManager.instance.PlayClick();
        StartCoroutine(Restart());
    }

    public void GameOver()
    {
        StartCoroutine(DiedScene());
    }
    IEnumerator DiedScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(4);
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log(previousSceneName);
        SceneManager.LoadScene(previousSceneName);
        
    }
}
