using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody rb;
    private Vector3 movement;
    private float currentVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Get the movement input from the player
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
    void FixedUpdate()
    {
        // Move the player
        if (movement != Vector3.zero)
        {
            rb.MovePosition((Vector3)transform.position + movement * speed * Time.deltaTime);
            // Rotate the player to the direction of movement
            float angle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            // Smoothly rotate the player
            float smooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref currentVelocity, 0.1f);
            // Apply the rotation
            transform.rotation = Quaternion.Euler(0, smooth, 0);
        }
    }