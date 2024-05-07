using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Windows.Speech;
using Microsoft.MixedReality.Toolkit.Audio;

enum SPEAKING_STATE
{
    USER_SPEAKING,
    URSA_SPEAKING,
    NO_ONE_SPEAKING
}

public class UrsaUIManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject networkManager;
    public Image ursaImage;
    public TextMeshProUGUI ursaText;
    public Sprite userSpeakingSprite;
    public Sprite ursaSpeakingSprite;
    private TextToSpeech textToSpeech;
    private KeywordRecognizer keywordRecognizer;
    private DictationRecognizer dictationRecognizer;
    private bool isListening = false;
    private SPEAKING_STATE speakingState = SPEAKING_STATE.NO_ONE_SPEAKING;

    // Hide everything initially
    void Start()
    {
        // SetVisibility(3);
        InitializeSpeechRecognition();
    }

    private void Update()
    {
        SetUIVisibility();
        switch (speakingState)
        {
            case SPEAKING_STATE.USER_SPEAKING: // User is speaking
                startDictationRecognizer();
                break;
            case SPEAKING_STATE.URSA_SPEAKING: // Ursa is speaking
                if (!textToSpeech.IsSpeaking())
                {
                    speakingState = SPEAKING_STATE.NO_ONE_SPEAKING;
                    startKeywordRecognizer();
                }
                break;
            case SPEAKING_STATE.NO_ONE_SPEAKING: // No one is speaking
                startKeywordRecognizer();
                break;
            default:
                Debug.LogError("Unsupported state");
                break;
        }
    }

    private void startDictationRecognizer()
    {
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.Stop();
            keywordRecognizer.Dispose();
            keywordRecognizer = null;
            PhraseRecognitionSystem.Shutdown();
        }
        if (keywordRecognizer == null || !keywordRecognizer.IsRunning)
        {
            if (dictationRecognizer == null)
            {
                dictationRecognizer = get_new_dictationRecognizer();
            }
            if (dictationRecognizer.Status != SpeechSystemStatus.Running)
            {
                dictationRecognizer.Start();
            }
        }
    }

    private void startKeywordRecognizer()
    {
        if (dictationRecognizer != null && dictationRecognizer.Status != SpeechSystemStatus.Stopped)
        {
            dictationRecognizer.Stop();
            dictationRecognizer.Dispose();
            dictationRecognizer = null;
        }
        if (dictationRecognizer == null || dictationRecognizer.Status == SpeechSystemStatus.Stopped)
        {
            PhraseRecognitionSystem.Restart();
            if (keywordRecognizer == null)
            {
                keywordRecognizer = get_new_keywordRecognizer();
            }
            if (!keywordRecognizer.IsRunning)
            {
                keywordRecognizer.Start();
            }
        }
    }

    private void Awake()
    {
        textToSpeech = GetComponent<TextToSpeech>();
    }

    private void InitializeSpeechRecognition()
    {
        // Keyword recognition for "Ursa"
        keywordRecognizer = get_new_keywordRecognizer();
        keywordRecognizer.Start();

        // Dictation recognizer setup
        // dictationRecognizer = get_new_dictationRecognizer();
    }

    private KeywordRecognizer get_new_keywordRecognizer()
    {
        KeywordRecognizer result = new KeywordRecognizer(new string[] { "Hello", "Bear", "Ursa" });
        result.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        return result;
    }

    private DictationRecognizer get_new_dictationRecognizer()
    {
        DictationRecognizer dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
        dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;
        dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;
        dictationRecognizer.DictationError += DictationRecognizer_DictationError;
        dictationRecognizer.AutoSilenceTimeoutSeconds = 3f;
        dictationRecognizer.InitialSilenceTimeoutSeconds = 8f;
        return dictationRecognizer;
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
            speakingState = SPEAKING_STATE.USER_SPEAKING; // User starts speaking
        }
    }

    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        // Set the recognized text
        setInputText(text);
        isListening = false;
        speakingState = SPEAKING_STATE.NO_ONE_SPEAKING;
        Debug.Log("Result: " + text);
        NetworkManager network = networkManager.GetComponent<NetworkManager>();
        network.sendCommand(text);
    }

    private void DictationRecognizer_DictationHypothesis(string text)
    {
        // Update text with ongoing dictation results
        setInputText(text);
        Debug.Log("Hypo: " + text);
    }

    private void DictationRecognizer_DictationComplete(DictationCompletionCause cause)
    {
        if (cause != DictationCompletionCause.Complete)
        {
            Debug.LogError("Dictation stopped unexpectedly: " + cause);
            NetworkManager network = networkManager.GetComponent<NetworkManager>();
            network.sendCommand(ursaText.text);
        }
        isListening = false;
        speakingState = SPEAKING_STATE.NO_ONE_SPEAKING;
    }

    private void DictationRecognizer_DictationError(string error, int hresult)
    {
        Debug.LogError("Dictation error: " + error);
        isListening = false;
        speakingState = SPEAKING_STATE.NO_ONE_SPEAKING;
    }

    private void setText(string text)
    {
        ursaText.text = text;
    }

    private void SetUIVisibility()
    {
        switch (speakingState)
        {
            case SPEAKING_STATE.USER_SPEAKING: // User is speaking
                ursaImage.sprite = userSpeakingSprite;
                ursaImage.enabled = true;
                ursaText.enabled = true;
                panel.SetActive(true);
                break;
            case SPEAKING_STATE.URSA_SPEAKING: // Ursa is speaking
                ursaImage.sprite = ursaSpeakingSprite;
                ursaImage.enabled = true;
                ursaText.enabled = true;
                panel.SetActive(true);
                break;
            case SPEAKING_STATE.NO_ONE_SPEAKING: // No one is speaking
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
        speakingState = SPEAKING_STATE.URSA_SPEAKING;
        textToSpeech.StartSpeaking(outputText);
    }

    public void setInputText(string inputText)
    {
        setText(inputText);
        speakingState = SPEAKING_STATE.USER_SPEAKING;
    }

    public void on_suits_get_incorrect_request_HMD()
    {
        setOutputText("Incorrect data request, please refine your question");
    }

}
