using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EgressTaskManager : MonoBehaviour
{
    public GameObject[] taskPanels;
    public TextMeshProUGUI[] task1StepsText;
    public TextMeshProUGUI[] task2StepsText;
    public TextMeshProUGUI[] task3StepsText;

    public UrsaUIManager ursaUIManager;
    public Image[] taskHighlights;
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

    void HideAllHighlights()
    {
        foreach (var highlight in taskHighlights)
        {
            highlight.gameObject.SetActive(false);
        }
    }

    void ShowTask(int taskIndex)
    {
        HideAllTasks();
        taskPanels[taskIndex].SetActive(true);
        HideAllHighlights();
        taskHighlights[taskIndex].gameObject.SetActive(true);
    }

    void HighlightStep(int stepIndex, TextMeshProUGUI[] stepsText)
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
        HighlightStep(0, task1StepsText); // Highlight Step 1 in task 1
        ursaUIManager.setOutputText(display_string);
    }

    void on_egress_menu_do_subtask_1b_HMD(string display_string)
    {
        ShowTask(0);
        HighlightStep(1, task1StepsText);
        ursaUIManager.setOutputText(display_string);
    }

    void on_egress_menu_do_subtask_1c_HMD(string display_string)
    {
        ShowTask(0);
        HighlightStep(2, task1StepsText);
        ursaUIManager.setOutputText(display_string);
    }
    void on_egress_menu_do_subtask_2_HMD(string display_string)
    {
        ShowTask(1);
        HighlightStep(0, task2StepsText);
        ursaUIManager.setOutputText(display_string);
    }

    void on_egress_menu_do_subtask_3a_HMD(string display_string)
    {
        ShowTask(2);
        HighlightStep(0, task3StepsText);
        ursaUIManager.setOutputText(display_string);
    }

    void on_egress_menu_do_subtask_3b_HMD(string display_string)
    {
        ShowTask(2);
        HighlightStep(1, task3StepsText);
        ursaUIManager.setOutputText(display_string);
    }

    void on_egress_menu_do_subtask_3c_HMD(string display_string)
    {
        ShowTask(2);
        HighlightStep(2, task3StepsText);
        ursaUIManager.setOutputText(display_string);
    }
}
