using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum GameState
{
    Menu,
    Pause,
    GameOver,
    Finish
}

public class GameManager : Singleton<GameManager>
{

    private CanvasManager canvasManager;

    private bool isPlay;
    public bool IsPlay { get { return isPlay; } set { isPlay = value; } }


    private GameState gameState = GameState.Menu;
    public GameState GetGameState { get { return gameState; } set { gameState = value; } }


    private void Start()
    {
        canvasManager = FindObjectOfType<CanvasManager>();
    }


    public void GameEnd(GameState state)
    {
        gameState = state;

        canvasManager.GameEnd(state);
    }

}
