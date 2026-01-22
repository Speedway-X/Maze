using UnityEngine;
using System;

public class StopFloorTrap : MonoBehaviour
{
    //Event
    public static event Action OnStopTrap;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnStopTrap?.Invoke();
        }
    }
}
