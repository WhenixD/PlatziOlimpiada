using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player") {
            Debug.Log("!");
            SceneManager.LoadScene("Credits");
        }
    }
}
