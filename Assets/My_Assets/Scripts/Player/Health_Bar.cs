using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    [SerializeField] private Slider Slider;
    [SerializeField] private Camera Camera;
    [SerializeField] private Transform Target;
    [SerializeField] private Vector3 Offsets;

    private void Update()
    {
        transform.rotation = Camera.transform.rotation;
        transform.position = Target.position + Offsets;
    }

}
