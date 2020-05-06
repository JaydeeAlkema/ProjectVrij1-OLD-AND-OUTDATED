using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	#region Variables
	[SerializeField] private GameObject textBoxObject = default;                        // Reference to the entire Text Box Gameobject.
	[SerializeField] private TextMeshProUGUI textBoxTitleTextMesh = default;            // Reference to the Text Box Title Text Mesh Component.
	[SerializeField] private TextMeshProUGUI textBoxContextTextMesh = default;          // Reference to the Text Box Context Text Mesh Component.
	[Space]
	[SerializeField] private IInteractable interactable = default;
	[SerializeField] private bool interactionPressed = false;
	#endregion

	#region Properties
	public TextMeshProUGUI TextBoxTitleTextMesh { get => textBoxTitleTextMesh; set => textBoxTitleTextMesh = value; }
	public TextMeshProUGUI TextBoxContextTextMesh { get => textBoxContextTextMesh; set => textBoxContextTextMesh = value; }
	public GameObject TextBoxObject { get => textBoxObject; set => textBoxObject = value; }
	#endregion

	#region Monobehaviour Callbacks
	private void Start()
	{
		textBoxObject.SetActive(false);
	}

	private void Update()
	{
		interactionPressed = Input.GetAxisRaw("Submit") == 1 ? true : false;

		if(interactionPressed && interactable != null)
		{
			textBoxObject.SetActive(true);
			interactable.Interact(gameObject);
			interactable.TogglePrompt(false);
		}
	}
	#endregion

	private void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<IInteractable>() != null)
		{
			interactable = other.GetComponent<IInteractable>();
			interactable.TogglePrompt(true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		textBoxObject.SetActive(false);
		interactable.TogglePrompt(false);
		interactable = null;
	}
}
