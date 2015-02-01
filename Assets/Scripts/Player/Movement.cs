using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    Animator anim;
    SoundManager soundManager;

    int JumpHash = Animator.StringToHash("Jump");

    Players player;

    private float fallSpeed = 10.0f;

    Transform QbertP;

   

    public int id;

    void Start()
    {
        this.soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        this.player = this.gameObject.transform.GetComponent<Players>();
        anim = gameObject.transform.GetComponentInChildren<Animator>();
        this.QbertP = this.player.QbertP.transform;
       
        
    }

    public void DeadMovement()
    {
        this.transform.Translate(Vector3.down * Time.deltaTime * (fallSpeed + 1));
    }
    void JumpSound() {
        if (this.player.idPlayer == 1)
        {
            this.soundManager.qbertjump();
        }
        else if (this.player.idPlayer == 2)
        {
            this.soundManager.PacmanJump();
        }
    }

    public void PlayerMovement()
    {
        if (Input.GetButtonDown("UpRightMovement (P" + this.player.idPlayer + ")"))
        {
            Debug.Log("UpRight");
            iTween.MoveTo(this.gameObject, this.transform.position + new Vector3(-1.0f, 1.0f, 0.0f), 0.3f);
            //this.QbertP.position = this.QbertP.position + new Vector3(-1, 1, 0);
            this.QbertP.localRotation = Quaternion.Euler(0, 180, 0);
            anim.SetTrigger(JumpHash);
            JumpSound();
          

            
            StartCoroutine(this.player.Waitinput());
          }
        else if (Input.GetButtonDown("DownLeftMovement (P" + this.player.idPlayer + ")"))
        {
            //this.QbertP.position = this.QbertP.position + new Vector3(1, -1, 0);
            iTween.MoveTo(this.gameObject, this.transform.position + new Vector3(1.0f, -1.0f, 0.0f), 0.3f);
            this.QbertP.localRotation = Quaternion.Euler(0, 0, 0);
            anim.SetTrigger(JumpHash);
            JumpSound();

            StartCoroutine(this.player.Waitinput());

        }
        else if (Input.GetButtonDown("UpLeftMovement (P" + this.player.idPlayer + ")"))
        {
            //this.QbertP.position = this.QbertP.position + new Vector3(0, 1, -1);
            iTween.MoveTo(this.gameObject, this.transform.position + new Vector3(0.0f, 1.0f, -1.0f), 0.3f);
            this.QbertP.localRotation = Quaternion.Euler(0, 90, 0);
            anim.SetTrigger(JumpHash);
            JumpSound();

            StartCoroutine(this.player.Waitinput());

        }
        else if (Input.GetButtonDown("DownRightMovement (P" + this.player.idPlayer + ")"))
        {
            //this.QbertP.position = this.QbertP.position + new Vector3(0, -1, 1);
            iTween.MoveTo(this.gameObject, this.transform.position + new Vector3(0.0f, -1.0f, 1.0f), 0.3f);
            this.QbertP.localRotation = Quaternion.Euler(0, 270, 0);
            anim.SetTrigger(JumpHash);
            JumpSound();

            StartCoroutine(this.player.Waitinput());

        }
    }

}

