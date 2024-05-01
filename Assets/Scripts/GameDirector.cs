using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject tutorial_menus;
    public GameObject aim_menus;
    public GameObject survival_menus;
    public GameObject tutorial_obj;


    TutorialController tutorial_;
    AimGameMode aimGameMode_;
    SurvivalGameMode survivalGameMode_;


    // Start is called before the first frame update
    void Start()
    {
        tutorial_menus.SetActive(false);
        aim_menus.SetActive(false);
        survival_menus.SetActive(false);
        tutorial_ = tutorial_obj.GetComponent<TutorialController>();
        aimGameMode_ = GetComponent<AimGameMode>();
        survivalGameMode_ = GetComponent<SurvivalGameMode>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        switch(GameSceneLink.instance.challengeSelected){
            case GameHelpers.GameChallenge.GameChallenge_Tutorial:
                if (!tutorial_menus)
                {
                    tutorial_menus.SetActive(true);
                }
                if (aim_menus)
                {
                    aim_menus.SetActive(false);
                }
                if (survival_menus)
                {
                    survival_menus.SetActive(false);
                }
                tutorial_.CustomUpdate();
                break;
            case GameHelpers.GameChallenge.GameChallenge_Aim:
                if (tutorial_menus)
                {
                    tutorial_menus.SetActive(false);
                }
                if (!aim_menus)
                {
                    aim_menus.SetActive(true);
                }
                if (survival_menus)
                {
                    survival_menus.SetActive(false);
                }
                aimGameMode_.CustomUpdate(); ;
                break;
            case GameHelpers.GameChallenge.GameChallenge_Survive:
                if (tutorial_menus)
                {
                    tutorial_menus.SetActive(false);
                }
                if (aim_menus)
                {
                    aim_menus.SetActive(false);
                }
                if (!survival_menus)
                {
                    survival_menus.SetActive(true);
                }
                survivalGameMode_.CustomUpdate(); 
                break;
        }
    }
}
