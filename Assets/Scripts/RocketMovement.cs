using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour {
    public float rocketAcceleration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        //destroy if out of bounds
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1) {
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        GetComponent<Rigidbody>().AddForce(transform.up * rocketAcceleration);
    }
}
