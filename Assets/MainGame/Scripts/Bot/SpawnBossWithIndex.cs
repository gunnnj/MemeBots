using System.Collections.Generic;
using UnityEngine;

public class SpawnBossWithIndex : MonoBehaviour
{
    [SerializeField] List<GameObject> listBoss;
    private int[] listIdBoss;
    void Start()
    {
        listIdBoss = GameManager.Instance.GetIndexBoss();
        // Spawn();

    }
    public void Spawn(){
        foreach(var item in listIdBoss){
            listBoss[item].SetActive(true);
        }
    }
}
