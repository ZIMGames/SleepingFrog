using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Collision : MonoBehaviour
    {
        private int damage;
        private float reloadDur;
        private bool canAttack;

        private void Start()
        {
            canAttack = true;
            damage = Config.Instance.mobDamage;
            reloadDur = GetComponent<Controller>().reloadDur;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") || canAttack)
            {
                var tmp = collision.gameObject.GetComponent<Player.GetDamage>();
                if (tmp != null)
                {
                    tmp.Damage(damage);
                    canAttack = false;
                    Invoke("Reload", reloadDur);
                }
            }
        }

        private void Reload()
        {
            canAttack = true;
        }
    }
}
