using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelController : MonoBehaviour



{
    public Button Replay;
    public Button LoadLevel;    
    public Button Quit;    

    Scene scene;
    private void Awake() 
    {
        Replay.onClick.AddListener(ReloadLevel);
        LoadLevel.onClick.AddListener(LoadNext);
        Quit.onClick.AddListener(QuitGame);
        scene =  SceneManager.GetActiveScene();
    }
    public void LevelComplete()
    {
        gameObject.SetActive(true);
        SoundManager.Instance.Play(Sounds.Complete); 
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(scene.buildIndex);
    }
    private void LoadNext()
    {
        SceneManager.LoadScene(scene.buildIndex + 1);
        SoundManager.Instance.Play(Sounds.Next);
    }
    private void QuitGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Quit Game");
    }
} 