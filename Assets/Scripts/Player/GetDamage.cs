using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Player
{
    public class GetDamage : MonoBehaviour
    {
        public static Action<int> TakedDamage;
        public void Damage(int value)
        {
            TakedDamage?.Invoke(value);
        }
    }
}
