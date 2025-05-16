using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int[] indexBoss = new int[3];
    void Awake()
    {
        if(Instance==null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }

    }
    public void SetIndexBoss(int id1, int id2, int id3){
        indexBoss[0] = id1;
        indexBoss[1] = id2;
        indexBoss[2] = id3;
    }
    public int[] GetIndexBoss(){
        return indexBoss;
    }
    public async void LoadScenePlay(){
        SceneManager.LoadScene(1);
        await Task.Delay(100);
        ManagerUI.Instance.HideAllUI();
    }
    public void LoadHome(){
        SceneManager.LoadScene(0);
    }
}
