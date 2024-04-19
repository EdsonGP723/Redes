using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
	public override void OnStartServer()
	{
		//base.OnStartServer();
		Debug.Log("Servidor iniciado");
	}
	
	public override void OnStopServer()
	{
		//base.OnStopServer();
		Debug.Log("Servidor detenido");
	}
	
	public override void OnClientConnect()
	{
		base.OnClientConnect();
		Debug.Log("Cliente Conectado");
	}
	
	public override void OnClientDisconnect()
	{
		base.OnClientDisconnect();
		Debug.Log("Cliente desconectado desde el servidor");
	}
	
	
}
