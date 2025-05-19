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

    public void SetTime(int time){
        txtTime.text = time+" s";
    }
    private void DisplayTime()
    {
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
