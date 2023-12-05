using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetInput : MonoBehaviour
{
    public static Action<InputDirection> NewInput;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            NewInput?.Invoke(InputDirection.left);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            NewInput?.Invoke(InputDirection.right);
        }
    }
}
[Serializable]

public enum InputDirection { left = 0, right}
