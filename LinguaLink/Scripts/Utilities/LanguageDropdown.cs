using UnityEngine;
using TMPro;
using System.Collections.Generic;

[RequireComponent(typeof(TMP_Dropdown))]
public class LanguageDropdown : MonoBehaviour
{
    private TMP_Dropdown _dropdown;

    void Start()
    {
        _dropdown = GetComponent<TMP_Dropdown>();
        InitializeDropdown();
        _dropdown.onValueChanged.AddListener(OnLanguageSelected);
    }

    private void InitializeDropdown()
    {
        _dropdown.ClearOptions();
        var options = new List<TMP_Dropdown.OptionData>();
        foreach (var lang in LocalizationManager.Instance._availableLanguages)
        {
            options.Add(new TMP_Dropdown.OptionData(lang.languageName));
        }
        _dropdown.AddOptions(options);
        _dropdown.RefreshShownValue();
    }

    private void OnLanguageSelected(int index)
    {
        if (index < LocalizationManager.Instance._availableLanguages.Count)
        {
            LocalizationManager.Instance.SetLanguage(
                LocalizationManager.Instance._availableLanguages[index].languageCode);
        }
    }
}
