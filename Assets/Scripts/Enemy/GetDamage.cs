using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class GetDamage : MonoBehaviour
    {
        public void TakeDamage(int damage)
        {
            GetComponent<Controller>().TakeDamage(damage);
        }
    }
}
