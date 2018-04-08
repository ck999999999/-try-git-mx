using System.Collections;
using System.Collections.Generic;
using System;
public class WeaponTemplate  {

    public int id;
    public string name;
    public int charType;
    public int maxLevel;
    public Dictionary<int, WeaponLevelTemplate> dicWeaponLevelTemplte = new Dictionary<int, WeaponLevelTemplate>();
}

public class WeaponLevelTemplate
{
    public int id;
    public int level;
    public int exp;
    public int limitLevel;
    public int luck;
    public int attack;
    public int def;
    public int hp;
    public int mp;
    public int cost;
    public int dig;
}
