using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckColorPyramide : MonoBehaviour
{


    private ColorCube colorCube;
    public ScoreController score;
    public Text stage;
    private int stageint =0;
    private int countP1 = 0;
    private int countP2 = 0;

    public int victoryP1;
    public int victoryP2;

    public Text player1Objectif;
    public Text player2Objectif;


    public bool changeVictoryNumber = true;

    void Start() 
    {

    }

    void Update()
    {
        if (changeVictoryNumber == true)
        {
            RandomNumberVictory();
        }
        player1Objectif.text = "Qbert : " + victoryP1;
        player2Objectif.text = "PacMan : " + victoryP2;

        foreach (Transform child in transform)
        {
           
            colorCube = child.GetComponent<ColorCube>();
            if ((int)colorCube.whosColor == 1)
            {
                countP1++;
            }
            else if ((int)colorCube.whosColor == 2)
            {
                countP2++;
            }

        }
        if (countP1 == victoryP1 && countP2 == victoryP2)
        {
            stageint += 1;
            changeVictoryNumber = true;
            score.AddScore(1000);
            stage.text = "Stage " + stageint;
        
        }
        countP1 = 0;
        countP2 = 0;

    }


    void RandomNumberVictory()
    {
        victoryP2 = Mathf.CeilToInt(Random.Range(5, 24));
        victoryP1 = transform.childCount - victoryP2;
        changeVictoryNumber = false;
        stage.text = "";        

        foreach (Transform child in this.gameObject.transform)
        {
            ColorCube ChildScript = child.GetComponent<ColorCube>();
            ChildScript.whosColor = 0;
            ChildScript.transform.gameObject.renderer.material.color = Color.white;
        }

    }
}
