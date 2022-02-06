using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public bool keyA = false;
    public bool keyD = false;
    public bool keySpace = false;
    public float dir;
    void Update()
    {
        keyA = Input.GetKey("a");
        keyD = Input.GetKey("d");
        keySpace = Input.GetKey("space");
        dir = Input.GetAxis("Horizontal");
    }
}
