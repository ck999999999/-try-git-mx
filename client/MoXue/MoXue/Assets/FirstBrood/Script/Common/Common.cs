using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MainButtonType
{
    none=0,
    fight,
    skill,
    attribute,
    exchange,
    bitCoin,
    weapon,
    setting,
}
public enum CharacterType
{
    xuanyuan=1,
    murong,    
    dugu,
    yecha,
}
public enum CoinType
{
    gold = 1,
    gen,
    bitCoin,
    all,
}
public enum AttributeType
{
    strong=1,
    dex,
    vit,
    brain,
}
public class CommonArg
{
    public static string skillLeveUpCon = "人物等级{0},帝皇{1},金币{2}";
    public static string weaponLeveUpCon = "人物等级{0},帝皇{1}";
    public static string alreadyMaxLevel = " Max Level ,Good Job !";
    public static string levelFailed = "等级不够,升级失败";
    public static string genFailed = "帝皇不够,升级失败";
    public static string goldFailed = "金币不够,升级失败";
    public static string expFailed = "经验不足,升级失败";


    //public static string wingDes = "挖宝 {0},幸运 {1},攻击 {2},防御 {3},HP {4},MP {5}";
    //public static string heartDes = "挖宝 {0},幸运 {1},攻击 {2},防御 {3},HP {4},MP {5}";
    public static string weaponDes = "挖宝 {0},幸运 {1},攻击 {2},破防 {3},HP {4},MP {5}";
    public static string levelUpDes = "升级条件: 等级 {0},帝黄 {1}";
}

