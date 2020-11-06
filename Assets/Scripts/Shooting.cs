using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject pew;
    public GameObject rocket;
    public Vector3 firingOffset;
    public float bulletSpeed;
    public float rocketSpeed;
    public float timeBetweenShots;
    public float timeBetweenRockets;
    private float lastShotTime = 0f;
    private float lastRocketTime = 0f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Fire1")) {
            if (Time.time - lastShotTime > timeBetweenShots) {
                Shoot();
                lastShotTime = Time.time;
            }
        }
        if (Input.GetKey(KeyCode.R)) {
            if (Time.time - lastRocketTime > timeBetweenRockets) {
                FireRocket();
                lastRocketTime = Time.time;
            }
        }
    }

    private void FireRocket() {
        GameObject b = Instantiate(rocket, transform.position + transform.up * firingOffset.magnitude, transform.rotation, null);
        b.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity + transform.up * rocketSpeed;

    }

    public void Shoot() {
        GameObject b = Instantiate(bullet, transform.position + transform.up * firingOffset.magnitude, Quaternion.identity, null);
        Instantiate(pew);
        b.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity + transform.up * bulletSpeed;

    }
}
