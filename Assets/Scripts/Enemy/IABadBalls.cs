using UnityEngine;
using System.Collections;

public class IABadBalls : MonoBehaviour 
{
	Animator anim;
	int JumpHash = Animator.StringToHash("Jump");

    private float fallSpeed = 5f;
    private bool onCollision = false;
    public bool[] arrayMovementX;
    public float Timer = 1;
    private GameManager gameManger;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="Cube")
        {
            onCollision = true;
        }   
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag =="ZoneExit")
        {
            onCollision = false;
        }
    }

    void Start()
    {
       //arrayMovement[1] = transform.position + new Vector3(1, -1, 0);
       //arrayMovement[2] =  transform.position + new Vector3(0, -1, 1);
		anim = gameObject.transform.GetComponentInChildren<Animator>();
        gameManger = this.gameObject.transform.GetComponentInParent<GameManager>();
    }

	//IEnumerator BallCollider() // Timer pour collider
	//{
		//this.transform.collider.enabled = false;
		//yield return new WaitForSeconds(1.2f);
		//this.transform.collider.enabled = true;
		
	//}

    void Update() 
    {
        if (onCollision == false)
        {
            FallMovement();
        }
        else { 
        Movement();
        }

        if (gameManger.DestroyAll == true) {
            Destroy(this.gameObject);
        }
    }

    void FallMovement() 
    {
            transform.Translate(Vector3.down * Time.deltaTime * (fallSpeed + 1));
    }

    void Movement() 
    {
        //En bas droite transform.position = transform.position + new Vector3(1, -1, 0);
        //Enbas gauche transform.position = transform.position + new Vector3(1, -1, 0);

       bool randomMovementX = arrayMovementX[Random.Range(0, arrayMovementX.Length)];
       //bool randomMovementZ= arrayMovementZ[Random.Range(0, arrayMovementZ.Length)];
      // Debug.Log("Random " + randomMovementX);
        
        Timer -=  Time.deltaTime;
        if (Timer <= 0) 
        {
            
            if (randomMovementX == true) {
                //transform.position = transform.position + new Vector3(1, -1, 0);
				iTween.MoveTo(this.gameObject, this.transform.position + new Vector3(1.0f, -1.0f, 0.0f), 0.8f);
				anim.SetTrigger(JumpHash);
				//StartCoroutine(BallCollider());
                //Debug.Log("Movementx gauche");
            }

            if (randomMovementX == false) 
            {
                //transform.position = transform.position + new Vector3(0, -1, 1);
				iTween.MoveTo(this.gameObject, this.transform.position + new Vector3(0.0f, -1.0f, 1.0f), 0.8f);
				anim.SetTrigger(JumpHash);
				//StartCoroutine(BallCollider());
               // Debug.Log("Movementx droite");
            }
            Timer += 0.8f;
            
        }
        

           // transform.Translate(Vector3.MoveTowards)
    }

   
}
