using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//本地所有数据加载，预备入口
public class GameLocalDataManager {

    public static GameLocalDataManager Instance;

    public bool localDataIsReady=false;

    public bool gameIsRuning = false;

    public static void InitAllLocalData()
    {
        Instance = new GameLocalDataManager();
        Instance.InitData();
    }

    void InitData()
    {

        //模板数据,角色模板，技能，技能表，技能升级表

        //1 角色模板-出生及升级
        CharacterModelManager.Init();

        //2 技能
        CharacterMuGongManager.Init();
        CharacterMuGongManager.Instance.CheckRndVal();
        //CharacterMuGongManager.Instance.CheckAllMuGongTemplateRndVal();

        //3 奇物
        WeaponModelManager.Init();

        //4 怪物数据
        MonsterTemplateManager.Init();
        MonsterTemplateManager.Instance.CheckTemplateIsOk();

        //4 道具

        //5 本地角色
        PlayerManager.Init();




        //角色数据


        localDataIsReady = true;
    }

}
