using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Level 1");
    }//end loadscene

    public void QuitGame()
    {
        Debug.Log("GAME ENDED");
        Application.Quit();
    }
}
