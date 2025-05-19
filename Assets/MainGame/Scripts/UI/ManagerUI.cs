using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    [SerializeField] List<BaseScreenUI> listScreen;
    private List<GameObject> listScreenGo = new List<GameObject>();
    private GameObject currentUI;
    public static ManagerUI Instance;

    void Awake()
    {
        if(Instance==null){
            Instance = this;
        }
    }

    void Start()
    {
        foreach(var item in listScreen){
            currentUI = Instantiate(item.gameObject,transform);
            listScreenGo.Add(currentUI);
        }
        ShowUI(Screen.SelectBossUI);
    }

    public void HideAllUI(){
        foreach(var item in listScreenGo){
            item.SetActive(false);
        }
    }
    public GameObject GetLoseUI(){
        return listScreenGo[0];
    }

    public void ChangeBoss()
    {
        Debug.Log("ChangeBoss");
    }

    public void Continue()
    {
        Debug.Log("Show UI select map");
    }

    public void Play()
    {
        GameManager.Instance.LoadScenePlay();
    }

    public void LoadHome()
    {
        GameManager.Instance.LoadHome();
    }
    public void ShowUI(Screen screen){
        HideAllUI();
        listScreenGo[(int)screen].SetActive(true);
    }
    public enum Screen{
        LoseUI,
        SelectBossUI,
        SelectMapUI,
        SelectItemSpUI,
        GamePlayUI
        
    }
}
