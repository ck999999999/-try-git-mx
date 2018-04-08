using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModelManager  {

    //角色属性出生点
    public static CharacterModelManager Instance;

    public Dictionary<int, CharacterTemplate> dicCharacterTempate = new Dictionary<int, CharacterTemplate>();

    public static void Init()
    {
        Instance = new CharacterModelManager();
        Instance.InitData();
    }

    void InitData()
    {
        //角色
        CharacterTemplate ct_1 = new CharacterTemplate() { charType = 1, name = "轩辕", skill0Id = 1, skill0Level = 1, skill1Id = 2, skill1Level = 1, skill2Id = 11, skill2Level = 1, skill3Id = 12, skill3Level = 1, skill4Id = 13, skill4Level = 1, wing = 11, wingLevel = 1, heart = 12, heartLevel = 1, weapon = 13, weaponLevel = 1 }; AddCharacterTemplate(ct_1);
        //CharacterTemplate ct_2 = new CharacterTemplate() { charType = 2, name = "慕容", skill0Id = 1, skill0Level = 1, skill1Id = 2, skill1Level = 1, skill2Id = 21, skill2Level = 1, skill3Id = 22, skill3Level = 1, skill4Id = 23, skill4Level = 1, wing = 11, wingLevel = 1, heart = 22, heartLevel = 1, weapon = 23, weaponLevel = 1 }; AddCharacterTemplate(ct_2);
        //CharacterTemplate ct_3 = new CharacterTemplate() { charType = 3, name = "独孤", skill0Id = 1, skill0Level = 1, skill1Id = 2, skill1Level = 1, skill2Id = 31, skill2Level = 1, skill3Id = 32, skill3Level = 1, skill4Id = 33, skill4Level = 1, wing = 31, wingLevel = 1, heart = 32, heartLevel = 1, weapon = 33, weaponLevel = 1 }; AddCharacterTemplate(ct_3);
        //CharacterTemplate ct_4 = new CharacterTemplate() { charType = 4, name = "夜叉", skill0Id = 1, skill0Level = 1, skill1Id = 2, skill1Level = 1, skill2Id = 41, skill2Level = 1, skill3Id = 42, skill3Level = 1, skill4Id = 43, skill4Level = 1, wing = 41, wingLevel = 1, heart = 42, heartLevel = 1, weapon = 43, weaponLevel = 1 }; AddCharacterTemplate(ct_4);

        //等级和经验
        InitXuanYuanCharacterLevelTemplate();
        //InitMuRongCharacterLevelTemplate();
        //InitDuGuCharacterLevelTemplate();
        //InitYeChaCharacterLevelTemplate();
    }
    
    public CharacterTemplate GetCharacterTemplate(int charType)
    {
        return dicCharacterTempate[charType];
    }

    public bool HaveNextLevel(int charType, int nowLevel)
    {
        return (nowLevel<dicCharacterTempate[charType].maxLevel);
    }

    public CharacterLevelTemplate GetCharacterLevelTemplate(int charType, int level)
    {
        return dicCharacterTempate[charType].dicCharacterLevelTemplate[level];
    }

    #region Insert Template

    void AddCharacterTemplate(CharacterTemplate ct)
    {
        dicCharacterTempate.Add(ct.charType, ct);
    }

    void AddCharacterLevelTemplate(CharacterLevelTemplate clt)
    {
        CharacterTemplate ct = dicCharacterTempate[clt.charType];
        if (ct.maxLevel < clt.level) ct.maxLevel = clt.level;

        ct.dicCharacterLevelTemplate.Add(clt.level, clt);
    }

    #endregion

    #region xuanyuan 

    void InitXuanYuanCharacterLevelTemplate()
    {
        CharacterLevelTemplate clt_1 = new CharacterLevelTemplate() { level = 1, nextLevelExp = 50, sp = 5, str = 5, dex = 6, vit = 5, brain = 5, gen = 100, gold = 15000, charType = 1 }; AddCharacterLevelTemplate(clt_1);
        CharacterLevelTemplate clt_2 = new CharacterLevelTemplate() { level = 2, nextLevelExp = 184, sp = 3, str = 2, dex = 3, vit = 2, brain = 2, gen = 5, gold = 100, charType = 1 }; AddCharacterLevelTemplate(clt_2);
        CharacterLevelTemplate clt_3 = new CharacterLevelTemplate() { level = 3, nextLevelExp = 381, sp = 3, str = 2, dex = 3, vit = 2, brain = 2, gen = 7, gold = 150, charType = 1 }; AddCharacterLevelTemplate(clt_3);
        CharacterLevelTemplate clt_4 = new CharacterLevelTemplate() { level = 4, nextLevelExp = 650, sp = 3, str = 2, dex = 3, vit = 2, brain = 2, gen = 10, gold = 200, charType = 1 }; AddCharacterLevelTemplate(clt_4);
        CharacterLevelTemplate clt_5 = new CharacterLevelTemplate() { level = 5, nextLevelExp = 1000, sp = 3, str = 2, dex = 3, vit = 2, brain = 2, gen = 12, gold = 250, charType = 1 }; AddCharacterLevelTemplate(clt_5);
        CharacterLevelTemplate clt_6 = new CharacterLevelTemplate() { level = 6, nextLevelExp = 1442, sp = 3, str = 2, dex = 3, vit = 2, brain = 2, gen = 15, gold = 300, charType = 1 }; AddCharacterLevelTemplate(clt_6);
        CharacterLevelTemplate clt_7 = new CharacterLevelTemplate() { level = 7, nextLevelExp = 1986, sp = 3, str = 2, dex = 3, vit = 2, brain = 2, gen = 17, gold = 350, charType = 1 }; AddCharacterLevelTemplate(clt_7);
        CharacterLevelTemplate clt_8 = new CharacterLevelTemplate() { level = 8, nextLevelExp = 2643, sp = 3, str = 2, dex = 3, vit = 2, brain = 2, gen = 20, gold = 400, charType = 1 }; AddCharacterLevelTemplate(clt_8);
        CharacterLevelTemplate clt_9 = new CharacterLevelTemplate() { level = 9, nextLevelExp = 3425, sp = 3, str = 2, dex = 3, vit = 2, brain = 2, gen = 22, gold = 450, charType = 1 }; AddCharacterLevelTemplate(clt_9);
        CharacterLevelTemplate clt_10 = new CharacterLevelTemplate() { level = 10, nextLevelExp = 4344, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 150, gold = 17500, charType = 1 }; AddCharacterLevelTemplate(clt_10);
        CharacterLevelTemplate clt_11 = new CharacterLevelTemplate() { level = 11, nextLevelExp = 5413, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 27, gold = 550, charType = 1 }; AddCharacterLevelTemplate(clt_11);
        CharacterLevelTemplate clt_12 = new CharacterLevelTemplate() { level = 12, nextLevelExp = 6645, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 30, gold = 600, charType = 1 }; AddCharacterLevelTemplate(clt_12);
        CharacterLevelTemplate clt_13 = new CharacterLevelTemplate() { level = 13, nextLevelExp = 8055, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 32, gold = 650, charType = 1 }; AddCharacterLevelTemplate(clt_13);
        CharacterLevelTemplate clt_14 = new CharacterLevelTemplate() { level = 14, nextLevelExp = 9657, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 35, gold = 700, charType = 1 }; AddCharacterLevelTemplate(clt_14);
        CharacterLevelTemplate clt_15 = new CharacterLevelTemplate() { level = 15, nextLevelExp = 11467, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 37, gold = 750, charType = 1 }; AddCharacterLevelTemplate(clt_15);
        CharacterLevelTemplate clt_16 = new CharacterLevelTemplate() { level = 16, nextLevelExp = 13502, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 40, gold = 800, charType = 1 }; AddCharacterLevelTemplate(clt_16);
        CharacterLevelTemplate clt_17 = new CharacterLevelTemplate() { level = 17, nextLevelExp = 15779, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 42, gold = 850, charType = 1 }; AddCharacterLevelTemplate(clt_17);
        CharacterLevelTemplate clt_18 = new CharacterLevelTemplate() { level = 18, nextLevelExp = 18315, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 45, gold = 900, charType = 1 }; AddCharacterLevelTemplate(clt_18);
        CharacterLevelTemplate clt_19 = new CharacterLevelTemplate() { level = 19, nextLevelExp = 21130, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 47, gold = 950, charType = 1 }; AddCharacterLevelTemplate(clt_19);
        CharacterLevelTemplate clt_20 = new CharacterLevelTemplate() { level = 20, nextLevelExp = 24244, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 250, gold = 20000, charType = 1 }; AddCharacterLevelTemplate(clt_20);
        CharacterLevelTemplate clt_21 = new CharacterLevelTemplate() { level = 21, nextLevelExp = 27678, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 52, gold = 1050, charType = 1 }; AddCharacterLevelTemplate(clt_21);
        CharacterLevelTemplate clt_22 = new CharacterLevelTemplate() { level = 22, nextLevelExp = 31453, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 55, gold = 1100, charType = 1 }; AddCharacterLevelTemplate(clt_22);
        CharacterLevelTemplate clt_23 = new CharacterLevelTemplate() { level = 23, nextLevelExp = 35593, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 57, gold = 1150, charType = 1 }; AddCharacterLevelTemplate(clt_23);
        CharacterLevelTemplate clt_24 = new CharacterLevelTemplate() { level = 24, nextLevelExp = 40122, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 60, gold = 1200, charType = 1 }; AddCharacterLevelTemplate(clt_24);
        CharacterLevelTemplate clt_25 = new CharacterLevelTemplate() { level = 25, nextLevelExp = 45066, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 62, gold = 1250, charType = 1 }; AddCharacterLevelTemplate(clt_25);
        CharacterLevelTemplate clt_26 = new CharacterLevelTemplate() { level = 26, nextLevelExp = 50451, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 65, gold = 1300, charType = 1 }; AddCharacterLevelTemplate(clt_26);
        CharacterLevelTemplate clt_27 = new CharacterLevelTemplate() { level = 27, nextLevelExp = 56305, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 67, gold = 1350, charType = 1 }; AddCharacterLevelTemplate(clt_27);
        CharacterLevelTemplate clt_28 = new CharacterLevelTemplate() { level = 28, nextLevelExp = 62658, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 70, gold = 1400, charType = 1 }; AddCharacterLevelTemplate(clt_28);
        CharacterLevelTemplate clt_29 = new CharacterLevelTemplate() { level = 29, nextLevelExp = 69540, sp = 3, str = 4, dex = 5, vit = 4, brain = 4, gen = 72, gold = 1450, charType = 1 }; AddCharacterLevelTemplate(clt_29);
        CharacterLevelTemplate clt_30 = new CharacterLevelTemplate() { level = 30, nextLevelExp = 76985, sp = 5, str = 9, dex = 11, vit = 9, brain = 9, gen = 350, gold = 22500, charType = 1 }; AddCharacterLevelTemplate(clt_30);
        CharacterLevelTemplate clt_31 = new CharacterLevelTemplate() { level = 31, nextLevelExp = 85026, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 77, gold = 1550, charType = 1 }; AddCharacterLevelTemplate(clt_31);
        CharacterLevelTemplate clt_32 = new CharacterLevelTemplate() { level = 32, nextLevelExp = 93699, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 80, gold = 1600, charType = 1 }; AddCharacterLevelTemplate(clt_32);
        CharacterLevelTemplate clt_33 = new CharacterLevelTemplate() { level = 33, nextLevelExp = 103041, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 82, gold = 1650, charType = 1 }; AddCharacterLevelTemplate(clt_33);
        CharacterLevelTemplate clt_34 = new CharacterLevelTemplate() { level = 34, nextLevelExp = 113093, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 85, gold = 1700, charType = 1 }; AddCharacterLevelTemplate(clt_34);
        CharacterLevelTemplate clt_35 = new CharacterLevelTemplate() { level = 35, nextLevelExp = 123895, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 87, gold = 1750, charType = 1 }; AddCharacterLevelTemplate(clt_35);
        CharacterLevelTemplate clt_36 = new CharacterLevelTemplate() { level = 36, nextLevelExp = 135491, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 90, gold = 1800, charType = 1 }; AddCharacterLevelTemplate(clt_36);
        CharacterLevelTemplate clt_37 = new CharacterLevelTemplate() { level = 37, nextLevelExp = 147927, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 92, gold = 1850, charType = 1 }; AddCharacterLevelTemplate(clt_37);
        CharacterLevelTemplate clt_38 = new CharacterLevelTemplate() { level = 38, nextLevelExp = 161251, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 95, gold = 1900, charType = 1 }; AddCharacterLevelTemplate(clt_38);
        CharacterLevelTemplate clt_39 = new CharacterLevelTemplate() { level = 39, nextLevelExp = 175513, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 97, gold = 1950, charType = 1 }; AddCharacterLevelTemplate(clt_39);
        CharacterLevelTemplate clt_40 = new CharacterLevelTemplate() { level = 40, nextLevelExp = 190766, sp = 5, str = 12, dex = 15, vit = 12, brain = 12, gen = 450, gold = 25000, charType = 1 }; AddCharacterLevelTemplate(clt_40);
        CharacterLevelTemplate clt_41 = new CharacterLevelTemplate() { level = 41, nextLevelExp = 207066, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 102, gold = 2050, charType = 1 }; AddCharacterLevelTemplate(clt_41);
        CharacterLevelTemplate clt_42 = new CharacterLevelTemplate() { level = 42, nextLevelExp = 224471, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 105, gold = 2100, charType = 1 }; AddCharacterLevelTemplate(clt_42);
        CharacterLevelTemplate clt_43 = new CharacterLevelTemplate() { level = 43, nextLevelExp = 243042, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 107, gold = 2150, charType = 1 }; AddCharacterLevelTemplate(clt_43);
        CharacterLevelTemplate clt_44 = new CharacterLevelTemplate() { level = 44, nextLevelExp = 262844, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 110, gold = 2200, charType = 1 }; AddCharacterLevelTemplate(clt_44);
        CharacterLevelTemplate clt_45 = new CharacterLevelTemplate() { level = 45, nextLevelExp = 283944, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 112, gold = 2250, charType = 1 }; AddCharacterLevelTemplate(clt_45);
        CharacterLevelTemplate clt_46 = new CharacterLevelTemplate() { level = 46, nextLevelExp = 306413, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 115, gold = 2300, charType = 1 }; AddCharacterLevelTemplate(clt_46);
        CharacterLevelTemplate clt_47 = new CharacterLevelTemplate() { level = 47, nextLevelExp = 330325, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 117, gold = 2350, charType = 1 }; AddCharacterLevelTemplate(clt_47);
        CharacterLevelTemplate clt_48 = new CharacterLevelTemplate() { level = 48, nextLevelExp = 355759, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 120, gold = 2400, charType = 1 }; AddCharacterLevelTemplate(clt_48);
        CharacterLevelTemplate clt_49 = new CharacterLevelTemplate() { level = 49, nextLevelExp = 382796, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 122, gold = 2450, charType = 1 }; AddCharacterLevelTemplate(clt_49);
        CharacterLevelTemplate clt_50 = new CharacterLevelTemplate() { level = 50, nextLevelExp = 411523, sp = 5, str = 17, dex = 20, vit = 17, brain = 17, gen = 550, gold = 27500, charType = 1 }; AddCharacterLevelTemplate(clt_50);
        CharacterLevelTemplate clt_51 = new CharacterLevelTemplate() { level = 51, nextLevelExp = 442031, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 127, gold = 2550, charType = 1 }; AddCharacterLevelTemplate(clt_51);
        CharacterLevelTemplate clt_52 = new CharacterLevelTemplate() { level = 52, nextLevelExp = 474414, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 130, gold = 2600, charType = 1 }; AddCharacterLevelTemplate(clt_52);
        CharacterLevelTemplate clt_53 = new CharacterLevelTemplate() { level = 53, nextLevelExp = 508772, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 132, gold = 2650, charType = 1 }; AddCharacterLevelTemplate(clt_53);
        CharacterLevelTemplate clt_54 = new CharacterLevelTemplate() { level = 54, nextLevelExp = 545210, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 135, gold = 2700, charType = 1 }; AddCharacterLevelTemplate(clt_54);
        CharacterLevelTemplate clt_55 = new CharacterLevelTemplate() { level = 55, nextLevelExp = 583838, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 137, gold = 2750, charType = 1 }; AddCharacterLevelTemplate(clt_55);
        CharacterLevelTemplate clt_56 = new CharacterLevelTemplate() { level = 56, nextLevelExp = 624771, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 140, gold = 2800, charType = 1 }; AddCharacterLevelTemplate(clt_56);
        CharacterLevelTemplate clt_57 = new CharacterLevelTemplate() { level = 57, nextLevelExp = 668131, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 142, gold = 2850, charType = 1 }; AddCharacterLevelTemplate(clt_57);
        CharacterLevelTemplate clt_58 = new CharacterLevelTemplate() { level = 58, nextLevelExp = 714045, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 145, gold = 2900, charType = 1 }; AddCharacterLevelTemplate(clt_58);
        CharacterLevelTemplate clt_59 = new CharacterLevelTemplate() { level = 59, nextLevelExp = 762647, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 147, gold = 2950, charType = 1 }; AddCharacterLevelTemplate(clt_59);
        CharacterLevelTemplate clt_60 = new CharacterLevelTemplate() { level = 60, nextLevelExp = 814077, sp = 5, str = 22, dex = 26, vit = 22, brain = 22, gen = 650, gold = 30000, charType = 1 }; AddCharacterLevelTemplate(clt_60);
        CharacterLevelTemplate clt_61 = new CharacterLevelTemplate() { level = 61, nextLevelExp = 868482, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 152, gold = 3050, charType = 1 }; AddCharacterLevelTemplate(clt_61);
        CharacterLevelTemplate clt_62 = new CharacterLevelTemplate() { level = 62, nextLevelExp = 926018, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 155, gold = 3100, charType = 1 }; AddCharacterLevelTemplate(clt_62);
        CharacterLevelTemplate clt_63 = new CharacterLevelTemplate() { level = 63, nextLevelExp = 986846, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 157, gold = 3150, charType = 1 }; AddCharacterLevelTemplate(clt_63);
        CharacterLevelTemplate clt_64 = new CharacterLevelTemplate() { level = 64, nextLevelExp = 1051138, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 160, gold = 3200, charType = 1 }; AddCharacterLevelTemplate(clt_64);
        CharacterLevelTemplate clt_65 = new CharacterLevelTemplate() { level = 65, nextLevelExp = 1119072, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 162, gold = 3250, charType = 1 }; AddCharacterLevelTemplate(clt_65);
        CharacterLevelTemplate clt_66 = new CharacterLevelTemplate() { level = 66, nextLevelExp = 1190837, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 165, gold = 3300, charType = 1 }; AddCharacterLevelTemplate(clt_66);
        CharacterLevelTemplate clt_67 = new CharacterLevelTemplate() { level = 67, nextLevelExp = 1266630, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 167, gold = 3350, charType = 1 }; AddCharacterLevelTemplate(clt_67);
        CharacterLevelTemplate clt_68 = new CharacterLevelTemplate() { level = 68, nextLevelExp = 1346659, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 170, gold = 3400, charType = 1 }; AddCharacterLevelTemplate(clt_68);
        CharacterLevelTemplate clt_69 = new CharacterLevelTemplate() { level = 69, nextLevelExp = 1431141, sp = 3, str = 5, dex = 6, vit = 5, brain = 5, gen = 172, gold = 3450, charType = 1 }; AddCharacterLevelTemplate(clt_69);
        CharacterLevelTemplate clt_70 = new CharacterLevelTemplate() { level = 70, nextLevelExp = 1520306, sp = 10, str = 25, dex = 30, vit = 25, brain = 25, gen = 750, gold = 32500, charType = 1 }; AddCharacterLevelTemplate(clt_70);
        CharacterLevelTemplate clt_71 = new CharacterLevelTemplate() { level = 71, nextLevelExp = 1614393, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 177, gold = 3550, charType = 1 }; AddCharacterLevelTemplate(clt_71);
        CharacterLevelTemplate clt_72 = new CharacterLevelTemplate() { level = 72, nextLevelExp = 1713654, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 180, gold = 3600, charType = 1 }; AddCharacterLevelTemplate(clt_72);
        CharacterLevelTemplate clt_73 = new CharacterLevelTemplate() { level = 73, nextLevelExp = 1818354, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 182, gold = 3650, charType = 1 }; AddCharacterLevelTemplate(clt_73);
        CharacterLevelTemplate clt_74 = new CharacterLevelTemplate() { level = 74, nextLevelExp = 1928771, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 185, gold = 3700, charType = 1 }; AddCharacterLevelTemplate(clt_74);
        CharacterLevelTemplate clt_75 = new CharacterLevelTemplate() { level = 75, nextLevelExp = 2045197, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 187, gold = 3750, charType = 1 }; AddCharacterLevelTemplate(clt_75);
        CharacterLevelTemplate clt_76 = new CharacterLevelTemplate() { level = 76, nextLevelExp = 2167938, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 190, gold = 3800, charType = 1 }; AddCharacterLevelTemplate(clt_76);
        CharacterLevelTemplate clt_77 = new CharacterLevelTemplate() { level = 77, nextLevelExp = 2297316, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 192, gold = 3850, charType = 1 }; AddCharacterLevelTemplate(clt_77);
        CharacterLevelTemplate clt_78 = new CharacterLevelTemplate() { level = 78, nextLevelExp = 2433669, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 195, gold = 3900, charType = 1 }; AddCharacterLevelTemplate(clt_78);
        CharacterLevelTemplate clt_79 = new CharacterLevelTemplate() { level = 79, nextLevelExp = 2577352, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 197, gold = 3950, charType = 1 }; AddCharacterLevelTemplate(clt_79);
        CharacterLevelTemplate clt_80 = new CharacterLevelTemplate() { level = 80, nextLevelExp = 2728737, sp = 10, str = 25, dex = 30, vit = 25, brain = 25, gen = 850, gold = 35000, charType = 1 }; AddCharacterLevelTemplate(clt_80);
        CharacterLevelTemplate clt_81 = new CharacterLevelTemplate() { level = 81, nextLevelExp = 2888215, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 202, gold = 4050, charType = 1 }; AddCharacterLevelTemplate(clt_81);
        CharacterLevelTemplate clt_82 = new CharacterLevelTemplate() { level = 82, nextLevelExp = 3056197, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 205, gold = 4100, charType = 1 }; AddCharacterLevelTemplate(clt_82);
        CharacterLevelTemplate clt_83 = new CharacterLevelTemplate() { level = 83, nextLevelExp = 3233114, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 207, gold = 4150, charType = 1 }; AddCharacterLevelTemplate(clt_83);
        CharacterLevelTemplate clt_84 = new CharacterLevelTemplate() { level = 84, nextLevelExp = 3419419, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 210, gold = 4200, charType = 1 }; AddCharacterLevelTemplate(clt_84);
        CharacterLevelTemplate clt_85 = new CharacterLevelTemplate() { level = 85, nextLevelExp = 3615587, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 212, gold = 4250, charType = 1 }; AddCharacterLevelTemplate(clt_85);
        CharacterLevelTemplate clt_86 = new CharacterLevelTemplate() { level = 86, nextLevelExp = 3822118, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 215, gold = 4300, charType = 1 }; AddCharacterLevelTemplate(clt_86);
        CharacterLevelTemplate clt_87 = new CharacterLevelTemplate() { level = 87, nextLevelExp = 4039535, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 217, gold = 4350, charType = 1 }; AddCharacterLevelTemplate(clt_87);
        CharacterLevelTemplate clt_88 = new CharacterLevelTemplate() { level = 88, nextLevelExp = 4268389, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 220, gold = 4400, charType = 1 }; AddCharacterLevelTemplate(clt_88);
        CharacterLevelTemplate clt_89 = new CharacterLevelTemplate() { level = 89, nextLevelExp = 4509258, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 222, gold = 4450, charType = 1 }; AddCharacterLevelTemplate(clt_89);
        CharacterLevelTemplate clt_90 = new CharacterLevelTemplate() { level = 90, nextLevelExp = 4762748, sp = 10, str = 25, dex = 30, vit = 25, brain = 25, gen = 950, gold = 37500, charType = 1 }; AddCharacterLevelTemplate(clt_90);
        CharacterLevelTemplate clt_91 = new CharacterLevelTemplate() { level = 91, nextLevelExp = 5029497, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 227, gold = 4550, charType = 1 }; AddCharacterLevelTemplate(clt_91);
        CharacterLevelTemplate clt_92 = new CharacterLevelTemplate() { level = 92, nextLevelExp = 5310173, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 230, gold = 4600, charType = 1 }; AddCharacterLevelTemplate(clt_92);
        CharacterLevelTemplate clt_93 = new CharacterLevelTemplate() { level = 93, nextLevelExp = 5605479, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 232, gold = 4650, charType = 1 }; AddCharacterLevelTemplate(clt_93);
        CharacterLevelTemplate clt_94 = new CharacterLevelTemplate() { level = 94, nextLevelExp = 5916152, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 235, gold = 4700, charType = 1 }; AddCharacterLevelTemplate(clt_94);
        CharacterLevelTemplate clt_95 = new CharacterLevelTemplate() { level = 95, nextLevelExp = 6242967, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 237, gold = 4750, charType = 1 }; AddCharacterLevelTemplate(clt_95);
        CharacterLevelTemplate clt_96 = new CharacterLevelTemplate() { level = 96, nextLevelExp = 6586737, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 240, gold = 4800, charType = 1 }; AddCharacterLevelTemplate(clt_96);
        CharacterLevelTemplate clt_97 = new CharacterLevelTemplate() { level = 97, nextLevelExp = 6948315, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 242, gold = 4850, charType = 1 }; AddCharacterLevelTemplate(clt_97);
        CharacterLevelTemplate clt_98 = new CharacterLevelTemplate() { level = 98, nextLevelExp = 7328598, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 245, gold = 4900, charType = 1 }; AddCharacterLevelTemplate(clt_98);
        CharacterLevelTemplate clt_99 = new CharacterLevelTemplate() { level = 99, nextLevelExp = 7728527, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 247, gold = 4950, charType = 1 }; AddCharacterLevelTemplate(clt_99);
        CharacterLevelTemplate clt_100 = new CharacterLevelTemplate() { level = 100, nextLevelExp = 8149091, sp = 10, str = 25, dex = 30, vit = 25, brain = 25, gen = 1050, gold = 40000, charType = 1 }; AddCharacterLevelTemplate(clt_100);
        CharacterLevelTemplate clt_101 = new CharacterLevelTemplate() { level = 101, nextLevelExp = 8591327, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 252, gold = 5050, charType = 1 }; AddCharacterLevelTemplate(clt_101);
        CharacterLevelTemplate clt_102 = new CharacterLevelTemplate() { level = 102, nextLevelExp = 9056325, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 255, gold = 5100, charType = 1 }; AddCharacterLevelTemplate(clt_102);
        CharacterLevelTemplate clt_103 = new CharacterLevelTemplate() { level = 103, nextLevelExp = 9545229, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 257, gold = 5150, charType = 1 }; AddCharacterLevelTemplate(clt_103);
        CharacterLevelTemplate clt_104 = new CharacterLevelTemplate() { level = 104, nextLevelExp = 10059240, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 260, gold = 5200, charType = 1 }; AddCharacterLevelTemplate(clt_104);
        CharacterLevelTemplate clt_105 = new CharacterLevelTemplate() { level = 105, nextLevelExp = 10599620, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 262, gold = 5250, charType = 1 }; AddCharacterLevelTemplate(clt_105);
        CharacterLevelTemplate clt_106 = new CharacterLevelTemplate() { level = 106, nextLevelExp = 11167693, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 265, gold = 5300, charType = 1 }; AddCharacterLevelTemplate(clt_106);
        CharacterLevelTemplate clt_107 = new CharacterLevelTemplate() { level = 107, nextLevelExp = 11764849, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 267, gold = 5350, charType = 1 }; AddCharacterLevelTemplate(clt_107);
        CharacterLevelTemplate clt_108 = new CharacterLevelTemplate() { level = 108, nextLevelExp = 12392549, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 270, gold = 5400, charType = 1 }; AddCharacterLevelTemplate(clt_108);
        CharacterLevelTemplate clt_109 = new CharacterLevelTemplate() { level = 109, nextLevelExp = 13052326, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 272, gold = 5450, charType = 1 }; AddCharacterLevelTemplate(clt_109);
        CharacterLevelTemplate clt_110 = new CharacterLevelTemplate() { level = 110, nextLevelExp = 13745790, sp = 10, str = 25, dex = 30, vit = 25, brain = 25, gen = 1150, gold = 42500, charType = 1 }; AddCharacterLevelTemplate(clt_110);
        CharacterLevelTemplate clt_111 = new CharacterLevelTemplate() { level = 111, nextLevelExp = 14474631, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 277, gold = 5550, charType = 1 }; AddCharacterLevelTemplate(clt_111);
        CharacterLevelTemplate clt_112 = new CharacterLevelTemplate() { level = 112, nextLevelExp = 15240624, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 280, gold = 5600, charType = 1 }; AddCharacterLevelTemplate(clt_112);
        CharacterLevelTemplate clt_113 = new CharacterLevelTemplate() { level = 113, nextLevelExp = 16045633, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 282, gold = 5650, charType = 1 }; AddCharacterLevelTemplate(clt_113);
        CharacterLevelTemplate clt_114 = new CharacterLevelTemplate() { level = 114, nextLevelExp = 16891614, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 285, gold = 5700, charType = 1 }; AddCharacterLevelTemplate(clt_114);
        CharacterLevelTemplate clt_115 = new CharacterLevelTemplate() { level = 115, nextLevelExp = 17780622, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 287, gold = 5750, charType = 1 }; AddCharacterLevelTemplate(clt_115);
        CharacterLevelTemplate clt_116 = new CharacterLevelTemplate() { level = 116, nextLevelExp = 18714815, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 290, gold = 5800, charType = 1 }; AddCharacterLevelTemplate(clt_116);
        CharacterLevelTemplate clt_117 = new CharacterLevelTemplate() { level = 117, nextLevelExp = 19696457, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 292, gold = 5850, charType = 1 }; AddCharacterLevelTemplate(clt_117);
        CharacterLevelTemplate clt_118 = new CharacterLevelTemplate() { level = 118, nextLevelExp = 20727927, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 295, gold = 5900, charType = 1 }; AddCharacterLevelTemplate(clt_118);
        CharacterLevelTemplate clt_119 = new CharacterLevelTemplate() { level = 119, nextLevelExp = 21811723, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 297, gold = 5950, charType = 1 }; AddCharacterLevelTemplate(clt_119);
        CharacterLevelTemplate clt_120 = new CharacterLevelTemplate() { level = 120, nextLevelExp = 22950467, sp = 10, str = 25, dex = 30, vit = 25, brain = 25, gen = 1250, gold = 45000, charType = 1 }; AddCharacterLevelTemplate(clt_120);
        CharacterLevelTemplate clt_121 = new CharacterLevelTemplate() { level = 121, nextLevelExp = 24146912, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 302, gold = 6050, charType = 1 }; AddCharacterLevelTemplate(clt_121);
        CharacterLevelTemplate clt_122 = new CharacterLevelTemplate() { level = 122, nextLevelExp = 25403949, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 305, gold = 6100, charType = 1 }; AddCharacterLevelTemplate(clt_122);
        CharacterLevelTemplate clt_123 = new CharacterLevelTemplate() { level = 123, nextLevelExp = 26724614, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 307, gold = 6150, charType = 1 }; AddCharacterLevelTemplate(clt_123);
        CharacterLevelTemplate clt_124 = new CharacterLevelTemplate() { level = 124, nextLevelExp = 28112094, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 310, gold = 6200, charType = 1 }; AddCharacterLevelTemplate(clt_124);
        CharacterLevelTemplate clt_125 = new CharacterLevelTemplate() { level = 125, nextLevelExp = 29569736, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 312, gold = 6250, charType = 1 }; AddCharacterLevelTemplate(clt_125);
        CharacterLevelTemplate clt_126 = new CharacterLevelTemplate() { level = 126, nextLevelExp = 31101054, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 315, gold = 6300, charType = 1 }; AddCharacterLevelTemplate(clt_126);
        CharacterLevelTemplate clt_127 = new CharacterLevelTemplate() { level = 127, nextLevelExp = 32709738, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 317, gold = 6350, charType = 1 }; AddCharacterLevelTemplate(clt_127);
        CharacterLevelTemplate clt_128 = new CharacterLevelTemplate() { level = 128, nextLevelExp = 34399662, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 320, gold = 6400, charType = 1 }; AddCharacterLevelTemplate(clt_128);
        CharacterLevelTemplate clt_129 = new CharacterLevelTemplate() { level = 129, nextLevelExp = 36174895, sp = 5, str = 5, dex = 7, vit = 5, brain = 5, gen = 322, gold = 6450, charType = 1 }; AddCharacterLevelTemplate(clt_129);
        CharacterLevelTemplate clt_130 = new CharacterLevelTemplate() { level = 130, nextLevelExp = 38039707, sp = 10, str = 25, dex = 30, vit = 25, brain = 25, gen = 1350, gold = 47500, charType = 1 }; AddCharacterLevelTemplate(clt_130);
        CharacterLevelTemplate clt_131 = new CharacterLevelTemplate() { level = 131, nextLevelExp = 39998584, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 327, gold = 6550, charType = 1 }; AddCharacterLevelTemplate(clt_131);
        CharacterLevelTemplate clt_132 = new CharacterLevelTemplate() { level = 132, nextLevelExp = 42056235, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 330, gold = 6600, charType = 1 }; AddCharacterLevelTemplate(clt_132);
        CharacterLevelTemplate clt_133 = new CharacterLevelTemplate() { level = 133, nextLevelExp = 44217604, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 332, gold = 6650, charType = 1 }; AddCharacterLevelTemplate(clt_133);
        CharacterLevelTemplate clt_134 = new CharacterLevelTemplate() { level = 134, nextLevelExp = 46487884, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 335, gold = 6700, charType = 1 }; AddCharacterLevelTemplate(clt_134);
        CharacterLevelTemplate clt_135 = new CharacterLevelTemplate() { level = 135, nextLevelExp = 48872526, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 337, gold = 6750, charType = 1 }; AddCharacterLevelTemplate(clt_135);
        CharacterLevelTemplate clt_136 = new CharacterLevelTemplate() { level = 136, nextLevelExp = 51377254, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 340, gold = 6800, charType = 1 }; AddCharacterLevelTemplate(clt_136);
        CharacterLevelTemplate clt_137 = new CharacterLevelTemplate() { level = 137, nextLevelExp = 54008078, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 342, gold = 6850, charType = 1 }; AddCharacterLevelTemplate(clt_137);
        CharacterLevelTemplate clt_138 = new CharacterLevelTemplate() { level = 138, nextLevelExp = 56771309, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 345, gold = 6900, charType = 1 }; AddCharacterLevelTemplate(clt_138);
        CharacterLevelTemplate clt_139 = new CharacterLevelTemplate() { level = 139, nextLevelExp = 59673574, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 347, gold = 6950, charType = 1 }; AddCharacterLevelTemplate(clt_139);
        CharacterLevelTemplate clt_140 = new CharacterLevelTemplate() { level = 140, nextLevelExp = 62721830, sp = 10, str = 25, dex = 30, vit = 25, brain = 25, gen = 1450, gold = 50000, charType = 1 }; AddCharacterLevelTemplate(clt_140);
        CharacterLevelTemplate clt_141 = new CharacterLevelTemplate() { level = 141, nextLevelExp = 65923383, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 352, gold = 7050, charType = 1 }; AddCharacterLevelTemplate(clt_141);
        CharacterLevelTemplate clt_142 = new CharacterLevelTemplate() { level = 142, nextLevelExp = 69285904, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 355, gold = 7100, charType = 1 }; AddCharacterLevelTemplate(clt_142);
        CharacterLevelTemplate clt_143 = new CharacterLevelTemplate() { level = 143, nextLevelExp = 72817447, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 357, gold = 7150, charType = 1 }; AddCharacterLevelTemplate(clt_143);
        CharacterLevelTemplate clt_144 = new CharacterLevelTemplate() { level = 144, nextLevelExp = 76526469, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 360, gold = 7200, charType = 1 }; AddCharacterLevelTemplate(clt_144);
        CharacterLevelTemplate clt_145 = new CharacterLevelTemplate() { level = 145, nextLevelExp = 80421850, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 362, gold = 7250, charType = 1 }; AddCharacterLevelTemplate(clt_145);
        CharacterLevelTemplate clt_146 = new CharacterLevelTemplate() { level = 146, nextLevelExp = 84512914, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 365, gold = 7300, charType = 1 }; AddCharacterLevelTemplate(clt_146);
        CharacterLevelTemplate clt_147 = new CharacterLevelTemplate() { level = 147, nextLevelExp = 88809451, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 367, gold = 7350, charType = 1 }; AddCharacterLevelTemplate(clt_147);
        CharacterLevelTemplate clt_148 = new CharacterLevelTemplate() { level = 148, nextLevelExp = 93321741, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 370, gold = 7400, charType = 1 }; AddCharacterLevelTemplate(clt_148);
        CharacterLevelTemplate clt_149 = new CharacterLevelTemplate() { level = 149, nextLevelExp = 98060578, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 372, gold = 7450, charType = 1 }; AddCharacterLevelTemplate(clt_149);
        CharacterLevelTemplate clt_150 = new CharacterLevelTemplate() { level = 150, nextLevelExp = 103037294, sp = 10, str = 25, dex = 30, vit = 25, brain = 25, gen = 1550, gold = 52500, charType = 1 }; AddCharacterLevelTemplate(clt_150);
        CharacterLevelTemplate clt_151 = new CharacterLevelTemplate() { level = 151, nextLevelExp = 108263790, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 377, gold = 7550, charType = 1 }; AddCharacterLevelTemplate(clt_151);
        CharacterLevelTemplate clt_152 = new CharacterLevelTemplate() { level = 152, nextLevelExp = 113752561, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 380, gold = 7600, charType = 1 }; AddCharacterLevelTemplate(clt_152);
        CharacterLevelTemplate clt_153 = new CharacterLevelTemplate() { level = 153, nextLevelExp = 119516727, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 382, gold = 7650, charType = 1 }; AddCharacterLevelTemplate(clt_153);
        CharacterLevelTemplate clt_154 = new CharacterLevelTemplate() { level = 154, nextLevelExp = 125570063, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 385, gold = 7700, charType = 1 }; AddCharacterLevelTemplate(clt_154);
        CharacterLevelTemplate clt_155 = new CharacterLevelTemplate() { level = 155, nextLevelExp = 131927034, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 387, gold = 7750, charType = 1 }; AddCharacterLevelTemplate(clt_155);
        CharacterLevelTemplate clt_156 = new CharacterLevelTemplate() { level = 156, nextLevelExp = 138602827, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 390, gold = 7800, charType = 1 }; AddCharacterLevelTemplate(clt_156);
        CharacterLevelTemplate clt_157 = new CharacterLevelTemplate() { level = 157, nextLevelExp = 145613390, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 392, gold = 7850, charType = 1 }; AddCharacterLevelTemplate(clt_157);
        CharacterLevelTemplate clt_158 = new CharacterLevelTemplate() { level = 158, nextLevelExp = 152975467, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 395, gold = 7900, charType = 1 }; AddCharacterLevelTemplate(clt_158);
        CharacterLevelTemplate clt_159 = new CharacterLevelTemplate() { level = 159, nextLevelExp = 160706640, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 397, gold = 7950, charType = 1 }; AddCharacterLevelTemplate(clt_159);
        CharacterLevelTemplate clt_160 = new CharacterLevelTemplate() { level = 160, nextLevelExp = 168825370, sp = 10, str = 25, dex = 30, vit = 25, brain = 25, gen = 1650, gold = 55000, charType = 1 }; AddCharacterLevelTemplate(clt_160);
        CharacterLevelTemplate clt_161 = new CharacterLevelTemplate() { level = 161, nextLevelExp = 177351040, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 402, gold = 8050, charType = 1 }; AddCharacterLevelTemplate(clt_161);
        CharacterLevelTemplate clt_162 = new CharacterLevelTemplate() { level = 162, nextLevelExp = 186304004, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 405, gold = 8100, charType = 1 }; AddCharacterLevelTemplate(clt_162);
        CharacterLevelTemplate clt_163 = new CharacterLevelTemplate() { level = 163, nextLevelExp = 195705632, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 407, gold = 8150, charType = 1 }; AddCharacterLevelTemplate(clt_163);
        CharacterLevelTemplate clt_164 = new CharacterLevelTemplate() { level = 164, nextLevelExp = 205578363, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 410, gold = 8200, charType = 1 }; AddCharacterLevelTemplate(clt_164);
        CharacterLevelTemplate clt_165 = new CharacterLevelTemplate() { level = 165, nextLevelExp = 215945759, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 412, gold = 8250, charType = 1 }; AddCharacterLevelTemplate(clt_165);
        CharacterLevelTemplate clt_166 = new CharacterLevelTemplate() { level = 166, nextLevelExp = 226832558, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 415, gold = 8300, charType = 1 }; AddCharacterLevelTemplate(clt_166);
        CharacterLevelTemplate clt_167 = new CharacterLevelTemplate() { level = 167, nextLevelExp = 238264737, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 417, gold = 8350, charType = 1 }; AddCharacterLevelTemplate(clt_167);
        CharacterLevelTemplate clt_168 = new CharacterLevelTemplate() { level = 168, nextLevelExp = 250269571, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 420, gold = 8400, charType = 1 }; AddCharacterLevelTemplate(clt_168);
        CharacterLevelTemplate clt_169 = new CharacterLevelTemplate() { level = 169, nextLevelExp = 262875699, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 422, gold = 8450, charType = 1 }; AddCharacterLevelTemplate(clt_169);
        CharacterLevelTemplate clt_170 = new CharacterLevelTemplate() { level = 170, nextLevelExp = 276113191, sp = 10, str = 25, dex = 30, vit = 25, brain = 25, gen = 1750, gold = 57500, charType = 1 }; AddCharacterLevelTemplate(clt_170);
        CharacterLevelTemplate clt_171 = new CharacterLevelTemplate() { level = 171, nextLevelExp = 290013622, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 427, gold = 8550, charType = 1 }; AddCharacterLevelTemplate(clt_171);
        CharacterLevelTemplate clt_172 = new CharacterLevelTemplate() { level = 172, nextLevelExp = 304610145, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 430, gold = 8600, charType = 1 }; AddCharacterLevelTemplate(clt_172);
        CharacterLevelTemplate clt_173 = new CharacterLevelTemplate() { level = 173, nextLevelExp = 319937570, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 432, gold = 8650, charType = 1 }; AddCharacterLevelTemplate(clt_173);
        CharacterLevelTemplate clt_174 = new CharacterLevelTemplate() { level = 174, nextLevelExp = 336032448, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 435, gold = 8700, charType = 1 }; AddCharacterLevelTemplate(clt_174);
        CharacterLevelTemplate clt_175 = new CharacterLevelTemplate() { level = 175, nextLevelExp = 352933158, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 437, gold = 8750, charType = 1 }; AddCharacterLevelTemplate(clt_175);
        CharacterLevelTemplate clt_176 = new CharacterLevelTemplate() { level = 176, nextLevelExp = 370679997, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 440, gold = 8800, charType = 1 }; AddCharacterLevelTemplate(clt_176);
        CharacterLevelTemplate clt_177 = new CharacterLevelTemplate() { level = 177, nextLevelExp = 389315278, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 442, gold = 8850, charType = 1 }; AddCharacterLevelTemplate(clt_177);
        CharacterLevelTemplate clt_178 = new CharacterLevelTemplate() { level = 178, nextLevelExp = 408883429, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 445, gold = 8900, charType = 1 }; AddCharacterLevelTemplate(clt_178);
        CharacterLevelTemplate clt_179 = new CharacterLevelTemplate() { level = 179, nextLevelExp = 429431100, sp = 5, str = 6, dex = 8, vit = 6, brain = 6, gen = 447, gold = 8950, charType = 1 }; AddCharacterLevelTemplate(clt_179);
        CharacterLevelTemplate clt_180 = new CharacterLevelTemplate() { level = 180, nextLevelExp = 451007273, sp = 10, str = 25, dex = 30, vit = 25, brain = 25, gen = 1850, gold = 60000, charType = 1 }; AddCharacterLevelTemplate(clt_180);
        CharacterLevelTemplate clt_181 = new CharacterLevelTemplate() { level = 181, nextLevelExp = 473663378, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 452, gold = 9050, charType = 1 }; AddCharacterLevelTemplate(clt_181);
        CharacterLevelTemplate clt_182 = new CharacterLevelTemplate() { level = 182, nextLevelExp = 497453418, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 455, gold = 9100, charType = 1 }; AddCharacterLevelTemplate(clt_182);
        CharacterLevelTemplate clt_183 = new CharacterLevelTemplate() { level = 183, nextLevelExp = 522434096, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 457, gold = 9150, charType = 1 }; AddCharacterLevelTemplate(clt_183);
        CharacterLevelTemplate clt_184 = new CharacterLevelTemplate() { level = 184, nextLevelExp = 548664950, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 460, gold = 9200, charType = 1 }; AddCharacterLevelTemplate(clt_184);
        CharacterLevelTemplate clt_185 = new CharacterLevelTemplate() { level = 185, nextLevelExp = 576208495, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 462, gold = 9250, charType = 1 }; AddCharacterLevelTemplate(clt_185);
        CharacterLevelTemplate clt_186 = new CharacterLevelTemplate() { level = 186, nextLevelExp = 605130371, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 465, gold = 9300, charType = 1 }; AddCharacterLevelTemplate(clt_186);
        CharacterLevelTemplate clt_187 = new CharacterLevelTemplate() { level = 187, nextLevelExp = 635499501, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 467, gold = 9350, charType = 1 }; AddCharacterLevelTemplate(clt_187);
        CharacterLevelTemplate clt_188 = new CharacterLevelTemplate() { level = 188, nextLevelExp = 667388254, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 470, gold = 9400, charType = 1 }; AddCharacterLevelTemplate(clt_188);
        CharacterLevelTemplate clt_189 = new CharacterLevelTemplate() { level = 189, nextLevelExp = 700872616, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 472, gold = 9450, charType = 1 }; AddCharacterLevelTemplate(clt_189);
        CharacterLevelTemplate clt_190 = new CharacterLevelTemplate() { level = 190, nextLevelExp = 736032374, sp = 10, str = 25, dex = 30, vit = 25, brain = 25, gen = 1950, gold = 62500, charType = 1 }; AddCharacterLevelTemplate(clt_190);
        CharacterLevelTemplate clt_191 = new CharacterLevelTemplate() { level = 191, nextLevelExp = 772951304, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 477, gold = 9550, charType = 1 }; AddCharacterLevelTemplate(clt_191);
        CharacterLevelTemplate clt_192 = new CharacterLevelTemplate() { level = 192, nextLevelExp = 811717371, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 480, gold = 9600, charType = 1 }; AddCharacterLevelTemplate(clt_192);
        CharacterLevelTemplate clt_193 = new CharacterLevelTemplate() { level = 193, nextLevelExp = 852422937, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 482, gold = 9650, charType = 1 }; AddCharacterLevelTemplate(clt_193);
        CharacterLevelTemplate clt_194 = new CharacterLevelTemplate() { level = 194, nextLevelExp = 895164983, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 485, gold = 9700, charType = 1 }; AddCharacterLevelTemplate(clt_194);
        CharacterLevelTemplate clt_195 = new CharacterLevelTemplate() { level = 195, nextLevelExp = 940045340, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 487, gold = 9750, charType = 1 }; AddCharacterLevelTemplate(clt_195);
        CharacterLevelTemplate clt_196 = new CharacterLevelTemplate() { level = 196, nextLevelExp = 987170929, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 490, gold = 9800, charType = 1 }; AddCharacterLevelTemplate(clt_196);
        CharacterLevelTemplate clt_197 = new CharacterLevelTemplate() { level = 197, nextLevelExp = 1036654017, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 492, gold = 9850, charType = 1 }; AddCharacterLevelTemplate(clt_197);
        CharacterLevelTemplate clt_198 = new CharacterLevelTemplate() { level = 198, nextLevelExp = 1088612485, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 495, gold = 9900, charType = 1 }; AddCharacterLevelTemplate(clt_198);
        CharacterLevelTemplate clt_199 = new CharacterLevelTemplate() { level = 199, nextLevelExp = 1143170109, sp = 5, str = 7, dex = 9, vit = 7, brain = 7, gen = 497, gold = 9950, charType = 1 }; AddCharacterLevelTemplate(clt_199);
        CharacterLevelTemplate clt_200 = new CharacterLevelTemplate() { level = 200, nextLevelExp = 1200328614, sp = 10, str = 42, dex = 50, vit = 42, brain = 42, gen = 2050, gold = 65000, charType = 1 }; AddCharacterLevelTemplate(clt_200);
    }

    #endregion

}
