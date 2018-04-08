using System.Collections;
using System.Collections.Generic;
using System;

public class CharacterTemplate  {

    public int charType;
    public string name;
    public int maxLevel;
    public int skill0Id;
    public int skill0Level;
    public int skill1Id;
    public int skill1Level;
    public int skill2Id;
    public int skill2Level;
    public int skill3Id;
    public int skill3Level;
    public int skill4Id;
    public int skill4Level;
    public int wing;
    public int wingLevel;
    public int heart;
    public int heartLevel;
    public int weapon;
    public int weaponLevel;
    //level,CharacterLevelTemplate
    public Dictionary<int, CharacterLevelTemplate> dicCharacterLevelTemplate = new Dictionary<int, CharacterLevelTemplate>();

}
public class CharacterLevelTemplate
{
    public int charType;//角色类型
    public int level;//等级
    public long nextLevelExp;//需要的经验
    public int sp;//获得自由点数
    public int str;//力量
    public int dex;//敏捷
    public int vit;//体质
    public int brain;//智力
    public int gen;//宝石
    public long gold;//金币

}