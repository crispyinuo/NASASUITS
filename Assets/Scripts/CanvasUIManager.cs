using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CanvasUIManager : MonoBehaviour
{
    public GameObject[] UIPanels; // NavigationSystem, DetailsPanel, Egress & Ingress Panels
    public GameObject headerPanel;
    public Toast toast;

    [System.Serializable]
    public class Toast
    {
        public TextMeshProUGUI toastText;
        public GameObject toastGameObject;
    }

    // Start is called before the first frame update

    void Start()
    {
        // can be comment out2
        HideAllPanels();
        show_top_menu();
        ShowPanel(1); //default to show egress, can be deleted after testing
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HideAllPanels()
    {
        foreach (var panel in UIPanels)
        {
            panel.SetActive(false);
        }
    }

    // 0 => EVATaskPanel
    // 1 => NavigationSystem
    // 2 => DetailsPanel
    void ShowPanel(int panelIndex)
    {
        HideAllPanels();
        UIPanels[panelIndex].SetActive(true);
    }

    void HidePanel(int panelIndex)
    {
        UIPanels[panelIndex].SetActive(false);
    }

    void show_top_menu()
    {
        headerPanel.SetActive(true);
    }
    void hide_top_menu()
    {
        headerPanel.SetActive(false);
    }
    void ShowToast(string toastMessage)
    {
        toast.toastGameObject.SetActive(true);
        toast.toastText.text = toastMessage;
    }
    void HideToast()
    {
        toast.toastGameObject.SetActive(false);
    }

    public void on_suits_open_my_suit_HMD()
    {
        ShowPanel(2);
    }
}
