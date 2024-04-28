using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Windows.Speech;
using Microsoft.MixedReality.Toolkit.Audio;

public class UrsaUIManager : MonoBehaviour
{
    public GameObject panel;
    public Image ursaImage;
    public TextMeshProUGUI ursaText;
    public Sprite userSpeakingSprite;
    public Sprite ursaSpeakingSprite;
    private TextToSpeech textToSpeech;
    private KeywordRecognizer keywordRecognizer;
    private DictationRecognizer dictationRecognizer;
    private bool isListening = false;

    // Hide everything initially
    void Start()
    {
        SetVisibility(3);
        InitializeSpeechRecognition();
    }

    private void Awake()
    {
        textToSpeech = GetComponent<TextToSpeech>();
    }

    private void InitializeSpeechRecognition()
    {
        // Keyword recognition for "Ursa"
        keywordRecognizer = new KeywordRecognizer(new string[] { "Ursa" });
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();

        // Dictation recognizer setup
        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
        dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;
        dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;
        dictationRecognizer.DictationError += DictationRecognizer_DictationError;
    }

    private void OnDestroy()
    {
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.Stop();
            keywordRecognizer.Dispose();
        }

        if (dictationRecognizer != null)
        {
            if (dictationRecognizer.Status == SpeechSystemStatus.Running)
                dictationRecognizer.Stop();

            dictationRecognizer.Dispose();
        }
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if (!isListening)
        {
            isListening = true;
            dictationRecognizer.Start();
            SetVisibility(1); // User starts speaking
        }
    }

    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        // Set the recognized text
        setInputText(text);
        isListening = false;
        dictationRecognizer.Stop();
    }

    private void DictationRecognizer_DictationHypothesis(string text)
    {
        // Update text with ongoing dictation results
        setInputText(text);
    }

    private void DictationRecognizer_DictationComplete(DictationCompletionCause cause)
    {
        if (cause != DictationCompletionCause.Complete)
            Debug.LogError("Dictation stopped unexpectedly: " + cause);
        isListening = false;
    }

    private void DictationRecognizer_DictationError(string error, int hresult)
    {
        Debug.LogError("Dictation error: " + error);
        isListening = false;
    }

    private void setText(string text)
    {
        ursaText.text = text;
    }

    private void SetVisibility(int state)
    {
        switch (state)
        {
            case 1: // User is speaking
                ursaImage.sprite = userSpeakingSprite;
                ursaImage.enabled = true;
                ursaText.enabled = true;
                panel.SetActive(true);
                break;
            case 2: // Ursa is speaking
                ursaImage.sprite = ursaSpeakingSprite;
                ursaImage.enabled = true;
                ursaText.enabled = true;
                panel.SetActive(true);
                break;
            case 3: // No one is speaking
                ursaImage.enabled = false;
                ursaText.enabled = false;
                panel.SetActive(false);
                break;
            default:
                Debug.LogError("Unsupported state");
                break;
        }
    }

    public void setOutputText(string outputText)
    {
        setText(outputText);
        SetVisibility(2);
        textToSpeech.StartSpeaking(outputText);
    }

    public void setInputText(string inputText)
    {
        setText(inputText);
        SetVisibility(1);
    }

}
