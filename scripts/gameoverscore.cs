using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameoverscore : MonoBehaviour
{
    //highscorem hsm;
    public TMP_Text currentscoretext;
    public TMP_Text highscoretext;
    public float hscore = 0; //stores current score values
    public float hhscore; //stores highscore
    void Start()
    {
        hhscore = PlayerPrefs.GetFloat("hscore");
        highscoretext.text = "" + hhscore;
        currentscoretext.text = "SCORE: " + PlayerPrefs.GetFloat("score");
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