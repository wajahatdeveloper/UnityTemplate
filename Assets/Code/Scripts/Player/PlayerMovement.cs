using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public PlayerData playerData;
	[AutoRef] public Rigidbody rigidbody;

	private float horizontalForce;
	private float verticalForce;
	private Vector3 movementForce;

	private void Update()
	{
		verticalForce = Player.Buffer.verticalMovement;
		horizontalForce = Player.Buffer.horizontalMovement;
		movementForce = new Vector3(horizontalForce, 0, verticalForce);
	}

	private void FixedUpdate()
	{
		rigidbody.AddForce(movementForce * playerData.MoveSpeed,ForceMode.Impulse);
	}
}
