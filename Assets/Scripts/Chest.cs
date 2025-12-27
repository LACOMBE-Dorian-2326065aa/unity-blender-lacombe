using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator animator;
    public AudioClip openSound;

    private bool isOpened = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by: " + other.name);

        if (animator == null)
            animator = GetComponent<Animator>();

        RuntimeAnimatorController rac = animator.runtimeAnimatorController;

        if (rac == null)
        {
            Debug.Log("Pas de RuntimeAnimatorController.");
            return;
        }

        AnimationClip[] clips = rac.animationClips;

        Debug.Log("=== Animation Clips ===");

        foreach (AnimationClip clip in clips)
        {
            Debug.Log("Clip : " + clip.name);
        }

        if (isOpened) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the chest trigger.");
            Inventory inv = other.GetComponent<Inventory>();

            if (inv != null && inv.hasKey)
            {
                Debug.Log("Player has the key. Opening chest.");
                animator.SetTrigger("Chest_Opening_UnCommon");

                if (openSound)
                    AudioSource.PlayClipAtPoint(openSound, transform.position);

                isOpened = true;
            }
        }
    }
}
