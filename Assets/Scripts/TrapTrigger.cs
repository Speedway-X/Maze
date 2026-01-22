using UnityEngine;

public class TrapTrigger : MonoBehaviour 
{
    [SerializeField] private bool m_bIsFloorTrap;
    private Trap trap;

    private void Awake()
    {
        trap = GetComponentInParent<Trap>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) { return; }
        trap.ActivateTrap();
        if (!m_bIsFloorTrap) { Destroy(gameObject); }
    }
}
