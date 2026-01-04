using UnityEngine;
using UnityEngine.UI;

public class ZoneMortelle : MonoBehaviour
{
    public GameObject deathUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            deathUI.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
