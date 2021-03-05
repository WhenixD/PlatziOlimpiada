using UnityEngine;

public class ActivateLight : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player") {
            GetComponent<ActivateLight>().enabled = true;
        }

    }
}
