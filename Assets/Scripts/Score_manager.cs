using UnityEngine.UI;
using UnityEngine;
using System;

public class Score_manager : MonoBehaviour
{

    
    public Text ScoreTxt;
    public static Score_manager Instance { get; private set; }

    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(ScoreTxt);
        }
        else
        {
            Destroy(gameObject);
        }

        Score = 0;
    }

  

    public void AddScore(int value)
    {
        
        ScoreTxt.text = "Score: " + value.ToString();
        GameData.Instance.Score = value;
    }

    public int GetScore()
    {
        return Score;
    }
}
