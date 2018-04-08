using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WeaponLine {
    public Text textLvVal;
    public Text textProVal;
    public Text textDes;
    public Text textLevelUpDes;
}

public enum WeaponType
{
    wing=0,
    heart=1,
    weapon=2,
    dig,
    luck,
    all,
}