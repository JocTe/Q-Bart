using UnityEngine;

public class ColorCube : MonoBehaviour
{
    public enum Color { p0 = 0, p1 = 1, p2, p3, p4 }

    public ScoreController score;
    private Players player;

    private int index = 0;
    public Color whosColor;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Debug.Log("ennemy");
        }
        else
        {
            index = col.GetComponent<Players>().idPlayer;
            if (col.tag == "Qbert (P" + index + ")")
            {
                score.AddScore(25);
                whosColor = (Color)index;
                this.player = col.transform.gameObject.GetComponent<Players>();
                this.transform.gameObject.renderer.material.color = this.player.isColor;
            }
        }
    }
}