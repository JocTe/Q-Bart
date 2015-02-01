using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour {

	

	void Update()
	{
		if (Input.GetButtonDown("Start"))
		{
			this.gameObject.SetActive(!this.gameObject.activeSelf);
			
		}
	}
	
}
