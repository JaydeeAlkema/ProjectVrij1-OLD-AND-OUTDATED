using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple Interactable Interface used for Objects and NPC with which the Player can interact.
/// </summary>
public interface IInteractable
{
	void Interact(GameObject Interactor);

	void TogglePrompt(bool toggle);
}
