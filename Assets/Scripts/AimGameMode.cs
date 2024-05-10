using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AimGameMode : MonoBehaviour
{
    public float currentTime_;
    public float initDelay_;
    public float maxTime_;

    public bool isFinished_;
    public TMP_Text challengeText_;

    public GameObject menu_;
    public GameObject countdownCanvas_;
    public TMP_Text coundownText_;

    public float internalTimer_;
    public int newTargetProbability_;

    // Start is called before the first frame update
    void Start()
    {
        countdownCanvas_.SetActive(false);
        currentTime_ = maxTime_;
        isFinished_ = false;
    }

    public void CustomUpdate()
    {
        if(!isFinished_){
            if(initDelay_ > 0.0f){
                initDelay_ -= Time.deltaTime;
                //Update menu text
                challengeText_.text = "Destroy as many targets as you \n can in the given time \n\n" + (int)initDelay_;
                if(initDelay_ <= 0.0f){
                    GameManager.instance.spawnTempTarget();
                    menu_.SetActive(false);
                    countdownCanvas_.SetActive(true);
                }
            }else{
                internalTimer_ += Time.deltaTime;
                if(internalTimer_ >= 1.0f){
                    internalTimer_ = 0.0f;
                    if(Random.Range(0,10) < newTargetProbability_){
                        GameManager.instance.spawnTempTarget();
                    }
                }
                currentTime_ -= Time.deltaTime;
                int seconds = (int)(currentTime_ % 60);
                int minutes = (int)(currentTime_ / 60);
                coundownText_.text = minutes.ToString() + ":" + seconds.ToString();
                if(minutes < 1 && seconds < 30){
                    coundownText_.color = Color.red;
                }else{
                    coundownText_.color = Color.black;
                }
                if (0 >= currentTime_){
                    isFinished_ = true;
                }
            }
        }else{
            countdownCanvas_.SetActive(false);
        }
    }
}
