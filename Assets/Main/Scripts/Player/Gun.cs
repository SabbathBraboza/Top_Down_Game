using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
     public ushort PistolAmmo, RifleAmmo;

      [Header("References:")]
      [SerializeField] private Bullet bullet;
      [SerializeField] private Transform nozzle;

      [Header("GameObject:")]
      [SerializeField] private List<Bullet> bullets;

    private readonly WaitForSeconds bulletShootInterval = new(0.1f);

      private void Start()
      {
            for (int i = 0; i < 5; i++)
            {
                  bullets.Add(Instantiate(bullet, nozzle.position, Quaternion.identity));
            }
      }
      public void Shoot(int ID)
      {
            switch (ID)
            {
                  case 0: // Pistol
                        {
                            ShootInactiveBullet();
                        }
                        break;

                  case 1: // Rifle
                        {
                    for (byte i = 0; i < 3; i++)
                    {
                        StartCoroutine(ShootRifle());
                    }
                        }
                        break;
            }
      }
    private IEnumerator ShootRifle()
    {
        for (byte i = 0; i < 3; i++)
        {
            ShootInactiveBullet();
            if (i == 2) break;
            yield return bulletShootInterval;
            yield break;
        }
    }

    private void ShootInactiveBullet()
    {
        foreach (var bullet in bullets)
        {
            if (bullet.gameObject.activeSelf) continue;
            bullet.transform.position = nozzle.position;
            bullet.gameObject.SetActive(true);
            bullet.Fire(-nozzle.up, 10f);
            break;
        }
    }

}
