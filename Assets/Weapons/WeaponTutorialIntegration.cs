using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class WeaponTutorialIntegration : MonoBehaviour
{
    // Start is called before the first frame update
    public TutorialController tutorialController;
    void Start()
    {
        
    }

    void Update(){
        if(tutorialController.tutorialState == TutorialController.TutorialState.TutorialState_ShotWeapon || 
           tutorialController.tutorialState == TutorialController.TutorialState.TutorialState_ReloadTank ||
           tutorialController.tutorialState == TutorialController.TutorialState.TutorialState_FinalTest || 
           GameSceneLink.instance.challengeSelected != GameHelpers.GameChallenge.GameChallenge_Tutorial){
            GetComponent<PistolController>().canShoot = true;
        }else{
            GetComponent<PistolController>().canShoot = false;
        }
    }
    // Update is called once per frame
    public void WeaponGrabbed(){
        tutorialController.WeaponGrabbed();
    }

    public void EmptyTank(){
        tutorialController.EmptyTank();
    }
}
