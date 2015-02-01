using UnityEngine;
using System.Collections;
using System;
using XInputDotNetPure;

[RequireComponent(typeof(Movement))]
public class Players : MonoBehaviour, IComparable<Players>
{
    public float countDown=0.3f;
    private PlayerIndex playerIndex;

    private bool inputTimer;
    public int idPlayer { get; private set; }
    public string nameP { get; private set; }
    public GameObject QbertP { get; private set; }

    public bool isDeadP = false;
    public bool isFallP = false;
    public bool isHit = false;
    public Color isColor { get; private set; }

    private GameManager gameManager;

    private float timerRespawn = 2.0f;
    private Movement movementScript;
    private Vector3 QbertStart;
    private Vector3 SavePos;
    private Health health;
    public ScoreController score;
    private SoundManager soundManager;
    public void AddPlayer(int id, GameObject qp, Color col, string name)
    {
        isColor = col;
        QbertP = qp;
        idPlayer = id;
        nameP = name;
    }

    void Start()
    {
        playerIndex = (PlayerIndex)idPlayer-1;
        this.soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();        
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>() ;
        GameObject go = GameObject.FindGameObjectWithTag("Health");
        health = go.GetComponent<Health>();
        this.movementScript = this.gameObject.transform.GetComponent<Movement>();
        this.QbertStart = this.QbertP.transform.position;
        Debug.Log("ID PLAYER : "+this.idPlayer);
    }

  public IEnumerator Waitinput() // Timer entre les inputs
    {
        inputTimer = true;
        yield return new WaitForSeconds(countDown);
        inputTimer = false;
    }

  IEnumerator WaitForDying() {

      yield return new WaitForSeconds(1.0f);
      this.isDeadP = true;
      this.isHit = false;
  }
    void Update()
    {
        if (this.isHit == true) {
            this.SavePos = this.gameObject.transform.position;
            GamePad.SetVibration(playerIndex, 0.5f, 0.5f);
          
            StartCoroutine(WaitForDying());
        }
        
        if (this.isDeadP == true)
        {
            this.movementScript.DeadMovement();
            this.QbertP.collider.enabled = false;

            this.Respawn();
        }
        else if (this.isHit == false && inputTimer== false)
        {
            GamePad.SetVibration(playerIndex, 0, 0);
            
            this.movementScript.PlayerMovement();
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            this.isHit = true;
            this.health.ModifyHealth(-2);
            gameManager.DestroyAll = true;
            this.soundManager.touchball();
            Debug.Log("Enemy");
        }

        else if (col.tag == "Cube")
        {
            this.SavePos = this.gameObject.transform.position;
           // QbertFunction.SavePosition(nameP, col.transform);
            this.isFallP = false;
            this.isDeadP = false;
        }

        else if (col.tag == "Invincible") 
        {
            StartCoroutine(DesactivateCollider());
            soundManager.bonus();
            score.AddScore(250);
            
        }
        else if (col.tag == "Upgrade(1)")
        {
            soundManager.bonus();
            score.AddScore(250);

        }

       
    }
    IEnumerator DesactivateCollider() {
        this.collider.enabled = false;
        yield return new WaitForSeconds(4.0f);
        this.collider.enabled = false;
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "ZoneExit")
        {
            this.health.ModifyHealth(-2);
            this.isFallP = true;
            this.soundManager.eventsound();      
            GamePad.SetVibration(playerIndex, 0.5f, 0.5f);
            this.isDeadP = true;
        }
    }
    void Respawn()
    {
        this.timerRespawn -= Time.deltaTime;
        Debug.Log("Respawn");

        if (this.timerRespawn <= 0 && this.isDeadP == true)
        {

            this.isDeadP = false;
            this.QbertP.collider.enabled = true;
            if (this.isFallP == false)
            {
                this.transform.position = this.SavePos;
                GamePad.SetVibration(playerIndex, 0, 0);
                //QbertFunction.LastPosition(this.nameP, this.QbertP.transform);
            }
            else
            {
                this.QbertP.transform.position = this.QbertStart;
                this.isFallP = false;
            }
            this.timerRespawn += 2;
        }

    }
    public int CompareTo(Players other)
    {
        if (other == null)
        {
            return 1;
        }

        // //Return the difference in power.
        return idPlayer - other.idPlayer;
    }
}
