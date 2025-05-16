using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectMapUI : BaseScreenUI
{
    [SerializeField] Button btnPlay;

    void Start()
    {
        btnPlay.onClick.AddListener(Play);
    }

    private void Play()
    {
        ManagerUI.Instance.Play();
    }
}
