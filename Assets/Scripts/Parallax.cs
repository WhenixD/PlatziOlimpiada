using UnityEngine;

public class Parallax : MonoBehaviour {
    public Transform cam;
    public float relativeMove;
    public bool lockY = true;

    void Update() {
        transform.position = new Vector2(cam.position.x * relativeMove, transform.position.y);
    }

}
