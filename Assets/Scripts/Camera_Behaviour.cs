using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behaviour : MonoBehaviour
{
	[SerializeField] private Transform target; // the transform the camera is locked to
	[SerializeField] private float smoothing; //The amount of smoothing that gets applied to the movement of the camera
	[SerializeField] private float frontOffset; //The offset of the camera in the direction the target is moving
	[SerializeField] private Vector3 offset; //frontOffset gets applied to this to make it work
	[SerializeField] private Vector2 clampX; //Clamp to level width
	[SerializeField] private bool clamp; //Is the camera clamped to level width?

	private Player_Behaviour player; //The player

	private Vector3 smoothedPos; //The end result of the camerapositioning after smoothing

	private void Awake() //Get component on object
	{
		player = FindObjectOfType<Player_Behaviour>();
	}

	private void FixedUpdate() //Calculate the camera position after the actual player position is calculated to prevent hitching
	{
		Vector3 desiredPos = new Vector3(target.transform.position.x + offset.x + (player.MovementInput.x * frontOffset), offset.y, offset.z); //Calculates the desired position of the camera relative to the movement of the player
		smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothing * Time.deltaTime); //Does the camera moving stuff

		if(clamp) //is clamped? yes? then clamp
		{
			Vector3 pos = transform.position;
			pos.x = Mathf.Clamp(transform.position.x, clampX.x, clampX.y);
			transform.position = pos;
		}

		transform.position = smoothedPos;
	}
}
