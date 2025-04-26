using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

[ExecuteAlways]
public class TranslatableText : MonoBehaviour
{
    public bool useTMP = true;
    public int translationID;

    private TMP_Text tmpTextComponent;
    private Text legacyTextComponent;

    public static List<TranslatableText> AllTextComponents = new List<TranslatableText>();

    void OnEnable()
    {
        AllTextComponents.Add(this);
        UpdateTextComponents();
    }

    void OnDisable()
    {
        AllTextComponents.Remove(this);
    }

    private void Start()
    {
        RefreshTranslation();
    }

    private void UpdateTextComponents()
    {
        if (useTMP)
        {
            tmpTextComponent = GetComponent<TMP_Text>();
            legacyTextComponent = null;
        }
        else
        {
            legacyTextComponent = GetComponent<Text>();
            tmpTextComponent = null;
        }
    }

    public void RefreshTranslation()
    {
        if (LocalizationManager.Instance == null) return;

        string translatedText = LocalizationManager.Instance.GetTranslation(translationID);

        if (useTMP && tmpTextComponent != null)
            tmpTextComponent.text = translatedText;
        else if (!useTMP && legacyTextComponent != null)
            legacyTextComponent.text = translatedText;
    }
}
