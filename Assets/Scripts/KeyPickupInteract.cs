using UnityEngine;
using UnityEngine.InputSystem;

public class KeyPickupInteract : MonoBehaviour
{
    public float interactRange = 3f;
    public LayerMask keyLayer;

    private InputActions input;
    private Inventory inventory;

    private void Awake()
    {
        input = new InputActions();
        inventory = GetComponent<Inventory>();
    }

    private void OnEnable()
    {
        input.Player.Enable();
        input.Player.Interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        input.Player.Interact.performed -= OnInteract;
        input.Player.Disable();
    }

    private void OnInteract(InputAction.CallbackContext ctx)
    {
        TryPickupKey();
    }

    private void TryPickupKey()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, interactRange, keyLayer);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Key"))
            {
                inventory.hasKey = true;
                Destroy(hit.gameObject);
                return;
            }
        }
    }
}
