using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTemplate  {
    public int id;
    public int level;
    public string name;
    public int hp;
    public int toHp;//当减少到的hp位置
    public int maxHP;
    public int atk;
    public int def;
    public int exp;
    //public float hpRestore;
    public float atkRate;
    public int isBos;
    public int gold;
    public void ResetHp()
    {
        hp = (int)maxHP;
        toHp = (int)maxHP;
    }
    //public bool RestoreHP(float val)
    //{
    //    if (0 == hp) return false;
    //    if (maxHP == hp) return false;

    //    val = val * hpRestore;
    //    hp = hp + val;
    //    if (hp > maxHP) hp = maxHP;

    //    return true;
    //}
}
