using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EventManager : MonoBehaviour
{
    public GameObject pyramide;

    

    public float timerEvent = 15f;

    public int childRandom1;
    public int childRandom2;
    WeHaveToCoorperate childS1;
    WeHaveToCoorperate childS2;
    public float timerofThisEvent = 8.0f;
    public GameObject prefabLifeUp;
    public GameObject prefabInvincible;

    private bool EventCompleted = false;
    public bool EventFail = false;
    bool EventFinish = true;
    bool launchEvent;
    int numberOfEvent;
    public GameObject Player1;
    public GameObject Player2;
    private string nameEvent;
    public Text TextEvent;
    private bool Event1 = false;
    private bool Event2 = false;

    public ScoreController score;

    void Start (){
      StartCoroutine(Event_Reset());
    }
    void Update()
    {
        TextEvent.text = nameEvent;
            if (launchEvent == true)
            {
                if (numberOfEvent <=20)
                {
                    Event_WeHaveToCooperate();
                    nameEvent = "Cooperate";
                }
                if (numberOfEvent >20)
                {
              
                        Event_UpLife();
                        nameEvent = "1 LIFE";
                    
                    
                }

            
        }
        if (EventFinish == true)
        {
            
            
            if (EventFail == true)
            {
                

                foreach (Transform child in pyramide.transform)
                {
                    ColorCube ChildScript = child.GetComponent<ColorCube>();
                    ChildScript.whosColor = 0;
                    ChildScript.transform.gameObject.renderer.material.color = Color.white;
                }
                timerofThisEvent = 0.0f;
               
                
               
                Debug.Log("Fail");
            }

            else if (EventFail == false) {
                timerofThisEvent = 0.0f;

                Debug.Log("Completed");
               
                
            }
            StartCoroutine(Event_Reset());
        }
    }

    IEnumerator Event_Reset (){
        EventFinish = false;
        nameEvent = "";
        EventFail = false;
        foreach (Transform child in pyramide.transform)
        {
            child.GetComponent<WeHaveToCoorperate>().playerDetected = false;
        }
        EventCompleted = false;
        launchEvent = false;
        
        Debug.Log("FAAAAAAAAALSSSSE");
        yield return new WaitForSeconds(timerEvent);
        childRandom1 = Random.Range(1, 25);
        childRandom2 = Random.Range(0, 28);
        numberOfEvent = Random.Range(0,30);
        launchEvent = true;
        EventFinish = false;
        timerofThisEvent = 8.0f;
        Debug.Log("TRUUUUUUUEEEEEE");
        StopCoroutine(Event_Reset());
        

    }

    void Event_UpLife() 
    {
        Vector3 whereToSpawn = pyramide.transform.GetChild(childRandom2).position+new Vector3(0.0f, 0.5f,0.0f);
       Instantiate(prefabLifeUp, whereToSpawn, Quaternion.identity);
        EventFinish = true;
    }
    void Event_UpInvincible()
    {
        Vector3 whereToSpawn = pyramide.transform.GetChild(childRandom1).position + new Vector3(0.0f, 0.5f, 0.0f);
        Instantiate(prefabInvincible, whereToSpawn, Quaternion.identity);
        EventFinish = true;
    }

    void Event_WeHaveToCooperate()
    {
        childS1 = pyramide.transform.GetChild(childRandom2).GetComponent<WeHaveToCoorperate>();
        childS2 = pyramide.transform.GetChild(childRandom1).GetComponent<WeHaveToCoorperate>();
        childS2.enabled = true;
        childS1.enabled = true;

        if (EventFinish == false)
        {
           

            
                timerofThisEvent -= Time.deltaTime;
             if(timerofThisEvent < 0 && childS1.playerDetected == false || timerofThisEvent < 0 && childS2.playerDetected == false)
                {
                    Debug.Log("FAIL");
                    launchEvent = false;
                    EventFail = true;
                    EventFinish = true;
                    childS2.StopiTween();
                    childS1.StopiTween();
                    childS2.enabled = false;
                    childS1.enabled = false;
               
                }
             else if (childS1.playerDetected == true && childS2.playerDetected == true)
             {
                 EventFail = false;
                 EventFinish = true;
                 launchEvent = false;
                 childS2.StopiTween();
                 childS1.StopiTween();
                 childS2.enabled = false;
                 childS1.enabled = false;
                 score.AddScore(500);
             
             }
            
        }
    }

 
}