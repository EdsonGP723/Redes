using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] private TMP_InputField nameInputField = null;
	[SerializeField] private Button continueButton = null;
	
	public string DisplayName {get; private set;}
	
	private const string PlayerPrefNameKey = "PlayerName";
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	private void Start() => SetUpInputField();
	
	private void SetUpInputField()
	{
		if (!PlayerPrefs.HasKey(PlayerPrefNameKey))
		{
			return;
		}
		string defaultName = PlayerPrefs.GetString(PlayerPrefNameKey);
		
		nameInputField.text = defaultName;
		
		SetPlayerName(defaultName);
	}
	
	public void SetPlayerName(string name)
	{
		continueButton.interactable = !string.IsNullOrEmpty(name);
	}
	
	public void SavePlayerName()
	{
		DisplayName = nameInputField.text;
		PlayerPrefs.SetString(PlayerPrefNameKey, DisplayName);
	}
}
