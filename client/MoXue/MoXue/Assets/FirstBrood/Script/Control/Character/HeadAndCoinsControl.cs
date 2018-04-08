using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadAndCoinsControl : MonoBehaviour {

    public Text textGold;
    public Text textGen;
    public Text textBitCoin;
    //public Image imageHero;
    public GameObject aniGold;
    public GameObject aniGen;
    public GameObject aniBitCoin;

    public static HeadAndCoinsControl Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void StartWork()
    {
        Refresh(CoinType.all); 
    }
    public void RefreshGold()
    {
        textGold.text = PlayerManager.Instance.localPlayer.gold.ToString();
        aniGold.GetComponent<IconRotation>().StartRotation();
    }
    public void RefreshGen()
    {
        textGen.text = PlayerManager.Instance.localPlayer.gen.ToString();
        aniGen.GetComponent<IconRotation>().StartRotation();
    }
    public void RefreshCoin()
    {
        textBitCoin.text = PlayerManager.Instance.localPlayer.bitCoin.ToString();
        aniBitCoin.GetComponent<IconRotation>().StartRotation();
    }

    public void Refresh(CoinType ct)
    {
        switch (ct)
        {
            case CoinType.gold:
                RefreshGold();
                break;
            case CoinType.gen:
                RefreshGen();
                break;
            case CoinType.bitCoin:
                RefreshCoin();
                break;
            case CoinType.all:
                RefreshGold();
                RefreshGen();
                RefreshCoin();
                break;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
