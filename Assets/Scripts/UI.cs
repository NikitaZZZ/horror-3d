using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Slider staminaSlider = default;

    private void OnEnable()
    {
        PlayerMovement.OnStaminaChange += UpdateStamina;
    }
    
    private void OnDisable()
    {
        PlayerMovement.OnStaminaChange -= UpdateStamina;
    }

    private void UpdateStamina(float currentStamina)
    {
        if (currentStamina == 100)
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        else
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;

        staminaSlider.value = currentStamina;
    }
}
