using UnityEngine;

public class Gun : MonoBehaviour
{

    public ushort PistolAmmo, RifleAmmo;
    private Input_Manager Keys;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform Nozzel;

    public void Shoot(int ID)
    {
        switch(ID)
        {
            case 0: // Pistol
                {
                    var InstantiateBullet = Instantiate(Bullet, Nozzel.position, Quaternion.identity);
                    

                }
                break;

            case 1: // Rifle
                {

                }break;
        }
    }
    
}
