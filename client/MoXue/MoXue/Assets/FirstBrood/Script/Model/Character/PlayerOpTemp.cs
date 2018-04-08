using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//属性面板,临时调动属性
public class PlayerOpTemp 
{
    public int hp = 0;
    public int mp = 0;
    public int atk = 0;
    public int def = 0;
    public int str = 0;
    public int dex = 0;
    public int vit = 0;
    public int brain = 0;
    public int remainSp = 0;

    public void Reset()
    {
        hp = 0;
        mp = 0;
        atk = 0;
        def = 0;
        str = 0;
        dex = 0;
        vit = 0;
        brain = 0;
        remainSp = PlayerManager.Instance.localPlayer.remainSp;
    }
}

