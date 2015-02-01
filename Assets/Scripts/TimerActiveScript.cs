using UnityEngine;
using System.Collections;

public class TimerActiveScript : MonoBehaviour {

    public float timer;
    private Collider colorManagerCol;


    void Start() 
    {
        colorManagerCol = transform.gameObject.GetComponent<Collider>();
        colorManagerCol.enabled = false;
    }

    void Update ()
    {
        timer -= Time.deltaTime;
        if (timer <=0)
        {
            colorManagerCol.enabled = true;
            timer =0;
        }
    }
}
