using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MenuUIEvents
{
	BeginGame,
	SetSound,
	SetMusic,
}

public class MainMenuLogic : MonoBehaviour
{
	private void Start()
	{
		gameObject.ConnectEvent(MenuUIEvents.BeginGame.ToString(), BeginGame);
		gameObject.ConnectEvent(MenuUIEvents.SetSound.ToString(), SetSound);
		gameObject.ConnectEvent(MenuUIEvents.SetMusic.ToString(), SetMusic);
	}

	public void SetMusic(GameObject sender, object data)
	{
		bool toggleState = (bool)data;
		Debug.Log("Music Set To " + toggleState);
		AudioController.instance.SetMusicVolume(toggleState ? 1 : 0);
	}

	public void SetSound(GameObject sender, object data)
	{
		bool toggleState = (bool)data;
		Debug.Log("Sound Set To " + toggleState);
		AudioController.instance.SetSoundFXVolume(toggleState ? 1 : 0);
	}

	public void BeginGame(GameObject sender, object data)
	{
		Debug.Log("Game Started By Clicking " + sender.name);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
