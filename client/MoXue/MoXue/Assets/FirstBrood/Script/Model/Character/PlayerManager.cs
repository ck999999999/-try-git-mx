using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager  {

    public static PlayerManager Instance;

    //public const float hpSeed= 3.5f;
    //public const float mpSeed= 2.5f;
    public const float fireBaseRate = 1.3f;
    public const float fireBaseRateSeed = 1.1f;

    //被选中的角色类型
    public int selectedCharType=1;

    //账号下所有角色
    public Dictionary<int, Player> playerDic = new Dictionary<int, Player>(5);

    //当前正在用的角色
    public Player localPlayer;

    public string GetNickName()
    {
       return "player_" ;
    }

    public static void Init()
    {
        Instance = new PlayerManager();
        Instance.LoadData();
    }
    public bool LocalPlayerIsMaxLevel()
    {
        return CharacterModelManager.Instance.GetCharacterTemplate(localPlayer.charType).maxLevel <= localPlayer.level;
    }
    public void CreatePlayer(int charType)
    {
        localPlayer = new Player();
        localPlayer.name=GetNickName();//昵称
        localPlayer.id=0;//唯一id
        localPlayer.guid=Guid.NewGuid().ToString();//本地生成的guid
        localPlayer.bornDateTime=DateTime.Now;//创建时间
        localPlayer.totalOnlineSecond=0;//在线时长
        localPlayer.deviceId="";
        localPlayer.lastIp="";

        CopyCharacterModelToPlayer(localPlayer, CharacterModelManager.Instance.GetCharacterTemplate(charType));

        RefreshPlayerAttribute();

        Debug.Log("LocalPlayer is ok");
    }
    public void ResetLocalPlayer()
    {
        localPlayer.Reset();
        CopyCharacterModelToPlayer(localPlayer, CharacterModelManager.Instance.GetCharacterTemplate(localPlayer.charType));

        CurrentDyAttribute(localPlayer);

        Debug.Log("ResetLocalPlayer is ok");
    }

    public void Save(PlayerOpTemp pt)
    {
        //附加属性里
        localPlayer.remainSp = pt.remainSp;
        localPlayer.strExt += pt.str;
        localPlayer.vitExt += pt.vit;
        localPlayer.dexExt += pt.dex;
        localPlayer.brainExt += pt.brain;
        //Debug.Log(" brain:" + pt.brain+ ",brainTemp:" + pt.brainTemp+ ",localPlayer.brain:"+ localPlayer.brain);
        CurrentDyAttribute(localPlayer);
    }

    /// <summary>
    /// 对应外面输出升级效果
    /// </summary>
    /// <returns></returns>
    public bool LevelUp()
    {
        if (localPlayer.exp >= localPlayer.nextExp)
        {
            //处理等级导致的属性重计
            localPlayer.level++;
            CurrentPlayerDataForLevelUp(localPlayer);
            CurrentDyAttribute(localPlayer);
            return true;
        }
        return false;
    }

    void CopyCharacterModelToPlayer(Player player, CharacterTemplate ct)
    {
        CharacterLevelTemplate clt = ct.dicCharacterLevelTemplate[1];
        //player.maxHP;//最大血量，动态
        //player.maxMP;//最大法力，动态
        //player.hp;
        //player.mp;
        //player.atk;//攻击力
        //player.def;//防御力
        //player.rate;//攻击频率
        player.exp = 0;//当前经验
        player.nextExp = clt.nextLevelExp;//下一级经验
        player.level = 1;
        player.remainSp = clt.sp;
        player.str = clt.str;
        player.dex = clt.dex;
        player.vit = clt.vit;
        player.brain = clt.brain;

        player.gen = clt.gen;
        player.gold = clt.gold;

        player.charType = ct.charType;
        player.skillId = ct.skill0Id;
        player.skillLevel = ct.skill0Level;
        player.skillId1 = ct.skill1Id;
        player.skillLevel1 = ct.skill1Level;
        player.skillId2 = ct.skill2Id;
        player.skillLevel2 = ct.skill2Level;
        player.skillId3 = ct.skill3Id;
        player.skillLevel3 = ct.skill3Level;
        player.skillId4 = ct.skill4Id;
        player.skillLevel4 = ct.skill4Level;

        player.wing = ct.wing;
        player.wingLevel = ct.wingLevel;
        player.heart = ct.heart;
        player.heartLevel = ct.heartLevel;
        player.weapon = ct.weapon;
        player.weaponLevel = ct.weaponLevel;
        //string strLog = string.Format("lv:{0},ct:{1},hp:{2},mp:{3},atk:{4},def:{5},str:{6},dex:{7},vit:{8},brain:{9},exp:{10}," +
        //    "lid0:{11},lev0:{12},lid1:{13},lev1:{14},lid2:{15},lev2:{16},lid3:{17},lev3:{18},lid4:{19},lev4:{20}",
        //    player.level, player.charType, player.hp, player.mp, player.atk, player.def, player.str, player.dex, player.vit, player.brain, player.nextExp
        //    , player.skillId, player.skillLevel
        //    , player.skillId1, player.skillLevel2
        //    , player.skillId2, player.skillLevel2
        //    , player.skillId3, player.skillLevel3
        //    , player.skillId4, player.skillLevel4
        //    );
        //Debug.Log(strLog);
    }

    void CurrentPlayerDataForLevelUp(Player player)
    {
        CharacterTemplate ct = CharacterModelManager.Instance.GetCharacterTemplate(player.charType);
        CharacterLevelTemplate clt =  ct.dicCharacterLevelTemplate[player.level];
        //player.maxHP;//最大血量，动态
        //player.maxMP;//最大法力，动态
        //player.hp;
        //player.mp;
        //player.atk;//攻击力
        //player.def;//防御力
        //player.rate;//攻击频率
        //player.exp -= player.nextExp;//扣除前经验
        player.nextExp = clt.nextLevelExp;//下一级经验
        player.remainSp += clt.sp;
        player.str += clt.str;
        player.dex += clt.dex;
        player.vit += clt.vit;
        player.brain += clt.brain;
        player.gen += clt.gen;//宝石
        player.gold += clt.gold;//金币
    }

    public void RefreshPlayerAttribute()
    {
        CurrentDyAttribute(localPlayer);
    }
    /// <summary>
    /// 重计算动态属性值
    /// </summary>
    public void CurrentDyAttribute(Player player)
    {
        PlayerAttribteLogic pal = new PlayerAttribteLogic();
        //player.attributeData;
        //pal.Clear();
        //基本属性 
        pal.level_hp = GetHP(player.GetVit(), player.GetBrain());
        pal.level_mp = GetMP(player.GetVit(), player.GetBrain(),player.GetDex()) ;
        pal.level_atk = GetAttack(player.GetStr(), player.GetDex(), player.GetVit(), player.GetBrain());
        pal.level_def = GetDef(player.GetStr(), player.GetDex(), player.GetVit(), player.GetBrain());
        pal.level_mpRestoreRate =  GetMpRestoreRate(player.level, player.GetStr(), player.GetDex(), player.GetVit(), player.GetBrain());
        pal.level_luckey = 0;
        pal.level_dig = 0;

        //技能属性 洗髓经 易筋经
        MuGongLevel mgl1 = CharacterMuGongManager.Instance.GetMuGongLevelTemplate(player.skillId, player.skillLevel);
        MuGongLevel mgl2 = CharacterMuGongManager.Instance.GetMuGongLevelTemplate(player.skillId1, player.skillLevel1);
        pal.skill_hpRestoreRate += mgl1.mp;
        pal.skill_mpRestoreRate += mgl2.mp;
        pal.skill_atk =0;
        pal.skill_def =0;
        pal.skill_luckey = 0;
        pal.skill_dig = 0;
        pal.skill_mp += mgl2.level * 10;

        //奇物属性
        WeaponLevelTemplate wlt1 = WeaponModelManager.Instance.GetWeaponLevelTemplate(player.wing, player.wingLevel);
        WeaponLevelTemplate wlt2 = WeaponModelManager.Instance.GetWeaponLevelTemplate(player.heart, player.heartLevel);
        WeaponLevelTemplate wlt3 = WeaponModelManager.Instance.GetWeaponLevelTemplate(player.weapon, player.weaponLevel);
        pal.weapon_hp += wlt1.hp;
        pal.weapon_mp += wlt1.mp;
        pal.weapon_atk += wlt1.attack;
        pal.weapon_def += wlt1.def;
        pal.weapon_decDef += wlt1.def;
        pal.weapon_luckey += wlt1.luck;
        pal.weapon_dig += wlt1.dig;

        pal.weapon_hp += wlt2.hp;
        pal.weapon_mp += wlt2.mp;
        pal.weapon_atk += wlt2.attack;
        pal.weapon_def += wlt2.def;
        pal.weapon_decDef += wlt2.def;
        pal.weapon_luckey += wlt2.luck;
        pal.weapon_dig += wlt2.dig;

        pal.weapon_hp += wlt3.hp;
        pal.weapon_mp += wlt3.mp;
        pal.weapon_atk += wlt3.attack;
        pal.weapon_def += wlt3.def;
        pal.weapon_decDef += wlt3.def;
        pal.weapon_luckey += wlt3.luck;
        pal.weapon_dig += wlt3.dig;

        //合成
        player.hp = pal.GetTotalHp();
        player.mp = pal.GetTotalMp();
        player.maxMP = player.mp;
        player.maxHP = player.hp;
        player.atk = pal.GetTotalAtk();
        player.def = pal.GetTotalDef();
        player.power = pal.GetTotalPower();
        player.dig = pal.GetTotalDig();
        player.lucky = pal.GetTotalLuckey();
        player.hpRestoreRate = pal.GetTotalRestoreHp();
        player.mpRestoreRate = pal.GetTotalRestoreMp();
        player.fireRate = GetFireRate(player.str,player.dex,player.vit,player.brain,player.level);
    }

    #region 角色的攻击,防御,HP,MP,回血,回蓝,攻击速率计算

    public int GetAttack(int strong, int dex, int vit, int brain)
    {
        return strong + strong + strong + strong + Convert.ToInt32( (dex*1.4f)) + vit + brain + vit;
    }
    public int GetDef(int strong, int dex, int vit, int brain)
    {
        return strong + dex + dex + dex + dex + vit + brain;
    }
    public int GetHP(int vit, int brain)
    {
        return vit + vit + vit + vit + vit + vit + vit + vit + vit + vit + brain;
    }
    public int GetMP(int vit, int brain,int dex)
    {
        return brain + brain + brain + brain + vit + vit + Convert.ToInt32((float)dex/1.5f); ;
    }
    public int GetFireRate(int strong, int dex, int vit, int brain,int playerLevel)
    {
        int temp = strong + dex + dex+ dex+ dex+ dex + vit + brain;
        float curRate = (fireBaseRate + fireBaseRateSeed - (temp + playerLevel / (temp + 500)))*1000;
        if (curRate < 300 || curRate > 5000) curRate = 2000;
        return System.Convert.ToInt32( curRate);
    }
    public int GetMpRestoreRate(int playerlevel, int strong, int dex, int vit, int brain)
    {//1700
        float curRate = (float)strong/170 + (float)vit/160 + (float)dex/120 + (float)brain/70 + (float)playerlevel / 20;
        return Convert.ToInt32(curRate);
    }
    #endregion

    #region temp atk,def,hp,mp,预览加四大基本属性

    public int PreviewExtHp(PlayerOpTemp pt)
    {
        return GetHP(pt.vit, pt.brain);
    }
    public int PreviewExtMp(PlayerOpTemp pt)
    {
        return GetMP(pt.vit, pt.brain,pt.dex);
    }
    public int PreviewExtAtk(PlayerOpTemp pt)
    {
        return GetAttack(pt.str, pt.dex, pt.vit, pt.brain);
    }
    public int PreviewExtDef(PlayerOpTemp pt)
    {
        return GetDef(pt.str, pt.dex, pt.vit, pt.brain);
    }

    #endregion

    #region Load and Save localdata

    public void SaveLocalPlaerData()
    {
        //Debug.Log("Save!!!!!!!!!!!!!!!!!!!!!!!!!Begin=----");
        string jsonPlayer=JsonUtility.ToJson(localPlayer);
        PlayerPrefs.SetString(localPlayer.charType.ToString(), jsonPlayer);
        //PlayerPrefs.Save();
        //Debug.Log("Save!!!!!!!!!!!!!!!!!!!!!!!!!OK============");
    }

    void LoadData()
    {
        //PlayerPrefs.DeleteAll();
        //Try load
        string jsonPlayer1 = PlayerPrefs.GetString("1");
        //string jsonPlayer2 = PlayerPrefs.GetString("2");
        //string jsonPlayer3 = PlayerPrefs.GetString("3");
        //string jsonPlayer4 = PlayerPrefs.GetString("4");
        if (null != jsonPlayer1)
        {
            if (jsonPlayer1.Length > 10)
            {
                Player player = JsonUtility.FromJson<Player>(jsonPlayer1);
                playerDic.Add(player.charType, player);
                if (1 == selectedCharType) localPlayer = player;
            }
        }
        //if (null != jsonPlayer2)
        //{
        //    if (jsonPlayer2.Length > 10)
        //    {
        //        Player player = JsonUtility.FromJson<Player>(jsonPlayer2);
        //        playerDic.Add(player.charType, player);
        //        if (2 == selectedCharType) localPlayer = player;
        //    }
        //}
        //if (null != jsonPlayer3)
        //{
        //    if (jsonPlayer3.Length > 10)
        //    {
        //        Player player = JsonUtility.FromJson<Player>(jsonPlayer3);
        //        playerDic.Add(player.charType, player);
        //        if (3 == selectedCharType) localPlayer = player;
        //    }
        //}
        //if (null != jsonPlayer4)
        //{
        //    if (jsonPlayer4.Length > 10)
        //    {
        //        Player player = JsonUtility.FromJson<Player>(jsonPlayer4);
        //        playerDic.Add(player.charType, player);
        //        if (4 == selectedCharType) localPlayer = player;
        //    }
        //}

        if (0 == playerDic.Count) CreatePlayer(1);

    }
    #endregion

}
