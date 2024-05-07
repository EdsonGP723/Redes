using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JoinLobbyMenu : MonoBehaviour
{
	[SerializeField] private NetworkManagerLobby networkManager = null;
	
	[Header("UI")]
	[SerializeField] private GameObject landindPagePanel = null;
	[SerializeField] private TMP_InputField ipAdressInputField = null;
	[SerializeField] private Button joinButton = null;
	
	private void OnEnable()
	{
		NetworkManagerLobby.OnClientConnected += HandleClientConnected;
		NetworkManagerLobby.OnClientDisconnected += HandleClientDisconnected;
	}
	
	private void HandleClientConnected()
	{
		joinButton.interactable = true;
		gameObject.SetActive(false);
		landindPagePanel.SetActive(false);
	}
	
	private void HandleClientDisconnected()
	{
		joinButton.interactable = true;
	}
	
	private void OnDesable()
	{
		NetworkManagerLobby.OnClientConnected -= HandleClientConnected;
		NetworkManagerLobby.OnClientDisconnected -= HandleClientDisconnected;
	}
	
	public void JoinLobby()
	{
		string ipAdress = ipAdressInputField.text;
		networkManager.networkAddress = ipAdress;
		networkManager.StartClient();
		joinButton.interactable = false;
	}
}
