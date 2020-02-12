using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "stick")
		{
			ScoreController.instance.AddScore(other.gameObject.GetComponentInParent<Stick>().score);
			Destroy(other.gameObject);
		}
	}
}
