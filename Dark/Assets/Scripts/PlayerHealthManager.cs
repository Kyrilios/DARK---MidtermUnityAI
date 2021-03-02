using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public int startingHealth;
    private int currentHealth;

    public float flashLength;
    private float flashCounter;

    private Renderer rend;


    private Color storedColor;

    public Text LifeText;

    public Timer timerSc;
   
    void Start()
    {
       timerSc =  GameObject.FindGameObjectWithTag("Canvas").GetComponent<Timer>();
        currentHealth = startingHealth;
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
    }

 
    void Update()
    {
        if(currentHealth<=0)
        {
            gameObject.SetActive(false);
    
          EndScene.finalTimeToString = "Time Survived: " + timerSc.totalTime.ToString();
       
            SceneManager.LoadScene("End");
           
            // StartCoroutine(Death());

        }        
        if(flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if(flashCounter <=0 )
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }
    }
    public void HurtPlayer(int damageAmount)
    {
        currentHealth -=  damageAmount;

        LifeText.text = "Life: " + currentHealth.ToString();
        Debug.Log(currentHealth);
        
        flashCounter = flashLength;

        rend.material.SetColor("_Color", Color.white);
    }

    IEnumerator Death()
    {
        gameObject.SetActive(false);
        Debug.Log("DED");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("End");
    }
}
