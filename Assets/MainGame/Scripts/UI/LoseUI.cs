using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoseUI : BaseScreenUI
{
    [SerializeField] Button playeAgain;
    [SerializeField] Button home;
    [SerializeField] TMP_Text txtTime;

    void Start()
    {
        playeAgain.onClick.AddListener(PlayAgain);
        home.onClick.AddListener(Home);
        GamePlayUI.loseGame += DisplayTime; 
        
    }

    private async void DisplayTime()
    {
        txtTime.text = "";
        await Task.Delay(100);
        txtTime.text = ManagerUI.Instance.GetTime()+" s";
    }

    private void Home()
    {
        ManagerUI.Instance.LoadHome();
    }

    private void PlayAgain()
    {
        ManagerUI.Instance.Play();
    }
}
