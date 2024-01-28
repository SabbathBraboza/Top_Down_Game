using UnityEngine;
using UnityEngine.UI;

public class In_Game_UI : MonoBehaviour
{
    [SerializeField] private TDS_Player.Animation anime;
    [SerializeField] private Text AmmoCount;
    [SerializeField] private Sprite[] WeaponImage;
    [SerializeField] private Image EquppiedWeaponImage;


    private void Start() => EquppiedWeaponImage.sprite = WeaponImage[anime.Weapon];
    private void OnEnable()
    {
        anime.OnSwitch += WhenSwitch;
    }

    private void OnDisable()
    {
        anime.OnSwitch += WhenSwitch;
    }

    private void WhenSwitch(int ID)
    {
        EquppiedWeaponImage.sprite = WeaponImage[ID];

        switch(ID)
        {
            case <= 1:
                {
                    AmmoCount.text = "∞";
                }break;

               
        }
    }
}
