using System.Collections;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    [SerializeField] protected float m_Duration = 5f;
    protected bool m_bIsMoving = false;

    public bool IsMoving => m_bIsMoving;

    // Método empezar la corutina
    public void ActivateTrap()
    {
        StartCoroutine(Move());
    }

    // Método abstracto para definir el movimiento específico de la trampa
    protected abstract IEnumerator Move();
}
