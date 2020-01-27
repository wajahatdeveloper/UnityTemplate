using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
	public static Vector3 ScaleByValue(this Vector3 obj, float n)
	{
		return obj *= n;
	}

	public static Vector3 down(this Vector3 obj)
	{
		return -Vector3.up;
	}

	public static Vector3 left(this Vector3 obj)
	{
		return -Vector3.right;
	}

	public static Vector3 backward(this Vector3 obj)
	{
		return -Vector3.forward;
	}
}
