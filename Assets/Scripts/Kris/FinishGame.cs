using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;

public class FinishGame : MonoBehaviour
{
    public XRRayInteractor rayInteractor;

    public GameObject gameOverMenu;
    public GameObject toolMenu;
    public GameObject controlMenu;

    private AudioSource endAudio;
    public AudioClip endSound;
    public AudioClip putt;
    private bool gameHasEnded = false;

    public void EnableGameOverMenu()
    {
        toolMenu.SetActive(false);
        controlMenu.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    void Start()
    {
        endAudio = GetComponent<AudioSource>();
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
        endAudio.PlayOneShot(putt, 1f);
        endAudio.PlayOneShot(endSound, 0.7f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Time.timeScale = 1f;
        gameHasEnded = false;
    }

}
