using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevelUpEffectCtrl : MonoBehaviour {

    public float hideTime = 2;
    bool firstTimes = true;

	// Use this for initialization
	void Start () {
        //声音
        SoundManager.Instance.LevelUp();
        firstTimes = false;
    }
    private void OnEnable()
    {
        if (firstTimes) return;
        
        hideTime = 2;
        SoundManager.Instance.LevelUp();
    }
    // Update is called once per frame
    void Update () {
        hideTime -= Time.deltaTime;
        if (hideTime <= 0) gameObject.SetActive(false);
    }

}
