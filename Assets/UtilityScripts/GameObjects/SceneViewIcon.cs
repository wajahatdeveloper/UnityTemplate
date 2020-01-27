using UnityEngine;
using System.Collections;

public class SceneViewIcon : MonoBehaviour
{

	public Color iconColor = Color.yellow;
	public float radius = 0.1f;

	void OnDrawGizmos()
	{
		// Draw a yellow sphere at the transform's position
		Gizmos.color = iconColor;
		Gizmos.DrawSphere(transform.position,radius);
	}
}