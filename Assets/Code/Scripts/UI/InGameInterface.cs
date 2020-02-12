using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameInterface : MonoBehaviour
{
	public Button btnPause;
	public Button btnResume;

	private void Start()
	{
		gameObject.ConnectEvent(InGameUIEvents_Retro.UI_Pause_Hide.ToString(), On_UI_Pause_Hide);
		gameObject.ConnectEvent(InGameUIEvents_Retro.UI_Resume_Hide.ToString(), On_UI_Resume_Hide);

		btnPause.onClick.AddListener(() => { btnPause.gameObject.RaiseEvent(InGameUIEvents.Paused.ToString()); });
		btnResume.onClick.AddListener(() => { btnResume.gameObject.RaiseEvent(InGameUIEvents.Resumed.ToString()); });
	}

	public void On_UI_Pause_Hide(GameObject sender, object data)
	{
		btnPause.gameObject.SetActive(false);
		btnResume.gameObject.SetActive(true);
	}

	public void On_UI_Resume_Hide(GameObject sender, object data)
	{
		btnResume.gameObject.SetActive(false);
		btnPause.gameObject.SetActive(true);
	}
}
