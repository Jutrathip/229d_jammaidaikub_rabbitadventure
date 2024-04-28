using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
   
    public Text scoreText;
    public static int scoreCount;

    
 
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    void Update()
    {
        
        scoreText.text = "Score:"+ Mathf.Round(scoreCount);

    }
    public void AddScore(int points)
    {
        scoreCount += points;
    }
}

    
