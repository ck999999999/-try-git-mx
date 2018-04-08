using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtomMenu : MonoBehaviour {

    public GameObject middleBoardWnd;

    public GameObject fightWnd;
    public GameObject skillWnd;
    public GameObject attributeWnd;
    public GameObject exChangeWnd;
    public GameObject bitCoinDesWnd;
    public GameObject weaponWnd;
    //public GameObject settingWnd;

    //public AudioSource mainButtonEffectSound;

    public MainButtonType currentMainButtonType= MainButtonType.fight;

    public static ButtomMenu Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        middleBoardWnd.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void UnActiveAll()
    {
        fightWnd.SetActive(false);
        skillWnd.SetActive(false);
        attributeWnd.SetActive(false);
        exChangeWnd.SetActive(false);
        bitCoinDesWnd.SetActive(false);
        weaponWnd.SetActive(false);
        //settingWnd.SetActive(false);
    }
    void ShowMiddleWnd(MainButtonType mbt)
    {
        bool show = true;

        if (mbt == currentMainButtonType)
            show = !middleBoardWnd.activeInHierarchy;

        currentMainButtonType = mbt;

        if (!show || MainButtonType.none == mbt)
        {
            middleBoardWnd.SetActive(false);
            return;
        }
        UnActiveAll();

        SoundManager.Instance.OpWnd();

        switch (currentMainButtonType)
        {
            case MainButtonType.fight:
                {
                    fightWnd.SetActive(show);
                }
                break;
            case MainButtonType.attribute:
                {
                    attributeWnd.SetActive(show);
                    if (show) CharacterAttributeControl.Instance.Refresh();
                }
                break;
            case MainButtonType.exchange:
                {
                    ShopWndControl.Instance.ShowPreGenResult();
                    ShopWndControl.Instance.ShowPreGoldResult();
                    exChangeWnd.SetActive(show);
                }
                break;
            case MainButtonType.bitCoin:
                { bitCoinDesWnd.SetActive(show); }
                break;
            case MainButtonType.skill:
                {
                    if (show) SkillWndHander.Instance.Refresh();
                    skillWnd.SetActive(show);
                }
                break;
            case MainButtonType.weapon:
                {
                    if (show) WeaponWndControl.Instance.Refresh( WeaponType.all);
                    weaponWnd.SetActive(show);
                }
                break;
            case MainButtonType.setting:
                {
                    //settingWnd.SetActive(show);
                }
                break;
        }
        middleBoardWnd.SetActive(show);
    }
    public void OnClickAutoFight()
    {
        ShowMiddleWnd(MainButtonType.fight);
    }
    public void OnClickSkill()
    {
        ShowMiddleWnd(MainButtonType.skill);
    }
    public void OnClickAttribute()
    {
        ShowMiddleWnd(MainButtonType.attribute);
    }
    public void OnClickExChangeCenter()
    {
        ShowMiddleWnd(MainButtonType.exchange);
    }
    public void OnClickBitCoinDes()
    {
        ShowMiddleWnd(MainButtonType.bitCoin);
    }
    public void OnClickWeapon()
    {
        ShowMiddleWnd(MainButtonType.weapon);
    }
    public void OnClickSetting()
    {
        ShowMiddleWnd(MainButtonType.setting);
    }
    public void OnClickCloseWnd()
    {
        ShowMiddleWnd(MainButtonType.none);
    }
    public void OnClickClearData()
    {
        PlayerManager.Instance.CreatePlayer(1);
        CharacterAttributeControl.Instance.StartWork();
        HeadAndCoinsControl.Instance.StartWork();
        PlayerPrefs.DeleteAll();
        FightControl.Instance.StopFight();
    }
    public void OnClickRefreshPlayerAttribute()
    {
        PlayerManager.Instance.RefreshPlayerAttribute();
    }
}
