using UnityEngine;

public class ActivateLight : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        GetComponentInParent<WispController>().enabled = true;
    }
}
