using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance = null;
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
        spawnTarget();
    }

    public void spawnTarget(){
        int spawnSelected_ = Random.Range(0,spawnTRs_.Count-1);
        GameObject go_ = Instantiate<GameObject>(targetPrefab_, spawnTRs_[spawnSelected_].position, spawnTRs_[spawnSelected_].rotation);

        go_.transform.LookAt(player_.transform);
    }
}
