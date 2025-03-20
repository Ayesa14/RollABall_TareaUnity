using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    private PlayerImmortality playerImmortality;
    private Animator animator; // Añadido para controlar las animaciones

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // Asignamos el Animator

        if (player != null)
        {
            playerImmortality = player.GetComponent<PlayerImmortality>();
        }
    }

    void Update()
    {
        if (player != null && playerImmortality != null)
        {
            // El enemigo persigue al jugador solo si NO está en estado "Inmortal"
            if (playerImmortality.currentState != PlayerImmortality.PlayerState.Immortal)
            {
                navMeshAgent.SetDestination(player.position);
                if (animator != null)
                {
                    animator.SetBool("isChasing", true); // El enemigo está persiguiendo
                }
            }
            else
            {
                navMeshAgent.ResetPath(); // Si está inmortal, el enemigo se detiene
                if (animator != null)
                {
                    animator.SetBool("isChasing", false); // El enemigo no está persiguiendo
                }
            }
        }
    }
}

