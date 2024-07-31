using UnityEngine;
using UnityEngine.UI;

public class In_Game_UI : MonoBehaviour
{
    [SerializeField] private TDS_Player.Animation anime;
    [SerializeField] private Text AmmoCount;
    [SerializeField] private Sprite[] WeaponImage;
    [SerializeField] private Image EquppiedWeaponImage;


    private void Start() => WhenSwitch(anime.Weapon);
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

        AmmoCount.text = ID switch
        {
            <= 1 => "∞",
            2 => AmmoCount.text = anime.GetComponent<Gun>().PistolAmmo.ToString(),
            3=> AmmoCount.text = anime.GetComponent<Gun>().RifleAmmo.ToString(),
            _=>string.Empty
        };      
    }
}
