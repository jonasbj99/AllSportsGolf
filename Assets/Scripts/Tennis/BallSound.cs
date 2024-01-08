using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    public AudioSource ballHit;
    public AudioClip ballSound;

    void Start()
    {
        ballHit = GetComponent<AudioSource>();
        ballHit.clip = ballSound;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Bat"))
        {
            ballHit.Play();
        }
    }
}
