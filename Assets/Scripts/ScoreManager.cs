using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;
    private void Awake() 
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    private void Start() 
    {
        RefreshUI();
    }
    public void IncreaseScore(int increment)
    {
        score += increment;
        RefreshUI();
    }
    private void RefreshUI()
    {
        scoreText.text = "Score :" + score;
    }
}
