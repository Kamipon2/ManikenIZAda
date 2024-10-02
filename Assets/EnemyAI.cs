using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    public float detectionRange = 10f; // Дальность обнаружения
    public float fieldOfViewAngle = 110f; // Угол поля зрения
    public float chaseSpeed = 3.5f; // Скорость преследования
    public float stoppingDistance = 1.5f; // Расстояние, на котором враг останавливается от игрока

    private NavMeshAgent agent;
    private bool isChasing = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            DetectPlayer();
        }
    }

    private void DetectPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            if (angleToPlayer < fieldOfViewAngle / 2)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange))
                {
                    if (hit.transform == player)
                    {
                        Debug.Log("Игрок обнаружен!");
                        isChasing = true;
                    }
                }
            }
        }
    }

    private void ChasePlayer()
    {
        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= stoppingDistance)
        {
            agent.isStopped = true; // Остановить движение, когда слишком близко к игроку
        }
        else
        {
            agent.isStopped = false; // Возобновить движение к игроку
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Vector3 leftBoundary = Quaternion.Euler(0, -fieldOfViewAngle / 2, 0) * transform.forward * detectionRange;
        Vector3 rightBoundary = Quaternion.Euler(0, fieldOfViewAngle / 2, 0) * transform.forward * detectionRange;

        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}
