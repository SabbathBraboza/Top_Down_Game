using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.Rendering.Universal;
using static UnityEngine.Random;

public class Lighting : MonoBehaviour
{
    private enum Type { Flickering, Shifting }

    public bool IsFixed;

    [SerializeField] private new Light2D light;
    [SerializeField] private Type type;


    private float elapsed, next;

    [SerializeField] private float minNextTime = 0.5F, maxNextTime = 3F;


    private void Reset()
    {
        if (!light) light = GetComponent<Light2D>();
    }
    private void OnEnable()
    {
        if (IsFixed) enabled = false;
    }
    private void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > next)
        {
            switch (type)
            {
                case Type.Flickering:
                    {
                        light.enabled = !light.enabled;
                    }
                    break;

                case Type.Shifting:
                    {
                        light.color = Color.HSVToRGB(value, Range(0.2F, 0.7F), Range(0.25F, 0.7F));
                    }
                    break;
            }

            next = Range(minNextTime, maxNextTime);
            elapsed = 0F;
        }
    }
}
