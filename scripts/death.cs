using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    public Animator anim;
    public GameObject satya;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (satya != null && satya.transform.position.y < -25)
        {
            Destroy(satya);
            anim.SetBool("dead", true);
            // KillPlayer();
        }
    }
    public void loadgameover()
    {
        SceneManager.LoadScene("gameover");
    }
   
}