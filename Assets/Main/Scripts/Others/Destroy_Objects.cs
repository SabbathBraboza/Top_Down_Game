using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Objects : MonoBehaviour
{
 public void DestroyEnemy(float delay) => Destroy(gameObject, delay); 
}
