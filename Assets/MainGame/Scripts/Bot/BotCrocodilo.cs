using System.Collections;
using UnityEngine;

public class BotCrocodilo : MonoBehaviour
{
    public GameObject[] gameObjects;

    void Start()
    {
        StartCoroutine(PlayAnim());
    }
    public void SwitchState(bool value){
        gameObjects[0].SetActive(value);
        gameObjects[1].SetActive(!value);
    }
    public IEnumerator PlayAnim(){
        while(true){
            SwitchState(true);
            yield return new WaitForSeconds(1f);
            SwitchState(false);
            yield return new WaitForSeconds(1f);
        }
        
    }
    
}
