using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startmenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/GameScreen");
    }
}
