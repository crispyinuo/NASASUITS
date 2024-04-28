using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UrsaUIManager : MonoBehaviour
{
    public GameObject panel;
    public Image ursaImage;
    public TextMeshProUGUI ursaText;
    public Sprite userSpeakingSprite;
    public Sprite ursaSpeakingSprite;

    // Hide everything initially
    void Start()
    {
        SetVisibility(3);
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
    }

    public void setInputText(string inputText)
    {
        setText(outputText);
        SetVisibility(1);
    }

}
