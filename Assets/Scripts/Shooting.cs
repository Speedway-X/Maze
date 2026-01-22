using UnityEngine;
using System;

public enum ColorType
{
    Green,
    Red,
    Blue,
    Yellow,
}

public class Shooting : MonoBehaviour
{
    //Event
    public static event Action<ColorType> OnButtonPressed;

    private void Update()
    {
        //Creamos el rayo desde la camara hasta la posicion del mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit; //Variable para almacenar la informacion del impacto

        if (Physics.Raycast(ray, out hit))
        {
            //Si el rayo impacta con un objeto, obtenemos su transform
            Transform obj = hit.transform;
            Button button = obj.GetComponent<Button>();

            //Si el objeto tiene un componente Button y se presiona el boton izquierdo del mouse,
            //se activa el eveneto
            if (button != null && Input.GetMouseButtonDown(0))
            {
                OnButtonPressed?.Invoke(button.ColorType);
            }
        }
    }
}
