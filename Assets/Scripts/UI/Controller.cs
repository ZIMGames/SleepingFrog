using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace UI
{
    public class Controller : MonoBehaviour
    {
        public static Action<string> PlayAnim;

        [SerializeField] private Text gamePoints;
        [SerializeField] private Text menuPoints;
        [SerializeField] private Image playerHPFill;
        private int maxhp;

        private void Start()
        {
            GameController.NewGameStatus += HandleNewGameStatus;
            GameController.NewPointsValue += UpdateCounter;
            Player.Controller.OnHPChanged += UpdateHPFill;
            maxhp = Config.Instance.playerHP;
        }

        private void HandleNewGameStatus(GameStatus status)
        {
            string triggerName = "";
            switch (status)
            {
                case GameStatus.start:
                    Debug.Log("trigger start");
                    triggerName = "game";
                    break;
                case GameStatus.end:
                    triggerName = "menu";
                    break;
            }

            PlayAnim?.Invoke(triggerName);
        }

        private void UpdateCounter(int val)
        {
            gamePoints.text = val.ToString();
            menuPoints.text = val.ToString();
        }

        private void UpdateHPFill(int newVal)
        {
            playerHPFill.fillAmount = (float)newVal / (float)maxhp;
        }

        private void OnDestroy()
        {
            GameController.NewGameStatus -= HandleNewGameStatus;
            GameController.NewPointsValue -= UpdateCounter;
            Player.Controller.OnHPChanged -= UpdateHPFill;
        }
    }
}
