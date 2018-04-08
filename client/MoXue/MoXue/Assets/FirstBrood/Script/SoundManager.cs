using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    public GameObject buttonOpenSound;
    public GameObject buttonCloseSound;

    public AudioSource soundBackGround;
    public AudioSource effectSound;
    public AudioSource levelUpSound;
    public AudioSource spriteDieSound;
    public AudioSource getCoinSound;

    public AudioClip[] spriteDies;

    public Slider sliderSound;

    public Image imageSoundSliderHandle;
    public Image imageSoundSliderFill;

    public static SoundManager Instance;

    float disanceOfEffectSoundAndGroundSound=0.3f;

    private void Awake()
    {
        Instance = this;
    }

    void Start () {
        buttonCloseSound.SetActive(false);
        buttonOpenSound.SetActive(true);
        disanceOfEffectSoundAndGroundSound= effectSound.volume - soundBackGround.volume;
        ShowSlider();
    }

    void ShowSlider()
    {
        imageSoundSliderHandle.GetComponent<SoundSliderColorAControl>().StartColorA();
        imageSoundSliderFill.GetComponent<SoundSliderColorAControl>().StartColorA();
    }
    public void OnClickOpenSound()
    {
        buttonCloseSound.SetActive(false);
        buttonOpenSound.SetActive(true);
        sliderSound.gameObject.SetActive(true);
        effectSound.gameObject.SetActive(true);
        levelUpSound.gameObject.SetActive(true);
        spriteDieSound.gameObject.SetActive(true);
        getCoinSound.gameObject.SetActive(true);
        ShowSlider();
        StartEnv();
    }

    public void OnClickCloseSound()
    {
        buttonOpenSound.SetActive(false);
        buttonCloseSound.SetActive(true);
        sliderSound.gameObject.SetActive(false);
        effectSound.gameObject.SetActive(false);
        levelUpSound.gameObject.SetActive(false);
        spriteDieSound.gameObject.SetActive(false);
        getCoinSound.gameObject.SetActive(false);
        StopEnv();
    }
    public void ChangeVolume()
    {
        soundBackGround.volume = sliderSound.value ;
        effectSound.volume = soundBackGround.volume+disanceOfEffectSoundAndGroundSound;
        levelUpSound.volume = effectSound.volume;
        spriteDieSound.volume = effectSound.volume;
        getCoinSound.volume = effectSound.volume;
        ShowSlider();
    }
    public void GetCoin()
    {
        if (!getCoinSound.gameObject.activeInHierarchy) return;
        if (getCoinSound.isPlaying) getCoinSound.Stop();
        getCoinSound.Play();
    }
    public void LevelUp()
    {
        if (!levelUpSound.gameObject.activeInHierarchy) return;
        if (levelUpSound.isPlaying) levelUpSound.Stop();
        levelUpSound.Play();
    }
    public void SpriteDie()
    {
        int index = Random.Range(0, spriteDies.Length);
        if (spriteDieSound.isPlaying) spriteDieSound.Stop();
        spriteDieSound.clip = spriteDies[index];
        spriteDieSound.Play();
    }
    public void OpWnd()
    {
        if (!effectSound.gameObject.activeInHierarchy) return;
        if (effectSound.isPlaying) effectSound.Stop();
        effectSound.Play();
    }
    void StopEnv()
    {
        if (soundBackGround.isPlaying) soundBackGround.Stop();
    }
    void StartEnv()
    {
        if (soundBackGround.isPlaying) return;

        soundBackGround.Play();
    }
}
