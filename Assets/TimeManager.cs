using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] static float _slowdownFactor = 0.2f;
    [SerializeField] static float _slowdownDuration = 0.5f;
    [SerializeField] static float _transitionTime = 0.1f;

    private static float _timeToEndSlowdown = 0f;

    public static void SlowDown(float factor, float duration)
    {
        DOTween.To(x => Time.timeScale = x, Time.timeScale, factor, _transitionTime);
        _timeToEndSlowdown = Time.time + duration;
    }

    public static void SlowDown()
    {
        SlowDown(_slowdownFactor, _slowdownDuration);
    }

    private void Update()
    {
        if (Time.time >= _timeToEndSlowdown)
        {
            EndSlowdown();
        }   
    }

    private void EndSlowdown()
    {
        DOTween.To(x => Time.timeScale = x, Time.timeScale, 1f, _transitionTime);
    }
}
