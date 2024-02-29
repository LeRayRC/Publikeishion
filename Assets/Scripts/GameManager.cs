using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance = null;
    private int lastSpawnSelected_;
    public List<Transform> spawnTRs_ = new List<Transform>();
    public GameObject targetPrefab_;
    public GameObject player_;


    void Awake(){
        //Check if instance already exists
        if (instance == null){
            instance = this;
        }else if (instance != this){
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        lastSpawnSelected_ = 0;
        spawnTarget();
    }

    public void spawnTarget(){
        int spawnSelected_;
        do{
            spawnSelected_ = Random.Range(0,spawnTRs_.Count-1);
        }while(spawnSelected_ == lastSpawnSelected_);
        GameObject go_ = Instantiate<GameObject>(targetPrefab_, spawnTRs_[spawnSelected_].position, spawnTRs_[spawnSelected_].rotation);
        go_.transform.LookAt(player_.transform);
        lastSpawnSelected_ = spawnSelected_;
    }
}
