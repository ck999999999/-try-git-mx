using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSliderColorAControl : MonoBehaviour {

    public float speed = 0.2f;
    public bool startColorA=false;
    Color colorBase;
    Image imageSelfColor;
    public float a;
    public float minA = 0.3f;
    public float maxA = 2.0f;
	void Start () {
        imageSelfColor = GetComponent<Image>();
        colorBase = imageSelfColor.color;
        startColorA = true;
    }
    public void StartColorA()
    {
        colorBase.a = maxA;
        startColorA = true;
    }
    void Update () {
        if (startColorA) HideSliderSlowy();
    }
    void HideSliderSlowy()
    {
        colorBase.a -= Time.deltaTime * speed;
        imageSelfColor.color = colorBase;
        a = colorBase.a;
        if (colorBase.a < minA)
        {
            startColorA = false;
        }
    }
}
