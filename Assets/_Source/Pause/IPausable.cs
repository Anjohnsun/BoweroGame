using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPausable
{
    public GameStates CurrentGameState { get; protected set; }
    public void OnGameStateChanged(GameStates newGameState);
}
