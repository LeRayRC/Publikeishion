using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[System.Serializable]
public class GameStats {
    public float shotsMade_;
    public float shotsAimed_;
    public float score_;

    public TMP_Text scoreText_;
    public TMP_Text acurracyText_;
    public TMP_Text newRecordText_;
    

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

    public void AddScore(float score){
        score_ += score;
    }

    public void UpdateStats(){
        scoreText_.text = Mathf.FloorToInt(score_).ToString();
        acurracyText_.text = GetAccuracy().ToString("F2") + "%";

        if(score_ > GameSceneLink.instance.highestScore_){
            newRecordText_.gameObject.SetActive(true);
            GameSceneLink.instance.highestScore_ = score_;
            GameSceneLink.instance.SaveHighestScore(score_);
            //New record text!

        }
    }

    public void ResetStats(){
        shotsAimed_ = 0;
        shotsMade_ = 0;
        score_ = 0;
    }
}
