using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance = null;
    private int lastSpawnSelected_;
    public List<Transform> spawnTRs_ = new List<Transform>();
    public GameObject targetPrefab_;
    public GameObject player_;
    public GameObject impactTargetFX_;
    public GameObject impacTargetSound_;

    public GameObject UiGameobject_;
    
    public uint currentScore_;
    public uint highestScore_;

    public TMP_Text currentScoreText_;
    public TMP_Text highestScoreText_;

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

    public void UpdateScore(uint score){
        currentScore_ += score;
        if (currentScore_ > highestScore_){
           highestScore_ = currentScore_; 
           highestScoreText_.text = highestScore_.ToString();
        }
        //Update Text
        currentScoreText_.text = currentScore_.ToString();
    }

    public void ResetScore(){
        currentScore_ = 0;
        highestScore_ = 0;
        highestScoreText_.text = highestScore_.ToString();
        currentScoreText_.text = currentScore_.ToString();
    }
}
