using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
   public GameObject scoreText;
   public int theScore;

    void OnTriggerEnter(Collider other)
    {
        theScore += 1;
        scoreText.GetComponent<Text>().text = "SCORE: " + theScore;
    }



}
