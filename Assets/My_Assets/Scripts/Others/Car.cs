using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Car : MonoBehaviour
{
    //References
    private float RotationSpeed = 90f;
    private float maxFuel = 100f;
    private Rigidbody2D rb;
    private float currentFuel;
    [SerializeField] private int CarSpeed;
    [SerializeField] private BoxCollider2D box;

    [SerializeField] private GameObject[] headLight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 1f;
        currentFuel = maxFuel;
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (currentFuel > 0f)
        {
            MoveCar(verticalInput);
            RotateCar(horizontalInput);
        }
        else
            ApplyBrakingForce();
    }

    private void MoveCar(float verticalInput)
    {
        Vector2 carForward = transform.right;
        Vector2 force = CarSpeed * verticalInput * carForward;
        rb.AddForce(force);
    }

    private void RotateCar(float horizontalInput)
    {
        float rotation = -horizontalInput * RotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotation);
    }
    private void ApplyBrakingForce()
    {
        Vector2 oppositeForce = -rb.velocity * 0.5f;
        rb.AddForce(oppositeForce);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            Destroy(collision.gameObject);
        }
    }
}