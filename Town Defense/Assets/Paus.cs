using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paus : MonoBehaviour
{
    [SerializeField] private GameObject stopPanel;
    public void Stop()
    {
        Time.timeScale = 0f;
        stopPanel.SetActive(true);
    }
    public void Play()
    {
        Time.timeScale = 1f;
        stopPanel.SetActive(false);
    }
}
