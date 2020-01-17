using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ObjectRotator : MonoBehaviour
{

	public Transform TransformToRotate;
	public float SensitivityX = 0.4f;
	public float SensitivityY = 0.4f;

	public UnityEvent OnRotate;

	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;
	private Vector3 _rotation;
	private bool _isRotating;

	void Start()
	{
		_rotation = Vector3.zero;
	}

	void Update()
	{
		if (_isRotating)
		{
			// offset
			_mouseOffset = (Input.mousePosition - _mouseReference);

			// apply rotation
			_rotation.y = -(_mouseOffset.x) * SensitivityX;
			_rotation.x = (_mouseOffset.y) * SensitivityY;

			// rotate
			TransformToRotate.Rotate(_rotation,Space.World);

			// store mouse
			_mouseReference = Input.mousePosition;
		}
	}

	void OnMouseDown()
	{
		// rotating flag
		_isRotating = true;

		// store mouse
		_mouseReference = Input.mousePosition;

		if (OnRotate != null)
		{
			OnRotate.Invoke();
		}
	}

	void OnMouseUp()
	{
		// rotating flag
		_isRotating = false;
	}

}