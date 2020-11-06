using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float acceleration;
    public float turnSpeed;
    bool isBoosting = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        Move();
        ResetPositionIfOOB();
    }

    private void Move() {
        isBoosting = false;
        if(Input.GetKey(KeyCode.LeftShift)){
            Debug.Log("BOOSTING!");
            isBoosting = true;
        }
        //handle turning
        if (Input.GetKey("a")) {
            transform.Rotate(new Vector3(0f, 0f, turnSpeed));
        } else if(Input.GetKey("d")) {
            transform.Rotate(new Vector3(0f, 0f, -1*turnSpeed));
        }
        //handle throttle
        if (Input.GetKey("w")) {
            //TODO if velocity is under some limit
            Vector3 force = transform.up * acceleration;
            if(isBoosting) force = force * 2;
            GetComponent<Rigidbody>().AddForce(force);
        }
    }

    void ResetPositionIfOOB() {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.x < 0) {
            //its off the left of the screen
            //reset it to the right side of the screen
            Vector3 newViewportPosition = new Vector3(1f, viewportPosition.y, viewportPosition.z);
            transform.position = Camera.main.ViewportToWorldPoint(newViewportPosition);
        }
        if (viewportPosition.x > 1) {
            //its off the right of the screen
            //reset it to the left side of the screen
            Vector3 newViewportPosition = new Vector3(0f, viewportPosition.y, viewportPosition.z);
            transform.position = Camera.main.ViewportToWorldPoint(newViewportPosition);
        }
        if (viewportPosition.y > 1) {
            //its off the top of the screen
            //reset it to the bottom side of the screen
            Vector3 newViewportPosition = new Vector3(viewportPosition.x, 0f, viewportPosition.z);
            transform.position = Camera.main.ViewportToWorldPoint(newViewportPosition);
        }
        if (viewportPosition.y < 0) {
            //its off the top of the screen
            //reset it to the bottom side of the screen
            Vector3 newViewportPosition = new Vector3(viewportPosition.x, 1f, viewportPosition.z);
            transform.position = Camera.main.ViewportToWorldPoint(newViewportPosition);
        }
    }
}
