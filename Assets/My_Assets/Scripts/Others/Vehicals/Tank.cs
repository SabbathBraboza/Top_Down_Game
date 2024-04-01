using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private readonly float RotationSpeed = 90f;
    private readonly float maxFuel = 100f;

    private Rigidbody2D rb;
    private Collider2D col;
    private float currentFuel;
    private bool IsPlayerInside = false;
    [SerializeField] private int CarSpeed;
    [SerializeField] private BoxCollider2D box;
    [SerializeField] public float interactionRadius = 2f;
    [SerializeField] private Transform PlayerExitPoint;
    [SerializeField] private GameObject player;
    public Movements Movements { get; private set; }
    [SerializeField]private GameObject PlayerLigth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        rb.drag = 1f;
        currentFuel = maxFuel;
    }


}
