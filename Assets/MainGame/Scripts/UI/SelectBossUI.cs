using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class SelectBossUI : BaseScreenUI
{
    [SerializeField] Button btnContinue;
    [SerializeField] Button btnChangeAll;
    public Action changeBoss;

    async void Start()
    {
        btnContinue.interactable = false;
        btnContinue.onClick.AddListener(Continue);
        btnChangeAll.onClick.AddListener(ChangeAll);
        await Task.Delay(2000);
        btnContinue.interactable = true;
    }

    private async void ChangeAll()
    {
        Debug.Log("Change all boss");
        btnContinue.interactable = false;
        changeBoss?.Invoke();
        await Task.Delay(2000);
        btnContinue.interactable = true;
    }

    private void Continue()
    {
        ManagerUI.Instance.ShowUI(ManagerUI.Screen.SelectMapUI);
    }
}
