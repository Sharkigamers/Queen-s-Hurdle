using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWriter : MonoBehaviour
{
    private static TextWriter instance;
    private List<TextWriterSingle> textWriterSingleList;

    private void Awake() {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    public static TextWriterSingle AddWriter_Static(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd) {
        if (removeWriterBeforeAdd) {
            instance.RemoveWriter(uiText);
        }
        return instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters);
    }

    public TextWriterSingle AddWriter(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters) {
        TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
    }

    public static void RemoveWriter_Static(TextMeshProUGUI uiText) {
        instance.RemoveWriter(uiText);
    }

    private void RemoveWriter(TextMeshProUGUI uiText) {
        for (int i = 0; i < textWriterSingleList.Count; i++) {
            if (textWriterSingleList[i].GetUiText() == uiText) {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    private void Update() {
        for (int i = 0; i < textWriterSingleList.Count; i++) {
            bool destroyInstance = textWriterSingleList[i].Update();
            if (destroyInstance) {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    // Represents a single TextWriter instance
    public class TextWriterSingle {

        private TextMeshProUGUI uiText;
        private string textToWrite;
        private int characterIndex;
        private float timePerCharacter;
        private float timer;
        private bool invisibleCharacters;

        public TextWriterSingle(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters) {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
            characterIndex = 0;
        }

        //returns true on complet
        public bool Update() {
            if (uiText != null) {
                timer -= Time.deltaTime;
                while (timer <= 0f) {
                    //Display next char
                    timer += timePerCharacter;
                    characterIndex++;
                    string _text = textToWrite.Substring(0, characterIndex);
                    if (invisibleCharacters) {
                        _text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                    }
                    uiText.text = _text;

                    //Checks if entire string is displayed
                    if (characterIndex >= textToWrite.Length) {
                        uiText = null;
                        return true;
                    }
                }
            }
            return false;
        }

        public TextMeshProUGUI GetUiText() {
            return uiText;
        }

        public bool IsActive() {
            return characterIndex < textToWrite.Length;
        }

        public void WriteAllAndDestroy() {
            uiText.text = textToWrite;
            characterIndex = textToWrite.Length;
            TextWriter.RemoveWriter_Static(uiText);
        }
    }

}