using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneLink : MonoBehaviour
{
    public static GameSceneLink instance = null;
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
}
