using System.Collections;
using System.Collections.Generic;
using UnityEngine;

{
    [System.Serializable]

    public class ValueSystem
    {
        private int _value;
        private int _valueMax;

        public void Setup(int value)
        {
            _value = _valueMax = value;
        }
    }
}
