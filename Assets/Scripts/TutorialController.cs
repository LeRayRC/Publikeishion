using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialController : MonoBehaviour
{

    public enum TutorialState{
        TutorialState_None,
        TutorialState_GrabWeapon,
        TutorialState_ShotWeapon,
        TutorialState_GrabTank,
        TutorialState_ReloadTank,
        TutorialState_ReleaseTank,
        TutorialState_FinalTest,
    }

    public TutorialState tutorialState;


    public TutorialState lastTutorialState;
    public GameObject grabWeaponCanvas;
    public GameObject shotWeaponCanvas; 
    public GameObject grabTankCanvas;
    public GameObject reloadTankCanvas;
    public GameObject releaseTankCanvas;
    public GameObject finalTestCanvas;

    //State Grab Weapo
    public TMP_Text grabWeaponText;
    public bool firstGrabbedWeapon;
    public int task_weaponGrabbedTimesGoal;
    public int weaponGrabbedTimes;


    //State Shoot Weapon
    public bool firstTimeEmptyTank;

    //State Grab Tank
    public bool firstTimeGrabbedTank;
    void Start()
    {
        firstGrabbedWeapon = false;
        firstTimeGrabbedTank = false;
        firstTimeEmptyTank = false;
        tutorialState = TutorialState.TutorialState_GrabWeapon;
        lastTutorialState = tutorialState;
    }

    // Update is called once per frame
    void Update(){
        switch(tutorialState){
            case TutorialState.TutorialState_GrabWeapon:
                
                break;
            case TutorialState.TutorialState_ShotWeapon:{
                // if(state_shootWeaponCompleted){
                    // tutorialState = TutorialState.TutorialState_GrabTank;
                // }
                break;
            }
            case TutorialState.TutorialState_GrabTank:{
                Debug.Log("Grab Tank State");
                // if(state_shootWeaponCompleted){
                //     tutorialState = TutorialState.TutorialState_GrabTank;
                // }
                break;
            }
        }
        
    }

    public IEnumerator GrabWeapon_SecondScreen(float delay){
        while(delay >= 0.0f){
            delay -= Time.deltaTime;
            yield return null;
        }
        weaponGrabbedTimes = 0;
        grabWeaponText.text = "Grab the weapon and release it " + task_weaponGrabbedTimesGoal + " times.";
    }

    public IEnumerator ChangeStateWithDelay(float delay, TutorialState state){
        while(delay >= 0.0f){
            delay -= Time.deltaTime;
            yield return null;
        }
        lastTutorialState = tutorialState;
        tutorialState = state;
        EnableCanvas(tutorialState);
        DisableCanvas(lastTutorialState);
    }

    public void WeaponGrabbed(){
        if(!firstGrabbedWeapon){
            firstGrabbedWeapon = true;
            StartCoroutine(GrabWeapon_SecondScreen(1.0f));
        }else{
            weaponGrabbedTimes++;
            if(weaponGrabbedTimes == task_weaponGrabbedTimesGoal){
                StartCoroutine(ChangeStateWithDelay(1.5f, TutorialState.TutorialState_ShotWeapon));
            }
        }
    }

    public void EmptyTank(){
        if(!firstTimeEmptyTank){
            firstTimeEmptyTank = true;
            StartCoroutine(ChangeStateWithDelay(1.5f, TutorialState.TutorialState_GrabTank));
        }
    }

    public void EnableCanvas(TutorialState state){
        switch(state){
            case TutorialState.TutorialState_GrabWeapon:
                grabWeaponCanvas.SetActive(true);
                break;
            case TutorialState.TutorialState_ShotWeapon:{
                shotWeaponCanvas.SetActive(true);
                break;
            }
            case TutorialState.TutorialState_GrabTank:{
                grabTankCanvas.SetActive(true);
                break;
            }
            case TutorialState.TutorialState_ReloadTank:{
                reloadTankCanvas.SetActive(true);
                break;
            }
            case TutorialState.TutorialState_ReleaseTank: {
                releaseTankCanvas.SetActive(true);
                break;
            } 
            case TutorialState.TutorialState_FinalTest: {
                finalTestCanvas.SetActive(true);
                break;
            }
        }
    }

    public void DisableCanvas(TutorialState state){
        switch(state){
            case TutorialState.TutorialState_GrabWeapon:
                grabWeaponCanvas.SetActive(false);
                break;
            case TutorialState.TutorialState_ShotWeapon:{
                shotWeaponCanvas.SetActive(false);
                break;
            }
            case TutorialState.TutorialState_GrabTank:{
                grabTankCanvas.SetActive(false);
                break;
            }
            case TutorialState.TutorialState_ReloadTank:{
                reloadTankCanvas.SetActive(false);
                break;
            }
            case TutorialState.TutorialState_ReleaseTank: {
                releaseTankCanvas.SetActive(false);
                break;
            } 
            case TutorialState.TutorialState_FinalTest: {
                finalTestCanvas.SetActive(false);
                break;
            }
        }
    }

    public void GrabbedTank(){
        if(!firstTimeGrabbedTank){
            firstTimeGrabbedTank = true;
            StartCoroutine(ChangeStateWithDelay(1.5f, TutorialState.TutorialState_ReloadTank));
        }
    }
}
