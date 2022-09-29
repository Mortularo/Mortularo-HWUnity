using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWounds : MonoBehaviour
{
    public float _wounds = 50f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            _wounds -= 30;
        }
        if (_wounds <= 0)
        {
            _wounds = 0;
        }
    }
    void OnGUI()
    {
        GUI.TextArea(new Rect(Screen.width - 80, Screen.height - 20, 80, 20), "Health: " + _wounds);
    }
}

