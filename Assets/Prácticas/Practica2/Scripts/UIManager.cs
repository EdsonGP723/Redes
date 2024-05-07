using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
	public static UIManager instance;
	
	public static GameObject startMenu;
	public TMP_InputField usernameField;
	
	
	// Awake is called when the script instance is being loaded.
	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Debug.Log("Ya existe la instancia, destruir objeto");
			Destroy(this);
		}
	}
	
	public void ConnectToServer()
	{
		startMenu.SetActive(false);
		usernameField.interactable = false;
		Client2.instance.ConnectToServer();
	}
    
}
