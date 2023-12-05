using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Player
{
    public class Controller : MonoBehaviour
    {
        public static Action<string> PlayAnimation;
        public static Action<int> Attack;
        public static Action Die;
        public static Action TakedDamage;
        public static Action<int> OnHPChanged;

        private int hp;
        private int maxhp;
        private int damage;

        private void Start()
        {
            GetInput.NewInput += HandleInput;
            GetDamage.TakedDamage += TakeDamage;
            GameController.NewGameStatus += Handle;
            LoadData();
        }

        private void HandleInput(InputDirection dir)
        {
            string newPlayerDir = "";
            switch (dir)
            {
                case InputDirection.left:
                    newPlayerDir = "left";
                    break;
                case InputDirection.right:
                    newPlayerDir = "right";
                    break;
            }
            PlayAnimation?.Invoke(newPlayerDir);

            Attack?.Invoke(damage);
        }

        private void TakeDamage(int damage)
        {
            TakedDamage?.Invoke();
            hp -= damage;
            OnHPChanged?.Invoke(hp);

            if (hp <= 0)
            {
                Die?.Invoke();
            }
        }

        private void LoadData()
        {
            maxhp = Config.Instance.playerHP;
            damage = Config.Instance.playerDamage;

            hp = maxhp;
            OnHPChanged?.Invoke(hp);
        }

        private void Handle(GameStatus status)
        {
            if (status == GameStatus.start)
            {
                hp = maxhp;
                OnHPChanged?.Invoke(hp);
            }
        }

        private void OnDestroy()
        {
            GetInput.NewInput -= HandleInput;
            GetDamage.TakedDamage -= TakeDamage;
            GameController.NewGameStatus -= Handle;
        }
    }
}
