using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public ushort PistolAmmo, RifleAmmo;
   
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform nozzle;

   [SerializeField] private List<Bullet> bullets;


    private void Start()
    {
        for(int i=0; i< 10; i++)
        {
            //bullets.Add(Instantiate(bullet, nozzle.position, Quaternion.identity));
        }
    }
    public void Shoot(int ID)
    {
        switch(ID)
        {
            case 0: // Pistol
                {
                    foreach(var bullet in bullets)
                    {
                        //if (bullet.gameObject.activeSelf) continue;
                        //bullet.transform.position = Nozzle.position;
                        //bullet.gameObject.SetActive(true);
                        //bullet.Fire(-Nozzle.up, 100f);
                        //break;
                    }
                }
                break;

            case 1: // Rifle
                {

                }break;
        }
    }
    
}
