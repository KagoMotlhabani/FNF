using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool paused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

    }//end update

    public void Pause()
    {
        if (!paused)
        {
            pauseMenu.SetActive(true);
            paused = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            paused = false;
        }
    }//end loadscene

    public void QuitGame()
    {
        Debug.Log("GAME ENDED");
        Application.Quit();
    }
}//end class
