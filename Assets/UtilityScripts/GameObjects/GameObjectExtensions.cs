using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions
{

	public static void SetTransformX(this GameObject obj,float n)
	{
		obj.transform.position = new Vector3(n, obj.transform.position.y, obj.transform.position.z);
	}

	public static void SetTransformY(this GameObject obj, float n)
	{
		obj.transform.position = new Vector3(obj.transform.position.x, n, obj.transform.position.z);
	}

	public static void SetTransformZ(this GameObject obj, float n)
	{
		obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, n);
	}

}
