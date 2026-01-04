using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator animator;
    public AudioClip openSound;
    public int value = 10;

    private bool isOpened = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by: " + other.name);

        if (animator == null)
            animator = GetComponent<Animator>();

        RuntimeAnimatorController rac = animator.runtimeAnimatorController;

        if (rac == null)
        {
            return;
        }

        AnimationClip[] clips = rac.animationClips;

        if (isOpened) return;

        if (other.CompareTag("Player"))
        {
            Inventory inv = other.GetComponent<Inventory>();

            if (inv != null && inv.hasKey)
            {
                animator.SetTrigger("Chest_Opening_UnCommon");

                if (openSound)
                    AudioSource.PlayClipAtPoint(openSound, transform.position);

                ScoreManager.Instance.AddScore(value);
                isOpened = true;
            }
        }
    }
}
