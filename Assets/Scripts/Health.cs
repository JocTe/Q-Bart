using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

    public int startingHealth;
    public int healthPerLife;

    public int currentHealth;
    private int maxHealth;
    public GameManager gameManager;

    public GUITexture lifeGUI;
    public Texture[] images;

    private ArrayList lifes = new ArrayList();

    public int maxLifePerColumn;
    private float spacingX;
    private float spacingY;

    void Start()
    {
        currentHealth = startingHealth;
        spacingX = lifeGUI.pixelInset.width;
        spacingY = -lifeGUI.pixelInset.height;

        addLife(startingHealth / healthPerLife);

    }

    public void addLife(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Transform newLife = ((GameObject)Instantiate(lifeGUI.gameObject)).transform;
            newLife.parent = this.transform.parent;

            int x = Mathf.FloorToInt(lifes.Count / maxLifePerColumn);
            int y = lifes.Count - x * maxLifePerColumn;

            newLife.GetComponent<GUITexture>().pixelInset = new Rect(x * spacingX, y * spacingY, 80, 80);

            lifes.Add(newLife);
        }

        maxHealth += n * healthPerLife;

    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, -2, maxHealth);
        //Debug.Log("Health " + currentHealth);
        UpdateLife();
    }
    private void UpdateLife()
    {

        bool restAreEmpty = false;
        int i = 0;

        foreach (Transform life in lifes)
        {
            if (restAreEmpty)
            {
                life.guiTexture.texture = images[0];
            }


            else
            {
                i += 1;
                if (currentHealth >= i * healthPerLife)
                {
                    life.guiTexture.texture = images[images.Length - 1];
                }
				else
				{
					if (restAreEmpty)
					{
						life.guiTexture.texture = images[images.Length-1];
					}

				
                	else
                	{
                    	int currentLifeHealth = (int)(healthPerLife - (healthPerLife * i - currentHealth));
                    	int healthPerImage = healthPerLife / images.Length;
                    	int imageIndex = currentLifeHealth / healthPerImage;

                    	if (imageIndex == 0 && currentLifeHealth > 0)
                    	{
                       		imageIndex = 1;
                    	}

                    	life.guiTexture.texture = images[imageIndex];
                    	restAreEmpty = true;
                	}
				}

            }
        }
    }

}
