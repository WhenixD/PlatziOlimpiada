using UnityEngine;
using TMPro;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {
    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeGrounded = .1f;
    float accelerationTimeAirborne = .2f;
    public float moveSpeed = 6;

    public float gravity;
    public float maxJumpVelocity;
    public float minJumpVelocity;

    bool jumpRequest;

    Vector3 velocity;

    float velocityXSmoothing;

    Controller2D controller;

    private Animator anim;
    private SpriteRenderer sprite;

    public GameObject cameraAux;


    void Start() {
        controller = GetComponent<Controller2D>();
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpVelocity);

        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        jumpRequest = false;
    }

    void Update() {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        int wallDirX = (controller.collisions.left) ? -1 : 1;

        AnimatePlayer(input, velocity);

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing,
        (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

        if (controller.collisions.above || controller.collisions.below) {
            velocity.y = 0;

            anim.SetBool("jumpRequest", false);
            anim.SetBool("isFalling", false);

            if (jumpRequest) {
                jumpRequest = false;

                if (!controller.collisions.above) {
                }
            }
        } else {
            anim.SetTrigger("hasJumped");
            anim.SetBool("jumpRequest", true);
        }

        if (velocity.y < 0) {
            jumpRequest = true;
            anim.SetBool("isFalling", true);
        }

        if (Input.GetButtonDown("Jump") && (controller.collisions.above || controller.collisions.below)) {
            jumpRequest = true;
            velocity.y = maxJumpVelocity;
        }

        if (Input.GetButtonUp("Jump") && velocity.y > minJumpVelocity) {
            velocity.y = minJumpVelocity;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime, input);
    }

    void OnTriggerEnter2D(Collider2D other) {
        string otherTag = other.tag.ToString();

        switch (otherTag) {
            case "Collectable":
                Destroy(other.gameObject);
                break;

            case "Hazard":
                DestroyPlayer();
                break;

            case "Limit":
                DestroyPlayer();
                break;
        }
    }

    void AnimatePlayer(Vector2 input, Vector3 velocity) {
        if (input.x == 0) {
            anim.SetBool("isRunning", false);
        } else {
            anim.SetBool("isRunning", true);
        }

        if (velocity.x < 0) {
            sprite.flipX = true;
        } else if (velocity.x > 0) {
            sprite.flipX = false;
        }
    }

    void DestroyPlayer() {
        cameraAux.GetComponent<CameraFollow>().enabled = false;
        Destroy(gameObject);
        FindObjectOfType<GameManager>().ResetLevel();
    }
}
