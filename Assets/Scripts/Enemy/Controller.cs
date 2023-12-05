using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Enemy
{
    public class Controller : MonoBehaviour
    {
        public static Action OnEnemyDie;
        public float speed;
        public int damage;
        public int hp;
        public float reloadDur;

        public bool isFast;

        private void Start()
        {
            LoadData();
        }

        public void TakeDamage(int damage)
        {
            hp -= damage;
            GetComponent<Animations>().TakeDamage();
            if (hp <= 0)
            {
                OnEnemyDie?.Invoke();
                Destroy(gameObject);
            }
        }

        private void LoadData()
        {
            damage = Config.Instance.mobDamage;
            hp = Config.Instance.mobHP;
            reloadDur = Config.Instance.mobReloadDur;
            if (isFast)
            {
                speed = Config.Instance.mobSpeed;
            }
            else
            {
                speed = Config.Instance.fastMobSpeed;
            }
        }

    }
}
