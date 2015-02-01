using UnityEngine;

public class LifeUp : MonoBehaviour
{
    private Health healthScript;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Qbert (P1)")
        {
            this.healthScript.addLife(1);
            this.healthScript.ModifyHealth(+2);
            Destroy(this.gameObject);
        }

        if (col.tag == "Qbert (P2)")
        {
            this.healthScript.addLife(1);
            this.healthScript.ModifyHealth(+2);
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Health");
        //GameObject go = GameObject.FindGameObjectWithTag("Qbert (P1)");
        healthScript = go.GetComponent<Health>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.up * 45 * Time.deltaTime);

        float timer = 5.0f;
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(this.gameObject);
        }
    }
}