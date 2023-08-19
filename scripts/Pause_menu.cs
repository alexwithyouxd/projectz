using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_menu : MonoBehaviour
{
   public static bool gameispaused = false;
    
    public GameObject pausemenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameispaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
            
        }
    }

    // functions

    public void ResumeGame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        gameispaused = false;
    }

    void PauseGame()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        gameispaused = true;
    }

    
}
