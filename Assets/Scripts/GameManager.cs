using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Splines;

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
    
    [SerializeField]
    public GameStats gameStats_ = new GameStats();

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
    public PistolController pistolController_;

    public List<SplineContainer> targetsSplines_ = new List<SplineContainer>();

    public List<TargetPointsController> targetPointsList_ = new List<TargetPointsController>();

    public int targetCount_;
    public bool gamePaused_;


    
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
        gamePaused_ = false;
        lastSpawnSelected_ = 0;
        gameStats_.ResetStats();
        //spawnTarget();
        targetCount_ = 0;
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
        go_.GetComponent<TargetController>().init();
        
        targetCount_++;
        //lastSpawnSelected_ = spawnSelected_;
    }

    public void spawnTempTarget(){
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
        TargetController targetController_ = go_.GetComponent<TargetController>();
        targetController_.init();
        targetController_.isTemporal_ = true;


        targetCount_++;
        //lastSpawnSelected_ = spawnSelected_;
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

    public void ActivateTargetPoint(float score, Vector3 pos){
        for(int i=0;i<targetPointsList_.Count;i++){
            if(!targetPointsList_[i].inUse_){
                targetPointsList_[i].Activate(score,pos);
                break;
            }
        }
    }
}
