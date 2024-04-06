using UnityEngine;

public class Police_Tank : MonoBehaviour
{
    private readonly float RotationSpeed = 90f;
    private readonly float maxFuel = 100f;

    private Rigidbody2D rb;
    private float currentFuel;
    private bool IsPlayerInside = false;
    [SerializeField] private int PoliceTankSpeed;
    public float interactionRadius = 9f;
    
    [SerializeField] private Transform PlayerExitPoint;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject PoliceTankCamera;
    [SerializeField] private GameObject PlayerLigth;
    [SerializeField]
    private GameObject headLight1, HeadLigth2;

    public Movements Movements { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 1f;
        currentFuel = maxFuel;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (IsPlayerInside)
                Exit();
            else
            {
                TryEnterPoliceTank();
                enabled = true;
            }
        }
        if (IsPlayerInside)
        {
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");
            if (currentFuel > 0f)
            {
                MovePoliceTank(verticalInput);
                RotatePoliceTank(horizontalInput);
            }
            else ApplyBrakingForce();
        }
    }
    private void TryEnterPoliceTank()
    {
        Collider2D[] col = Physics2D.OverlapAreaAll(transform.position, Vector2.left);
        foreach (Collider2D col2 in col)
        {
            if (col2.CompareTag("Player"))
            {
                EnterPoliceTank();
                break;
            }
        }
    }
    private void EnterPoliceTank()
    {
        IsPlayerInside = true;

        Movements = player.GetComponent<Movements>();
        if (Movements != null) Movements.DriveTank(transform);

        player.transform.position = transform.position;
        player.transform.parent = transform;

        if (player.TryGetComponent<Renderer>(out var PlayeRenderer)) PlayeRenderer.enabled = false;

        if (player.TryGetComponent<Collider2D>(out var Playercollider)) Playercollider.enabled = false;

        if (PoliceTankCamera != null) PoliceTankCamera.SetActive(true);
        if (PlayerLigth != null) PlayerLigth.SetActive(false);
        if (headLight1 != null && HeadLigth2 != null)
        {
            headLight1.SetActive(true);
            HeadLigth2.SetActive(true);
        }
    }
    private void Exit()
    {
        Movements = player.GetComponent<Movements>();
        if (Movements != null) Movements.ExitTank();

        player.transform.position = PlayerExitPoint.position;
        player.transform.parent = null;

        if (player.TryGetComponent<Renderer>(out var playerRenderer)) playerRenderer.enabled = true;

        if (player.TryGetComponent<Collider2D>(out var playerCollider)) playerCollider.enabled = true;

        if (PoliceTankCamera != null) PoliceTankCamera.SetActive(false);
        if (PlayerLigth != null) PlayerLigth.SetActive(true);
        if (headLight1 != null && HeadLigth2 != null)
        {
            headLight1.SetActive(false);
            HeadLigth2.SetActive(false);
        }
        enabled = false;
    }
    private void MovePoliceTank(float verticalInput)
    {
        Vector2 TankForward = transform.right;
        Vector2 force = PoliceTankSpeed * verticalInput * TankForward;
        rb.AddForce(force);
    }
    private void RotatePoliceTank(float horizontalInput)
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
