using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introtomenu : MonoBehaviour
{

    public int scene;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Invoke("change_scene", 6.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void change_scene()
    {
        SceneManager.LoadScene("main menu");
    }
}
