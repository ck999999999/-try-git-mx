using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAttributeControl : MonoBehaviour {

    public Text textLevel;
    public Text textRemainSp;
    public Text textExp;
    public Text textHP;
    public Text textMP;
    public Text textAttackPower;
    public Text textDefPower;
    public Text textStrong;
    public Text textVit;
    public Text textDex;
    public Text textBrain;

    public Text textExtHP;
    public Text textExtMP;
    public Text textExtAttackPower;
    public Text textExtDefPower;
    public Text textExtStrong;
    public Text textExtVit;
    public Text textExtDex;
    public Text textExtBrain;
    public Text textExtRemainSp;

    public GameObject gameObjectLevelUp;

    public static CharacterAttributeControl Instance;

    public PlayerOpTemp playerOpTempData=new PlayerOpTemp();
    Player player;

    IEnumerator StartRun()
    {
        while (!GameLocalDataManager.Instance.localDataIsReady)
        {
            yield return new WaitForSeconds(1.0f);
        }

        StartWork();
    }
    private void Awake()
    {
        Instance = this;
    }

    void ResetPlayerOpTempData()
    {
        playerOpTempData.Reset();
    }
    void ShowAttributeVal()
    {
        //Debug.Log("ShowAttributeVal!!!!!!!!!!!!!!!!!!!!!");
        textLevel.text = player.level.ToString();
        textRemainSp.text = player.remainSp.ToString();
        if (PlayerManager.Instance.LocalPlayerIsMaxLevel())
        {
            textExp.text = string.Format(" Max Level , Good Job ! ", player.exp, player.nextExp);          
        }
        else
        {
            textExp.text = string.Format("{0} / {1}", player.exp, player.nextExp);
        }
        textHP.text = player.maxHP.ToString();
        textMP.text = player.maxMP.ToString();
        textAttackPower.text = player.atk.ToString();
        textDefPower.text = player.def.ToString();
        textStrong.text = player.GetStr().ToString();
        textVit.text = player.GetVit().ToString();
        textDex.text = player.GetDex().ToString();
        textBrain.text = player.GetBrain().ToString();
        //Debug.Log("ShowAttributeVal!!!!!!!!!!!!!!!333333333!!!!!!");
    }
    public void ShowAllExtAttributeVal()
    {
        //重计算
        playerOpTempData.hp = PlayerManager.Instance.PreviewExtHp(playerOpTempData);
        playerOpTempData.mp = PlayerManager.Instance.PreviewExtMp(playerOpTempData);
        playerOpTempData.atk = PlayerManager.Instance.PreviewExtAtk(playerOpTempData);
        playerOpTempData.def = PlayerManager.Instance.PreviewExtDef(playerOpTempData);

        if (0 < playerOpTempData.atk)
            textExtAttackPower.text = playerOpTempData.atk.ToString();
        else
            textExtAttackPower.text = "";

        if (0 < playerOpTempData.brain)
            textExtBrain.text = playerOpTempData.brain.ToString();
        else
            textExtBrain.text = "";

        if (0 < playerOpTempData.def)
            textExtDefPower.text = playerOpTempData.def.ToString();
        else
            textExtDefPower.text = "";

        if (0 < playerOpTempData.dex)
            textExtDex.text = playerOpTempData.dex.ToString();
        else
            textExtDex.text = "";

        if (0 < playerOpTempData.str)
            textExtStrong.text = playerOpTempData.str.ToString();
        else
            textExtStrong.text = "";

        if (0 < playerOpTempData.vit)
            textExtVit.text = playerOpTempData.vit.ToString();
        else
            textExtVit.text = "";

        if (playerOpTempData.remainSp != player.remainSp)
            textExtRemainSp.text = playerOpTempData.remainSp.ToString();
        else
            textExtRemainSp.text = "";


        if (0 < playerOpTempData.hp)
            textExtHP.text = playerOpTempData.hp.ToString();
        else
            textExtHP.text = "";

        if (0 < playerOpTempData.mp)
            textExtMP.text = playerOpTempData.mp.ToString();
        else
            textExtMP.text = "";
    }
// Use this for initialization
    void Start () {
       
    }
    public void StartWork()
    {
        player = PlayerManager.Instance.localPlayer;
        Refresh();
    }
    public void Refresh()
    {
        //重置显示
        ResetPlayerOpTempData();
        ShowAttributeVal();
        ShowAllExtAttributeVal();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnClickAddStrong()
    {
        if (playerOpTempData.remainSp > 0)
        {
            playerOpTempData.remainSp--;
            playerOpTempData.str++;
            ShowAllExtAttributeVal();
        }
    }
    public void OnClickDesStrong()
    {
        if (playerOpTempData.str > 0)
        {
            playerOpTempData.remainSp++;
            playerOpTempData.str--;
            ShowAllExtAttributeVal();
        }
    }
    public void OnClickAddVit()
    {
        if (playerOpTempData.remainSp > 0)
        {
            playerOpTempData.remainSp--;
            playerOpTempData.vit++;
            ShowAllExtAttributeVal();
        }
    }
    public void OnClickDesVit()
    {
        if (playerOpTempData.vit > 0)
        {
            playerOpTempData.remainSp++;
            playerOpTempData.vit--;
            ShowAllExtAttributeVal();
        }
    }
    public void OnClickAddDex()
    {
        if (playerOpTempData.remainSp > 0)
        {
            playerOpTempData.remainSp--;
            playerOpTempData.dex++;
            ShowAllExtAttributeVal();
        }
    }
    public void OnClickDesDex()
    {
        if (playerOpTempData.dex > 0)
        {
            playerOpTempData.remainSp++;
            playerOpTempData.dex--;
            ShowAllExtAttributeVal();
        }
    }
    public void OnClickAddBrain()
    {
        if (playerOpTempData.remainSp > 0)
        {
            playerOpTempData.remainSp--;
            playerOpTempData.brain++;
            ShowAllExtAttributeVal();
        }
    }
    public void OnClickDesBrain()
    {
        if (playerOpTempData.brain > 0)
        {
            playerOpTempData.remainSp++;
            playerOpTempData.brain--;
            ShowAllExtAttributeVal();
        }
    }

    public void OnClickCancel()
    {
        Refresh();
    }
    public void OnClickSave()
    {
        PlayerManager.Instance.Save(this.playerOpTempData);
        Refresh();
    }

    //2次一升级
    public void OnClickAddExp()
    {
        if (PlayerManager.Instance.LocalPlayerIsMaxLevel()) return;
        long exp = player.nextExp / 2;
        AddExp(exp);
    }
    public bool AddExpAfterKillMonster(long exp)
    {
        int lv = player.level;
        AddExp(exp);
        return lv != player.level;
    }
    public void AddExp(long exp)
    {
        player.exp += exp;
        if (PlayerManager.Instance.LevelUp())
        {
            //声音
            if (!gameObjectLevelUp.activeInHierarchy) gameObjectLevelUp.SetActive(true);
            //面板数据
            Refresh();
            HeadAndCoinsControl.Instance.Refresh(CoinType.all);
            return;
        }
        ShowAttributeVal();
    }
    public void PlayLevelUp()
    {
        //声音
        if (!gameObjectLevelUp.activeInHierarchy) gameObjectLevelUp.SetActive(true);
        //面板数据
        Refresh();
    }
}
