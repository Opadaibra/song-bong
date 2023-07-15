using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed
    public float jumpForce = 5f; // Force applied when jumping
    private bool _isJumping = false; // Flag to track if the player is jumping
    private Rigidbody _rb; // Reference to the player's Rigidbody component
    private Camera _mainCamera; 
    void Start()
    {
        // Get the reference to the Rigidbody component
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
    }

    void Update()
    {
        // Player movement in the forward direction
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = _mainCamera.transform.forward * verticalInput;
        moveDirection.y = 0f; // Ignore vertical movement
        moveDirection.Normalize(); // Normalize the direction vector to avoid faster diagonal movement
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Player jumping
        if (Input.GetButtonDown("Jump") && !_isJumping)
        {
            _rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            _isJumping = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (_rb.detectCollisions)
        {
            _isJumping = false;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fall"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}