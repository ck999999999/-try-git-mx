using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WeaponWndControl : MonoBehaviour {

    public Text textLuckVal;
    public Text textDigVal;

    public WeaponLine wings;
    public WeaponLine heart;
    public WeaponLine weapon;
    public static WeaponWndControl Instance;
    const string stringMaxLevel = " Max Level,Good Job ! ";

    public GameObject failedTipWnd;
    public Text textFailedMsg;

    Player player;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Refresh(WeaponType wt)
    {
        if (IsEmptyPlayer()) return;

        switch (wt)
        {
            case WeaponType.wing:
                RefreshWing();
                break;
            case WeaponType.heart:
                RefreshHeart();
                break;
            case WeaponType.weapon:
                RefreshWeapon();
                break;
            case WeaponType.dig:
            case WeaponType.luck:
                break;
            case WeaponType.all:
                RefreshWing();
                RefreshHeart();
                RefreshWeapon();
                break;
        }
        RefreshLuck();
        RefreshDig();
    }
    void RefreshDig()
    {
        textDigVal.text = player.dig.ToString();
    }

    void RefreshLuck()
    {
        textLuckVal.text = player.lucky.ToString();
    }

    void RefreshWing()
    {
        wings.textLvVal.text = player.wingLevel.ToString();
        WeaponLevelTemplate wlt = WeaponModelManager.Instance.GetWeaponLevelTemplate(player.wing, player.wingLevel);
        wings.textDes.text = string.Format(CommonArg.weaponDes, wlt.dig, wlt.luck, wlt.attack, wlt.def, wlt.hp, wlt.mp);
        if (!WeaponModelManager.Instance.IsMaxLevel(player.wing, player.wingLevel))
        {
            wings.textProVal.text = player.wingExp.ToString() + " / " + wlt.exp.ToString();
            wings.textLevelUpDes.text = string.Format(CommonArg.levelUpDes, wlt.limitLevel, wlt.cost);
        }
        else
        {
            wings.textProVal.text = stringMaxLevel;
            wings.textLevelUpDes.text = "";
        }
    }

    void RefreshHeart()
    {
        heart.textLvVal.text = player.heartLevel.ToString();
        WeaponLevelTemplate wlt = WeaponModelManager.Instance.GetWeaponLevelTemplate(player.heart, player.heartLevel);
        heart.textDes.text = string.Format(CommonArg.weaponDes, wlt.dig, wlt.luck, wlt.attack, wlt.def, wlt.hp, wlt.mp);
        if (!WeaponModelManager.Instance.IsMaxLevel(player.heart, player.heartLevel))
        {
            heart.textLevelUpDes.text = string.Format(CommonArg.levelUpDes, wlt.limitLevel, wlt.cost);
            heart.textProVal.text = player.heartExp.ToString() + " / " + wlt.exp.ToString();
        }
        else
        {
            heart.textProVal.text = stringMaxLevel;
            heart.textLevelUpDes.text = "";
        }
    }

    void RefreshWeapon()
    {
        weapon.textLvVal.text = player.weaponLevel.ToString();
        WeaponLevelTemplate wlt = WeaponModelManager.Instance.GetWeaponLevelTemplate(player.weapon, player.weaponLevel);
        weapon.textDes.text = string.Format(CommonArg.weaponDes, wlt.dig, wlt.luck, wlt.attack, wlt.def, wlt.hp, wlt.mp);
        if (!WeaponModelManager.Instance.IsMaxLevel(player.weapon, player.weaponLevel))
        {
            weapon.textLevelUpDes.text = string.Format(CommonArg.levelUpDes, wlt.limitLevel, wlt.cost);
            weapon.textProVal.text = player.weaponExp.ToString() + " / " + wlt.exp.ToString();
        }
        else
        {
            weapon.textProVal.text = stringMaxLevel;
            weapon.textLevelUpDes.text = "";
        }
    }

    public void OnClickWingUpgrade()
    {
        if (IsEmptyPlayer()) return;
        WeaponLevelTemplate wlt = WeaponModelManager.Instance.GetWeaponLevelTemplate(player.wing, player.wingLevel);

        if (player.level < wlt.limitLevel)
        {
            textFailedMsg.text = CommonArg.levelFailed;
            ShowTip();
            return;
        }
        if (player.wingExp < wlt.exp)
        {
            textFailedMsg.text = CommonArg.expFailed;
            ShowTip();
            return;
        }
        if (wlt.cost > player.gen)
        {
            textFailedMsg.text = CommonArg.genFailed;
            ShowTip();
            return;
        }

        player.wingLevel++;
        player.gen -= wlt.cost;
        DoneEffect(WeaponType.wing);
        CharacterContorl.Instance.RefreshShowWing();
    }

    public void OnClickHeartUpgrade()
    {
        if (IsEmptyPlayer()) return;
        WeaponLevelTemplate wlt = WeaponModelManager.Instance.GetWeaponLevelTemplate(player.heart, player.heartLevel);
        if (player.level < wlt.limitLevel)
        {
            textFailedMsg.text = CommonArg.levelFailed;
            ShowTip();
            return;
        }
        if (player.heartExp < wlt.exp)
        {
            textFailedMsg.text = CommonArg.expFailed;
            ShowTip();
            return;
        }
        if (wlt.cost > player.gen)
        {
            textFailedMsg.text = CommonArg.genFailed;
            ShowTip();
            return;
        }

        player.heartLevel++;
        player.gen -= wlt.cost;
        DoneEffect(WeaponType.heart);
    }

    public void OnClickWeaponUpgrade()
    {
        if (IsEmptyPlayer()) return;
        WeaponLevelTemplate wlt = WeaponModelManager.Instance.GetWeaponLevelTemplate(player.weapon, player.weaponLevel);
        if (player.level < wlt.limitLevel)
        {
            textFailedMsg.text = CommonArg.levelFailed;
            ShowTip();
            return;
        }
        if (player.weaponExp < wlt.exp)
        {
            textFailedMsg.text = CommonArg.expFailed;
            ShowTip();
            return;
        }
        if (wlt.cost > player.gen)
        {
            textFailedMsg.text = CommonArg.genFailed;
            ShowTip();
            return;
        }

        player.weaponLevel++;
        player.gen -= wlt.cost;        
        DoneEffect(WeaponType.weapon);
    }
    void DoneEffect(WeaponType wt)
    {
        Refresh(wt);
        SoundManager.Instance.LevelUp();
        PlayerManager.Instance.RefreshPlayerAttribute();
        HeadAndCoinsControl.Instance.RefreshGen();
        FightControl.Instance.needReCurrentWeapon = true;
    }
    
    public void AddExp()
    {
        if (IsEmptyPlayer()) return;

        WeaponLevelTemplate wlt1 = WeaponModelManager.Instance.GetWeaponLevelTemplate(player.weapon, player.weaponLevel);
        WeaponLevelTemplate wlt2 = WeaponModelManager.Instance.GetWeaponLevelTemplate(player.wing, player.wingLevel);
        WeaponLevelTemplate wlt3 = WeaponModelManager.Instance.GetWeaponLevelTemplate(player.heart, player.heartLevel);

        player.weaponExp += wlt1.exp / 2;
        player.wingExp += wlt2.exp / 2;
        player.heartExp += wlt3.exp / 2;
        Refresh(WeaponType.all);
    }

    bool IsEmptyPlayer()
    {
        player = PlayerManager.Instance.localPlayer;

        if (null == player) return true;

        return false;
    }

    public void ShowTip()
    {
        if (!failedTipWnd.gameObject.activeInHierarchy)
        {
            failedTipWnd.SetActive(true);
            StartCoroutine("AutoHideFailedTipWnd");
        }
    }

    IEnumerator AutoHideFailedTipWnd()
    {
        yield return new WaitForSeconds(2.0f);

        failedTipWnd.SetActive(false);
    }
}
