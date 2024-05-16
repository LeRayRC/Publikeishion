using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneLink : MonoBehaviour
{
    public static GameSceneLink instance = null;
    public float highestScore_;
    // Start is called before the first frame update
    public GameHelpers.GameChallenge challengeSelected;

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

    void Start(){
        //Load highscore;
        if(PlayerPrefs.HasKey("highestScore")){
            highestScore_ = PlayerPrefs.GetFloat("highestScore");
        }else{
            PlayerPrefs.SetFloat("highestScore",0.0f);
            highestScore_ =0.0f;
        }
    }

    public void SaveHighestScore(float score){
        PlayerPrefs.SetFloat("highestScore",score);
    }
}
