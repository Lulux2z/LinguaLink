using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLanguage", menuName = "LinguaLink/Language Data", order = 1)]
public class LanguageData : ScriptableObject
{
    [System.Serializable]
    public class TranslationEntry
    {
        public int ID;
        public string translation;
    }

    public string languageName;
    public string languageCode;
    public List<TranslationEntry> entries = new List<TranslationEntry>();
}