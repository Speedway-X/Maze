using System.Collections;
using UnityEngine;

public class CeillingTrap : Trap
{
    protected override IEnumerator Move()
    {
        m_bIsMoving = true;

        //Obtenemos las posiciones inicial y final
        Vector3 start = transform.position;
        Vector3 end = start + new Vector3(0, -10.01f, 0);

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
        Collider col = gameObject.GetComponent<Collider>();
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
