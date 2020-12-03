using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaycastWorldInfo : MonoBehaviour
{
    private NavMeshAgent _playerAgent;
    private PlayerController _playerController;

    private void Start()
    {
        _playerAgent = GetComponent<NavMeshAgent>();
        _playerController = GetComponent<PlayerController>();
        if (_playerAgent == null)
        {
            throw new MissingComponentException();
        }
        if (_playerController == null)
        {
            Debug.LogWarning("El jugador no tiene un player controller");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) 
        {
            GetRaycastInfo();
        }        
    }

    void GetRaycastInfo() 
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(interactionRay, out RaycastHit interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (interactedObject.tag == "Interactable")
            {
                // Debug.Log("Interactuando");
                _playerAgent.stoppingDistance = 5f;
                _playerAgent.destination = interactedObject.transform.position;

                interactedObject.GetComponent<Interactable>().GetInteractionValues(_playerController, _playerAgent, interactedObject);
            }
            else
            {
                _playerAgent.stoppingDistance = 0f;
                _playerAgent.destination = interactionInfo.point;
                Debug.Log("Caminando");
            }
        }
    }

}
