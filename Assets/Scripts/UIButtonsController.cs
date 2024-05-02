using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonsController : MonoBehaviour
{
    public GameHelpers.GameMenu menu;
    public GameHelpers.GameChallenge challenge;
    // public void ResetScore(){
        // GameManager.instance.ResetScore();
    // }

    public void InteractWithMainMenu(){
        GameManager.instance.menuController_.InteractMainMenu(GameManager.instance.MainMenuShiftedPosition_, menu);
    }

    public void SetControlImage(int id){
        GameManager.instance.controlImage_.GetComponent<Image>().sprite = GameManager.instance.controlImagesList_[id];
    }

    public void SelectChallange(){
        switch(challenge){
            case GameHelpers.GameChallenge.GameChallenge_Aim:
                GameManager.instance.playChallengeDescription.text = 
                    "How many targets can you destroy?";
                GameSceneLink.instance.challengeSelected = GameHelpers.GameChallenge.GameChallenge_Aim;
                break;
            case GameHelpers.GameChallenge.GameChallenge_Survive:
                GameManager.instance.playChallengeDescription.text = 
                    "Destroy targets to keep playing";
                GameSceneLink.instance.challengeSelected = GameHelpers.GameChallenge.GameChallenge_Survive;
                break;
            case GameHelpers.GameChallenge.GameChallenge_Tutorial:
                GameManager.instance.playChallengeDescription.text = 
                    "Learn the game basics";
                GameSceneLink.instance.challengeSelected = GameHelpers.GameChallenge.GameChallenge_Tutorial;
                break;
        }
    }

    public void PlayChallenge(){
        if(GameSceneLink.instance.challengeSelected != GameHelpers.GameChallenge.GameChallenge_None){
            SceneManager.LoadScene(1);
        }else{
            GameManager.instance.playChallengeDescription.text = 
                    "Select a challenge";
        }
    }

    public void ReturnToMainMenu(){
        SceneManager.LoadScene(0);
    }
}


