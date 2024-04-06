using TDS_Player;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }
    [SerializeField] private float playerAwarenessDistance;
    [SerializeField] private Transform player;

    [System.Obsolete]
    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<Controller>()?.transform;
            if (player == null) Debug.LogError("Player reference not found!");
        }
    }
    private void Update()
    {
        if (player == null)
            return;
        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        AwareOfPlayer = enemyToPlayerVector.sqrMagnitude < playerAwarenessDistance * playerAwarenessDistance;
    }

}
