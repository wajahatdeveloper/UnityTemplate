using UnityEngine;
using UnityEngine.Events;

public class MouseDrag : MonoBehaviour
{
	private Vector3 screenPoint;
	private Vector3 offset;

	public UnityEvent OnMouseDragBegin;

	private void Start()
	{
		OnMouseDown();
		InvokeRepeating("OnMouseDrag", 0.2f, 0.01f);
		this.Invoke(()=> { CancelInvoke("OnMouseDrag"); },0.8f);
	}

	private void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

		if (OnMouseDragBegin != null)
		{
			OnMouseDragBegin.Invoke();
		}
	}

	private void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}
}