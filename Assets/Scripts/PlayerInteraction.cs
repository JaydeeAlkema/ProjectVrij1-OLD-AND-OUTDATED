using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
	#region Variables
	[SerializeField] private TextMeshProUGUI textBoxTitleTextMesh = default;			// Reference to the Text Box Title Text Mesh Component.
	[SerializeField] private TextMeshProUGUI textBoxContextTextMesh = default;          // Reference to the Text Box Context Text Mesh Component.
	#endregion

	#region Properties
	public TextMeshProUGUI TextBoxTitleTextMesh { get => textBoxTitleTextMesh; set => textBoxTitleTextMesh = value; }
	public TextMeshProUGUI TextBoxContextTextMesh { get => textBoxContextTextMesh; set => textBoxContextTextMesh = value; }
	#endregion

	private void OnTriggerEnter(Collider other)
	{
		other.GetComponent<IInteractable>()?.Interact(gameObject);
	}
}
