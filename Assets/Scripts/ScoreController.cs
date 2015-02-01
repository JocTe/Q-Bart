using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour {

	public Text scoreText;
	public int score;
    public Text newscore;

	void Start () 
	{
		score = 0;
		UpdateScore ();
	}

	void Update() {
		UpdateScore ();
        if (Application.loadedLevelName == "Level Q-bert") {
            PlayerPrefs.SetInt("Score", score);
        }
        if (Application.loadedLevelName == "GameOver")
        {
            score = PlayerPrefs.GetInt("Score");
        }
       

	}
    public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
        newscore.text = "+ " + newScoreValue;
        float timer = 0.5f;
        timer -= Time.deltaTime;
        if (timer < 0) {
            newscore.text = "";
        }
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score : " + score;
	}
}
