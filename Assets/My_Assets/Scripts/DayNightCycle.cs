using System;

using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
      public new Light2D light;

      public enum State
      {
            Day,
            Night
      }

      [Serializable]
      public struct Phase
      {
            public Color Shade;
            public float Intensity;
      }
      public Phase Day, Night, Target;

      [SerializeField] private State _current;
      public State Current
      {
            get => _current;
            set
            {
                  _current = value;

                  switch (_current)
                  {
                        case State.Day:
                              Target.Shade = Night.Shade;
                              Target.Intensity = 0.5F;
                              SetShadowEnable(true);
                              break;

                        case State.Night:
                              Target.Shade = Day.Shade;
                              Target.Intensity = 1F;
                              SetShadowEnable(false);
                              break;
                  }

                  void SetShadowEnable(bool value) => Array.ForEach(shadowCasters, shadow => shadow.castsShadows = value);
            }
      }

      [SerializeField] private float elapsed;

      public float Duration;


      public ShadowCaster2D[] shadowCasters;


      private void Awake()
      {
            shadowCasters = FindObjectsOfType<ShadowCaster2D>(true);
      }
      private void Start()
      {
            Current = State.Day;
      }
      public void Update()
      {
            elapsed += Time.deltaTime / Duration;
            if (elapsed >= 1F)
            {
                  switch (Current)
                  {
                        case State.Day:
                              Current = State.Night;
                              break;

                        case State.Night:
                              Current = State.Day;
                              break;
                  }

                  elapsed = 0F;
            }
            light.color = Color.Lerp(light.color, Target.Shade, elapsed);
            light.intensity = Mathf.Lerp(light.intensity, Target.Intensity, elapsed);
      }
}