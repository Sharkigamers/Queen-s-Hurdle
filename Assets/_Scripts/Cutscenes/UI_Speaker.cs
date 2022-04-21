using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Speaker : MonoBehaviour
{
    [SerializeField] private float timePerCharacter = .05f;
    private TextMeshProUGUI messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    [SerializeField] private GameObject movingTriangle;
    private int currentMessage = 0;
    [SerializeField] private string[] messageArray = new string[] {""};

    private void Awake() {
        messageText = transform.Find("message").Find("messageText").GetComponent<TextMeshProUGUI>();

        transform.Find("message").GetComponent<UI_Button>().ClickFunc = () => {
            if (textWriterSingle != null && textWriterSingle.IsActive()) {
                //Currently active TextWriter
                textWriterSingle.WriteAllAndDestroy();
            } else {
                if (currentMessage < messageArray.Length) {
                    string message = messageArray[currentMessage];
                    textWriterSingle = TextWriter.AddWriter_Static(messageText, message, timePerCharacter, true, true);
                    currentMessage++;
                }
            }

        };
    }

    private void Start() {
        TextWriter.AddWriter_Static(messageText, messageArray[currentMessage], timePerCharacter, true, true);
        currentMessage++;
    }

    private void Update() {
        if (textWriterSingle != null && textWriterSingle.IsActive()) {
            movingTriangle.SetActive(false);
        } else {
            movingTriangle.SetActive(true);
        }
    }
}
