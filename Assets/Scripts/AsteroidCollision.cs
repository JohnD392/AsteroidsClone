using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour {

    public GameObject asteroidPrefab;
    public float speedModifier;
    bool isColliding = false;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name.Contains("Bullet")) {
            if (!isColliding) {
                isColliding = true;
                Destroy(other.gameObject);
                SpawnChildren();
                Destroy(gameObject);
            }
        }
        if(other.gameObject.name.Contains("Rocket")) {
            if(!isColliding) {
                isColliding = true;
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }

    private void SpawnChildren() {
        float xScale = gameObject.transform.localScale.x;
        if(xScale > 2f) {
            GameObject a1 = Instantiate(asteroidPrefab, transform.position, Quaternion.identity, null);
            GameObject a2 = Instantiate(asteroidPrefab, transform.position, Quaternion.identity, null);
            a1.transform.localScale = new Vector3(xScale / 2, xScale / 2, xScale / 2);
            a2.transform.localScale = a1.transform.localScale;
            float speed = GetComponent<Rigidbody>().velocity.magnitude;
            Vector3 a1Velocity = Random.insideUnitSphere * speed * speedModifier;
            a1Velocity.z = 0f;
            Vector3 a2Velocity = Random.insideUnitSphere * speed * speedModifier;
            a2Velocity.z = 0f;
            a1.GetComponent<Rigidbody>().velocity = a1Velocity;
            a2.GetComponent<Rigidbody>().velocity = a2Velocity; 
            a1.GetComponent<AsteroidMovement>().enabled = true; //for some reason this doesnt start enabled :(
            a2.GetComponent<AsteroidMovement>().enabled = true;
        }
    }
}
