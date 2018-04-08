using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterMuGongManager  {
    //所有技能,出生1级
    public static CharacterMuGongManager Instance;
    public float currentDamageParam1 = 0.25f;
    public float currentDamageParam2 = 100.0f;
    //等级
    public Dictionary<int, MuGongTemplate> dicMuGongTemplate = new Dictionary<int, MuGongTemplate>();
    const int rndValLen = 32;
    public float[] arrayEffectVal = new float[rndValLen];
    int indexRndEffectVal = 0;
    public void MakeRndEffectVal()
    {
        List<float> effectVals = MakeRndVal(0.9f,1.2f);
        for (int i = 0; i < rndValLen; i++)
        {
            arrayEffectVal[i] = effectVals[i];
        }
    }
    public void CheckRndVal()
    {
        for (int i = 0; i < rndValLen; i++)
        {
            if (0 == arrayEffectVal[i])
            {
                Debug.LogError("CheckRndVal:" + i );
            }
        }
    }
    public float GetRndEffectVal(float effectVal)
    {
        float val = effectVal * arrayEffectVal[indexRndEffectVal];
        indexRndEffectVal++;
        if (indexRndEffectVal >= rndValLen) indexRndEffectVal = 0;
        return val;
    }
    //public void CheckAllMuGongTemplateRndVal()
    //{
    //    foreach (var item in dicMuGongTemplate.Values)
    //    {
    //        foreach (var lt in item.muGongLevel.Values)
    //        {
    //            for (int i = 0; i < 64; i++)
    //            {
    //                if (0 == lt.GetRndEffectVal())
    //                {
    //                    //return false;
    //                    Debug.LogError("CheckAllMuGongTemplateRndVal:"+i+",lv:"+lt.level+",id:"+lt.muGongId);
    //                }
    //        }
    //        }
    //    }
    //}
    private List<float> MakeRndVal(float minVal, float maxVal)
    {
        List<float> lst = new List<float>(rndValLen + 1);
        for (int i = 0; i < rndValLen; i++)
        {
            for (; ; )
            {
                float val = System.Convert.ToSingle(System.Math.Round(UnityEngine.Random.Range(minVal, maxVal), 4));
                if (!lst.Contains(val) )
                {
                    lst.Add(val);
                    break;
                }
            }
        }
        return lst;
    }

    public static void Init()
    {
        Instance = new CharacterMuGongManager();
        Instance.InitMuGong();
    }
    public string GetMuGongName(int skillId)
    {
        return dicMuGongTemplate[skillId].name;
    }
    public MuGongTemplate GetMuGongTemplate(int skillId)
    {
        if (!dicMuGongTemplate.ContainsKey(skillId)) Debug.Log("error skill id : "+skillId.ToString());
        return dicMuGongTemplate[skillId];
    }
    public MuGongLevel GetMuGongLevelTemplate(int skillId,int level)
    {
        return dicMuGongTemplate[skillId].muGongLevel[level];
    }
    void InitMuGong()
    {
        MakeRndEffectVal();
        InitMuGong1();//洗髓经
        InitMuGong2();//易筋经

        InitMuGong11();//独孤九式
        InitMuGong12();//御剑术
        InitMuGong13();//分神斩
    }
     
    private void AddMuGongTemplate(MuGongTemplate mt)
    {
        dicMuGongTemplate.Add(mt.id, mt);
    }
    private void AddMuGongLevelTemplate(MuGongLevel mg)
    {
        //for (int i = 0; i < rndValLen; i++)
        //{
        //    mg.arrayEffectVal[i] = 1+ ( mg.mp *arrayEffectVal[i] / 100 );
        //}
        mg.effectVal = 1.0f + mg.mp / 100;
        dicMuGongTemplate[mg.muGongId].muGongLevel.Add(mg.level, mg);
        if (dicMuGongTemplate[mg.muGongId].maxLevel < mg.level)
        {
            dicMuGongTemplate[mg.muGongId].maxLevel = mg.level;
        }
    }

    #region initWuGongTemplate

    #region xuanyuan

    //独孤九式
    public void InitMuGong11()
    {
        MuGongTemplate mt_11 = new MuGongTemplate() { id = 11, name = "独孤九式", charType = 1, des = "独孤九式：远古时期,独孤大神的强大剑术,随中系数{0}" };
        AddMuGongTemplate(mt_11);

        MuGongLevel mg_11_1 = new MuGongLevel() { muGongId = 11, level = 1, limitLevel = 3, cost = 16, gold = 3540, mp = 30, seed = 5 }; AddMuGongLevelTemplate(mg_11_1);
        MuGongLevel mg_11_2 = new MuGongLevel() { muGongId = 11, level = 2, limitLevel = 6, cost = 43, gold = 9680, mp = 80, seed = 10 }; AddMuGongLevelTemplate(mg_11_2);
        MuGongLevel mg_11_3 = new MuGongLevel() { muGongId = 11, level = 3, limitLevel = 15, cost = 67, gold = 15600, mp = 120, seed = 15 }; AddMuGongLevelTemplate(mg_11_3);
        MuGongLevel mg_11_4 = new MuGongLevel() { muGongId = 11, level = 4, limitLevel = 25, cost = 125, gold = 31500, mp = 225, seed = 20 }; AddMuGongLevelTemplate(mg_11_4);
        MuGongLevel mg_11_5 = new MuGongLevel() { muGongId = 11, level = 5, limitLevel = 36, cost = 198, gold = 54360, mp = 360, seed = 25 }; AddMuGongLevelTemplate(mg_11_5);
        MuGongLevel mg_11_6 = new MuGongLevel() { muGongId = 11, level = 6, limitLevel = 48, cost = 288, gold = 86064, mp = 528, seed = 30 }; AddMuGongLevelTemplate(mg_11_6);
        MuGongLevel mg_11_7 = new MuGongLevel() { muGongId = 11, level = 7, limitLevel = 57, cost = 370, gold = 117648, mp = 684, seed = 35 }; AddMuGongLevelTemplate(mg_11_7);
        MuGongLevel mg_11_8 = new MuGongLevel() { muGongId = 11, level = 8, limitLevel = 66, cost = 462, gold = 155298, mp = 858, seed = 40 }; AddMuGongLevelTemplate(mg_11_8);
        MuGongLevel mg_11_9 = new MuGongLevel() { muGongId = 11, level = 9, limitLevel = 75, cost = 562, gold = 199500, mp = 1050, seed = 45 }; AddMuGongLevelTemplate(mg_11_9);
        MuGongLevel mg_11_10 = new MuGongLevel() { muGongId = 11, level = 10, limitLevel = 84, cost = 672, gold = 250740, mp = 1260, seed = 50 }; AddMuGongLevelTemplate(mg_11_10);
        MuGongLevel mg_11_11 = new MuGongLevel() { muGongId = 11, level = 11, limitLevel = 93, cost = 790, gold = 309504, mp = 1488, seed = 55 }; AddMuGongLevelTemplate(mg_11_11);
        MuGongLevel mg_11_12 = new MuGongLevel() { muGongId = 11, level = 12, limitLevel = 102, cost = 918, gold = 376278, mp = 1734, seed = 60 }; AddMuGongLevelTemplate(mg_11_12);
        MuGongLevel mg_11_13 = new MuGongLevel() { muGongId = 11, level = 13, limitLevel = 109, cost = 1035, gold = 439488, mp = 1962, seed = 65 }; AddMuGongLevelTemplate(mg_11_13);
        MuGongLevel mg_11_14 = new MuGongLevel() { muGongId = 11, level = 14, limitLevel = 116, cost = 1160, gold = 509124, mp = 2204, seed = 70 }; AddMuGongLevelTemplate(mg_11_14);
        MuGongLevel mg_11_15 = new MuGongLevel() { muGongId = 11, level = 15, limitLevel = 123, cost = 1291, gold = 585480, mp = 2460, seed = 75 }; AddMuGongLevelTemplate(mg_11_15);
        MuGongLevel mg_11_16 = new MuGongLevel() { muGongId = 11, level = 16, limitLevel = 130, cost = 1430, gold = 668850, mp = 2730, seed = 80 }; AddMuGongLevelTemplate(mg_11_16);
        MuGongLevel mg_11_17 = new MuGongLevel() { muGongId = 11, level = 17, limitLevel = 137, cost = 1575, gold = 759528, mp = 3014, seed = 85 }; AddMuGongLevelTemplate(mg_11_17);
        MuGongLevel mg_11_18 = new MuGongLevel() { muGongId = 11, level = 18, limitLevel = 144, cost = 1728, gold = 857808, mp = 3312, seed = 90 }; AddMuGongLevelTemplate(mg_11_18);
        MuGongLevel mg_11_19 = new MuGongLevel() { muGongId = 11, level = 19, limitLevel = 151, cost = 1887, gold = 963984, mp = 3624, seed = 95 }; AddMuGongLevelTemplate(mg_11_19);
        MuGongLevel mg_11_20 = new MuGongLevel() { muGongId = 11, level = 20, limitLevel = 156, cost = 2028, gold = 1056900, mp = 3900, seed = 100 }; AddMuGongLevelTemplate(mg_11_20);
        MuGongLevel mg_11_21 = new MuGongLevel() { muGongId = 11, level = 21, limitLevel = 161, cost = 2173, gold = 1155336, mp = 4186, seed = 105 }; AddMuGongLevelTemplate(mg_11_21);
        MuGongLevel mg_11_22 = new MuGongLevel() { muGongId = 11, level = 22, limitLevel = 166, cost = 2324, gold = 1259442, mp = 4482, seed = 110 }; AddMuGongLevelTemplate(mg_11_22);
        MuGongLevel mg_11_23 = new MuGongLevel() { muGongId = 11, level = 23, limitLevel = 171, cost = 2479, gold = 1369368, mp = 4788, seed = 115 }; AddMuGongLevelTemplate(mg_11_23);
        MuGongLevel mg_11_24 = new MuGongLevel() { muGongId = 11, level = 24, limitLevel = 176, cost = 2640, gold = 1485264, mp = 5104, seed = 120 }; AddMuGongLevelTemplate(mg_11_24);
        MuGongLevel mg_11_25 = new MuGongLevel() { muGongId = 11, level = 25, limitLevel = 181, cost = 2805, gold = 1607280, mp = 5430, seed = 125 }; AddMuGongLevelTemplate(mg_11_25);
        MuGongLevel mg_11_26 = new MuGongLevel() { muGongId = 11, level = 26, limitLevel = 184, cost = 2944, gold = 1705496, mp = 5704, seed = 130 }; AddMuGongLevelTemplate(mg_11_26);
        MuGongLevel mg_11_27 = new MuGongLevel() { muGongId = 11, level = 27, limitLevel = 187, cost = 3085, gold = 1807168, mp = 5984, seed = 135 }; AddMuGongLevelTemplate(mg_11_27);
        MuGongLevel mg_11_28 = new MuGongLevel() { muGongId = 11, level = 28, limitLevel = 190, cost = 3230, gold = 1912350, mp = 6270, seed = 140 }; AddMuGongLevelTemplate(mg_11_28);
        MuGongLevel mg_11_29 = new MuGongLevel() { muGongId = 11, level = 29, limitLevel = 193, cost = 3377, gold = 2021096, mp = 6562, seed = 145 }; AddMuGongLevelTemplate(mg_11_29);
        MuGongLevel mg_11_30 = new MuGongLevel() { muGongId = 11, level = 30, limitLevel = 196, cost = 3528, gold = 2133460, mp = 6860, seed = 150 }; AddMuGongLevelTemplate(mg_11_30);

    }

    //御剑术
    public void InitMuGong12()
    {
        MuGongTemplate mt_12 = new MuGongTemplate() { id = 12, name = "御剑术", charType = 1, des = "御剑术：一种神奇的攻击术,随中系数{0}" };
        AddMuGongTemplate(mt_12);

        MuGongLevel mg_12_1 = new MuGongLevel() { muGongId = 12, level = 1, limitLevel = 5, cost = 20, gold = 4200, mp = 35, seed = 5 }; AddMuGongLevelTemplate(mg_12_1);
        MuGongLevel mg_12_2 = new MuGongLevel() { muGongId = 12, level = 2, limitLevel = 11, cost = 55, gold = 12600, mp = 100, seed = 10 }; AddMuGongLevelTemplate(mg_12_2);
        MuGongLevel mg_12_3 = new MuGongLevel() { muGongId = 12, level = 3, limitLevel = 23, cost = 103, gold = 25392, mp = 184, seed = 15 }; AddMuGongLevelTemplate(mg_12_3);
        MuGongLevel mg_12_4 = new MuGongLevel() { muGongId = 12, level = 4, limitLevel = 32, cost = 160, gold = 42336, mp = 288, seed = 20 }; AddMuGongLevelTemplate(mg_12_4);
        MuGongLevel mg_12_5 = new MuGongLevel() { muGongId = 12, level = 5, limitLevel = 41, cost = 225, gold = 63960, mp = 410, seed = 25 }; AddMuGongLevelTemplate(mg_12_5);
        MuGongLevel mg_12_6 = new MuGongLevel() { muGongId = 12, level = 6, limitLevel = 50, cost = 300, gold = 90750, mp = 550, seed = 30 }; AddMuGongLevelTemplate(mg_12_6);
        MuGongLevel mg_12_7 = new MuGongLevel() { muGongId = 12, level = 7, limitLevel = 59, cost = 383, gold = 123192, mp = 708, seed = 35 }; AddMuGongLevelTemplate(mg_12_7);
        MuGongLevel mg_12_8 = new MuGongLevel() { muGongId = 12, level = 8, limitLevel = 68, cost = 476, gold = 161772, mp = 884, seed = 40 }; AddMuGongLevelTemplate(mg_12_8);
        MuGongLevel mg_12_9 = new MuGongLevel() { muGongId = 12, level = 9, limitLevel = 77, cost = 577, gold = 206976, mp = 1078, seed = 45 }; AddMuGongLevelTemplate(mg_12_9);
        MuGongLevel mg_12_10 = new MuGongLevel() { muGongId = 12, level = 10, limitLevel = 86, cost = 688, gold = 370230, mp = 1290, seed = 50 }; AddMuGongLevelTemplate(mg_12_10);
        MuGongLevel mg_12_11 = new MuGongLevel() { muGongId = 12, level = 11, limitLevel = 95, cost = 807, gold = 463600, mp = 1520, seed = 55 }; AddMuGongLevelTemplate(mg_12_11);
        MuGongLevel mg_12_12 = new MuGongLevel() { muGongId = 12, level = 12, limitLevel = 104, cost = 936, gold = 571064, mp = 1768, seed = 60 }; AddMuGongLevelTemplate(mg_12_12);
        MuGongLevel mg_12_13 = new MuGongLevel() { muGongId = 12, level = 13, limitLevel = 113, cost = 1073, gold = 693594, mp = 2034, seed = 65 }; AddMuGongLevelTemplate(mg_12_13);
        MuGongLevel mg_12_14 = new MuGongLevel() { muGongId = 12, level = 14, limitLevel = 122, cost = 1220, gold = 832162, mp = 2318, seed = 70 }; AddMuGongLevelTemplate(mg_12_14);
        MuGongLevel mg_12_15 = new MuGongLevel() { muGongId = 12, level = 15, limitLevel = 129, cost = 1354, gold = 962340, mp = 2580, seed = 75 }; AddMuGongLevelTemplate(mg_12_15);
        MuGongLevel mg_12_16 = new MuGongLevel() { muGongId = 12, level = 16, limitLevel = 136, cost = 1496, gold = 1105272, mp = 2856, seed = 80 }; AddMuGongLevelTemplate(mg_12_16);
        MuGongLevel mg_12_17 = new MuGongLevel() { muGongId = 12, level = 17, limitLevel = 143, cost = 1644, gold = 1261546, mp = 3146, seed = 85 }; AddMuGongLevelTemplate(mg_12_17);
        MuGongLevel mg_12_18 = new MuGongLevel() { muGongId = 12, level = 18, limitLevel = 150, cost = 1800, gold = 1431750, mp = 3450, seed = 90 }; AddMuGongLevelTemplate(mg_12_18);
        MuGongLevel mg_12_19 = new MuGongLevel() { muGongId = 12, level = 19, limitLevel = 155, cost = 1937, gold = 1581000, mp = 3720, seed = 95 }; AddMuGongLevelTemplate(mg_12_19);
        MuGongLevel mg_12_20 = new MuGongLevel() { muGongId = 12, level = 20, limitLevel = 160, cost = 2080, gold = 1740000, mp = 4000, seed = 100 }; AddMuGongLevelTemplate(mg_12_20);
        MuGongLevel mg_12_21 = new MuGongLevel() { muGongId = 12, level = 21, limitLevel = 165, cost = 2227, gold = 1909050, mp = 4290, seed = 105 }; AddMuGongLevelTemplate(mg_12_21);
        MuGongLevel mg_12_22 = new MuGongLevel() { muGongId = 12, level = 22, limitLevel = 170, cost = 2380, gold = 2088450, mp = 4590, seed = 110 }; AddMuGongLevelTemplate(mg_12_22);
        MuGongLevel mg_12_23 = new MuGongLevel() { muGongId = 12, level = 23, limitLevel = 175, cost = 2537, gold = 2278500, mp = 4900, seed = 115 }; AddMuGongLevelTemplate(mg_12_23);
        MuGongLevel mg_12_24 = new MuGongLevel() { muGongId = 12, level = 24, limitLevel = 180, cost = 2700, gold = 2479500, mp = 5220, seed = 120 }; AddMuGongLevelTemplate(mg_12_24);
        MuGongLevel mg_12_25 = new MuGongLevel() { muGongId = 12, level = 25, limitLevel = 183, cost = 2836, gold = 2640690, mp = 5490, seed = 125 }; AddMuGongLevelTemplate(mg_12_25);
        MuGongLevel mg_12_26 = new MuGongLevel() { muGongId = 12, level = 26, limitLevel = 186, cost = 2976, gold = 2808042, mp = 5766, seed = 130 }; AddMuGongLevelTemplate(mg_12_26);
        MuGongLevel mg_12_27 = new MuGongLevel() { muGongId = 12, level = 27, limitLevel = 189, cost = 3118, gold = 2981664, mp = 6048, seed = 135 }; AddMuGongLevelTemplate(mg_12_27);
        MuGongLevel mg_12_28 = new MuGongLevel() { muGongId = 12, level = 28, limitLevel = 192, cost = 3264, gold = 3161664, mp = 6336, seed = 140 }; AddMuGongLevelTemplate(mg_12_28);
        MuGongLevel mg_12_29 = new MuGongLevel() { muGongId = 12, level = 29, limitLevel = 195, cost = 3412, gold = 3348150, mp = 6630, seed = 145 }; AddMuGongLevelTemplate(mg_12_29);
        MuGongLevel mg_12_30 = new MuGongLevel() { muGongId = 12, level = 30, limitLevel = 198, cost = 3564, gold = 3541230, mp = 6930, seed = 150 }; AddMuGongLevelTemplate(mg_12_30);


    }

    //分神斩
    public void InitMuGong13()
    {
        MuGongTemplate mt_13 = new MuGongTemplate() { id = 13, name = "分神斩", charType = 1, des = "分神斩：召唤天神分身进行攻击,随中系数{0}" };
        AddMuGongTemplate(mt_13);

        MuGongLevel mg_13_1 = new MuGongLevel() { muGongId = 13, level = 1, limitLevel = 7, cost = 26, gold = 5490, mp = 45, seed = 5 }; AddMuGongLevelTemplate(mg_13_1);
        MuGongLevel mg_13_2 = new MuGongLevel() { muGongId = 13, level = 2, limitLevel = 13, cost = 61, gold = 14080, mp = 110, seed = 10 }; AddMuGongLevelTemplate(mg_13_2);
        MuGongLevel mg_13_3 = new MuGongLevel() { muGongId = 13, level = 3, limitLevel = 25, cost = 112, gold = 28000, mp = 200, seed = 15 }; AddMuGongLevelTemplate(mg_13_3);
        MuGongLevel mg_13_4 = new MuGongLevel() { muGongId = 13, level = 4, limitLevel = 34, cost = 170, gold = 45594, mp = 306, seed = 20 }; AddMuGongLevelTemplate(mg_13_4);
        MuGongLevel mg_13_5 = new MuGongLevel() { muGongId = 13, level = 5, limitLevel = 43, cost = 236, gold = 67940, mp = 430, seed = 25 }; AddMuGongLevelTemplate(mg_13_5);
        MuGongLevel mg_13_6 = new MuGongLevel() { muGongId = 13, level = 6, limitLevel = 52, cost = 312, gold = 95524, mp = 572, seed = 30 }; AddMuGongLevelTemplate(mg_13_6);
        MuGongLevel mg_13_7 = new MuGongLevel() { muGongId = 13, level = 7, limitLevel = 61, cost = 396, gold = 128832, mp = 732, seed = 35 }; AddMuGongLevelTemplate(mg_13_7);
        MuGongLevel mg_13_8 = new MuGongLevel() { muGongId = 13, level = 8, limitLevel = 70, cost = 490, gold = 168350, mp = 910, seed = 40 }; AddMuGongLevelTemplate(mg_13_8);
        MuGongLevel mg_13_9 = new MuGongLevel() { muGongId = 13, level = 9, limitLevel = 79, cost = 592, gold = 214564, mp = 1106, seed = 45 }; AddMuGongLevelTemplate(mg_13_9);
        MuGongLevel mg_13_10 = new MuGongLevel() { muGongId = 13, level = 10, limitLevel = 88, cost = 704, gold = 384120, mp = 1320, seed = 50 }; AddMuGongLevelTemplate(mg_13_10);
        MuGongLevel mg_13_11 = new MuGongLevel() { muGongId = 13, level = 11, limitLevel = 97, cost = 824, gold = 479568, mp = 1552, seed = 55 }; AddMuGongLevelTemplate(mg_13_11);
        MuGongLevel mg_13_12 = new MuGongLevel() { muGongId = 13, level = 12, limitLevel = 106, cost = 954, gold = 589254, mp = 1802, seed = 60 }; AddMuGongLevelTemplate(mg_13_12);
        MuGongLevel mg_13_13 = new MuGongLevel() { muGongId = 13, level = 13, limitLevel = 115, cost = 1092, gold = 714150, mp = 2070, seed = 65 }; AddMuGongLevelTemplate(mg_13_13);
        MuGongLevel mg_13_14 = new MuGongLevel() { muGongId = 13, level = 14, limitLevel = 124, cost = 1240, gold = 855228, mp = 2356, seed = 70 }; AddMuGongLevelTemplate(mg_13_14);
        MuGongLevel mg_13_15 = new MuGongLevel() { muGongId = 13, level = 15, limitLevel = 131, cost = 1375, gold = 987740, mp = 2620, seed = 75 }; AddMuGongLevelTemplate(mg_13_15);
        MuGongLevel mg_13_16 = new MuGongLevel() { muGongId = 13, level = 16, limitLevel = 138, cost = 1518, gold = 1133118, mp = 2898, seed = 80 }; AddMuGongLevelTemplate(mg_13_16);
        MuGongLevel mg_13_17 = new MuGongLevel() { muGongId = 13, level = 17, limitLevel = 145, cost = 1667, gold = 1291950, mp = 3190, seed = 85 }; AddMuGongLevelTemplate(mg_13_17);
        MuGongLevel mg_13_18 = new MuGongLevel() { muGongId = 13, level = 18, limitLevel = 152, cost = 1824, gold = 1464824, mp = 3496, seed = 90 }; AddMuGongLevelTemplate(mg_13_18);
        MuGongLevel mg_13_19 = new MuGongLevel() { muGongId = 13, level = 19, limitLevel = 157, cost = 1962, gold = 1616472, mp = 3768, seed = 95 }; AddMuGongLevelTemplate(mg_13_19);
        MuGongLevel mg_13_20 = new MuGongLevel() { muGongId = 13, level = 20, limitLevel = 162, cost = 2106, gold = 1777950, mp = 4050, seed = 100 }; AddMuGongLevelTemplate(mg_13_20);
        MuGongLevel mg_13_21 = new MuGongLevel() { muGongId = 13, level = 21, limitLevel = 167, cost = 2254, gold = 1949558, mp = 4342, seed = 105 }; AddMuGongLevelTemplate(mg_13_21);
        MuGongLevel mg_13_22 = new MuGongLevel() { muGongId = 13, level = 22, limitLevel = 172, cost = 2408, gold = 2131596, mp = 4644, seed = 110 }; AddMuGongLevelTemplate(mg_13_22);
        MuGongLevel mg_13_23 = new MuGongLevel() { muGongId = 13, level = 23, limitLevel = 177, cost = 2566, gold = 2324364, mp = 4956, seed = 115 }; AddMuGongLevelTemplate(mg_13_23);
        MuGongLevel mg_13_24 = new MuGongLevel() { muGongId = 13, level = 24, limitLevel = 182, cost = 2730, gold = 2528162, mp = 5278, seed = 120 }; AddMuGongLevelTemplate(mg_13_24);
        MuGongLevel mg_13_25 = new MuGongLevel() { muGongId = 13, level = 25, limitLevel = 185, cost = 2867, gold = 2691750, mp = 5550, seed = 125 }; AddMuGongLevelTemplate(mg_13_25);
        MuGongLevel mg_13_26 = new MuGongLevel() { muGongId = 13, level = 26, limitLevel = 188, cost = 3008, gold = 2861548, mp = 5828, seed = 130 }; AddMuGongLevelTemplate(mg_13_26);
        MuGongLevel mg_13_27 = new MuGongLevel() { muGongId = 13, level = 27, limitLevel = 191, cost = 3151, gold = 3037664, mp = 6112, seed = 135 }; AddMuGongLevelTemplate(mg_13_27);
        MuGongLevel mg_13_28 = new MuGongLevel() { muGongId = 13, level = 28, limitLevel = 194, cost = 3298, gold = 3220206, mp = 6402, seed = 140 }; AddMuGongLevelTemplate(mg_13_28);
        MuGongLevel mg_13_29 = new MuGongLevel() { muGongId = 13, level = 29, limitLevel = 197, cost = 3447, gold = 3409282, mp = 6698, seed = 145 }; AddMuGongLevelTemplate(mg_13_29);
        MuGongLevel mg_13_30 = new MuGongLevel() { muGongId = 13, level = 30, limitLevel = 200, cost = 3600, gold = 3605000, mp = 7000, seed = 150 }; AddMuGongLevelTemplate(mg_13_30);

    }

    #endregion

    #region Common

    //易筋经
    public void InitMuGong2()
    {
        MuGongTemplate mt_2 = new MuGongTemplate() { id = 2, name = "易筋经", charType = 0, des = "易筋经，远古时期最强MP恢复术" }; AddMuGongTemplate(mt_2);

        MuGongLevel mg_2_1 = new MuGongLevel() { muGongId = 2, level = 1, mp = 3, limitLevel = 3, cost = 5, gold = 795 }; AddMuGongLevelTemplate(mg_2_1);
        MuGongLevel mg_2_2 = new MuGongLevel() { muGongId = 2, level = 2, mp = 7, limitLevel = 7, cost = 10, gold = 1995 }; AddMuGongLevelTemplate(mg_2_2);
        MuGongLevel mg_2_3 = new MuGongLevel() { muGongId = 2, level = 3, mp = 12, limitLevel = 12, cost = 20, gold = 3720 }; AddMuGongLevelTemplate(mg_2_3);
        MuGongLevel mg_2_4 = new MuGongLevel() { muGongId = 2, level = 4, mp = 23, limitLevel = 25, cost = 30, gold = 8625 }; AddMuGongLevelTemplate(mg_2_4);
        MuGongLevel mg_2_5 = new MuGongLevel() { muGongId = 2, level = 5, mp = 32, limitLevel = 36, cost = 40, gold = 65600 }; AddMuGongLevelTemplate(mg_2_5);
        MuGongLevel mg_2_6 = new MuGongLevel() { muGongId = 2, level = 6, mp = 43, limitLevel = 49, cost = 50, gold = 116100 }; AddMuGongLevelTemplate(mg_2_6);
        MuGongLevel mg_2_7 = new MuGongLevel() { muGongId = 2, level = 7, mp = 50, limitLevel = 56, cost = 60, gold = 152500 }; AddMuGongLevelTemplate(mg_2_7);
        MuGongLevel mg_2_8 = new MuGongLevel() { muGongId = 2, level = 8, mp = 56, limitLevel = 63, cost = 70, gold = 190400 }; AddMuGongLevelTemplate(mg_2_8);
        MuGongLevel mg_2_9 = new MuGongLevel() { muGongId = 2, level = 9, mp = 62, limitLevel = 70, cost = 80, gold = 232500 }; AddMuGongLevelTemplate(mg_2_9);
        MuGongLevel mg_2_10 = new MuGongLevel() { muGongId = 2, level = 10, mp = 69, limitLevel = 77, cost = 90, gold = 282900 }; AddMuGongLevelTemplate(mg_2_10);
        MuGongLevel mg_2_11 = new MuGongLevel() { muGongId = 2, level = 11, mp = 75, limitLevel = 84, cost = 100, gold = 333750 }; AddMuGongLevelTemplate(mg_2_11);
        MuGongLevel mg_2_12 = new MuGongLevel() { muGongId = 2, level = 12, mp = 82, limitLevel = 91, cost = 110, gold = 393600 }; AddMuGongLevelTemplate(mg_2_12);
        MuGongLevel mg_2_13 = new MuGongLevel() { muGongId = 2, level = 13, mp = 88, limitLevel = 98, cost = 120, gold = 453200 }; AddMuGongLevelTemplate(mg_2_13);
        MuGongLevel mg_2_14 = new MuGongLevel() { muGongId = 2, level = 14, mp = 94, limitLevel = 105, cost = 130, gold = 517000 }; AddMuGongLevelTemplate(mg_2_14);
        MuGongLevel mg_2_15 = new MuGongLevel() { muGongId = 2, level = 15, mp = 101, limitLevel = 112, cost = 140, gold = 590850 }; AddMuGongLevelTemplate(mg_2_15);
        MuGongLevel mg_2_16 = new MuGongLevel() { muGongId = 2, level = 16, mp = 107, limitLevel = 119, cost = 150, gold = 663400 }; AddMuGongLevelTemplate(mg_2_16);
        MuGongLevel mg_2_17 = new MuGongLevel() { muGongId = 2, level = 17, mp = 113, limitLevel = 126, cost = 160, gold = 740150 }; AddMuGongLevelTemplate(mg_2_17);
        MuGongLevel mg_2_18 = new MuGongLevel() { muGongId = 2, level = 18, mp = 120, limitLevel = 133, cost = 170, gold = 828000 }; AddMuGongLevelTemplate(mg_2_18);
        MuGongLevel mg_2_19 = new MuGongLevel() { muGongId = 2, level = 19, mp = 126, limitLevel = 140, cost = 180, gold = 913500 }; AddMuGongLevelTemplate(mg_2_19);
        MuGongLevel mg_2_20 = new MuGongLevel() { muGongId = 2, level = 20, mp = 131, limitLevel = 145, cost = 190, gold = 982500 }; AddMuGongLevelTemplate(mg_2_20);
        MuGongLevel mg_2_21 = new MuGongLevel() { muGongId = 2, level = 21, mp = 136, limitLevel = 150, cost = 200, gold = 1054000 }; AddMuGongLevelTemplate(mg_2_21);
        MuGongLevel mg_2_22 = new MuGongLevel() { muGongId = 2, level = 22, mp = 141, limitLevel = 155, cost = 210, gold = 1128000 }; AddMuGongLevelTemplate(mg_2_22);
        MuGongLevel mg_2_23 = new MuGongLevel() { muGongId = 2, level = 23, mp = 146, limitLevel = 160, cost = 220, gold = 1204500 }; AddMuGongLevelTemplate(mg_2_23);
        MuGongLevel mg_2_24 = new MuGongLevel() { muGongId = 2, level = 24, mp = 150, limitLevel = 165, cost = 230, gold = 1275000 }; AddMuGongLevelTemplate(mg_2_24);
        MuGongLevel mg_2_25 = new MuGongLevel() { muGongId = 2, level = 25, mp = 155, limitLevel = 170, cost = 240, gold = 1356250 }; AddMuGongLevelTemplate(mg_2_25);
        MuGongLevel mg_2_26 = new MuGongLevel() { muGongId = 2, level = 26, mp = 160, limitLevel = 175, cost = 250, gold = 1440000 }; AddMuGongLevelTemplate(mg_2_26);
        MuGongLevel mg_2_27 = new MuGongLevel() { muGongId = 2, level = 27, mp = 165, limitLevel = 180, cost = 260, gold = 1526250 }; AddMuGongLevelTemplate(mg_2_27);
        MuGongLevel mg_2_28 = new MuGongLevel() { muGongId = 2, level = 28, mp = 170, limitLevel = 185, cost = 270, gold = 1615000 }; AddMuGongLevelTemplate(mg_2_28);
        MuGongLevel mg_2_29 = new MuGongLevel() { muGongId = 2, level = 29, mp = 175, limitLevel = 190, cost = 280, gold = 1706250 }; AddMuGongLevelTemplate(mg_2_29);
        MuGongLevel mg_2_30 = new MuGongLevel() { muGongId = 2, level = 30, mp = 180, limitLevel = 195, cost = 290, gold = 1800000 }; AddMuGongLevelTemplate(mg_2_30);

    }

    //洗髓经
    public void InitMuGong1()
    {
        MuGongTemplate mt_1 = new MuGongTemplate() { id = 1, name = "洗髓经", charType = 0, des = "洗髓经：远古时期最强HP恢复术,传说身体越好越幸运" }; AddMuGongTemplate(mt_1);

        MuGongLevel mg_1_1 = new MuGongLevel() { muGongId = 1, level = 1, mp = 2, limitLevel = 5, cost = 5, gold = 270 }; AddMuGongLevelTemplate(mg_1_1);
        MuGongLevel mg_1_2 = new MuGongLevel() { muGongId = 1, level = 2, mp = 20, limitLevel = 15, cost = 25, gold = 2900 }; AddMuGongLevelTemplate(mg_1_2);
        MuGongLevel mg_1_3 = new MuGongLevel() { muGongId = 1, level = 3, mp = 35, limitLevel = 25, cost = 45, gold = 5425 }; AddMuGongLevelTemplate(mg_1_3);
        MuGongLevel mg_1_4 = new MuGongLevel() { muGongId = 1, level = 4, mp = 50, limitLevel = 35, cost = 65, gold = 8250 }; AddMuGongLevelTemplate(mg_1_4);
        MuGongLevel mg_1_5 = new MuGongLevel() { muGongId = 1, level = 5, mp = 80, limitLevel = 45, cost = 95, gold = 14000 }; AddMuGongLevelTemplate(mg_1_5);
        MuGongLevel mg_1_6 = new MuGongLevel() { muGongId = 1, level = 6, mp = 110, limitLevel = 55, cost = 125, gold = 20350 }; AddMuGongLevelTemplate(mg_1_6);
        MuGongLevel mg_1_7 = new MuGongLevel() { muGongId = 1, level = 7, mp = 140, limitLevel = 65, cost = 155, gold = 27300 }; AddMuGongLevelTemplate(mg_1_7);
        MuGongLevel mg_1_8 = new MuGongLevel() { muGongId = 1, level = 8, mp = 170, limitLevel = 75, cost = 185, gold = 34850 }; AddMuGongLevelTemplate(mg_1_8);
        MuGongLevel mg_1_9 = new MuGongLevel() { muGongId = 1, level = 9, mp = 200, limitLevel = 85, cost = 215, gold = 47000 }; AddMuGongLevelTemplate(mg_1_9);
        MuGongLevel mg_1_10 = new MuGongLevel() { muGongId = 1, level = 10, mp = 245, limitLevel = 95, cost = 255, gold = 60025 }; AddMuGongLevelTemplate(mg_1_10);
        MuGongLevel mg_1_11 = new MuGongLevel() { muGongId = 1, level = 11, mp = 290, limitLevel = 105, cost = 295, gold = 73950 }; AddMuGongLevelTemplate(mg_1_11);
        MuGongLevel mg_1_12 = new MuGongLevel() { muGongId = 1, level = 12, mp = 335, limitLevel = 115, cost = 335, gold = 98825 }; AddMuGongLevelTemplate(mg_1_12);
        MuGongLevel mg_1_13 = new MuGongLevel() { muGongId = 1, level = 13, mp = 380, limitLevel = 125, cost = 375, gold = 115900 }; AddMuGongLevelTemplate(mg_1_13);
        MuGongLevel mg_1_14 = new MuGongLevel() { muGongId = 1, level = 14, mp = 425, limitLevel = 135, cost = 415, gold = 133875 }; AddMuGongLevelTemplate(mg_1_14);
        MuGongLevel mg_1_15 = new MuGongLevel() { muGongId = 1, level = 15, mp = 485, limitLevel = 145, cost = 465, gold = 240075 }; AddMuGongLevelTemplate(mg_1_15);
        MuGongLevel mg_1_16 = new MuGongLevel() { muGongId = 1, level = 16, mp = 545, limitLevel = 155, cost = 515, gold = 329725 }; AddMuGongLevelTemplate(mg_1_16);
        MuGongLevel mg_1_17 = new MuGongLevel() { muGongId = 1, level = 17, mp = 605, limitLevel = 165, cost = 565, gold = 414425 }; AddMuGongLevelTemplate(mg_1_17);
        MuGongLevel mg_1_18 = new MuGongLevel() { muGongId = 1, level = 18, mp = 665, limitLevel = 175, cost = 700, gold = 581875 }; AddMuGongLevelTemplate(mg_1_18);
        MuGongLevel mg_1_19 = new MuGongLevel() { muGongId = 1, level = 19, mp = 725, limitLevel = 185, cost = 900, gold = 822875 }; AddMuGongLevelTemplate(mg_1_19);
        MuGongLevel mg_1_20 = new MuGongLevel() { muGongId = 1, level = 20, mp = 800, limitLevel = 195, cost = 3000, gold = 916000 }; AddMuGongLevelTemplate(mg_1_20);


    }

    #endregion

    #endregion


}
