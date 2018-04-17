using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWndControl : MonoBehaviour {
    public Text textTryExChangeBitCoinForGen;//
    public Text textTryExChangeGen;
    //public Text textMyBitCoinVal;//身上拥有数
    //public Text textMyGenVal;//身上拥有数
    const int ExtToGen=15;
    int tryGenCoin = 0;
    int tryGen = 0;

    public Text textTryExChangeBitCoinForGold;//
    public Text textTryExChangeGold;

    const int ExtToGold = 1000;
    int tryGoldGen = 0;
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
        //textMyBitCoinVal.text = PlayerManager.Instance.localPlayer.bitCoin.ToString();
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
        tryGold = tryGoldGen * ExtToGold;
        textTryExChangeBitCoinForGold.text = tryGoldGen.ToString();
        textTryExChangeGold.text = tryGold.ToString();
        //textMyBitCoinVal.text = PlayerManager.Instance.localPlayer.bitCoin.ToString();
    }
    public void GoldPreviewAdd()
    {
        if (tryGoldGen < PlayerManager.Instance.localPlayer.gen)
        {
            tryGoldGen++;
            ShowPreGoldResult();
        }
    }
    public void PreviewGoldDes()
    {
        if (tryGoldGen > 0)
        {
            tryGoldGen--;
            ShowPreGoldResult();
        }
    }
    public void ExChangeGoldNow()
    {
        if (0 == tryGoldGen || 0 == tryGold) return;
        if (tryGoldGen > PlayerManager.Instance.localPlayer.gen) return;

        PlayerManager.Instance.localPlayer.gen -= tryGoldGen;
        PlayerManager.Instance.localPlayer.gold += tryGold;
        tryGoldGen = 0;
        tryGold = 0;
        ShowPreGoldResult();
        //保存
        PlayerManager.Instance.SaveLocalPlaerData();
        //HeadAndCoinsControl.Instance.RefreshCoin();
        HeadAndCoinsControl.Instance.RefreshGen();
        HeadAndCoinsControl.Instance.RefreshGold();
    }
   
    #endregion gold

    public void Refresh()
    {
        //textMyBitCoinVal.text = PlayerManager.Instance.localPlayer.bitCoin.ToString();
    }
}
