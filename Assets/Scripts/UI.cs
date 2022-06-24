using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI staminaText = default;

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
        staminaText.text = currentStamina.ToString("00");
    }
}
