using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectItemSpUI : BaseScreenUI
{
    [SerializeField] Button btnGetTeleport;
    [SerializeField] Button btnNextBot;
    [SerializeField] Button btnMiss;

    void Start()
    {
        btnGetTeleport.onClick.AddListener(GetTeleport);
        btnNextBot.onClick.AddListener(NextBot);
        btnMiss.onClick.AddListener(Miss);
    }

    private void Miss()
    {
        Debug.Log("Choi map:"+ManagerUI.Instance.index);
        ManagerUI.Instance.Play();
        
        // ManagerUI.Instance.PlayScene();
    }

    private void NextBot()
    {
        Debug.Log("NextBot");
    }

    private void GetTeleport()
    {
        Debug.Log("Get teleport");
    }
}
