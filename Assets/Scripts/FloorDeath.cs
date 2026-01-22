using UnityEngine;
using System;

public class FloorDeath : MonoBehaviour
{
    //Event
    public static event Action OnPlayerDeath;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Death Triggered");
            OnPlayerDeath?.Invoke();
        }
    }
}
