using UnityEngine;

[RequireComponent(typeof(Camera))]
public class OrbitCamera : MonoBehaviour
{
	[SerializeField, Range(1f, 10f)]
	float speedH = 2.0f;
	[SerializeField, Range(1f, 10f)]
	float speedV = 2.0f;
	[SerializeField, Range(1f, 10f)]
	float distance = 5f;

	float yaw = 0.0f;
	float pitch = 0.0f;

	Transform player;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = true;
		player = PlayerManager.instance.player.transform;
	}

	private void Update()
	{
		yaw += speedH * Input.GetAxis("Mouse X");
		pitch -= speedV * Input.GetAxis("Mouse Y");
		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

		Vector3 focusPoint = player.position;
		Vector3 lookDirection = transform.forward;
		transform.localPosition = focusPoint - lookDirection * distance;
	}
}