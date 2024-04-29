using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance = null;
    private int lastSpawnSelected_;
    public List<Transform> spawnTRs_ = new List<Transform>();
    public GameObject targetSpawner_;
    public GameObject targetPrefab_;
    public GameObject player_;
    public GameObject impactTargetFX_;
    public GameObject impacTargetSound_;

    public GameObject UiGameobject_;
    
    public uint currentScore_;
    public uint highestScore_;

    public TMP_Text currentScoreText_;
    public TMP_Text highestScoreText_;

    public RectTransform MainMenuShiftedPosition_;
    public MainMenuController menuController_;

    public List<Sprite> controlImagesList_ = new List<Sprite>();
    public GameObject controlImage_;

    public GameHelpers.GameMenu currentActiveMenu;
    public GameHelpers.GameMenu previousActiveMenu;

    public GameObject playMenu;
    public GameObject controlsMenu;
    public GameObject settingsMenu;
    public GameObject creditsMenu;
    public GameObject navigationMenu;
    public TMP_Text playChallengeDescription;
    public bool isMenuActive;

    public TutorialController tutorialController;
    void Awake(){
        //Check if instance already exists
        if (instance == null){
            instance = this;
        }else if (instance != this){
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        lastSpawnSelected_ = 0;
        
        //spawnTarget();
        isMenuActive = true;
    }

    

    public void spawnTarget(){
        Collider collider_ = targetSpawner_.GetComponent<Collider>();
        Vector3 spawnPosition = new Vector3(
            Random.Range(collider_.bounds.min.x,collider_.bounds.max.x),
            Random.Range(collider_.bounds.min.y,collider_.bounds.max.y),
            Random.Range(collider_.bounds.min.z,collider_.bounds.max.z)
        );

        /*
        int spawnSelected_;
        do{
            spawnSelected_ = Random.Range(0,spawnTRs_.Count-1);
        }while(spawnSelected_ == lastSpawnSelected_);
        */
        GameObject go_ = Instantiate<GameObject>(targetPrefab_, spawnPosition,Quaternion.identity);
        go_.transform.LookAt(player_.transform);
        //lastSpawnSelected_ = spawnSelected_;
    }

    public void UpdateScore(uint score){
        currentScore_ += score;
        if (currentScore_ > highestScore_){
           highestScore_ = currentScore_; 
           highestScoreText_.text = highestScore_.ToString();
        }
        //Update Text
        currentScoreText_.text = currentScore_.ToString();
    }

    public void ResetScore(){
        currentScore_ = 0;
        currentScoreText_.text = currentScore_.ToString();
    }

    public void SetActiveMenu(GameHelpers.GameMenu menu){
        previousActiveMenu = currentActiveMenu;
        DisableMenu(previousActiveMenu);
        switch(menu){
            case GameHelpers.GameMenu.GameMenu_PlayMenu:{
                currentActiveMenu = GameHelpers.GameMenu.GameMenu_PlayMenu;                
                playMenu.SetActive(true);
                break;
            }
            case GameHelpers.GameMenu.GameMenu_ControlsMenu:{
                currentActiveMenu = GameHelpers.GameMenu.GameMenu_ControlsMenu;
                controlsMenu.SetActive(true);
                break;
            }
            case GameHelpers.GameMenu.GameMenu_SettingsMenu:{
                currentActiveMenu = GameHelpers.GameMenu.GameMenu_SettingsMenu;
                settingsMenu.SetActive(true);
                break;
            }
            case GameHelpers.GameMenu.GameMenu_CreditsMenu:{
                currentActiveMenu = GameHelpers.GameMenu.GameMenu_CreditsMenu;
                creditsMenu.SetActive(true);
                break;
            }
        }
    }

    public void DisableMenu(GameHelpers.GameMenu menu){
        switch(menu){
            case GameHelpers.GameMenu.GameMenu_PlayMenu:{
                playMenu.SetActive(false);
                break;
            }
            case GameHelpers.GameMenu.GameMenu_ControlsMenu:{
                controlsMenu.SetActive(false);
                break;
            }
            case GameHelpers.GameMenu.GameMenu_SettingsMenu:{
                settingsMenu.SetActive(false);
                break;
            }
            case GameHelpers.GameMenu.GameMenu_CreditsMenu:{
                creditsMenu.SetActive(false);
                break;
            }
        }
    }
}
