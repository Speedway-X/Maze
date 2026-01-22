using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Movement : MonoBehaviour
{
    //Variables para controlar la velociad de movimiento y rotación
    [SerializeField] private float m_MoveSpeed = 10f;
    [SerializeField] private float m_RotateSpeed = 200f;
    //Referencia al CharacterController
    private CharacterController controller;

    void Start()
    {
        //Obtenemos la referencia al CharacterController al empezar el juego
        controller = GetComponent<CharacterController>();
        StartCoroutine(Falling());
    }

    void FixedUpdate()
    {
        //Obtenemos la entrada del usuario para movimiento horizontal y vertical
        float horizontal = Input.GetAxis("Horizontal") * m_RotateSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * m_MoveSpeed * Time.deltaTime;

        transform.Rotate(0, horizontal, 0);//Rotar personaje

        Vector3 localMove = new Vector3(0, 0, vertical);//Movimiento local en Z
        Vector3 worldMove = transform.TransformDirection(localMove);//Convertimos el movimiento local a mundial
        controller.Move(worldMove);//Movemos el personaje
    }

    private IEnumerator Falling()
    {
        float gravity = -9.81f;
        Vector3 fallVelocity = new Vector3(0, gravity, 0);
        while (true) 
        {
            controller.Move(fallVelocity * Time.deltaTime);
            yield return null;
        }
    }
}
