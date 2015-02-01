using UnityEngine;
using System.Collections;
using XInputDotNetPure;
public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GamePad.SetVibration((PlayerIndex)0, 0, 0);
        GamePad.SetVibration((PlayerIndex)1, 0, 0);

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Back"))
        {
            Application.Quit();
            Debug.Log("Quit");
        }
        else if(Input.GetButtonDown("Start")) 
        {

        }
	
	}
}
