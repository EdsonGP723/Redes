using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
	[SerializeField] private NetworkManagerLobby networkManager = null;
	
	[Header("UI")]
	[SerializeField] private GameObject landinfPagePanel = null;
	
	public void HostLobby()
	{
		networkManager.StartHost();
		landinfPagePanel.SetActive(false);
	}
}
