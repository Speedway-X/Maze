using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class UIButton : MonoBehaviour
{
    [SerializeField] private UIDocument m_UI;
    private VisualElement m_UIRoot;
    private Label m_Label;

    private void Awake()
    {
        m_UIRoot = m_UI.rootVisualElement;
        m_Label = m_UIRoot.Q<Label>("Text");
    }

    private void OnEnable()
    {
        Shooting.OnButtonPressed += ShowText;
        PlayerDeath.OnPlayerRespawn += ChangeText;
    }

    private void OnDisable()
    {
        Shooting.OnButtonPressed -= ShowText;
        PlayerDeath.OnPlayerRespawn -= ChangeText;
    }

    private void ShowText(ColorType color)
    {
        m_Label.AddToClassList("FadeIn");
        StartCoroutine(HideText());
    }

    private IEnumerator HideText()
    {
        yield return new WaitForSeconds(5f);
        m_Label.RemoveFromClassList("FadeIn");
        yield return new WaitForSeconds(1f);
        m_Label.text = "A Door has been opened";
    }

    private void ChangeText()
    {
        m_Label.text = "A trap has killed you.\nYou have respawned";
        ShowText(ColorType.Red);
    }
}
