using UnityEngine;
using UnityEngine.Events;

using System;
using System.Collections;

[Serializable]
public class VoidEvent : UnityEvent { }

public class SwipeInput : MonoBehaviour
{

	// If the touch is longer than MAX_SWIPE_TIME, we don't consider it a swipe
	public float MAX_SWIPE_TIME = 0.5f;

	// Factor of the screen width that we consider a swipe
	// 0.17 works well for portrait mode 16:9 phone
	public float MIN_SWIPE_DISTANCE = 0.17f;

	public static bool swipedRight = false;
	public static bool swipedLeft = false;
	public static bool swipedUp = false;
	public static bool swipedDown = false;

	public VoidEvent onSwipeLeft;
	public VoidEvent onSwipeRight;
	public VoidEvent onSwipeBottom;
	public VoidEvent onSwipeTop;

	public bool debugWithArrowKeys = true;

	Vector2 startPos;
	float startTime;

	public void Update()
	{
		swipedRight = false;
		swipedLeft = false;
		swipedUp = false;
		swipedDown = false;

		if (Input.touches.Length > 0)
		{
			Touch t = Input.GetTouch(0);
			if (t.phase == TouchPhase.Began)
			{
				startPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
				startTime = Time.time;
			}
			if (t.phase == TouchPhase.Ended)
			{
				if (Time.time - startTime > MAX_SWIPE_TIME) // press too long
					return;

				Vector2 endPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);

				Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

				if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
					return;

				if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
				{ // Horizontal swipe
					if (swipe.x > 0)
					{
						swipedRight = true;
						if (onSwipeRight != null)
						{
							onSwipeRight.Invoke();
						}
					}
					else
					{
						swipedLeft = true;
						if (onSwipeLeft != null)
						{
							onSwipeLeft.Invoke();
						}
					}
				}
				else
				{ // Vertical swipe
					if (swipe.y > 0)
					{
						swipedUp = true;
						if (onSwipeTop != null)
						{
							onSwipeTop.Invoke();
						}
					}
					else
					{
						swipedDown = true;
						if (onSwipeBottom != null)
						{
							onSwipeBottom.Invoke();
						}
					}
				}
			}
		}

		if (debugWithArrowKeys)
		{
			if(Input.GetKeyDown(KeyCode.DownArrow)/* || Input.GetKeyDown(KeyCode.S)*/)
			{
				if (onSwipeBottom != null)
				{
					onSwipeBottom.Invoke();
				}
			}
			if(Input.GetKeyDown(KeyCode.UpArrow)/* || Input.GetKeyDown(KeyCode.W)*/)
			{
				if (onSwipeTop != null)
				{
					onSwipeTop.Invoke();
				}
			}
			if(Input.GetKeyDown(KeyCode.RightArrow)/* || Input.GetKeyDown(KeyCode.D)*/)
			{
				if (onSwipeRight != null)
				{
					onSwipeRight.Invoke();
				}
			}
			if(Input.GetKeyDown(KeyCode.LeftArrow)/* || Input.GetKeyDown(KeyCode.A)*/)
			{
				if (onSwipeLeft != null)
				{
					onSwipeLeft.Invoke();
				}
			}
		}
	}
}
