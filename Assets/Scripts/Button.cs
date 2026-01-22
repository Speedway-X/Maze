using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private ColorType m_ColorType;
    private Material m_Material;

    public ColorType ColorType => m_ColorType;

    private void Awake()
    {
        Renderer renderer = GetComponentInChildren<Renderer>();

        foreach (Material mat in renderer.materials)
        {
            if (mat.name.Contains("ButtonMaterial"))
            {
                m_Material = mat;
            }
        }
        //Asignar el color según su tipo
        switch (m_ColorType)
         {
             case ColorType.Green:
                 m_Material.color = Color.green;
                break;
             case ColorType.Red:
                 m_Material.color = Color.red;
                break;
             case ColorType.Blue:
                 m_Material.color = Color.blue;
                break;
            case ColorType.Yellow:
                m_Material.color = Color.yellow;
                break;
        }
    }
}
