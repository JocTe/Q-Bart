using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            Application.LoadLevel("TitleMenu");
        }
        else if (Input.GetButtonDown("Back"))
        {
            Application.Quit();
        }
    }
}