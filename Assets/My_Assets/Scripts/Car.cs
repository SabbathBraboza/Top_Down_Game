using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float AccelerationPower = 30f;
     private float StreeingPower = 5f;
    [SerializeField] private float StreeingAmount, Speed= 100f, direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        StreeingAmount = Input.GetAxis("Horizontal");
        Speed = Input.GetAxis("Vertical") * AccelerationPower;
        direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rb.rotation += StreeingAmount * StreeingPower * rb.velocity.magnitude * direction;

        rb.AddRelativeForce(Vector2.up * Speed);
        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * StreeingAmount / 2);
    }
}
