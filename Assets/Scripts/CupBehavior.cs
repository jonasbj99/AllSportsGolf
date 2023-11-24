using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupBehavior : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    AudioClip splash;

    private void Start()
    {
        splash = this.gameObject.GetComponent<AudioSource>().clip;
    }

    void OnColliderEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Ball")
        {
            CupGameBehavior.cupScore += 1f;
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(splash);
            Destroy(parentObject, 2f);
        }
    }
}
