using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button Restart;
    private void Awake() 
    {
        Restart.onClick.AddListener(ReloadLevel);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true); 
    }
    private void ReloadLevel()
    {
        Scene scene =  SceneManager.GetActiveScene();
        SoundManager.Instance.Play(Sounds.Failed);
        SceneManager.LoadScene(scene.buildIndex);
    }
}
