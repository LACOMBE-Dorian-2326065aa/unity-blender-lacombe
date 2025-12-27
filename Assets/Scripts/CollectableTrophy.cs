using UnityEngine;

public class CollectableTrophy : MonoBehaviour
{
    private AudioSource audioSource;
    private bool collected = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (collected) return;

        if (other.CompareTag("Player"))
        {
            collected = true;

            if (audioSource != null)
                audioSource.Play();

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            WinManager.Instance.WinGame();

            Destroy(gameObject, 1f);
        }
    }
}
