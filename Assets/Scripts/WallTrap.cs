using UnityEngine;
using System.Collections;

public class WallTrap : Trap
{
    [SerializeField] private float m_MoveAmount;

    private enum Coordinates { X, Z }
    [SerializeField] private Coordinates m_Coordinate;

    private Vector3 m_Direction;

    private void Awake()
    {
        switch (m_Coordinate)
        {
            case Coordinates.X: m_Direction = new Vector3(m_MoveAmount, 0, 0); break;

            case Coordinates.Z: m_Direction = new Vector3(0, 0, m_MoveAmount); break;
        }
    }

    protected override IEnumerator Move()
    {
        Collider col = gameObject.GetComponent<Collider>();
        col.isTrigger = true;
        m_bIsMoving = true;

        //Obtenemos las posiciones inicial y final
        Vector3 start = transform.position;
        Vector3 end = start + m_Direction;

        //Animar la trampa cayendo
        float elapsedTime = 0f;
        float duration = m_Duration;
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(start, end, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = end;

        //Desactivar el collider para que la trampa no siga afectando al jugador
        col.isTrigger = false;
        m_bIsMoving = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Si la trampa colisiona con el jugar, este vuelve al principio
        if (other.CompareTag("Player") && m_bIsMoving)
        {
            PlayerDeath death = other.GetComponent<PlayerDeath>();
            death.Respawn();
        }
    }
}
