using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("game");
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("main menu");
        }
    }

    public void game()
    {
        SceneManager.LoadScene("game");
    }

    public void highscore()
    {
        //Debug.Log("highscoremenu");
        SceneManager.LoadScene("highscore");
    }

    public void exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void retry()
    {
        
        SceneManager.LoadScene("game");
    }

    public void mainm()
    {

        SceneManager.LoadScene("main menu");
    }
}
