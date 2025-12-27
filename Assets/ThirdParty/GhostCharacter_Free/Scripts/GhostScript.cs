using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleMover : MonoBehaviour
{
    public float speed = 5f;          // vitesse de déplacement
    private CharacterController ctrl; // pour gérer la physique
    private Vector2 moveInput;        // input 2D (x, y)

    void Start()
    {
        ctrl = GetComponent<CharacterController>();
    }

    void Update()
    {
        // convertir l'input en direction 3D
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);

        // déplacer le perso
        if (move != Vector3.zero)
        {
            ctrl.Move(move * speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(move); // tourner vers la direction
        }
    }

    // callback du Input System
    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }
}
