using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public float destroyTimeMin = 3f;
    public float destroyTimeMax = 3f;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        // Generate a random time between destroyTimeMin and destroyTimeMax
        float destroyTime = Random.Range(destroyTimeMin, destroyTimeMax);

       // animator.SetTrigger("block des");
        // Destroy the sprite after a random amount of time
        Invoke("DestroySpriteGameObject", 6f /*destroyTime*/);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroySpriteGameObject()
    {
        // Play the animation
       // animator.SetTrigger("block des");

        // Destroy the sprite after the animation has finished playing
        //float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject/*, animationLength*/);
    }
}
