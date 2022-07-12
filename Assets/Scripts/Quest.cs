using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Quest : MonoBehaviour
{
    [SerializeField] string[] tasks = new string[5] { "Поднять ключи", "2", "3", "4", "5" };
    [SerializeField] private TMP_Text currentTask = default;
    [SerializeField] public GameObject[] objectForEndTask;

    private int current_task = 0; 

    void Awake() 
    {
        UpdateTask();
    }

    void OnTriggerEnter(Collider obj) {
        if (obj.GetComponent<Collider>().name == objectForEndTask[current_task].name)
        {
            current_task += 1;
            UpdateTask();
        }
    }

    private void UpdateTask()
    {
        currentTask.SetText(tasks[current_task]);
    }
}
