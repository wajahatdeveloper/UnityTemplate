using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuInterface : MonoBehaviour
{
	public Button btnPlay;
	public Toggle tglSound;
	public Toggle tglMusic;

	private void Start()
	{
		btnPlay.onClick.AddListener(() => { btnPlay.gameObject.RaiseEvent(MenuUIEvents.BeginGame.ToString()); });
		tglSound.onValueChanged.AddListener((val) => { tglSound.gameObject.RaiseEvent(MenuUIEvents.SetSound.ToString(),val); });
		tglMusic.onValueChanged.AddListener((val) => { tglMusic.gameObject.RaiseEvent(MenuUIEvents.SetMusic.ToString(),val); });
	}
}
