using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueBar : MonoBehaviour
{
    [SerializeField] private Transform _lineBar;

    public void SetValue(float value)
    {
        if (value < 0) value = 0f;
        if (value > 1) value = 1;
        _lineBar.localScale = new Vector2(value, 1f);
    }

}
