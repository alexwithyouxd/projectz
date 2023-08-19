using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class highscorem : MonoBehaviour
{
    public TMP_Text highscoretext;
    public float hscore = 0;
    public float hhscore = 1000;
    void Start()
    {
        //PlayerPrefs.GetFloat("hscore", hhscore);
        hscore = PlayerPrefs.GetFloat("score");
    }

    private void Update()
    {
        if (hscore > hhscore)
        {
            hhscore = hscore;
            highscoretext.text = "" + hhscore;
            PlayerPrefs.SetFloat("hscore", hhscore);
            PlayerPrefs.Save();
        }
    }
}
