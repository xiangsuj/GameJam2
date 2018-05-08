using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour {

    #region GameFacade单例模式
    private static GameFacade _instance;

    public static GameFacade Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = GameObject.Find("GameFacade");
                if (obj == null) return null;
                _instance = obj.GetComponent<GameFacade>();

            }
            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        
    }

    private void Start()
    {
        InitManager();
    }

    private void Update()
    {
        UpdateManager();
    }

    private void OnDestroy()
    {
        DestroyManager();
    }

    #region Managers

    private UIManager mUIManager;
    private PlayerManager mPlayerManager;
    private GameManager mGameManager;
    private ItemManager mItemManager;
    private DoorManager mDoorManager;
    private AudioManager mAudioManager;
    private EnergyManager mEnergyManager;

    #endregion

    private void InitManager()
    {
        mUIManager=new UIManager(this);
        mPlayerManager=new PlayerManager(this);
        mGameManager=new GameManager(this);
        mItemManager=new ItemManager(this);
        mDoorManager=new DoorManager(this);
        mAudioManager=new AudioManager(this);
        mEnergyManager=new EnergyManager(this);

        mUIManager.OnInit();
        mPlayerManager.OnInit();
        mGameManager.OnInit();
        mItemManager.OnInit();
        mDoorManager.OnInit();
        mAudioManager.OnInit();
        mEnergyManager.OnInit();
    }

    private void UpdateManager()
    {
        mUIManager.Update();
        mPlayerManager.Update();
        mGameManager.Update();
        mItemManager.Update();
        mDoorManager.Update();
        mAudioManager.Update();
        mEnergyManager.Update();

    }

    private void DestroyManager()
    {
        mUIManager.OnDestroy();
        mPlayerManager.OnDestroy();
        mGameManager.OnDestroy();
        mItemManager.OnDestroy();
        mDoorManager.OnDestroy();
        mAudioManager.OnDestroy();
        mEnergyManager.OnDestroy();
    }

    #region Public Methods
    /// <summary>
    /// 开始游戏
    /// </summary>
    public void StartGame()
    {
        mGameManager.StartGame();
    }
    /// <summary>
    /// 初始化玩家数据
    /// </summary>
    public void InitPlayerData()
    {
        mPlayerManager.InitRole();
        mPlayerManager.RandomPos(RoleType.P1);
        mPlayerManager.RandomPos(RoleType.P2);
    }

    public void StartEnergySystem()
    {
        mEnergyManager.StartEnergySystem();
    }

    public void GameOver()
    {
       
        mGameManager.GameOver();
        mUIManager.PushPanel(UIPanelType.GameOver);
    }
    #endregion
}
