using UnityEngine;
using System;

public class PlayerDeath : MonoBehaviour
{
    private Vector3 m_Spawn;

    //Event
    public static event Action OnPlayerRespawn;

    private void Awake()
    {
        m_Spawn = gameObject.transform.position;
    }

    private void OnEnable()
    {
        FloorDeath.OnPlayerDeath += Respawn;
    }

    private void OnDisable()
    {
        FloorDeath.OnPlayerDeath -= Respawn;
    }

    public void Respawn()
    {
        CharacterController cc = GetComponent<CharacterController>();

        cc.enabled = false;
        Vector3 rotation = new Vector3(0, -90, 0);
        transform.position = m_Spawn; transform.rotation = Quaternion.Euler(rotation);
        cc.enabled = true;
        OnPlayerRespawn?.Invoke();
    }
}
