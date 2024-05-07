using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
	[SyncVar (hook = nameof(OnHolaCountChange))]
	int holaCount = 0;
	
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
		
		if(isLocalPlayer && Input.GetKeyDown(KeyCode.X))
		{
			Hola();
		}
		
		if (isServer && transform.position.y > 5)
		{
			TooHigh();
		}
	}
	
	[Command]
	void Hola()
	{
		Debug.Log("Recibe un saludo desde el cliente");
		holaCount +=1;
		ReplayHola();
	}
	
	[ClientRpc]
	void TooHigh()
	{
		Debug.Log("Andas demasiado alto");
	}
	void OnHolaCountChange(int oldCount, int newCount)
	{
		Debug.Log($"Teniamos {oldCount} holas, pero ahora tenemos {newCount} holas");
	}
	
	[TargetRpc] 
	void ReplayHola()
	{
		Debug.Log("Recibe un saludo desde el servidor");
	}
	
	
}
