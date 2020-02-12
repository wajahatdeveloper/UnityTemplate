using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InGameUIEvents
{
	Paused,
	Resumed,
}

public enum InGameUIEvents_Retro
{
	UI_Pause_Hide,
	UI_Resume_Hide,
}

public class InGameLogic : MonoBehaviour
{
	private void Start()
	{
		gameObject.ConnectEvent(InGameUIEvents.Paused.ToString(), PauseGame);
		gameObject.ConnectEvent(InGameUIEvents.Resumed.ToString(), ResumeGame);
	}

	public void PauseGame(GameObject sender, object data)
	{
		Time.timeScale = 0.0000001f;
		gameObject.RaiseEvent(InGameUIEvents_Retro.UI_Pause_Hide.ToString());
	}

	public void ResumeGame(GameObject sender, object data)
	{
		Time.timeScale = 1f;
		gameObject.RaiseEvent(InGameUIEvents_Retro.UI_Resume_Hide.ToString());
	}
}
