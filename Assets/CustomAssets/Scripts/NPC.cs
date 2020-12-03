using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private string[] _dialogue;
    private DialogManager _dialogManager;

    void Start()
    {
        _dialogManager = FindObjectOfType<DialogManager>();
        if (_dialogManager == null)
        {
            Debug.LogWarning("No se encontró un manejador de dialogos");
        }
    }


    public override void Interact()
    {
        // base.Interact();
        Debug.Log("Interactuando con NPC");
        _dialogManager.GetDialogue(_name, _dialogue);
    }
}
