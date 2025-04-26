using UnityEngine;
using System.Collections.Generic;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;

    public List<LanguageData> _availableLanguages = new List<LanguageData>();
    private Dictionary<string, LanguageData> _languagesByCode;
    private LanguageData _currentLanguage;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        _languagesByCode = new Dictionary<string, LanguageData>(_availableLanguages.Count);
        foreach (var lang in _availableLanguages)
        {
            _languagesByCode[lang.languageCode] = lang;
        }

        if (_availableLanguages.Count > 0)
            SetLanguage(_availableLanguages[0].languageCode);
    }

    public void SetLanguage(string languageCode)
    {
        if (_languagesByCode.TryGetValue(languageCode, out LanguageData lang) && _currentLanguage != lang)
        {
            _currentLanguage = lang;
            RefreshAllTexts();
        }
    }

    public string GetTranslation(int id)
    {
        if (_currentLanguage == null)
        {
            Debug.LogError("No language selected !");
            return $"NO_LANG_{id}";
        }

        var entry = _currentLanguage.entries.Find(e => e.ID == id);
        if (entry != null)
        {
            return entry.translation;
        }

        Debug.LogWarning($"Missing translation (ID: {id})");
        return $"MISSING_{id}";
    }

    public void RefreshAllTexts()
    {
        foreach (var text in TranslatableText.AllTextComponents)
        {
            text.RefreshTranslation();
        }
    }
}
