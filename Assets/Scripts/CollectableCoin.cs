using UnityEngine;

public class CollectableCoin : MonoBehaviour
{
    public int value = 1;
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

            ScoreManager.Instance.AddScore(value);

            audioSource.Play();

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
