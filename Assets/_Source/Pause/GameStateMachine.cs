using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine
{
    public GameStates CurrentGameState { get; private set; }
    public delegate void StateChanging(GameStates newGameState);
    public static event StateChanging StateChanged; 

    public void ChangeGameState()
    {
        CurrentGameState = CurrentGameState == GameStates.Paused ? GameStates.Playing : GameStates.Paused;
        StateChanged.Invoke(CurrentGameState);
    }

    public void ChangeGameState(GameStates newGameState) //may be useless
    {
        if (CurrentGameState != newGameState)
            ChangeGameState();
    }
}
