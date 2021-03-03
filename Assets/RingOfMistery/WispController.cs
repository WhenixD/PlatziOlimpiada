using UnityEngine;

public class WispController : MonoBehaviour {
    Vector3 mousePosition;
    public float velocity;

    void Update() {
        mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
        transform.position = Vector3.Lerp(transform.position, mousePosition, velocity * Time.deltaTime);
    }
}
