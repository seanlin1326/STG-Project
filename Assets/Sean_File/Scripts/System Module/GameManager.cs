using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{

    public enum GameState
    {
        Playing,
        Paused,
        GameOver,
    }
    public class GameManager : PersistenSingleton<GameManager>
    {
        [SerializeField] private GameState gameState = GameState.Playing;
      public static GameState CurrentGameState
        {
            get => Instance.gameState;
            set => Instance.gameState = value;
        }
    }
}