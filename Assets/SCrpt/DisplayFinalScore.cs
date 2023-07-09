using UnityEngine;
using UnityEngine.UI;

public class DisplayFinalScore : MonoBehaviour
{
    
    private Text finalScoreText;

    private void Awake()
    {
        
        finalScoreText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        
        finalScoreText.text = "Final Score: " + GameData.Instance.Score;
    }
}
