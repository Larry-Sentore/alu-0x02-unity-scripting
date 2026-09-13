using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;

    private int score = 0;
    private Rigidbody playerRigidbody;
    private Vector3 movementInput;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementInput = new Vector3(horizontalInput, 0f, verticalInput);
        movementInput = Vector3.ClampMagnitude(movementInput, 1f);
    }

    private void FixedUpdate()
    {
        playerRigidbody.AddForce(movementInput * movementSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Pickup"))
        {
            return;
        }

        score++;
        Debug.Log($"Score: {score}");
        Destroy(other.gameObject);
    }
}
