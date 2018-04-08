using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.UI;
public class CharacterContorl : MonoBehaviour
{
    public GameObject gameObjectChiBang1;//0.6
    public GameObject gameObjectChiBang2;//1
    public GameObject gameObjectChiBang3;//1.76

    //双模型交替
    public GameObject gameObjectHero1;
    public GameObject gameObjectHero2;

    //max 1.76 ,,0.6 ,1
    public static CharacterContorl Instance;

    float timer = 0;
    int maxTimer = 5;

    float baseSize = 18.0f;//
    float minSize = 0.9f;
    float middleSize1 = 1f;
    float middleSize2 = 1.2f;
    float maxSize = 1.66f;
    public void StartWork()
    {
        RefreshShowWing();
    }

    void Awake()
    {
        Instance = this;
    }

    void Start () {
        StartCoroutine(ShowHero());
    }
    IEnumerator ShowHero()
    {
        yield return new WaitForSeconds(0.7f);
        gameObjectHero1.SetActive(true);
        
        yield return new WaitForSeconds(0.2f);
        gameObjectHero2.SetActive(true);
    }
    public void RefreshShowWing()
    {
        gameObjectChiBang1.SetActive(false);
        gameObjectChiBang2.SetActive(false);
        gameObjectChiBang3.SetActive(false);

        //控制翅膀3的大小,max 1.66
        float lv = PlayerManager.Instance.localPlayer.wingLevel;
        float currentSize = lv / baseSize;

        if (currentSize < minSize)
            currentSize = minSize;
        else if (currentSize > maxSize)
            currentSize = maxSize;

        gameObjectChiBang3.transform.localScale = new Vector3(currentSize,1,1);
        gameObjectChiBang3.SetActive(true);

        if(currentSize>= middleSize1) gameObjectChiBang1.SetActive(true);

        if (currentSize >= middleSize2) gameObjectChiBang1.SetActive(true);

    }

	void Update () {
    }
}
