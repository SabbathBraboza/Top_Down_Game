using UnityEngine;
using UnityEngine.Events;

public class Car : MonoBehaviour
{
    //References
    private readonly float RotationSpeed = 90f;

    private Rigidbody2D rb;
    private float currentFuel;
    private bool IsPlayerInside = false;

    [Header("Values:")]
    [SerializeField] private int CarSpeed;
    [SerializeField] private float interactionRadius;

    [Header("GameObject:")]
    [SerializeField] private Transform PlayerExitPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject headLight1, HeadLigth2, PlayerLigth;
    [SerializeField] private GameObject CarCamera;

      [Header("Unity Events:")]
      public UnityEvent OnEnter;
      public UnityEvent OnExit;
 
    public Movements Movements { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsPlayerInside)
                ExitCar();
            else 
              TryEnterCar();
        }

        if (IsPlayerInside)
        {
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");
            if (currentFuel > 0f)
            {
                MoveCar(verticalInput);
                RotateCar(horizontalInput);
            }
            else ApplyBrakingForce();
        }
    }

    private void TryEnterCar()
    {
        Collider2D[] colliders = Physics2D.OverlapAreaAll(transform.position, Vector2.left);
        foreach(Collider2D collider in colliders)
        {
            if(collider.CompareTag("Player"))
            {
                EnterCar();
                break;
            }
        }
    }
    private void EnterCar()
    {
        IsPlayerInside = true;
       
        Movements = player.GetComponent<Movements>();
        if (Movements != null) Movements.DriveCar(transform);
        
        player.transform.position = transform.position;
        player.transform.parent = transform;

        if (player.TryGetComponent<Renderer>(out var playerRenderer)) playerRenderer.enabled = false;

        if (player.TryGetComponent<Collider2D>(out var playerCollider)) playerCollider.enabled = false;

        if (headLight1 != null && HeadLigth2 !=null)
        {
            headLight1.SetActive(true);
            HeadLigth2.SetActive(true);
        }
         if(PlayerLigth != null) PlayerLigth.SetActive(false);
         if(CarCamera != null) CarCamera.SetActive(true);

            OnEnter.Invoke();
    }

    void ExitCar()
    {
        Movements  = player.GetComponent<Movements>();
        if (Movements != null) Movements.ExitCar();
        
        player.transform.position = PlayerExitPoint.position;
        player.transform.parent = null;

        if (player.TryGetComponent<Renderer>(out var playerRenderer))  playerRenderer.enabled = true;
        
        if (player.TryGetComponent<Collider2D>(out var playerCollider))  playerCollider.enabled = true;

        if (headLight1 != null && HeadLigth2 != null)
        {
            headLight1.SetActive(false);
            HeadLigth2.SetActive(false);
        }
        if (PlayerLigth != null) PlayerLigth.SetActive(true);
        if (CarCamera != null) CarCamera.SetActive(false);
        enabled = false;

            OnExit.Invoke();
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
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}