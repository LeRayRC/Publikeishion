using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.State;

public class WaterTankTutorialIntegration : MonoBehaviour
{
    // Start is called before the first frame update
    public TutorialController tutorialController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tutorialController.tutorialState == TutorialController.TutorialState.TutorialState_GrabTank ||
           tutorialController.tutorialState == TutorialController.TutorialState.TutorialState_ReloadTank ||
           tutorialController.tutorialState == TutorialController.TutorialState.TutorialState_ReleaseTank ||
           tutorialController.tutorialState == TutorialController.TutorialState.TutorialState_FinalTest || 
           GameSceneLink.instance.challengeSelected != GameHelpers.GameChallenge.GameChallenge_Tutorial){
            GetComponent<XRGrabInteractable>().enabled = true;
        }else{
            GetComponent<XRGrabInteractable>().enabled = false;
        }
    }

    public void GrabbedTank(){
        tutorialController.GrabbedTank();
    }

    public void ReloadedTank(){
        tutorialController.ReloadedTank();
    }

    public void ReleaseTank(){
        tutorialController.ReleaseTank();
    }
}
