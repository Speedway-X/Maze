using UnityEngine;
using System;

public class TutorialTrigger : MonoBehaviour
{
    //Events
    public static event Action OnTutorialTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnTutorialTriggered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
