using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    private bool gameHasEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("GolfBall") && gameHasEnded == false)
        {
            GameOver();
            
            Debug.Log("Game Over");
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        gameHasEnded = true;
    }

}
