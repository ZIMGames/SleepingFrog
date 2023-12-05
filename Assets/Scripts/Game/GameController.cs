using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    public static Action<GameStatus> NewGameStatus;
    public static Action<int> NewPointsValue;

    private GameStatus status;

    private int points;

    private void Start()
    {
        GetUIInput.NewRound += StartNewRound;
        Player.Controller.Die += EndRound;
        Enemy.Controller.OnEnemyDie += AddPoint;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartNewRound();
        }
    }

    private void StartNewRound()
    {
        points = 0;
        NewPointsValue?.Invoke(points);
        status = GameStatus.start;
        NewGameStatus?.Invoke(GameStatus.start);
    }

    private void EndRound()
    {
        status = GameStatus.end;
        NewGameStatus?.Invoke(GameStatus.end);
    }

    private void AddPoint()
    {
        if (status != GameStatus.end)
        {
            points++;
            NewPointsValue?.Invoke(points);
        }
    }

    private void OnDestroy()
    {
        GetUIInput.NewRound -= StartNewRound;
        Player.Controller.Die -= EndRound;
        Enemy.Controller.OnEnemyDie -= AddPoint;
    }
}

[Serializable]

public enum GameStatus { start = 0, end}
