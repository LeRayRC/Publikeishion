using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject tutorial_menus;
    public GameObject aim_menus;
    public GameObject survival_menus;

    public GameObject scoreBoard_;
    
    AimGameMode aimGameMode_;
    SurvivalGameMode survivalGameMode_;


    // Start is called before the first frame update
    void Start()
    {
        tutorial_menus.SetActive(false);
        aim_menus.SetActive(false);
        survival_menus.SetActive(false);
        scoreBoard_.SetActive(false);
        aimGameMode_ = GetComponent<AimGameMode>();
        survivalGameMode_ = GetComponent<SurvivalGameMode>();
    }

    // Update is called once per frame
    void Update()
    {
        
        switch(GameSceneLink.instance.challengeSelected){
            case GameHelpers.GameChallenge.GameChallenge_Tutorial:
                Debug.Log("activating tutorial");
                if (!tutorial_menus.activeSelf)
                {
                    tutorial_menus.SetActive(true);
                }
                if (aim_menus.activeSelf)
                {
                    aim_menus.SetActive(false);
                }
                if (survival_menus.activeSelf)
                {
                    survival_menus.SetActive(false);
                }
                GameManager.instance.tutorialController.CustomUpdate();
                break;
            case GameHelpers.GameChallenge.GameChallenge_Aim:
                if (tutorial_menus.activeSelf)
                {
                    tutorial_menus.SetActive(false);
                }
                if (!aim_menus.activeSelf && aimGameMode_.initDelay_ > 0.0f)
                {
                    aim_menus.SetActive(true);
                }
                if (survival_menus.activeSelf)
                {
                    survival_menus.SetActive(false);
                }
                aimGameMode_.CustomUpdate();
                if(aimGameMode_.isFinished_){
                    //Retrieve stats
                    scoreBoard_.SetActive(true);
                    GameManager.instance.gameStats_.UpdateStats();
                    GameManager.instance.pistolController_.gameObject.SetActive(false);
                }
                break;
            case GameHelpers.GameChallenge.GameChallenge_Survive:
                if (tutorial_menus.activeSelf)
                {
                    tutorial_menus.SetActive(false);
                }
                if (aim_menus.activeSelf)
                {
                    aim_menus.SetActive(false);
                }
                if (!survival_menus.activeSelf)
                {
                    survival_menus.SetActive(true);
                }
                survivalGameMode_.CustomUpdate(); 
                break;
        }
    }
}
