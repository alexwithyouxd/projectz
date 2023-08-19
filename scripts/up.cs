using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{

    public float currentspeed = 2;
    void Update()
    {
        transform.Translate(Vector2.up * currentspeed * Time.deltaTime);
    }
}
