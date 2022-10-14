using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
    public string[] Levels;
    private static LevelManager instance;
    public static LevelManager Instance{get {return instance;}}
    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start() 
    {
        if(GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
        
    }
    public void MarkCurrentComplete()
    {
        Scene Currentscene = SceneManager.GetActiveScene();
        //set level status to complete 
        SetLevelStatus(Currentscene.name, LevelStatus.Completed);
        //unlock next
        //int nextSceneindex = Currentscene.buildIndex + 1;
        //Scene NextScene = SceneManager.GetSceneByBuildIndex(nextSceneindex);
        //SetLevelStatus(NextScene.name, LevelStatus.Unlocked);
        int currentSceneIndex = Array.FindIndex(Levels, level => level == Currentscene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }
    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus =(LevelStatus) PlayerPrefs.GetInt(level,0);
        return levelStatus;
    }
    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Setting level : "+ level + "Status : "+ levelStatus);
    }
}