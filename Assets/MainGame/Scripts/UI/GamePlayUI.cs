using System;
using System.Collections;
using System.Globalization;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUI : BaseScreenUI
{
    public Image loseScreen;
    public TMP_Text txtTime;
    public Action onJump;
    public Action onHand;
    public Button btnJump;
    public Button btnHand;
    public RectTransform[] arrows;
    
    private LoseUI loseUI;
    private Coroutine coroutine;
    private int time = 0;

    //event
    public delegate void DisplayHand(bool value);
    public static DisplayHand displayHand;
    public delegate void LoseGame();
    public static LoseGame loseGame;
    //

    void OnEnable()
    {
        displayHand += PopUpHand;
        loseGame +=DisplayLoseGame;
    }
    void OnDisable()
    {
        displayHand -= PopUpHand;
        loseGame -= DisplayLoseGame;
    }
    void Start()
    {
        
        btnHand.gameObject.SetActive(false);
        btnJump.onClick.AddListener(Jump);
        btnHand.onClick.AddListener(Handle);
        
        coroutine = StartCoroutine(CountingTime());
        
        loseUI = ManagerUI.Instance.GetLoseUI().GetComponent<LoseUI>();

    }

    private async void DisplayLoseGame()
    {
        loseScreen.gameObject.SetActive(true);
        Color color = loseScreen.color;
        color.a = Mathf.Clamp01(0.6f);
        StopCoroutine(coroutine); 
        loseUI.SetTime(time);
        await Task.Delay(1000);
        loseScreen.color = color;
        PopUpHand(false);
        await Task.Delay(2000);
        ManagerUI.Instance.ShowUI(ManagerUI.Screen.LoseUI);
    }

    private void PopUpHand(bool value)
    {
        btnHand.gameObject.SetActive(value);
    }

    public void Handle()
    {
        if (btnHand != null){
            onHand?.Invoke();
        }
    }

    public void Jump(){
        onJump?.Invoke();
    }
    public void UpdateTime(int value){
        txtTime.text = ""+value;
    }
    public IEnumerator CountingTime(){
        time = 0;
        while(true){
            UpdateTime(time);
            yield return new WaitForSeconds(1f);
            time++;
        }
    }
    public void UpdateIndicator(int id, float angle){
        arrows[id].rotation = Quaternion.Euler(0f,0f,angle);
    }

}
