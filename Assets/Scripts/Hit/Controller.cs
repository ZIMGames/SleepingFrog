using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hit
{
    public class Controller : MonoBehaviour
    {
        private float lifeTime = 0.16f;
        public int damage;

        private void Start()
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(-30, 31));
            Invoke("Die", lifeTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Enemy.GetDamage>().TakeDamage(damage);
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
