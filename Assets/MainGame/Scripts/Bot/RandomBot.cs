using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RandomBot : MonoBehaviour
{
    [SerializeField] List<GameObject> listBoss;
    [SerializeField] Transform[] listPos;
    private GameObject goParent;
    public List<GameObject> listBossGo = new List<GameObject>();
    public SelectBossUI selectBossUI;
    int ran1 = 0;
    int ran2 = 0;
    int ran3 = 0;

    async void Start()
    {
        if(goParent==null){
            goParent = new GameObject("goParent");
        }

        SpawnModelBoss();

        await Task.Delay(1000);
        selectBossUI = FindFirstObjectByType<SelectBossUI>();
        selectBossUI.changeBoss += RunCoroutin;

        RunCoroutin();
    }

    public void SpawnModelBoss(){
        foreach(var item in listBoss){
            GameObject bossGo = Instantiate(item, goParent.transform);
            listBossGo.Add(bossGo);
            bossGo.SetActive(false);
        }
    }

    public void OnDestroy()
    {
        DestroyImmediate(goParent);
    }
    [ContextMenu("Ran1")]
    public void RunCoroutin(){
        StartCoroutine(RandomIndex());
    }
    public IEnumerator RandomIndex(){
        
        int count  = 10;
        
        listBossGo[ran1].SetActive(false);
        listBossGo[ran2].SetActive(false);
        listBossGo[ran3].SetActive(false);
        
        while(count>0){

            do{
                ran1 = Random.Range(0,listBoss.Count);
            }while(listBossGo[ran1].activeSelf);

            listBossGo[ran1].SetActive(true);
            
            do{
                ran2 = Random.Range(0,listBoss.Count);
            }while(listBossGo[ran2].activeSelf);
            
            listBossGo[ran2].SetActive(true);

            do{
                ran3 = Random.Range(0,listBoss.Count);
            }while(listBossGo[ran3].activeSelf);
            
            listBossGo[ran3].SetActive(true);

            listBossGo[ran1].transform.position = listPos[0].position;
            
            listBossGo[ran2].transform.position = listPos[1].position;
            
            listBossGo[ran3].transform.position = listPos[2].position;
            
            yield return new WaitForSeconds(0.2f);

            listBossGo[ran1].SetActive(false);
            listBossGo[ran2].SetActive(false);
            listBossGo[ran3].SetActive(false);

            count--;
        
        }

        listBossGo[ran1].SetActive(true);
        listBossGo[ran2].SetActive(true);
        listBossGo[ran3].SetActive(true);

        GameManager.Instance.SetIndexBoss(ran1,ran2,ran3);
        
    }
    

}
