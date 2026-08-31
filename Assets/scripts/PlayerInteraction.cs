using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactiondiatance = 3.5f;
    void Start()
    {
        
    }
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Tryinterract();
        }
    }

    void Tryinterract()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactiondiatance))
        {
            IIinteractable interactable = hit.collider.GetComponent<IIinteractable>();
            if(interactable != null)
            {
                interactable.Interact();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        IIinteractable interactable = other.GetComponent<IIinteractable>();
        if (interactable != null && other.gameObject.CompareTag("Doorsensor"))
        {
            interactable.Interact();
        }
    }

}
