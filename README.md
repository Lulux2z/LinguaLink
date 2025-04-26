# Localization System for Unity

## DISCLAIMER:
```
=================

This system is a flexible and efficient localization framework for Unity, designed to help developers easily
integrate and manage multiple languages in their games or applications. This framework allows you to switch
between languages dynamically, ensuring a seamless experience for users across the globe. 🌍✨
This system includes basic demo features such as language switching through a UI dropdown, automatic text
translation via `TextMeshPro` and legacy `UI Text`, and custom editor tools to streamline the translation
process. While this system can be used for production environments, it’s important to note that you
might need to extend it to suit specific project requirements. 🚀

=================
```

## ⚠️ Requires TextMeshPro asset ⚠️

---

## Features ✨

- **🌐 Multi-language Support**: Easily switch between languages at runtime.
- **📱 UI Translation**: Supports both **TextMeshPro** and legacy **UI Text** components.
- **🔄 Dynamic Language Switching**: Change languages dynamically through a language selector.
- **🛠️ Custom Editor Tools**: Manage translations directly within the Unity Inspector.
- **⚡ Optimized for Performance**: Avoids costly lookups by caching components and translations.
- **📂 Easy Language Setup**: Simply add new languages and translations through the provided data structure.
- **🧠 Event-Driven Updates**: Refresh all translations at once with minimal overhead.

---

## How It Works 🔧

This system relies on a central `LocalizationManager` to handle language management. It automatically updates the text of your UI components when the language is changed.

### Components 📋

1. **LocalizationManager**: 
   - Manages available languages and ensures the current language is set correctly.
   - Provides a method for retrieving translations by unique ID.
   
2. **TranslatableText**: 
   - A UI component that attaches to **TextMeshPro** or legacy **UI Text** components.
   - Automatically updates when the language changes.

3. **LanguageDropdown**: 
   - A simple UI component that allows users to choose their preferred language from a dropdown menu.

4. **TranslatableTextEditor**: 
   - A custom Unity editor tool for managing `TranslatableText` components in the Unity Inspector.

---

## Setup Instructions 🚀

Follow these steps to integrate the Localization System into your Unity project:

### Step 1: Add the Localization System to Your Project 📂
- Clone or download the repository.
- Drop the `LocalizationSystem` folder into your Unity project's `Assets` directory.

### Step 2: Create a New Language 📝
1. **Create a Language**: 
   - Go to **Tools -> LinguaLink -> New Language** in the Unity menu.
   - This will generate a new language file in `LinguaLink -> Data -> Languages`.
   - You can rename the language file as needed.
   
2. **Language Configuration**:
   - In the newly created language file, assign a **Language Name**. This name will appear in the UI dropdown menu.
   - The **Language Code** is used as an ID for switching between languages. Ensure that you use ISO 639-1 compliant codes (e.g., "en" for English, "fr" for French, "de" for German).

3. **Add Translations**:
   - Inside the language file, add translations for each text element in your game or app. Each translation should be associated with a unique **translation ID**.
   - Ensure that the **translation ID** is consistent across all languages. For example, if "Hello" is assigned ID 1 in English, "Bonjour" in French must also have ID 1.

### Step 3: Add Languages to LocalizationManager 📑
1. **Localization Manager Setup**:
   - Drag the `LocalizationManager` prefab into your Hierachy.
   - In the `LocalizationManager`, find the `Available Languages` list.
   - Add all the languages you created in the previous step to this list, referencing their respective language data files.

### Step 4: Assign Translatable Texts to UI Elements 🖋️
1. **Attach TranslatableText**: 
   - For any UI element that needs translation (e.g., buttons, labels), attach the `TranslatableText` component.
   
2. **Set Translation ID**: 
   - Set the `translationID` to the appropriate value for each text you want to translate, ensuring the ID corresponds to the correct translation in your language data.

3. **TextMeshPro Setup**: 
   - If you are using **TextMeshPro** for UI text, check the box labeled **Use TextMeshPro** in the `TranslatableText` component.
   - For legacy **UI Text**, leave the box unchecked.

### Step 5: Set Up the Language Dropdown (Optional) 🎮
If you want users to select their preferred language:

1. **Add the Language Dropdown**: 
   - Drag the `Select Language DropDown` prefab into your UI.
   
2. **Automatic Language Population**:
   - The dropdown will automatically populate with available languages based on the languages listed in the `LocalizationManager -> Available Languages`.

### Step 6: Play and Enjoy! 🎉
- Now, when you run the game, the language dropdown will allow you to switch between languages, and the text in your UI elements will automatically update based on the selected language.

---

## Built-in Actions and Tools 🔨

Here’s a quick overview of some built-in tools and actions:

| **Action**             | **Description**                                                                 |
|------------------------|---------------------------------------------------------------------------------|
| **SetLanguage**         | Switches the language dynamically by using the `languageCode` referenced in the languages created via the **Tool** menu. |
| **RefreshAllTexts**     | Refreshes all UI texts to reflect the new language.                            |
| **GetTranslation**      | Retrieves the translation for a given ID based on the `currentLanguage` selected. The translation ID corresponds to the text to be translated. 

---

## Troubleshooting and Notes ⚠️

1. **Language Missing**: If the translation for a specific ID is missing, a warning will be logged in the Unity console. Ensure all translation IDs are correctly assigned in the language data.
   
2. **Text Not Updating**: Ensure that your `TranslatableText` components are properly linked to the UI elements. For legacy `UI Text`, make sure the `useTMP` flag is unchecked.

3. **Dropdown Not Working**: Ensure the `LanguageDropdown` is properly linked to `LocalizationManager.Instance._availableLanguages`.

---

## License 📜

MIT — Feel free to use and modify for personal or commercial projects.

---

## Credits 👏

Created by **Lulux2z** - Spectral Interactive

---

### Thank you for using the Localization System! 🌟
