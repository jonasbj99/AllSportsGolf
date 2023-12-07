using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FinishGame : MonoBehaviour
{
    public GameObject gameOverMenu;
    private AudioSource endAudio;
    public AudioClip endSound;

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
    private bool gameHasEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        endAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Ball") && gameHasEnded == false)
        {
            GameOver();
            
            Debug.Log("Game Over");
        }
    }

    private void GameOver()
    {
        EnableGameOverMenu();
        //Time.timeScale = 0f;
        gameHasEnded = true;
        endAudio.PlayOneShot(endSound, 1f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Time.timeScale = 1f;
        gameHasEnded = false;
    }

}
