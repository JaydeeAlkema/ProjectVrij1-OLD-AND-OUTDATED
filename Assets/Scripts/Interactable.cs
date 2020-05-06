using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
	#region Variables
	[SerializeField] private GameObject interactionPromptObject = default;      // Reference to the interaction prompt object.
	[Space]
	[SerializeField] private string title = "";         // Title of the Object / NPC (a.k.a. A Name)
	[SerializeField] private string context = "";       // The context for this Object / NPC (a.k.a. A Description)
	#endregion

	#region Properties
	public string Title { get => title; set => title = value; }
	public string Context { get => context; set => context = value; }
	#endregion

	#region Monobehaviour Callbacks
	private void Start()
	{
		TogglePrompt(false);
	}
	#endregion

	public void Interact(GameObject Interactor)
	{
		Interactor.GetComponent<PlayerInteraction>().TextBoxTitleTextMesh.text = title;
		Interactor.GetComponent<PlayerInteraction>().TextBoxContextTextMesh.text = context;

		Debug.Log(Interactor.name + " Interacted with " + gameObject.name);
	}

	public void TogglePrompt(bool toggle)
	{
		interactionPromptObject.SetActive(toggle);
	}
}
