using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Zombai : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private Animator anime;
    private float distance;

    private void Awake()
    {
        anime = GetComponent<Animator>(); 
    }
    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        
    }
}
