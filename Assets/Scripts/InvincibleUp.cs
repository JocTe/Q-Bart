using UnityEngine;
using System.Collections;

public class InvincibleUp : MonoBehaviour {


    void Update()
    {
        transform.Rotate(Vector3.up * 45 * Time.deltaTime);

        float timer = 5.0f;
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Qbert (P1)")
        {
            Destroy(this.gameObject);
        }

        if (col.tag == "Qbert (P2)")
        {
         
            Destroy(this.gameObject);
        }

    }
}
