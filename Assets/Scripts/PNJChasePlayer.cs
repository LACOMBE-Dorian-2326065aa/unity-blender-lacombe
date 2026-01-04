using UnityEngine;
using UnityEngine.AI;

public class PNJChasePlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    public GameObject loseUI;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Aucun objet avec le tag Player trouvé !");
        }
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            loseUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
