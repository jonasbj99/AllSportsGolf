using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunBehavior : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPosition;

    public float bulletSpeed = 10;

    void Start()
    {
        XRGrabInteractable gunGrabable = GetComponent<XRGrabInteractable>();
        gunGrabable.activated.AddListener(Shoot);
    }
    public void Shoot(ActivateEventArgs actiEvent)
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = spawnPosition.position;
        newBullet.GetComponent<Rigidbody>().velocity = spawnPosition.forward * bulletSpeed;

        Destroy(newBullet, 10);
    }
}
