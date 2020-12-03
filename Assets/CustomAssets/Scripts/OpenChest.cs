using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : Interactable
{
    private Animator _chestAnimator;
    private bool _exists;

   void Start()
    {
        _chestAnimator = GetComponent<Animator>();
        _exists = true;

        if (_chestAnimator == null)
        {
            Debug.LogWarning("No se encontró el animador del cofre");
        }
    }
    public override void Interact()
    {
        Debug.Log("Interactuando con el cofre del tesoro");
        if (_exists)
        {
            _chestAnimator.SetTrigger("isOpen");
            playerController_.UpdateGold(20);
            StartCoroutine(DeleteObject());
            _exists = false;
        }
    }

    IEnumerator DeleteObject()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
