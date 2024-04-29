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
    public GameObject[] task4SubPanels;
    public TextMeshProUGUI[] task4aStepsText;
    public TextMeshProUGUI[] task4bStepsText;

    public UrsaUIManager ursaUIManager;
    public Image[] taskHighlights;
    Color32 noHighlightWhiteColor = new Color32(255, 255, 255, 100);
    Color32 dnoHighlightGreenColor = new Color32(255, 255, 255, 100);

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

    void ShowSubTask(int taskIndex, GameObject[] subPanels)
    {
        HideAllSubTasks(subPanels);
        subPanels[taskIndex].SetActive(true);
    }

    void HideAllSubTasks(GameObject[] subPanels)
    {
        foreach (var panel in subPanels)
        {
            panel.SetActive(false);
        }
    }

    void HighlightStep(int stepIndex, TextMeshProUGUI[] stepsText)
    {
        // Reset all steps to the non-highlighted
        foreach (var step in stepsText)
        {
            step.color = noHighlightWhiteColor;
        }
        // Highlight the current step
        stepsText[stepIndex].color = Color.white;
    }

    public void on_egress_menu_do_subtask_1a_HMD(string display_string)
    {
        ShowTask(0); // Show Task 1
        HighlightStep(0, task1StepsText); // Highlight Step 1 in task 1
        ursaUIManager.setOutputText(display_string);
    }

    public void on_egress_menu_do_subtask_1b_HMD(string display_string)
    {
        ShowTask(0);
        HighlightStep(1, task1StepsText);
        ursaUIManager.setOutputText(display_string);
    }

    public void on_egress_menu_do_subtask_1c_HMD(string display_string)
    {
        ShowTask(0);
        HighlightStep(2, task1StepsText);
        ursaUIManager.setOutputText(display_string);
    }
    public void on_egress_menu_do_subtask_2_HMD(string display_string)
    {
        ShowTask(1);
        HighlightStep(0, task2StepsText);
        ursaUIManager.setOutputText(display_string);
    }

    public void on_egress_menu_do_subtask_3a_HMD(string display_string)
    {
        ShowTask(2);
        HighlightStep(0, task3StepsText);
        ursaUIManager.setOutputText(display_string);
    }

    public void on_egress_menu_do_subtask_3b_HMD(string display_string)
    {
        ShowTask(2);
        HighlightStep(1, task3StepsText);
        ursaUIManager.setOutputText(display_string);
    }

    public void on_egress_menu_do_subtask_3c_HMD(string display_string)
    {
        ShowTask(2);
        HighlightStep(2, task3StepsText);
        ursaUIManager.setOutputText(display_string);
    }

    public void on_egress_menu_do_subtask_4a1_HMD(string display_string)
    {
        ShowTask(3); //Task 4
        ShowSubTask(0, task4SubPanels); //SubTask a
        HighlightStep(0, task4aStepsText); //Step 1
        ursaUIManager.setOutputText(display_string);
    }
    public void on_egress_menu_do_subtask_4a2_HMD(string display_string)
    {
        ShowTask(3);
        ShowSubTask(0, task4SubPanels);
        HighlightStep(1, task4aStepsText);
        ursaUIManager.setOutputText(display_string);
    }
    public void on_egress_menu_do_subtask_4a3_HMD(string display_string)
    {
        ShowTask(3);
        ShowSubTask(0, task4SubPanels);
        HighlightStep(2, task4aStepsText);
        ursaUIManager.setOutputText(display_string);
    }
    public void on_egress_menu_do_subtask_4a4_HMD(string display_string)
    {
        ShowTask(3);
        ShowSubTask(0, task4SubPanels);
        HighlightStep(3, task4aStepsText);
        ursaUIManager.setOutputText(display_string);
    }
    public void on_egress_menu_do_subtask_4b1_HMD(string display_string)
    {
        ShowTask(3);
        ShowSubTask(1, task4SubPanels);
        HighlightStep(0, task4aStepsText);
        ursaUIManager.setOutputText(display_string);
    }
    public void on_egress_menu_do_subtask_4b2_HMD(string display_string)
    {
        ShowTask(3);
        ShowSubTask(1, task4SubPanels);
        HighlightStep(1, task4aStepsText);
        ursaUIManager.setOutputText(display_string);
    }
    public void on_egress_menu_do_subtask_4b3_HMD(string display_string)
    {
        ShowTask(3);
        ShowSubTask(1, task4SubPanels);
        HighlightStep(2, task4aStepsText);
        ursaUIManager.setOutputText(display_string);
    }
    public void on_egress_menu_do_subtask_4b4_HMD(string display_string)
    {
        ShowTask(3);
        ShowSubTask(1, task4SubPanels);
        HighlightStep(3, task4aStepsText);
        ursaUIManager.setOutputText(display_string);
    }
    public void onEgressMenuDoSubtask4c(string display_string)
    {
        ShowTask(3);
        ShowSubTask(2, task4SubPanels);
        ursaUIManager.setOutputText(display_string);
    }
}
