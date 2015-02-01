using UnityEngine;
using System.Collections;

public class WeHaveToCoorperate : MonoBehaviour
{

    public bool playerDetected = false;
    Players player;
    int indexP;
 
    
    void Update() {
        if (this.enabled == true)
        {
            iTween.ColorTo(this.gameObject, iTween.Hash("color", Color.magenta, "time", 0.3f, "looptype", iTween.LoopType.pingPong));
        }
    }



    void OnTriggerEnter(Collider other)
    {
       
            this.indexP = other.transform.GetComponent<Players>().idPlayer;
            if (other.tag == "Qbert (P" + indexP + ")")
            {
                this.playerDetected = true;
                this.gameObject.renderer.material.color = other.transform.GetComponent<Players>().isColor;
            }

    }

   public void StopiTween() 
    {
        iTween.Stop(this.gameObject);
    }

  
}
