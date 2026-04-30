using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using TMPro;

public class ScoreTest : MonoBehaviour
{
    public TextMeshProUGUI stage1;
    public TextMeshProUGUI stage2;
    public TextMeshProUGUI stage3;
    public TextMeshProUGUI stage4;
    public TextMeshProUGUI stage5;

    void Start()
    {
        stage1.text = "STAGE 1 : " + HighScore.Load(1).ToString();
        stage2.text = "STAGE 2 : " + HighScore.Load(2).ToString();
        stage3.text = "STAGE 2 : " + HighScore.Load(3).ToString();
        stage4.text = "STAGE 2 : " + HighScore.Load(4).ToString();
        stage5.text = "STAGE 2 : " + HighScore.Load(5).ToString();
    }

    void Update()
    {
        
    }
}

public static class HighScore
{
    private const string KEY = "HighScore";

    public static int Load(int stage)
    {
        return PlayerPrefs.GetInt(KEY + "_" + stage, 0);
    }

    public static void TrySet(int stage, int newScore)
    {
        if (newScore <= Load(stage))
            return;

        PlayerPrefs.SetInt(KEY + "_" + stage, newScore);
        PlayerPrefs.Save();
    }
}