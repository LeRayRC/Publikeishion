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
    public InputGameController inputGameController_;
    public GameDirector gameDirector_;    // public void ResetScore(){
        // GameManager.instance.ResetScore();
    // }

    public void InteractWithMainMenu(){
        GameManager.instance.menuController_.InteractMainMenu(GameManager.instance.MainMenuShiftedPosition_, menu);
    }

    public void SetControlImage(int id){
        GameManager.instance.controlImage_.GetComponent<Image>().sprite = GameManager.instance.controlImagesList_[id];
    }

    public void InteractWithPauseNavBar(){
        GameManager.instance.SetActiveMenu(menu);
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
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void SkipIntro(){
        switch(challenge){
            case GameHelpers.GameChallenge.GameChallenge_Aim:
                Debug.Log("skipping");
                
                gameDirector_.GetComponent<AimGameMode>().StartChallenge();
                break;
            case GameHelpers.GameChallenge.GameChallenge_Survive:
                break;
        }
    }


    public void RestartLevel(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TogglePauseMenu(){
        inputGameController_.TooglePauseMenu();
    }
}


