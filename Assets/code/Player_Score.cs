using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour
{
    
    public int playerScore = 0;
    
    public GameObject playerScoreUI;

    // Update is called once per frame
    void Update()
    {
        
        
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);


        
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        
        if (trig.gameObject.name == "Coin")
        {
            playerScore += 10;
            Destroy(trig.gameObject);
        }


    }

    
}
