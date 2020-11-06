using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

    private void Start() {

    }

    void FixedUpdate() {
        ResetPositionIfOOB();
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
