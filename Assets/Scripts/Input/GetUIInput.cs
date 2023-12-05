using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetUIInput : MonoBehaviour
{
    public static Action NewRound;

    public void Restart()
    {
        NewRound?.Invoke();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
