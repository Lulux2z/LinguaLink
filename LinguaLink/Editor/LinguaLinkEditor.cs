using UnityEditor;
using UnityEngine;

public static class LinguaLinkEditor
{
    [MenuItem("Tools/LinguaLink/New Language")]
    public static void CreateNewLanguage()
    {
        LanguageData languageData = ScriptableObject.CreateInstance<LanguageData>();
        
        languageData.languageName = "Français"; // UI
        languageData.languageCode = "fr"; // Code 
        
        string path = "Assets/LinguaLink/Data/Languages/NewLanguage.asset";
        AssetDatabase.CreateAsset(languageData, AssetDatabase.GenerateUniqueAssetPath(path));
        AssetDatabase.SaveAssets();
        
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = languageData;
    }
}