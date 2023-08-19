using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanagerscript : MonoBehaviour
{
    public static AudioClip playerjump, coin, death;
    static AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        playerjump = Resources.Load<AudioClip>("playerjump");
        //coin = Resources.Load<AudioClip>("coin");
        //death = Resources.Load<AudioClip>("death");

        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playsound( string clip)
    {
        switch (clip)
        {
            /*case "coin": 
                audiosrc.PlayOneShot(coin); 
                break;*/
            case "playerjump":
                audiosrc.PlayOneShot(playerjump);
                break;
            /*case "death":
                audiosrc.PlayOneShot(death);
                break;*/
        }
    }
}
