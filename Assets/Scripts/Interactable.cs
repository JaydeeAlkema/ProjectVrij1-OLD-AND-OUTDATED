using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
	public void Interact(GameObject Interactor)
	{
		Debug.Log(Interactor.name + " Interacted with " + gameObject.name);
	}
}
