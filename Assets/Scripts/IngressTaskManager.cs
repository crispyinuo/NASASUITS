using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IngressTaskManager : MonoBehaviour
{
    public GameObject[] taskPanels;
    public TextMeshProUGUI[] task1StepsText;
    public TextMeshProUGUI[] task2StepsText;
    public GameObject[] task3SubPanels;
    public TextMeshProUGUI[] task3bStepsText;
    public TextMeshProUGUI[] task4StepsText;
    public UrsaUIManager ursaUIManager;
    public Image[] taskHighlights;
    Color32 noHighlightWhiteColor = new Color32(255, 255, 255, 100);

    public DefaultObserverEventHandler defaultObserverEventHandler;

    // Start is called before the first frame update
    void Start()
    {
        HideAllTasks();
        // Show Task 1 by default, should comment this line out when testing
        ShowTask(0);
    }

    // Update is called once per frame
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

    public void ExecuteTask(string functionName, string displayString)
    {
        switch (functionName)
        {
            case "on_ingress_menu_do_subtask_1a_HMD":
                on_ingress_menu_do_subtask_1a_HMD(displayString);
                break;
            case "on_ingress_menu_do_subtask_1b_HMD":
                on_ingress_menu_do_subtask_1b_HMD(displayString);
                break;
            case "on_ingress_menu_do_subtask_1c_HMD":
                on_ingress_menu_do_subtask_1c_HMD(displayString);
                break;
            case "on_ingress_menu_do_subtask_2a_HMD":
                on_ingress_menu_do_subtask_2a_HMD(displayString);
                break;
            case "on_ingress_menu_do_subtask_2b_HMD":
                on_ingress_menu_do_subtask_2b_HMD(displayString);
                break;
            case "on_ingress_menu_do_subtask_2c_HMD":
                on_ingress_menu_do_subtask_2c_HMD(displayString);
                break;
            case "on_ingress_menu_do_subtask_3a_HMD":
                on_ingress_menu_do_subtask_3a_HMD(displayString);
                break;
            case "on_ingress_menu_do_subtask_3b_HMD":
                on_ingress_menu_do_subtask_3b_HMD(displayString);
                break;
            case "on_ingress_menu_do_subtask_3c_HMD":
                on_ingress_menu_do_subtask_3c_HMD(displayString);
                break;
            case "on_ingress_menu_do_subtask_3d_HMD":
                on_ingress_menu_do_subtask_3d_HMD(displayString);
                break;
            case "on_ingress_menu_do_subtask_4a_HMD":
                on_ingress_menu_do_subtask_4a_HMD(displayString);
                break;
            case "on_ingress_menu_do_subtask_4b_HMD":
                on_ingress_menu_do_subtask_4b_HMD(displayString);
                break;
            default:
                Debug.Log("Function name does not match any defined method");
                break;
        }
    }

    public void on_ingress_menu_do_subtask_1a_HMD(string display_string)
    {
        ShowTask(0); // Show Task 1
        HighlightStep(0, task1StepsText); // Highlight Step 1 in task 1
        ursaUIManager.setOutputText(display_string);
    }

    public void on_ingress_menu_do_subtask_1b_HMD(string display_string)
    {
        ShowTask(0);
        HighlightStep(1, task1StepsText);
        ursaUIManager.setOutputText(display_string);
    }

    public void on_ingress_menu_do_subtask_1c_HMD(string display_string)
    {
        ShowTask(0);
        HighlightStep(2, task1StepsText);
        ursaUIManager.setOutputText(display_string);
    }

    public void on_ingress_menu_do_subtask_2a_HMD(string display_string)
    {
        ShowTask(1);
        HighlightStep(0, task2StepsText);
        defaultObserverEventHandler.AssignTagName("in-task2");
        ursaUIManager.setOutputText(display_string);
    }

    public void on_ingress_menu_do_subtask_2b_HMD(string display_string)
    {
        ShowTask(1);
        HighlightStep(1, task2StepsText);
        ursaUIManager.setOutputText(display_string);
    }

    public void on_ingress_menu_do_subtask_2c_HMD(string display_string)
    {
        ShowTask(1);
        HighlightStep(2, task2StepsText);
        ursaUIManager.setOutputText(display_string);
    }
    public void on_ingress_menu_do_subtask_3a_HMD(string display_string)
    {
        ShowTask(2);
        ShowSubTask(0, task3SubPanels);
        defaultObserverEventHandler.AssignTagName("in-task3");
        ursaUIManager.setOutputText(display_string);
    }
    public void on_ingress_menu_do_subtask_3b_HMD(string display_string)
    {
        ShowTask(2);
        ShowSubTask(1, task3SubPanels);
        HighlightStep(0, task3bStepsText);
        ursaUIManager.setOutputText(display_string);
    }
    public void on_ingress_menu_do_subtask_3c_HMD(string display_string)
    {
        ShowTask(2);
        ShowSubTask(1, task3SubPanels);
        HighlightStep(1, task3bStepsText);
        defaultObserverEventHandler.AssignTagName("in-task3");
        ursaUIManager.setOutputText(display_string);
    }
    public void on_ingress_menu_do_subtask_3d_HMD(string display_string)
    {
        ShowTask(2);
        ShowSubTask(1, task3SubPanels);
        HighlightStep(2, task3bStepsText);
        ursaUIManager.setOutputText(display_string);
    }
    public void on_ingress_menu_do_subtask_4a_HMD(string display_string)
    {
        ShowTask(3);
        HighlightStep(0, task4StepsText);
        defaultObserverEventHandler.AssignTagName("in-task4");
        ursaUIManager.setOutputText(display_string);
    }

    public void on_ingress_menu_do_subtask_4b_HMD(string display_string)
    {
        ShowTask(3);
        HighlightStep(1, task4StepsText);
        ursaUIManager.setOutputText(display_string);
    }

}
