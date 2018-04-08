using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalDataModel : MonoBehaviour {

    Coroutine coroutineSave;
    void Awake()
    {
        Application.targetFrameRate = 30;
        //Debug.Log("first ~~~~~~~~~~~~~~~~");
        //本地数据初始化总入口,唯一入口
        GameLocalDataManager.InitAllLocalData();
        Application.runInBackground = true;
    }
    private void OnApplicationQuit()
    {
        FightControl.Instance.QuitGame();
        if (GameLocalDataManager.Instance.gameIsRuning)
        {
            StopCoroutine(coroutineSave);
            GameLocalDataManager.Instance.gameIsRuning = false;
            PlayerManager.Instance.SaveLocalPlaerData();            
        }
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
    }
    IEnumerator AutoSave()
    {
        while (GameLocalDataManager.Instance.gameIsRuning)
        {
            //Debug.Log("Save!!!!!!!!!!!!!!!!!!!!!!!!!");
            PlayerManager.Instance.SaveLocalPlaerData();
            yield return new WaitForSeconds(10.0f);//每十秒存依次
        }
    }

    // Use this for initialization
    void Start () {
        //射击Awake后调用的
        CharacterAttributeControl.Instance.StartWork();
        CharacterContorl.Instance.StartWork();
        WeaponWndControl.Instance.Refresh( WeaponType.all);
        HeadAndCoinsControl.Instance.StartWork();
        GameLocalDataManager.Instance.gameIsRuning = true;
        FightControl.Instance.StartWork();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        coroutineSave =StartCoroutine("AutoSave");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
