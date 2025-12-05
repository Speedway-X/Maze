using UnityEngine;

public class CloseGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Cerrando el juego...");
            Application.Quit();
        }
    }
}
