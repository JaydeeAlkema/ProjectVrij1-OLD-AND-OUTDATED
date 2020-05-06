using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
	#region Variables
	[SerializeField] private string title = "";         // Title of the Object / NPC (a.k.a. A Name)
	[SerializeField] private string context = "";       // The context for this Object / NPC (a.k.a. A Description)
	#endregion

	#region Properties
	public string Title { get => title; set => title = value; }
	public string Context { get => context; set => context = value; }
	#endregion

	public void Interact(GameObject Interactor)
	{
		Interactor.GetComponent<PlayerInteraction>().TextBoxTitleTextMesh.text = title;
		Interactor.GetComponent<PlayerInteraction>().TextBoxContextTextMesh.text = context;

		Debug.Log(Interactor.name + " Interacted with " + gameObject.name);
	}
}
