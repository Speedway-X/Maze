using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variables para controlar la velociad de movimiento y rotación
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 200f;
    //Referencia al CharacterController
    private CharacterController controller;

    void Start()
    {
        //Obtenemos la referencia al CharacterController al empezar el juego
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Obtenemos la entrada del usuario para movimiento horizontal y vertical
        float horizontal = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, horizontal, 0);//Rotar personaje

        Vector3 localMove = new Vector3(0, 0, vertical);//Movimiento local en Z
        Vector3 worldMove = transform.TransformDirection(localMove);//Convertimos el movimiento local a mundial
        controller.Move(worldMove);//Movemos el personaje
    }

}
