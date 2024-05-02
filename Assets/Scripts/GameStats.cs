using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[System.Serializable]
public class GameStats {
    public float shotsMade_;
    public float shotsAimed_;
    public uint score_;

    public TMP_Text scoreText_;
    public TMP_Text acurracyText_;
    

    public float GetAccuracy(){
        if(0 != shotsMade_ ){
            return (shotsAimed_/shotsMade_) * 100.0f;
        }else{
            return 0;
        }
    }

    public void ShotMade(){
        shotsMade_++;
    }
    public void ShotAimed(){
        shotsAimed_++;
    }

    public void AddScore(uint score){
        score_ += score;
    }

    public void UpdateStats(){
        scoreText_.text = score_.ToString();
        acurracyText_.text = GetAccuracy().ToString() + "%";
    }

    public void ResetStats(){
        shotsAimed_ = 0;
        shotsMade_ = 0;
        score_ = 0;
    }
}
