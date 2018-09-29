﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(TimeOfDay))]
public class TimeOfDayEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Add time"))
        {
            ((TimeOfDay)target).AddTimeEditor(new TimeOfDay.Time()
            {
                sunRotation = GameObject.Find("Sun").transform.rotation
            });
        }

        if (GUILayout.Button("To Morning")) ((TimeOfDay)target).SetTimeOfDay("Morning");
        if (GUILayout.Button("To Afternoon")) ((TimeOfDay)target).SetTimeOfDay("Afternoon");
        if (GUILayout.Button("To Night")) ((TimeOfDay)target).SetTimeOfDay("Night");

    }
}
#endif

public class TimeOfDay : MonoBehaviour
{
    [System.Serializable]
    public class Time
    {
        public string name;
        public Quaternion sunRotation;
    }

    [SerializeField] private Transform sun;
    [SerializeField] private float transitionDuration = 0.5f;
    [SerializeField] private Time[] times;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTimeOfDay(string name)
    {
        SetTimeOfDay(GetTimeByName(name));
    }

    private void SetTimeOfDay(Time time)
    {
        sun.DORotateQuaternion(time.sunRotation, transitionDuration)
            .SetEase(Ease.InOutCubic);
    }

    private Time GetTimeByName(string name)
    {
        foreach (Time time in times)
        {
            if (time.name == name)
            {
                return time;
            }
        }

        throw new System.IndexOutOfRangeException();
    }

#if UNITY_EDITOR
    public void AddTimeEditor(Time time)
    {
        times = times.Concat(new Time[] { time }).ToArray();
    }
#endif
}
