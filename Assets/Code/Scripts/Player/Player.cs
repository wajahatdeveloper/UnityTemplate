using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public PlayerData playerData;
	[AutoRef] public PlayerInput input;
	[AutoRef] public PlayerMovement movement;
	[AutoRef] public PlayerInteraction interaction;

	// Buffer Object
	public struct Buffer
	{
		public static float horizontalMovement = 0f;
		public static float verticalMovement = 0f;
	}

}
