using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Sean
{

    public enum GameState
    {
        Playing,
        Paused,
        GameOver,
        Scoring
    }
    public class GameManager : PersistenSingleton<GameManager>
    {
        public static Action onGameOver;

        [SerializeField] private GameState gameState = GameState.Playing;
      public static GameState CurrentGameState
        {
            get => Instance.gameState;
            set => Instance.gameState = value;
        }
    }
}