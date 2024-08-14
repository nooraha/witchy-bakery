using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public enum GameState {
    Playing,
    Menu
}

public class GameStateEvent : UnityEvent<GameState> {

}
public class GameStateManager : MonoBehaviour
{
    public GameState currentState = GameState.Playing;
    public GameStateEvent onGameStateChange = new GameStateEvent();

    private void Start()
    {
        Application.targetFrameRate = 60;
        onGameStateChange.AddListener(debugStateChangeListener);
    }

    public void setState(GameState state) {
        currentState = state;
        onGameStateChange.Invoke(state);
    }

    private void debugStateChangeListener(GameState state) {
        Debug.Log("Game state changed to: " + state);
    }
}
