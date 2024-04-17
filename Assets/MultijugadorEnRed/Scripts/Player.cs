using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
	void HandleMovement()
	{
		if (isLocalPlayer)
		{
			float moveHoriontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
			
			Vector3 movement = new Vector3(moveHoriontal * 0.1f, moveVertical * 0.1f, 0);
			transform.position = transform.position + movement;
		}
	}
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		HandleMovement();
	}
}
