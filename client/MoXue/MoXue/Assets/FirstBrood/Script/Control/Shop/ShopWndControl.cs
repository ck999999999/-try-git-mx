using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWndControl : MonoBehaviour {
    public Text textTryExChangeBitCoinForGen;//
    public Text textTryExChangeGen;
    public Text textMyBitCoinVal;//身上拥有数
    const int ExtToGen=15;
    int tryGenCoin = 0;
    int tryGen = 0;

    public Text textTryExChangeBitCoinForGold;//
    public Text textTryExChangeGold;

    const int ExtToGold = 25000;
    int tryGoldCoin = 0;
    int tryGold = 0;

    public static ShopWndControl Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start () {
    }
    private void OnEnable()
    {
        ShowPreGenResult();
        ShowPreGoldResult();
    }

    // Update is called once per frame
    void Update () {
		
	}

    #region Gen

    public void ShowPreGenResult()
    {
        if (null == PlayerManager.Instance) return;
        if (null == PlayerManager.Instance.localPlayer) return;
        tryGen = tryGenCoin * ExtToGen;
        textTryExChangeBitCoinForGen.text = tryGenCoin.ToString();
        textTryExChangeGen.text = tryGen.ToString();
        textMyBitCoinVal.text = PlayerManager.Instance.localPlayer.bitCoin.ToString();
    }
    public void PreviewAdd()
    {
        if (tryGenCoin < PlayerManager.Instance.localPlayer.bitCoin)
        {
            tryGenCoin++;
            ShowPreGenResult();
        }
    }
    public void PreviewDes()
    {
        if (tryGenCoin > 0)
        {
            tryGenCoin--;
            ShowPreGenResult();
        }
    }
    public void ExChangeNow()
    {
        if (0 == tryGenCoin || 0 == tryGen) return;
        if (tryGenCoin > PlayerManager.Instance.localPlayer.bitCoin) return;

        PlayerManager.Instance.localPlayer.bitCoin -= tryGenCoin;
        PlayerManager.Instance.localPlayer.gen += tryGen;
        tryGenCoin = 0;
        tryGen = 0;
        ShowPreGenResult();
        //保存
        PlayerManager.Instance.SaveLocalPlaerData();
        HeadAndCoinsControl.Instance.RefreshCoin();
        HeadAndCoinsControl.Instance.RefreshGen();
    }

    #endregion Gen

    #region Gold

    public void ShowPreGoldResult()
    {
        if (null == PlayerManager.Instance) return;
        if (null == PlayerManager.Instance.localPlayer) return;
        tryGold = tryGoldCoin * ExtToGold;
        textTryExChangeBitCoinForGold.text = tryGoldCoin.ToString();
        textTryExChangeGold.text = tryGold.ToString();
        textMyBitCoinVal.text = PlayerManager.Instance.localPlayer.bitCoin.ToString();
    }
    public void GoldPreviewAdd()
    {
        if (tryGoldCoin < PlayerManager.Instance.localPlayer.bitCoin)
        {
            tryGoldCoin++;
            ShowPreGoldResult();
        }
    }
    public void PreviewGoldDes()
    {
        if (tryGoldCoin > 0)
        {
            tryGoldCoin--;
            ShowPreGoldResult();
        }
    }
    public void ExChangeGoldNow()
    {
        if (0 == tryGoldCoin || 0 == tryGold) return;
        if (tryGoldCoin > PlayerManager.Instance.localPlayer.bitCoin) return;

        PlayerManager.Instance.localPlayer.bitCoin -= tryGoldCoin;
        PlayerManager.Instance.localPlayer.gold += tryGold;
        tryGoldCoin = 0;
        tryGold = 0;
        ShowPreGoldResult();
        //保存
        PlayerManager.Instance.SaveLocalPlaerData();
        HeadAndCoinsControl.Instance.RefreshCoin();
        HeadAndCoinsControl.Instance.RefreshGold();
    }
   
    #endregion gold

    public void Refresh()
    {
        textMyBitCoinVal.text = PlayerManager.Instance.localPlayer.bitCoin.ToString();
    }
}
