using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	private float time = 6.0f;
	private SoundManager music;

	// Use this for initialization
	void Start () {
		music = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
		music.startmusic();
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		time -= Time.deltaTime;
		if (time <= 0) 
		{
			Application.LoadLevel("Level Q-bert");
		}
	
	}
}
