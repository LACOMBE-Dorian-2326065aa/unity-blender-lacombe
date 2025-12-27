using UnityEngine;
using UnityEngine.InputSystem; // Nouveau système d’entrée

public class PlayerMove : MonoBehaviour
{
    [Header("Réglages")]
    public float speed = 5f;

    private Vector2 moveInput; // Entrée du joueur (x,z)
    private Vector3 moveDirection;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogWarning("⚠️ Aucun CharacterController trouvé, ajout automatique.");
            controller = gameObject.AddComponent<CharacterController>();
        }
    }

    // Méthode appelée par le Input System
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        // Convertit l’entrée 2D en un vecteur 3D (X/Z)
        moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);

        // Déplace le joueur
        controller.Move(moveDirection * speed * Time.deltaTime);
    }
}
