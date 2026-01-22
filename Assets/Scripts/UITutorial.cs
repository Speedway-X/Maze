using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class UITutorial : MonoBehaviour
{
    [SerializeField] private UIDocument m_UI;
    private VisualElement m_UIRoot;
    private Label m_Label;

    private enum TutorialState
    {
        Door,
        Traps,
        Tip,
        Floor,
    }
    private TutorialState m_CurrentState = TutorialState.Door;

    //Suscribirse al evento
    private void OnEnable()
    {
        TutorialTrigger.OnTutorialTriggered += ShowTutorial;
    }

    //Desuscribirse al evento
    private void OnDisable()
    {
        TutorialTrigger.OnTutorialTriggered -= ShowTutorial;
    }

    //Inicialización de referencias UI
    private void Awake()
    {
        m_UIRoot = m_UI.rootVisualElement;
        m_Label = m_UIRoot.Q<Label>("Text");
    }

    //Mostrar tutorial y comenzar la rutina para ocultarlo
    private void ShowTutorial()
    {
        ChangeText();
        m_Label.AddToClassList("FadeIn");
        StartCoroutine(HideTutorial());
    }

    private void ChangeText()
    {
        switch (m_CurrentState)
        {
            case TutorialState.Traps:
                m_Label.text = "Be carefull with the traps";
                break;
            case TutorialState.Tip:
                m_Label.text = "Some Buttons\nmay be hidden behind traps";
                break;
            case TutorialState.Floor:
                m_Label.text = "The floor is\n going to colapse!\nYou must escape now!";
                break;
        }
    }

    //Rutina para ocultar el tutorial después de un tiempo
    private IEnumerator HideTutorial()
    {
        yield return new WaitForSeconds(5f);
        m_Label.RemoveFromClassList("FadeIn");
        yield return new WaitForSeconds(1f);

        m_CurrentState++; //Avanzar al siguiente estado del tutorial
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
