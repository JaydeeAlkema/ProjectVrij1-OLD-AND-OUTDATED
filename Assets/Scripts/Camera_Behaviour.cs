using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behaviour : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private float smoothing;
	[SerializeField] private float frontOffset;
	[SerializeField] private Vector3 offset;
	[SerializeField] private Vector2 clampX;
	[SerializeField] private bool clamp;

	private Player_Behaviour player;

	private Vector3 smoothedPos;

	private void Awake()
	{
		player = FindObjectOfType<Player_Behaviour>();
	}

	private void Update()
	{
		Vector3 desiredPos = new Vector3(target.transform.position.x + offset.x + (player.MovementInput.x * frontOffset), offset.y, offset.z);
		smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothing * Time.deltaTime);

		if (clamp)
		{
			Vector3 pos = transform.position;
			pos.x = Mathf.Clamp(transform.position.x, clampX.x, clampX.y);
			transform.position = pos;
		}
	}

	private void LateUpdate()
	{
		transform.position = smoothedPos;
	}
}
