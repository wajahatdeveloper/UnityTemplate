using MV.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonBehaviour<GameController>
{
	#region GameState

	public enum GameStates
	{
		PreGame,
		InGame,
		PostGame,
		Paused,
		GameOver,
		GameWin
	}

	public static StateMachine<GameStates> state;

	public override void Awake()
	{
		base.Awake();
		state = StateMachine<GameStates>.Initialize(this, GameStates.PreGame);
	}

	#endregion
}
