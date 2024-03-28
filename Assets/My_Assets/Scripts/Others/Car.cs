using System.Collections;
using TDS_Player;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Car : MonoBehaviour
{
    //References
    private float RotationSpeed = 90f;
    private float maxFuel = 100f;
    private Rigidbody2D rb;
    private float currentFuel;
    private float delay = 0.5f;
    [SerializeField] private int CarSpeed;
    [SerializeField] private BoxCollider2D box;
    public Transform exitPoint; // A transform representing where the character should exit to.
    public float exitDistanceThreshold = 1f;

    [SerializeField] private GameObject player;
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            ExitCar();
        }
        if (currentFuel > 0f)
        {
            MoveCar(verticalInput);
            RotateCar(horizontalInput);
        }
        else ApplyBrakingForce();
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
    void ExitCar()
    {        GameObject player = transform.Find("Player").gameObject;
       
        player.transform.position = exitPoint.position;
    }

}