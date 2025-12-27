using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    public Transform destination;
    public float teleportCooldown = 0.5f;

    private static bool isTeleporting = false;

    void OnTriggerEnter(Collider other)
    {
        if (isTeleporting)
            return;

        CharacterController controller = other.GetComponent<CharacterController>();
        if (controller != null)
        {
            StartCoroutine(Teleport(controller));
        }
    }

    private IEnumerator Teleport(CharacterController controller)
    {
        isTeleporting = true;

        controller.enabled = false;

        controller.transform.position = destination.position + Vector3.up * 0.1f;

        controller.enabled = true;

        yield return new WaitForSeconds(teleportCooldown);
        isTeleporting = false;
    }
}
