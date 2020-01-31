using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        string button = "joystick button ";
        for (int i = 0; i < 12; i++)
            PrintName(button + i.ToString());   
    }

    void PrintName(string buttonName)
    {
        if (Input.GetKey(buttonName))
            Debug.Log(buttonName);
    }
}
