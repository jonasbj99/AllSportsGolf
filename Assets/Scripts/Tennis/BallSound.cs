using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    public AudioSource ballHit;
    public AudioClip ballSound;
    // Start is called before the first frame update
    void Start()
    {
        ballHit = GetComponent<AudioSource>();
        ballHit.clip = ballSound;
    }

    // Update is called once per frame
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
