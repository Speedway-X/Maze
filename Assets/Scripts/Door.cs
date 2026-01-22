using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private ColorType m_ColorType;
    private Renderer m_Renderer;

    private void Awake()
    {
        m_Renderer = GetComponent<Renderer>();
        //Asignar el color de la puerta según su tipo
        switch (m_ColorType)
        {
            case ColorType.Green:
                m_Renderer.material.color = Color.green;
                break;
            case ColorType.Red:
                m_Renderer.material.color = Color.red;
                break;
            case ColorType.Blue:
                m_Renderer.material.color = Color.blue;
                break;
            case ColorType.Yellow:
                m_Renderer.material.color = Color.yellow;
                break;
        }
    }

    //Suscribirse al evento
    private void OnEnable()
    {
        Shooting.OnButtonPressed += OpenDoor;
    }

    //Desuscribirse al evento
    private void OnDisable()
    {
        Shooting.OnButtonPressed -= OpenDoor;
    }

    //Abrir la puerta según el color recibido
    private void OpenDoor(ColorType colorType)
    {
        if (m_ColorType == colorType)
        {
            StartCoroutine(MoveDoor()); //Iniciar la corutina para mover la puerta
        }
    }

    //Corutina para mover la puerta hacia abajo
    private IEnumerator MoveDoor()
    {
        //obtenemos las posiciones inicial y final
        Vector3 closedPosition = transform.position;
        Vector3 openPosition = closedPosition + new Vector3(0, -11f, 0);

        //Animar la puerta durante 5 segundos
        float elapsedTime = 0f;
        float duration = 5f;
        while (elapsedTime < duration)
        {
            //Interpolar la posición de la puerta
            transform.position = Vector3.Lerp(closedPosition, openPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = openPosition;
        Destroy(gameObject); //Destruir la puerta al finalizar el movimiento
    }
}
