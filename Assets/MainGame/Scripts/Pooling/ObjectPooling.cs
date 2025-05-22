using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> listPooling;
    public Transform limitA;
    public Transform limitB;

    public GameObject GetObjectPooling(){
        foreach(var item in listPooling){
            if(!item.activeSelf){
                return item;
            }
        }
        GameObject go = Instantiate(prefab,transform);
        return go;
    }


}
