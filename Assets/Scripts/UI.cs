using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Slider staminaSlider = default;

    private void OnEnable()
    {
        pmn.OnStaminaChange += UpdateStamina;
    }

    private void OnDisable()
    {
        pmn.OnStaminaChange -= UpdateStamina;
    }

    private void UpdateStamina(float currentStamina)
    {
        staminaSlider.value = currentStamina;
    }
}
