using System.Collections;
using UnityEngine;

public class FloorTrap : Trap
{
    [SerializeField] private GameObject m_Floor;

    private void OnEnable()
    {
        StopFloorTrap.OnStopTrap += StopTrap;
    }

    private void OnDisable()
    {
        StopFloorTrap.OnStopTrap -= StopTrap;
    }

    protected override IEnumerator Move()
    {
        //Esperar un tiempo antes de caer
        float elapsedTime = 0f;
        float duration = m_Duration;
        while (elapsedTime < duration)
        {
            Debug.Log(elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        m_Floor.SetActive(false);
        yield return new WaitForSeconds(1f);
        m_Floor.SetActive(true);
    }
    private void StopTrap()
    {
        StopAllCoroutines();
    }
}
