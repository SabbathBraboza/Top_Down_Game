using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private readonly float RotationSpeed = 90f;
    private readonly float maxFuel = 100f;

    private Rigidbody2D rb;
    private float currentFuel;
    private bool IsPlayerInside = false;
    [SerializeField] private int TankSpeed;
     public float interactionRadius = 9f;
    [SerializeField] private Transform PlayerExitPoint;
    [SerializeField] private GameObject player;

    [SerializeField] private Transform FirePoint;
    [SerializeField] private GameObject bulletperfabs;
    [SerializeField] private float bulletSpeed;

    [SerializeField] private GameObject TankCamera;
    [SerializeField] private GameObject PlayerLigth;
   public Movements Movements { get; private set; }

  
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 1f;
        currentFuel = maxFuel;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (IsPlayerInside)
                Exit();
            else
            {
                TryEnterTank();
                enabled = true;
            }
        }
        if (IsPlayerInside)
        {
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");
            if (currentFuel > 0f)
            {
                MoveTank(verticalInput);
                RotateTank(horizontalInput);
            }
            else ApplyBrakingForce();

            if (Input.GetKeyDown(KeyCode.Mouse0)) StartCoroutine(Shootbullet());
        }
    }


    private void TryEnterTank()
    {
        Collider2D[] col = Physics2D.OverlapAreaAll(transform.position, Vector2.left);
        foreach (Collider2D col2 in col)
        {
            if(col2.CompareTag("Player"))
            {
                EnterTank();
                break;
            }
        }
    }

    private void EnterTank()
    {
        IsPlayerInside = true;

        Movements = player.GetComponent<Movements>();
        if (Movements != null) Movements.DriveTank(transform);

        player.transform.position = transform.position;
        player.transform.parent = transform;

        if(player.TryGetComponent<Renderer>(out var PlayeRenderer)) PlayeRenderer.enabled = false;

        if(player.TryGetComponent<Collider2D>(out var Playercollider)) Playercollider.enabled = false;

        if (TankCamera != null) TankCamera.SetActive(true);
        if (PlayerLigth != null) PlayerLigth.SetActive(false);
    }

    private void Exit()
    {
        Movements = player.GetComponent<Movements>();
        if (Movements != null) Movements.ExitTank();

        player.transform.position = PlayerExitPoint.position;
        player.transform.parent = null;

        if (player.TryGetComponent<Renderer>(out var playerRenderer)) playerRenderer.enabled = true;

        if (player.TryGetComponent<Collider2D>(out var playerCollider)) playerCollider.enabled = true;

        if (TankCamera != null)TankCamera.SetActive(false);
        if (PlayerLigth != null) PlayerLigth.SetActive(true);
        enabled = false;
    }
    private void MoveTank(float verticalInput)
    {
        Vector2 TankForward = transform.right;
        Vector2 force = TankSpeed * verticalInput * TankForward;
        rb.AddForce(force);
    }

    private void RotateTank(float horizontalInput)
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

    private IEnumerator Shootbullet()
    {
        var bullet = Instantiate(bulletperfabs, FirePoint.position, FirePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = FirePoint.right * bulletSpeed;
        yield return new WaitForSeconds(0.5f);
        Destroy(bullet, 0.04f);
    }

}
