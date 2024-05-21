using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
   [SerializeField] GameObject panel;

void Awake()
{
    Instance=this;
}


public void LoadPanel()
{
    panel.SetActive(true);
    Time.timeScale=0;
}

public void RestartScene()
{
     Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale=1;
}

   
}
