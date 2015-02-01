using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

	private SoundManager coin;

	void Start()
	{
		coin = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
		coin.powerup();
	}

	void Update () 
	{
		if (Input.GetButtonDown("Start"))
		{
			Application.LoadLevel("Tutorial");
		}
		else if (Input.GetButtonDown("Back"))
		{
			Application.Quit();
		}
	}
}
