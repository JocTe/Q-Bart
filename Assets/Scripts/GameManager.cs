using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public GameObject panel;

    public CheckColorPyramide CheckColorPyramide;
	//public Players Players;
    

    public bool DestroyAll = false;

    public Vector3[] arraySpawn;

    public float startTimerSpawn = 3;


    private GameObject spawnBadBalls;
    public GameObject prefabBadBalls;

    public Health healthScript;
	

    private float timerAfterDeath = 6;

    public Color colorPlayer1;
    public Color colorPlayer2;

    public GameObject Player1;
    public GameObject Player2;

    private GameObject Player { get; set; }
    private Color colorPlayer { get; set; }

    private SoundManager soundManager;

    void Start()
    {
        this.soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        
        NewPlayer(1);
        NewPlayer(2);
	

        
    }
	

		void Update()
    {

        DontDestroyOnLoad(this.gameObject);
		PauseMenu ();
        if (Application.loadedLevelName == "Level Q-bert")
        {
            Timer();
            if (healthScript.currentHealth == -2)
            {
                
                Application.LoadLevel("GameOver");
                Debug.Log("Load level");
            }

        }
            

    }


    void Spawn()
    {
        DestroyAll = false;
		if (DestroyAll == false)
		{
			Vector3 RandomPosition = arraySpawn[Random.Range(0, arraySpawn.Length)];
            spawnBadBalls = Instantiate(prefabBadBalls, RandomPosition, Quaternion.identity) as GameObject;
            spawnBadBalls.transform.parent = this.gameObject.transform;
            //Debug.Log("Timer After " + timerAfterDeath);

        }
        else if (DestroyAll == true)
        {
			//startTimerSpawn = 6f;

			//Debug.Log("Timer After " + timerAfterDeath);
            if (startTimerSpawn <= 0)
            {
                Timer();

            }
             DestroyAllObject();
        }
    }


   

    void DestroyAllObject()
    {
        foreach (GameObject spawnBadBalls in this.gameObject.transform)
        {

            GameObject.Destroy(spawnBadBalls.gameObject);
        }
    }


    void NewPlayer(int idPlayer)
    {
        if (idPlayer == 1)
        {
            Player1.AddComponent<Players>().AddPlayer(idPlayer, SetPlayerObject(Player, idPlayer), SetPlayerColor(colorPlayer, idPlayer), "Qbert (P" + idPlayer + ")");
        }
        if (idPlayer == 2)
        {
            Player2.AddComponent<Players>().AddPlayer(idPlayer, SetPlayerObject(Player, idPlayer), SetPlayerColor(colorPlayer, idPlayer), "Qbert (P" + idPlayer + ")");
        }

    }


    void Timer()
    {
        startTimerSpawn -= Time.deltaTime;
        if (startTimerSpawn <= 0)
        {
            Spawn();
            startTimerSpawn += 5;
        }
    }
    private GameObject SetPlayerObject(GameObject p, int i)
    {
        if (i == 1)
        {
            return p = Player1;
        }
        else if (i == 2)
        {
            return p = Player2;
        }
        return null;
    }

    private Color SetPlayerColor(Color c, int i)
    {
        if (i == 1)
        {
            return c = colorPlayer1;
        }
        else if (i == 2)
        {
            return c = colorPlayer2;
        }
        else
        {
            return c = Color.black;
        }

    }

	void PauseMenu()
	{
		if (Input.GetButtonDown("Start"))
		{
			this.panel.gameObject.SetActive(!this.panel.gameObject.activeSelf);
			if (this.panel.gameObject.activeSelf == true)
			{
			Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = 1;
			}
		}
	}
}
