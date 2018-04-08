using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillWndHander : MonoBehaviour {

    public SkillLine SkillHander;
    public SkillLine SkillHander1;
    public SkillLine SkillHander2;
    public SkillLine SkillHander3;
    public SkillLine SkillHander4;

    public GameObject FailedTipWnd;
    public Text failedTextTip;

    public static SkillWndHander Instance;

    string nextDes= CommonArg.skillLeveUpCon;
    string maxDes = CommonArg.alreadyMaxLevel;
    string levelLimitDes = CommonArg.levelFailed;
    string genLimitDes = CommonArg.genFailed;
    string goldLimitDes = CommonArg.goldFailed;

    Player player;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        FailedTipWnd.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        //Refresh();
    }
    public void Refresh()
    {
        if (null == PlayerManager.Instance.localPlayer) return;

        //更新面板数据
        player = PlayerManager.Instance.localPlayer;
        for (int skillIndex = 0; skillIndex < 5; skillIndex++)
        {
            SetSkillNameAndLevelVal(skillIndex);
        }
    }
    void SetSkillNameAndLevelVal(int sindex)
    {
        MuGongTemplate mt;
        MuGongLevel mgl;
        //MuGongLevel mg2;
        float dmbase = 0;
        int mindm = 0;
        int maxdm = 0;

        switch (sindex)
        {
            case 0:
                {
                    Debug.Log(" SetSkillNameAndLevelVal : " + player.skillId);
                    mt = CharacterMuGongManager.Instance.GetMuGongTemplate(player.skillId);
                    mgl = mt.muGongLevel[player.skillLevel];
                    
                    SkillHander.textSkillName.text = mt.name;

                    SkillHander.textSkillLvVal.text = player.skillLevel.ToString();
                    dmbase = CharacterMuGongManager.Instance.GetMuGongLevelTemplate(player.skillId, player.skillLevel).mp;
                    SkillHander.textSkillDmVal.text = dmbase.ToString();
                    SkillHander.textSkillDes.text = mt.des;
                    if (mgl.level >= mt.maxLevel)
                    {
                        SkillHander.textSkillNextLimit.text = maxDes;
                        SkillHander.burronUpgrade.gameObject.SetActive(false);
                    }
                    else
                    {
                        SkillHander.textSkillNextLimit.text = string.Format(nextDes, mgl.limitLevel, mgl.cost, mgl.gold);
                    }
                }
                break;
            case 1:
                {
                    mt = CharacterMuGongManager.Instance.GetMuGongTemplate(player.skillId1);
                    mgl = mt.muGongLevel[player.skillLevel1];

                    SkillHander1.textSkillName.text = mt.name;

                    SkillHander1.textSkillLvVal.text = player.skillLevel1.ToString();
                    dmbase = CharacterMuGongManager.Instance.GetMuGongLevelTemplate(player.skillId1, player.skillLevel1).mp;
                    SkillHander1.textSkillDmVal.text = dmbase.ToString();
                    SkillHander1.textSkillDes.text = mt.des ;
                    if (mgl.level >= mt.maxLevel)
                    {
                        SkillHander1.textSkillNextLimit.text = maxDes;
                        SkillHander1.burronUpgrade.gameObject.SetActive(false);
                    }
                    else
                    {
                        SkillHander1.textSkillNextLimit.text = string.Format(nextDes, mgl.limitLevel, mgl.cost, mgl.gold);
                    }
                }
                break;
            case 2:
                {
                    mt = CharacterMuGongManager.Instance.GetMuGongTemplate(player.skillId2);
                    mgl = mt.muGongLevel[player.skillLevel2];

                    SkillHander2.textSkillName.text = mt.name;

                    SkillHander2.textSkillLvVal.text = player.skillLevel2.ToString();
                    dmbase = CharacterMuGongManager.Instance.GetMuGongLevelTemplate(player.skillId2, player.skillLevel2).mp;
                    mindm = System.Convert.ToInt32( dmbase * 0.8f );
                    maxdm = System.Convert.ToInt32(dmbase * 1.2f );

                    SkillHander2.textSkillDmVal.text = mindm.ToString()+" - " + maxdm.ToString();
                    SkillHander2.textSkillDes.text = string.Format( mt.des , mgl.seed.ToString());
                    if (mgl.level >= mt.maxLevel)
                    {
                        SkillHander2.textSkillNextLimit.text = maxDes;
                        SkillHander2.burronUpgrade.gameObject.SetActive(false);
                    }
                    else
                    {
                        SkillHander2.textSkillNextLimit.text = string.Format(nextDes, mgl.limitLevel, mgl.cost, mgl.gold);
                    }
                }
                break;
            case 3:
                {
                    mt = CharacterMuGongManager.Instance.GetMuGongTemplate(player.skillId3);
                    mgl = mt.muGongLevel[player.skillLevel3];

                    SkillHander3.textSkillName.text = mt.name;

                    SkillHander3.textSkillLvVal.text = player.skillLevel3.ToString();
                    dmbase = CharacterMuGongManager.Instance.GetMuGongLevelTemplate(player.skillId3, player.skillLevel3).mp;
                    mindm = System.Convert.ToInt32(dmbase * 0.8f);
                    maxdm = System.Convert.ToInt32(dmbase * 1.2f);

                    SkillHander3.textSkillDmVal.text = mindm.ToString() + " - " + maxdm.ToString();
                    SkillHander3.textSkillDes.text = string.Format(mt.des, mgl.seed.ToString());
                    if (mgl.level >= mt.maxLevel)
                    {
                        SkillHander3.textSkillNextLimit.text = maxDes;
                        SkillHander3.burronUpgrade.gameObject.SetActive(false);
                    }
                    else
                    {
                        SkillHander3.textSkillNextLimit.text = string.Format(nextDes, mgl.limitLevel, mgl.cost, mgl.gold);
                    }
                }
                break;
            case 4:
                {
                    mt = CharacterMuGongManager.Instance.GetMuGongTemplate(player.skillId4);
                    mgl = mt.muGongLevel[player.skillLevel4];

                    SkillHander4.textSkillName.text = mt.name;

                    SkillHander4.textSkillLvVal.text = player.skillLevel4.ToString();
                    dmbase = CharacterMuGongManager.Instance.GetMuGongLevelTemplate(player.skillId4, player.skillLevel4).mp;
                    mindm = System.Convert.ToInt32(dmbase * 0.8f);
                    maxdm = System.Convert.ToInt32(dmbase * 1.2f);

                    SkillHander4.textSkillDmVal.text = mindm.ToString() + " - " + maxdm.ToString();
                    SkillHander4.textSkillDes.text = string.Format(mt.des, mgl.seed.ToString());
                    if (mgl.level >= mt.maxLevel)
                    {
                        SkillHander4.textSkillNextLimit.text = maxDes;
                        SkillHander4.burronUpgrade.gameObject.SetActive(false);
                    }
                    else
                    {
                        SkillHander4.textSkillNextLimit.text = string.Format(nextDes, mgl.limitLevel, mgl.cost, mgl.gold);
                    }

                }
                break;
        }
    }

    public void OnClickSkillUp()//
    {
        SkillUp(0);
    }
    public void OnClickSkillUp1()
    {
        SkillUp(1);
    }
    public void OnClickSkillUp2()
    {
        SkillUp(2);
    }
    public void OnClickSkillUp3()
    {
        SkillUp(3);
    }
    public void OnClickSkillUp4()
    {
        SkillUp(4);
    }
    void SkillUp(int sindex)
    {
        MuGongLevel mt=null;

        switch (sindex)
        {
            case 0:
                {
                    mt = CharacterMuGongManager.Instance.GetMuGongLevelTemplate(player.skillId,player.skillLevel);
                }
                break;
            case 1:
                {
                    mt = CharacterMuGongManager.Instance.GetMuGongLevelTemplate(player.skillId1, player.skillLevel1);
                }
                break;
            case 2:
                {
                    mt = CharacterMuGongManager.Instance.GetMuGongLevelTemplate(player.skillId2, player.skillLevel2);
                }
                break;
            case 3:
                {
                    mt = CharacterMuGongManager.Instance.GetMuGongLevelTemplate(player.skillId3, player.skillLevel3);
                }
                break;
            case 4:
                {
                    mt = CharacterMuGongManager.Instance.GetMuGongLevelTemplate(player.skillId4, player.skillLevel4);
                }
                break;
        }

        if (mt.limitLevel > player.level)
        {
            failedTextTip.text = levelLimitDes;
            ShowTip();
        }
        else if (mt.cost > player.gen)
        {
            failedTextTip.text = genLimitDes;
            ShowTip();
        }
        else if (mt.gold > player.gold)
        {
            failedTextTip.text = goldLimitDes;
            ShowTip();
        }
        else
        {
            player.gold -= mt.gold;
            player.gen -= mt.cost;

            switch (sindex)
            {
                case 0:
                    player.skillLevel++;
                    break;
                case 1:
                    player.skillLevel1++;
                    break;
                case 2:
                    player.skillLevel2++;
                    break;
                case 3:
                    player.skillLevel3++;
                    break;
                case 4:
                    player.skillLevel4++;
                    break;
            }
            SoundManager.Instance.LevelUp();
            Refresh();
            if (mt.gold > 0) HeadAndCoinsControl.Instance.RefreshGold();//.Refresh(CoinType.gold);
            if (mt.cost > 0) HeadAndCoinsControl.Instance.RefreshGen();// (CoinType.gen);

            PlayerManager.Instance.RefreshPlayerAttribute();

            //挂机处
            FightControl.Instance.needReCurrentSkillSeed = true;
        }
    }
    public void ShowTip()
    {
        if (!FailedTipWnd.gameObject.activeInHierarchy)
        {
            FailedTipWnd.SetActive(true);
            StartCoroutine("AutoHideFailedTipWnd");
        }
    }
    IEnumerator AutoHideFailedTipWnd()
    {
        yield return new WaitForSeconds(2.0f);

        FailedTipWnd.SetActive(false);
    }
}
