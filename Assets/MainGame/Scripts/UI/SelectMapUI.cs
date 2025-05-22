using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectMapUI : BaseScreenUI
{
    [SerializeField] Button btnPlay;
    public int indexMap;

    void Start()
    {
        btnPlay.onClick.AddListener(Play);
        btnPlay.interactable = false;
    }

    private void Play()
    {
        // ManagerUI.Instance.Play();
        ManagerUI.Instance.ShowUI(ManagerUI.Screen.SelectItemSpUI);
    }
    public void ActiveBtnPlay(){
        btnPlay.interactable = true;
    }
}
