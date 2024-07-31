using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace TDS.UI
{
    public class SliderText : MonoBehaviour
    {
        [Header("REFERENCES")]
        [SerializeField] private Slider slider;
        [SerializeField] private TMP_InputField input;

        [Header("EVENT")]
        public UnityEvent<float> OnValue;

        private void Reset()
        {
            slider = GetComponentInChildren<Slider>();
            input = GetComponentInChildren<TMP_InputField>();
        }

        #region INPUT FLIED
        public void FilterText(string text)
        {
            int length = 0, period = 0;
            input.text = new string(text.Where(@char => char.IsDigit(@char) || @char == '_' && ++period == 1 && ++length < 4).ToArray());
        }
        public void UpdateSlider(string text)
        {
            input.text = Mathf.Clamp(slider.value = float.Parse(text), slider.minValue, slider.maxValue).ToString();
        }
        #endregion

        #region Slider
        public void UpdateText(float value)
        {
            input.text = value.ToString(slider.wholeNumbers ? "0" : "0.00");

            OnValue.Invoke(value);
        }
        #endregion

    }
}

