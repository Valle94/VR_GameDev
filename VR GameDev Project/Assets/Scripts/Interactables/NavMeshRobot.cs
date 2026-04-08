using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshRobot : MonoBehaviour
{
    public UnityEvent OnDestryWallCube;
    [SerializeField] AudioClip collisionClip;
    public AudioClip GetCollisionClip() => collisionClip;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveAgent(Vector3 move)
    {
        agent.destination = agent.transform.position + move;
    }

    public void StopAgent()
    {
        agent.ResetPath();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("WallCube"))
        {
            Destroy(other.gameObject);
            OnDestryWallCube?.Invoke();
        }
    }
}
