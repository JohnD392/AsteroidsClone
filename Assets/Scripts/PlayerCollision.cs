using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Asteroid") {
            //die
            Destroy(gameObject);
        }
    }
}
