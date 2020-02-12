using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";

	private void Update()
	{
		Player.Buffer.horizontalMovement = Input.GetAxisRaw(horizontalAxis);
		Player.Buffer.verticalMovement = Input.GetAxisRaw(verticalAxis);
	}
}
