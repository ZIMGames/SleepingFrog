using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Waves
{
    public class Controller : MonoBehaviour
    {
        public static Action<bool> SpawnMobs;

        private void Start()
        {
            GameController.NewGameStatus += HandleNewStatus;
        }

        private void HandleNewStatus(GameStatus status)
        {
            switch (status)
            {
                case GameStatus.start:
                    SpawnMobs?.Invoke(true);
                    break;
                case GameStatus.end:
                    SpawnMobs?.Invoke(false);
                    break;
            }
        }

        private void OnDestroy()
        {
            GameController.NewGameStatus -= HandleNewStatus;
        }
    }
}
