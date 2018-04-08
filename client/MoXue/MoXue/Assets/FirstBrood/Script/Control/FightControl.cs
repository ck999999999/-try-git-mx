using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class FightControl : MonoBehaviour
{
    public static FightControl Instance;

    public Slider sliderMonsterHP;

    public Text textMonsterStatus;
    public Text textMonsterName;
    public Text textMonsterHP;
    public Text textBeginFightTimer;
    public Text textMpVal;
    public Text textMonsterExpVal;
    public Text textLvVal;
    public Text textExp;

    public Text textTotalKillCountVal;
    public Text textTotalSkillCountVal;
    public Text textTotalPhyCountVal;
    public Text textTotalFightTimeVal;

    List<MonsterTemplate> monters = null;
    int selectedMonsterIndex = 0;

    public bool IsFight = false;

    Coroutine coroutineFight = null;

    int skillSeed2;
    int skillSeed3;
    int skillSeed4;
    int skillSeedTotal;
    int skillSeedTotal2;
    int rndSkill;
    MuGongLevel skill2;
    string skillName2;
    MuGongLevel skill3;
    string skillName3;
    MuGongLevel skill4;
    string skillName4;
    string selectedSkillName;
    //选中的技能
    MuGongLevel selectedSkill;
    //选中的怪物
    MonsterTemplate selectedMonster;

    string normalState = "[<color=blue>正常</color>]";
    string dieState = "[<color=red>死亡</color>]";
    string skillDamage = "技能'{0}',伤害<color=red>{1}</color>,血量{2}";//,atk:{3},ser:{4}";
    string physDamage = "<color=white>物理</color>攻击,伤害<color=red>{0}</color>,血量{1}";//,atk:{2},ser:{3}";
    string physLuckDamage = "[<color=blue>幸运</color>]<color=white>物理</color>攻击,伤害<color=red>{0}</color>,血量{1}";//,atk:{2},ser:{3}";
    string skillLuckDamage = "[<color=blue>幸运</color>]技能'{0}',伤害<color=red>{1}</color>,血量{2}";//,atk:{3},ser:{4}";
    string normalMonsterName = "[Lv:<color=blue>{0}</color>]{1}";
    string bossMonsterName = "[Lv:<color=blue>{0}</color>]<color=blue>Boss</color>{1}";
    string monsterHpString = "<color=blue>{0}</color>";

    //正在用来计算的等级
    public bool needReCurrentSelectedMonsters = true;
    //技能等级
    public bool needReCurrentSkillSeed = true;
    //新云
    public bool needReCurrentWeapon = true;

    public Text textFight0;
    public Text textFight1;
    public Text textFight2;
    public Text textFight3;
    public Text textFight4;
    public Text textFight5;
    //奇物是否加经验伪随即
    bool[] shouldGetWeaponExp = new bool[12] { false, false, true, false, false, false, false, false, false, true, false, true };
    int shouldGetWeaponExpIndex;

    float desBroodSpeed = 100;//动态,默认为玩家攻击力 * 1.5

    //信息类
    public GameObject heroInfo;
    public GameObject fireContents;
    public GameObject monsterHP;

    //切换到其它应用
    public bool isPauseBeCancel = false;

    //攻击日志
    public string[] strAtkLog = new string[12];

    //刷新关联面板
    bool waitRefreshForCoin = false;
    bool waitRefreshForLevelUp = false;
    bool waitRefreshForWeaponExp = false;
    bool waitRefreshForKillMonster = false;
    bool waitPayMonsterDie = false;
    int frameRateVal = 33;

    public void OnApplicationPause(bool pause)
    {
        Debug.Log(" OnApplicationPause:"+ pause.ToString());
        if(!pause) isPauseBeCancel = true;
    }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        heroInfo.SetActive(false);
        fireContents.SetActive(false);
        monsterHP.SetActive(false);
    }
    public void StartWork()
    {
        skillName2 = CharacterMuGongManager.Instance.GetMuGongName(PlayerManager.Instance.localPlayer.skillId2);
        skillName3 = CharacterMuGongManager.Instance.GetMuGongName(PlayerManager.Instance.localPlayer.skillId3);
        skillName4 = CharacterMuGongManager.Instance.GetMuGongName(PlayerManager.Instance.localPlayer.skillId4);
    }
    private void Update()
    {
    }
    public string GetTotalTimesString(double totals)
    {
        string dateDiff = null;
        try
        {

            TimeSpan ts = TimeSpan.FromMilliseconds(totals);
            string dates=ts.Days.ToString(), hours = ts.Hours.ToString(), minutes = ts.Minutes.ToString(), seconds = ts.Seconds.ToString();
            if (ts.Hours < 10)
            {
                hours = "0" + ts.Hours.ToString();
            }
            if (ts.Minutes < 10)
            {
                minutes = "0" + ts.Minutes.ToString();
            }
            if (ts.Seconds < 10)
            {
                seconds = "0" + ts.Seconds.ToString();
            }
            dateDiff = "Days:" + dates +" , "+ hours + ":" + minutes + ":" + seconds;
        }
        catch
        {

        }
        return dateDiff;
    }

    int fastCount = 0;
    const int fastCountTimes= 150;
    float curBroodSpeed = 0;

    public void StartFight()
    {
        if (IsFight) return;

        ClearAttackContent();
        IsFight = true;        
        shouldGetWeaponExpIndex = UnityEngine.Random.Range(0, shouldGetWeaponExp.Length);
        coroutineFight = StartCoroutine("AuthFight");
        Thread thread = new Thread(new ThreadStart(ThreadRestoreMP));
        thread.Start();
    }
    public void StopFight()
    {
        if (!IsFight) return;
        if (null != coroutineFight) StopCoroutine(coroutineFight);
        IsFight = false;
        if (null != selectedMonster) selectedMonster.ResetHp();
    }
    //重算技能随机种子
    void ResetSkillSeed()
    {
        skill2 = CharacterMuGongManager.Instance.GetMuGongLevelTemplate(PlayerManager.Instance.localPlayer.skillId2, PlayerManager.Instance.localPlayer.skillLevel2);
        skill3 = CharacterMuGongManager.Instance.GetMuGongLevelTemplate(PlayerManager.Instance.localPlayer.skillId3, PlayerManager.Instance.localPlayer.skillLevel3);
        skill4 = CharacterMuGongManager.Instance.GetMuGongLevelTemplate(PlayerManager.Instance.localPlayer.skillId4, PlayerManager.Instance.localPlayer.skillLevel4);
        skillSeed2 = (int)skill2.seed;
        skillSeed3 = (int)skill3.seed;
        skillSeed4 = (int)skill4.seed;
        skillSeedTotal2 = skillSeed2 + skillSeed3;
        skillSeedTotal = skillSeed2 + skillSeed3 + skillSeed4;

        needReCurrentSkillSeed = false;
    }
    //计算本次该用那个技能
    bool GetRandomSkillForAtk()
    {
        rndSkill = GetSkillId();
        //三个区间
        if (rndSkill < skillSeed2)
        {
            selectedSkill = skill2;
            selectedSkillName = skillName2;
        }
        else if (rndSkill < skillSeedTotal2)
        {
            selectedSkill = skill3;
            selectedSkillName = skillName3;
        }
        else
        {
            selectedSkill = skill3;
            selectedSkillName = skillName4;
        }
        if (selectedSkill.mp > PlayerManager.Instance.localPlayer.mp) return false;
        //扣除蓝
        PlayerManager.Instance.localPlayer.mp -= selectedSkill.mp;
        return true;
    }
    //重算该对应的等级怪物群
    void ResetMonsters()
    {
        //玩家升级了,或者重新开始挂机
        monters = MonsterTemplateManager.Instance.GetMonsterTemplateByLevel(PlayerManager.Instance.localPlayer.level);
        selectedMonsterIndex = 0;
        selectedMonster = monters[selectedMonsterIndex];
        //怪物信息
        if (0 == selectedMonster.isBos)
            strMonsterName = string.Format(normalMonsterName,selectedMonster.level, selectedMonster.name);
        else
            strMonsterName = string.Format(bossMonsterName, selectedMonster.level, selectedMonster.name);
       
        needReCurrentSelectedMonsters = false;

        //sliderMonsterHP.value = 1.0f;

        desBroodSpeed = PlayerManager.Instance.localPlayer.GetPower() ;

        strMonsterExpVal = selectedMonster.exp.ToString();
    }

    void AddAttackLog(string lastAtkContent)
    {
        for (int i = strAtkLog.Length - 1; i > 0; i--)
        {
            strAtkLog[i] = strAtkLog[i - 1];
        }
        strAtkLog[0] = lastAtkContent;
    }
    void ShowAtkLog()
    {
        textFight5.text = strAtkLog[5];
        textFight4.text = strAtkLog[4];
        textFight3.text = strAtkLog[3];
        textFight2.text = strAtkLog[2];
        textFight1.text = strAtkLog[1];
        textFight0.text = strAtkLog[0];
    }
    void ClearAttackContent()
    {
        for (int i = strAtkLog.Length - 1; i > 0; i--)
        {
            strAtkLog[i] = "";
        }
        ShowAtkLog();
    }
    void ShowTotalInfo(bool show)
    {
        heroInfo.SetActive(show);
        fireContents.SetActive(show);
        monsterHP.SetActive(show);
        if (false == show) ClearAttackContent();
    }
    private List<int> MakeRndIntIndex(int valCount, int ValLen)
    {
        List<int> lst = new List<int>(valCount + 1);
        for (int i = 0; i < valCount; i++)
        {
            for (; ; )
            {
                int val = UnityEngine.Random.Range(0, ValLen);
                if (!lst.Contains(val))
                {
                    lst.Add(val);
                    break;
                }
            }
        }
        return lst;
    }
    int[] rndLuckLogic = new int[1000];
    int rndLuckLogicIndex = 0;
    int[] rndIsSkillAtk = new int[12];
    int rndIsSkillAtkIndex = 0;
    int[] rndSkillId = new int[32];
    int rndSkillIdIndex = 0;
    int[] rndGetCoin = new int[10000];
    int rndGetCoinIndex = 0;
    bool IsLuck()
    {
        int val = rndLuckLogic[rndLuckLogicIndex];
        rndLuckLogicIndex++;
        if (rndLuckLogicIndex >= rndLuckLogic.Length) rndLuckLogicIndex = 0;
        return 1 == val;
    }
    bool IsSkillAtk()
    {
        int val = rndIsSkillAtk[rndIsSkillAtkIndex];
        rndIsSkillAtkIndex++;
        if (rndIsSkillAtkIndex >= rndIsSkillAtk.Length) rndIsSkillAtkIndex = 0;
        return 1 == val;
    }
    int GetSkillId()
    {
        int val = rndSkillId[rndSkillIdIndex];
        rndSkillIdIndex++;
        if (rndSkillIdIndex >= rndSkillId.Length) rndSkillIdIndex = 0;
        return val;
    }
    bool IsGetCoin()
    {
        int val = rndGetCoin[rndGetCoinIndex];
        rndGetCoinIndex++;
        if (rndGetCoinIndex >= rndGetCoin.Length) rndGetCoinIndex = 0;
        return 1 == val;
    }
    bool IsGetWeaponExp()
    {
        bool val = shouldGetWeaponExp[shouldGetWeaponExpIndex];
        shouldGetWeaponExpIndex++;
        if (shouldGetWeaponExpIndex >= shouldGetWeaponExp.Length) shouldGetWeaponExpIndex = 0;
        return val;
    }
    //随机值
    public void MakeAllRndArray()
    {
        MakeLuckRndArray();
        MakeSkillAtkRndArray();
        MakeSkillIdRndArray();
        MakeCoinRndArray();
    }
    void MakeLuckRndArray()
    {
        //是否luck
        for (int i = 0; i < rndLuckLogic.Length; i++)
        { rndLuckLogic[i] = 0; }
        int luck = PlayerManager.Instance.localPlayer.lucky + PlayerManager.Instance.localPlayer.skillLevel;
        List<int> valLuck = MakeRndIntIndex(luck, 1000);
        for (int i = 0; i < valLuck.Count; i++)
        {
            rndLuckLogic[valLuck[i]] = 1;
        }
    }
    void MakeSkillAtkRndArray()
    {
        //是否skillAtk
        for (int i = 0; i < rndIsSkillAtk.Length; i++)
        { rndIsSkillAtk[i] = 0; }

        List<int> valSkillAtk = MakeRndIntIndex(9, 12);
        for (int i = 0; i < valSkillAtk.Count; i++)
        {
            rndIsSkillAtk[valSkillAtk[i]] = 1;
        }
    }
    void MakeSkillIdRndArray()
    {
        //选用的技能
        for (int i = 0; i < rndSkillId.Length; i++)
        { rndSkillId[i] = 0; }
        for (int i = 0; i < rndSkillId.Length; i++)
        {
            rndSkillId[i] = UnityEngine.Random.Range(0, skillSeedTotal);
        }
    }
    void MakeCoinRndArray()
    { 
        //coin
        for (int i = 0; i < rndGetCoin.Length; i++)
        { rndGetCoin[i] = 0; }
        int dig = PlayerManager.Instance.localPlayer.dig;
        List<int> valCoin = MakeRndIntIndex(dig, 10000);
        for (int i = 0; i < valCoin.Count; i++)
        {
            rndGetCoin[valCoin[i]] = 1;
        }
    }

    //显示player信息
    void ShowAllTextContent()
    {
        textTotalFightTimeVal.text = GetTotalTimesString(PlayerManager.Instance.localPlayer.totalTimes);
        textTotalSkillCountVal.text = PlayerManager.Instance.localPlayer.skillKill.ToString();
        textTotalPhyCountVal.text = PlayerManager.Instance.localPlayer.phyKill.ToString();
        textTotalKillCountVal.text = PlayerManager.Instance.localPlayer.totalKill.ToString();
        textExp.text = PlayerManager.Instance.localPlayer.exp.ToString() + "/" + PlayerManager.Instance.localPlayer.nextExp.ToString();
        textLvVal.text = PlayerManager.Instance.localPlayer.level.ToString();
        //textMpVal.text = PlayerManager.Instance.localPlayer.mp.ToString();
        textMonsterExpVal.text = strMonsterExpVal;
        textMonsterName.text = strMonsterName;
        //textMonsterHP.text = strMonsterHP;随进度条显示
    }
    void ShowMonsterHP()
    {
        textMonsterHP.text = string.Format(monsterHpString, System.Convert.ToInt32(selectedMonster.toHp));  //实时更新
        sliderMonsterHP.value = (float)selectedMonster.toHp / (float)selectedMonster.maxHP;
        textMpVal.text = System.Convert.ToInt32(PlayerManager.Instance.localPlayer.mp).ToString();//实时更新
        if(0< selectedMonster.toHp)
            textMonsterStatus.text = normalState;
        else
            textMonsterStatus.text = dieState;
    }
    string strMonsterExpVal = "";
    string strMonsterName = "";
    void RefreshOtherControlInfo()
    {
        if (waitRefreshForCoin)
        {
            waitRefreshForCoin = false;
            SoundManager.Instance.GetCoin();
            HeadAndCoinsControl.Instance.RefreshCoin();
            ShopWndControl.Instance.Refresh();
        }
        if (waitRefreshForLevelUp)
        {
            waitRefreshForLevelUp = false;
            CharacterAttributeControl.Instance.PlayLevelUp();
            SoundManager.Instance.LevelUp();
            HeadAndCoinsControl.Instance.RefreshGen();            
        }
        if (waitRefreshForWeaponExp)
        {
            waitRefreshForWeaponExp = false;
            WeaponWndControl.Instance.Refresh(WeaponType.all);            
        }
        if (waitRefreshForKillMonster)
        {
            waitRefreshForKillMonster = false;
            HeadAndCoinsControl.Instance.RefreshGold();            
        }
        if (waitPayMonsterDie)
        {
            waitPayMonsterDie = false;
            SoundManager.Instance.SpriteDie();            
        }
    }
    IEnumerator AuthRestore()
    {
        while (IsFight)
        {
            yield return new WaitForFixedUpdate();
            ShowMonsterHP();
            ShowAllTextContent();
            //技能组是否需要重计
            if (needReCurrentSkillSeed)
            {
                //技能种子重算
                ResetSkillSeed();
                MakeSkillAtkRndArray();
            }
            if (needReCurrentWeapon)
            {
                MakeLuckRndArray();
                MakeCoinRndArray();
            }
            ShowAtkLog();
            RefreshOtherControlInfo();
        }
        ShowTotalInfo(false);
    }
    void ThreadRestoreMP()
    {
        float rate = 0.03f;
        while (IsFight || !PlayerManager.Instance.localPlayer.IsFullMP())
        {
            //恢复蓝
            //float rate = Time.deltaTime;
            PlayerManager.Instance.localPlayer.RestoreMP(rate);
            float curDesBroodSpeed = desBroodSpeed;

            if (null != selectedMonster)
            {
                if (0 < selectedMonster.toHp)
                {
                    if (selectedMonster.toHp > selectedMonster.hp)
                    {
                        if (fastCount < fastCountTimes)
                        {
                            if (0 == fastCount)
                            {
                                curBroodSpeed = curDesBroodSpeed + curDesBroodSpeed;
                            }
                            else if (0 == (fastCount % 10))
                            {
                                curBroodSpeed = curBroodSpeed + curDesBroodSpeed;
                            }
                            fastCount++;
                        }
                        curDesBroodSpeed = curBroodSpeed;
                        selectedMonster.toHp = selectedMonster.toHp - Mathf.CeilToInt(curDesBroodSpeed * rate);
                        if (selectedMonster.toHp < selectedMonster.hp) selectedMonster.toHp = selectedMonster.hp;

                        if (selectedMonster.toHp <= 0) fastCount = 0;
                    }
                    else
                    {
                        fastCount = 0;
                    }
                }
            }
            Thread.Sleep(frameRateVal);
        }
    }
    const int rndValLen = 12;
    float[] arrayEffectVal = new float[rndValLen];
    int indexRndEffectVal = 0;
    float bastPhyEffectVal = 1.0f;
    public void MakeRndEffectVal()
    {
        List<float> effectVals = MakeRndVal(0.8f, 1.2f);
        for (int i = 0; i < rndValLen; i++)
        {
            arrayEffectVal[i] = effectVals[i];
        }
    }
    public float GetRndEffectVal()
    {
        float val = arrayEffectVal[indexRndEffectVal];
        indexRndEffectVal++;
        if (indexRndEffectVal >= rndValLen) indexRndEffectVal = 0;
        return val;
    }
    private List<float> MakeRndVal(float minVal, float maxVal)
    {
        List<float> lst = new List<float>(rndValLen + 1);
        for (int i = 0; i < rndValLen; i++)
        {
            for (; ; )
            {
                float val = System.Convert.ToSingle(System.Math.Round(UnityEngine.Random.Range(minVal, maxVal), 4));
                if (!lst.Contains(val))
                {
                    lst.Add(val);
                    break;
                }
            }
        }
        return lst;
    }
    void NextMonster()
    {
        selectedMonsterIndex++;
        if (selectedMonsterIndex >= monters.Count) selectedMonsterIndex = 0;

        selectedMonster = monters[selectedMonsterIndex];
        selectedMonster.ResetHp();

        //怪物信息
        if (0 == selectedMonster.isBos)
            strMonsterName = string.Format(normalMonsterName, selectedMonster.level, selectedMonster.name);
        else
            strMonsterName = string.Format(bossMonsterName, selectedMonster.level, selectedMonster.name);

        strMonsterExpVal = selectedMonster.exp.ToString();
    }

    IEnumerator AuthFight()
    {

        int count = 3;
        textBeginFightTimer.gameObject.SetActive(true);
        textBeginFightTimer.text = count.ToString();


        //倒数3秒
        while (true)
        {
            yield return new WaitForSeconds(1f);
            count--;
            textBeginFightTimer.text = count.ToString();
            if (count <= 0) break;
        }
        textBeginFightTimer.gameObject.SetActive(false);

        //初次
        ResetMonsters();
        ResetSkillSeed();
        MakeAllRndArray();
        ShowAllTextContent();
        //物理随机攻击系数
        MakeRndEffectVal();
        StartCoroutine(AuthRestore());
        ShowTotalInfo(true);
        yield return new WaitForSeconds(0.5f);
        //战斗线程
        Thread thread = new Thread(new ThreadStart(ThreadMain));
        thread.Start();
    }
    void ThreadMain()
    { 
        long curHp = 0;
        DateTime _dtBegin = DateTime.Now;
        DateTime _dtEnd = DateTime.Now;
        bool isSkillAtk = false;

        int damage = 0;
        float damageSeed = 0;

        fastCount = 0;
        desBroodSpeed = PlayerManager.Instance.localPlayer.GetPower();

        while (IsFight)//整个战斗过程
        {
            _dtBegin = DateTime.Now;

            //怪物组是否需要重计
            if (needReCurrentSelectedMonsters)
            {
                Thread.Sleep(1400);
                //yield return new WaitForSeconds(1.5f);
                ResetMonsters();
                Thread.Sleep(1400);
                //yield return new WaitForSeconds(1.5f);
            }

            if (null == selectedMonster)
            {
                needReCurrentSelectedMonsters = true;
                continue;
            }

            //怪物是否已死
            if (null!= selectedMonster && selectedMonster.hp <= 0)
            {
                Thread.Sleep(1400);
                //yield return new WaitForSeconds(1.5f);
                NextMonster();
                Thread.Sleep(1400);
                //yield return new WaitForSeconds(1.5f);
            }

             isSkillAtk = IsSkillAtk();//物理还是技能
            if(isSkillAtk)isSkillAtk = GetRandomSkillForAtk();//抽技能
            string atkContent = "";
            //selectedMonster = monters[selectedMonsterIndex];
            float currentAtk = PlayerManager.Instance.localPlayer.GetPower() - selectedMonster.def;
            if (currentAtk < 1) currentAtk = 1;//控制最小攻击数
            if (currentAtk > 1000000) currentAtk = 1000000;
            bool isLuck = IsLuck();

            //随即技能
            if (isSkillAtk)
            {
                //计算伤害,技能系数*攻击力
                damageSeed = CharacterMuGongManager.Instance.GetRndEffectVal(selectedSkill.effectVal);//上下浮动

                if (isLuck) damageSeed = damageSeed * 2.5f;

                if (0 == damageSeed) damageSeed = selectedSkill.effectVal;

                damage = System.Convert.ToInt32(currentAtk * damageSeed);                

                curHp = selectedMonster.hp - damage;

                if (curHp < -500000) curHp = -500000;

                if (PlayerManager.Instance.localPlayer.level> 50&& damage < 500) Debug.LogError("damage is " + damage + ",currentAtk:" + currentAtk+ ",damageSeed:"+ damageSeed+",player->atk:"+ PlayerManager.Instance.localPlayer.GetPower() +",def:"+ selectedMonster.def);

                if (isLuck)
                    atkContent = string.Format(skillLuckDamage, selectedSkillName, damage, curHp);//, currentAtk, damageSeed);
                else
                    atkContent = string.Format(skillDamage, selectedSkillName, damage, curHp);//, currentAtk, damageSeed);

                PlayerManager.Instance.localPlayer.skillKill++;
            }
            else
            {
                damageSeed = GetRndEffectVal();

                if (isLuck) damageSeed = damageSeed * 2.5f;

                if (0 == damageSeed) damageSeed = bastPhyEffectVal;

                damage = System.Convert.ToInt32(currentAtk * damageSeed);
                if (PlayerManager.Instance.localPlayer.level > 50 && damage < 500) Debug.LogError("damage is "+ damage + ",currentAtk:" + currentAtk + ",damageSeed:" + damageSeed + ",player->atk:" + PlayerManager.Instance.localPlayer.GetPower() + ",def:" + selectedMonster.def);
                curHp = selectedMonster.hp - damage;

                if (curHp < -500000) curHp = -500000;

                if (isLuck)
                    atkContent = string.Format(physLuckDamage, damage, curHp);//, currentAtk, damageSeed);
                else
                    atkContent = string.Format(physDamage, damage, curHp);//, currentAtk, damageSeed);

                PlayerManager.Instance.localPlayer.phyKill++;
            }

            AddAttackLog(atkContent);

            selectedMonster.hp = System.Convert.ToInt32( curHp);

            bool isShouldGetCoin = IsGetCoin();
            bool isShouldGetWeaponExp = IsGetWeaponExp();

            //使用技能攻击,概率获得奇物经验
            if (isShouldGetWeaponExp || isLuck)
            {
                PlayerManager.Instance.localPlayer.AddWeaponExp(isSkillAtk,isLuck, isShouldGetCoin);
                waitRefreshForWeaponExp = true;
            }

            //挖矿
            if (isShouldGetCoin)
            {
                PlayerManager.Instance.localPlayer.bitCoin++;
                waitRefreshForCoin = true;
            }

            if (selectedMonster.hp <= 0)
            {
                //得到gold
                PlayerManager.Instance.localPlayer.gold += selectedMonster.gold;
                waitRefreshForKillMonster = true;

                //计算经验
                if (LevelUpAfterAddExp(selectedMonster.exp))
                {
                    needReCurrentSelectedMonsters = true;
                    waitRefreshForLevelUp = true;
                }

                PlayerManager.Instance.localPlayer.totalKill++;
            }
            else
            {
                //没杀死,攻击频率等待,杀死的在重选怪时体现间隔时间
                Thread.Sleep(PlayerManager.Instance.localPlayer.fireRate);
            }

            if (selectedMonster.hp < 0)
            {
                while (selectedMonster.toHp > 0)
                {
                    Thread.Sleep(frameRateVal);
                    //yield return new WaitForEndOfFrame();
                }
                waitPayMonsterDie = true;
                //SoundManager.Instance.SpriteDie();
                selectedMonster.hp = 0;
            }

            _dtEnd = DateTime.Now;

            PlayerManager.Instance.localPlayer.totalTimes += (_dtEnd - _dtBegin).TotalMilliseconds;
        }
    }

    public void QuitGame()
    {
        IsFight = false;
    }

    public bool LevelUpAfterAddExp(long exp)
    {
        PlayerManager.Instance.localPlayer.exp += exp;
        return PlayerManager.Instance.LevelUp();
    }
}
