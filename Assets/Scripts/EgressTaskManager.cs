using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EgressTaskManager : MonoBehaviour
{
    public GameObject[] taskPanels;
    public TextMeshProUGUI[] stepsText;
    public UrsaUIManager ursaUIManager;
    Color32 defaultColor = new Color32(255, 255, 255, 100);

    void Start()
    {
        HideAllTasks();
        // Show Task 1 by default, should comment this line out when testing
        ShowTask(0);
    }

    void Update()
    {

    }
    void HideAllTasks()
    {
        foreach (var panel in taskPanels)
        {
            panel.SetActive(false);
        }
    }

    void ShowTask(int taskIndex)
    {
        HideAllTasks();
        taskPanels[taskIndex].SetActive(true);
    }

    void HighlightStep(int stepIndex)
    {
        // Reset all steps to the non-highlighted
        foreach (var step in stepsText)
        {
            step.color = defaultColor;
        }
        // Highlight the current step
        stepsText[stepIndex].color = Color.white;
    }

    void on_egress_menu_do_subtask_1a_HMD(string display_string)
    {
        ShowTask(0); // Show Task 1
        HighlightStep(0); // Highlight Step 1
        ursaUIManager.setOutputText(display_string);
    }

    void on_egress_menu_do_subtask_1b_HMD(string display_string)
    {
        ShowTask(0);
        HighlightStep(1);
        ursaUIManager.setOutputText(display_string);
    }

    void on_egress_menu_do_subtask_1c_HMD(string display_string)
    {
        ShowTask(0);
        HighlightStep(2);
        ursaUIManager.setOutputText(display_string);
    }
}
