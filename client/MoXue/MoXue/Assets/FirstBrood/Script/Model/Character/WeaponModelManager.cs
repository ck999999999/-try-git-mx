using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModelManager
{

    public static WeaponModelManager Instance;

    //id,WeaponTemplate
    public Dictionary<int, WeaponTemplate> dicWeaponTemplate = new Dictionary<int, WeaponTemplate>();

    public static void Init()
    {
        Instance = new WeaponModelManager();
        Instance.InitData();
    }

    public WeaponTemplate GetWeaponTemplate(int weaponId)
    {
        return dicWeaponTemplate[weaponId];
    }

    public WeaponLevelTemplate GetWeaponLevelTemplate(int weaponId,int level)
    {
        return dicWeaponTemplate[weaponId].dicWeaponLevelTemplte[level];
    }

    public bool IsMaxLevel(int weaponId, int level)
    {
        return dicWeaponTemplate[weaponId].maxLevel <= level;
    }

    void InitData()
    {
        WeaponTemplate wt_11 = new WeaponTemplate() { id = 11, name = "天赋翼翅", charType = 1 }; AddWeaponTemplate(wt_11);
        WeaponTemplate wt_12 = new WeaponTemplate() { id = 12, name = "天赋之心", charType = 1 }; AddWeaponTemplate(wt_12);
        WeaponTemplate wt_13 = new WeaponTemplate() { id = 13, name = "天赋武器", charType = 1 }; AddWeaponTemplate(wt_13);

        InitWing();
        InitHeart();
        InitWeapon();
    }
    void AddWeaponTemplate(WeaponTemplate wt)
    {
        dicWeaponTemplate.Add(wt.id,wt);
    }
    void AddWeaponLevelTemplate(WeaponLevelTemplate wlt)
    {
        if (dicWeaponTemplate[wlt.id].maxLevel < wlt.level) dicWeaponTemplate[wlt.id].maxLevel = wlt.level;

        dicWeaponTemplate[wlt.id].dicWeaponLevelTemplte.Add(wlt.level, wlt);
    }

    void InitWing()
    {
        WeaponLevelTemplate wlt_11_1 = new WeaponLevelTemplate() { id = 11, level = 1, exp = 25, limitLevel = 5, dig = 1, luck = 10, attack = 0, def = 5, hp = 0, mp = 10, cost = 5 }; AddWeaponLevelTemplate(wlt_11_1);
        WeaponLevelTemplate wlt_11_2 = new WeaponLevelTemplate() { id = 11, level = 2, exp = 37, limitLevel = 14, dig = 3, luck = 16, attack = 0, def = 15, hp = 0, mp = 30, cost = 23 }; AddWeaponLevelTemplate(wlt_11_2);
        WeaponLevelTemplate wlt_11_3 = new WeaponLevelTemplate() { id = 11, level = 3, exp = 55, limitLevel = 23, dig = 5, luck = 22, attack = 0, def = 25, hp = 0, mp = 50, cost = 41 }; AddWeaponLevelTemplate(wlt_11_3);
        WeaponLevelTemplate wlt_11_4 = new WeaponLevelTemplate() { id = 11, level = 4, exp = 82, limitLevel = 32, dig = 7, luck = 28, attack = 0, def = 35, hp = 0, mp = 70, cost = 59 }; AddWeaponLevelTemplate(wlt_11_4);
        WeaponLevelTemplate wlt_11_5 = new WeaponLevelTemplate() { id = 11, level = 5, exp = 123, limitLevel = 41, dig = 9, luck = 34, attack = 0, def = 45, hp = 0, mp = 90, cost = 77 }; AddWeaponLevelTemplate(wlt_11_5);
        WeaponLevelTemplate wlt_11_6 = new WeaponLevelTemplate() { id = 11, level = 6, exp = 184, limitLevel = 50, dig = 11, luck = 40, attack = 0, def = 55, hp = 0, mp = 110, cost = 95 }; AddWeaponLevelTemplate(wlt_11_6);
        WeaponLevelTemplate wlt_11_7 = new WeaponLevelTemplate() { id = 11, level = 7, exp = 276, limitLevel = 59, dig = 13, luck = 46, attack = 0, def = 65, hp = 0, mp = 130, cost = 113 }; AddWeaponLevelTemplate(wlt_11_7);
        WeaponLevelTemplate wlt_11_8 = new WeaponLevelTemplate() { id = 11, level = 8, exp = 414, limitLevel = 68, dig = 15, luck = 52, attack = 0, def = 75, hp = 0, mp = 150, cost = 131 }; AddWeaponLevelTemplate(wlt_11_8);
        WeaponLevelTemplate wlt_11_9 = new WeaponLevelTemplate() { id = 11, level = 9, exp = 621, limitLevel = 77, dig = 17, luck = 58, attack = 0, def = 85, hp = 0, mp = 170, cost = 149 }; AddWeaponLevelTemplate(wlt_11_9);
        WeaponLevelTemplate wlt_11_10 = new WeaponLevelTemplate() { id = 11, level = 10, exp = 931, limitLevel = 86, dig = 19, luck = 64, attack = 0, def = 95, hp = 0, mp = 190, cost = 167 }; AddWeaponLevelTemplate(wlt_11_10);
        WeaponLevelTemplate wlt_11_11 = new WeaponLevelTemplate() { id = 11, level = 11, exp = 1396, limitLevel = 95, dig = 21, luck = 70, attack = 0, def = 120, hp = 0, mp = 220, cost = 185 }; AddWeaponLevelTemplate(wlt_11_11);
        WeaponLevelTemplate wlt_11_12 = new WeaponLevelTemplate() { id = 11, level = 12, exp = 2094, limitLevel = 104, dig = 23, luck = 76, attack = 0, def = 135, hp = 0, mp = 250, cost = 203 }; AddWeaponLevelTemplate(wlt_11_12);
        WeaponLevelTemplate wlt_11_13 = new WeaponLevelTemplate() { id = 11, level = 13, exp = 3141, limitLevel = 113, dig = 25, luck = 82, attack = 0, def = 150, hp = 0, mp = 280, cost = 221 }; AddWeaponLevelTemplate(wlt_11_13);
        WeaponLevelTemplate wlt_11_14 = new WeaponLevelTemplate() { id = 11, level = 14, exp = 4711, limitLevel = 122, dig = 27, luck = 88, attack = 0, def = 165, hp = 0, mp = 310, cost = 239 }; AddWeaponLevelTemplate(wlt_11_14);
        WeaponLevelTemplate wlt_11_15 = new WeaponLevelTemplate() { id = 11, level = 15, exp = 7066, limitLevel = 129, dig = 29, luck = 94, attack = 0, def = 180, hp = 0, mp = 340, cost = 257 }; AddWeaponLevelTemplate(wlt_11_15);
        WeaponLevelTemplate wlt_11_16 = new WeaponLevelTemplate() { id = 11, level = 16, exp = 10599, limitLevel = 136, dig = 31, luck = 100, attack = 0, def = 195, hp = 0, mp = 370, cost = 275 }; AddWeaponLevelTemplate(wlt_11_16);
        WeaponLevelTemplate wlt_11_17 = new WeaponLevelTemplate() { id = 11, level = 17, exp = 15898, limitLevel = 143, dig = 33, luck = 106, attack = 0, def = 210, hp = 0, mp = 400, cost = 293 }; AddWeaponLevelTemplate(wlt_11_17);
        WeaponLevelTemplate wlt_11_18 = new WeaponLevelTemplate() { id = 11, level = 18, exp = 23847, limitLevel = 150, dig = 35, luck = 112, attack = 0, def = 225, hp = 0, mp = 430, cost = 311 }; AddWeaponLevelTemplate(wlt_11_18);
        WeaponLevelTemplate wlt_11_19 = new WeaponLevelTemplate() { id = 11, level = 19, exp = 35770, limitLevel = 155, dig = 37, luck = 118, attack = 0, def = 240, hp = 0, mp = 460, cost = 329 }; AddWeaponLevelTemplate(wlt_11_19);
        WeaponLevelTemplate wlt_11_20 = new WeaponLevelTemplate() { id = 11, level = 20, exp = 53655, limitLevel = 160, dig = 39, luck = 124, attack = 0, def = 255, hp = 0, mp = 490, cost = 347 }; AddWeaponLevelTemplate(wlt_11_20);
        WeaponLevelTemplate wlt_11_21 = new WeaponLevelTemplate() { id = 11, level = 21, exp = 80482, limitLevel = 165, dig = 41, luck = 130, attack = 0, def = 305, hp = 0, mp = 540, cost = 365 }; AddWeaponLevelTemplate(wlt_11_21);
        WeaponLevelTemplate wlt_11_22 = new WeaponLevelTemplate() { id = 11, level = 22, exp = 120723, limitLevel = 170, dig = 43, luck = 136, attack = 0, def = 355, hp = 0, mp = 590, cost = 383 }; AddWeaponLevelTemplate(wlt_11_22);
        WeaponLevelTemplate wlt_11_23 = new WeaponLevelTemplate() { id = 11, level = 23, exp = 181084, limitLevel = 175, dig = 45, luck = 142, attack = 0, def = 405, hp = 0, mp = 640, cost = 401 }; AddWeaponLevelTemplate(wlt_11_23);
        WeaponLevelTemplate wlt_11_24 = new WeaponLevelTemplate() { id = 11, level = 24, exp = 271626, limitLevel = 180, dig = 47, luck = 148, attack = 0, def = 455, hp = 0, mp = 690, cost = 419 }; AddWeaponLevelTemplate(wlt_11_24);
        WeaponLevelTemplate wlt_11_25 = new WeaponLevelTemplate() { id = 11, level = 25, exp = 407439, limitLevel = 183, dig = 49, luck = 154, attack = 0, def = 505, hp = 0, mp = 740, cost = 437 }; AddWeaponLevelTemplate(wlt_11_25);
        WeaponLevelTemplate wlt_11_26 = new WeaponLevelTemplate() { id = 11, level = 26, exp = 611158, limitLevel = 186, dig = 51, luck = 160, attack = 0, def = 555, hp = 0, mp = 790, cost = 455 }; AddWeaponLevelTemplate(wlt_11_26);
        WeaponLevelTemplate wlt_11_27 = new WeaponLevelTemplate() { id = 11, level = 27, exp = 916737, limitLevel = 189, dig = 53, luck = 166, attack = 0, def = 605, hp = 0, mp = 840, cost = 473 }; AddWeaponLevelTemplate(wlt_11_27);
        WeaponLevelTemplate wlt_11_28 = new WeaponLevelTemplate() { id = 11, level = 28, exp = 1375105, limitLevel = 192, dig = 55, luck = 172, attack = 0, def = 655, hp = 0, mp = 890, cost = 491 }; AddWeaponLevelTemplate(wlt_11_28);
        WeaponLevelTemplate wlt_11_29 = new WeaponLevelTemplate() { id = 11, level = 29, exp = 2062657, limitLevel = 195, dig = 57, luck = 178, attack = 0, def = 705, hp = 0, mp = 940, cost = 509 }; AddWeaponLevelTemplate(wlt_11_29);
        WeaponLevelTemplate wlt_11_30 = new WeaponLevelTemplate() { id = 11, level = 30, exp = 3093985, limitLevel = 198, dig = 59, luck = 184, attack = 0, def = 755, hp = 0, mp = 990, cost = 527 }; AddWeaponLevelTemplate(wlt_11_30);

    }

    void InitHeart()
    {
        WeaponLevelTemplate wlt_12_1 = new WeaponLevelTemplate() { id = 12, level = 1, exp = 30, limitLevel = 7, dig = 11, luck = 13, attack = 0, def = 7, hp = 0, mp = 10, cost = 5 }; AddWeaponLevelTemplate(wlt_12_1);
        WeaponLevelTemplate wlt_12_2 = new WeaponLevelTemplate() { id = 12, level = 2, exp = 45, limitLevel = 16, dig = 13, luck = 19, attack = 17, def = 20, hp = 0, mp = 30, cost = 25 }; AddWeaponLevelTemplate(wlt_12_2);
        WeaponLevelTemplate wlt_12_3 = new WeaponLevelTemplate() { id = 12, level = 3, exp = 67, limitLevel = 25, dig = 15, luck = 25, attack = 34, def = 33, hp = 0, mp = 50, cost = 45 }; AddWeaponLevelTemplate(wlt_12_3);
        WeaponLevelTemplate wlt_12_4 = new WeaponLevelTemplate() { id = 12, level = 4, exp = 100, limitLevel = 34, dig = 17, luck = 31, attack = 51, def = 46, hp = 0, mp = 70, cost = 65 }; AddWeaponLevelTemplate(wlt_12_4);
        WeaponLevelTemplate wlt_12_5 = new WeaponLevelTemplate() { id = 12, level = 5, exp = 150, limitLevel = 43, dig = 19, luck = 37, attack = 68, def = 59, hp = 0, mp = 90, cost = 85 }; AddWeaponLevelTemplate(wlt_12_5);
        WeaponLevelTemplate wlt_12_6 = new WeaponLevelTemplate() { id = 12, level = 6, exp = 225, limitLevel = 52, dig = 21, luck = 43, attack = 85, def = 72, hp = 0, mp = 110, cost = 105 }; AddWeaponLevelTemplate(wlt_12_6);
        WeaponLevelTemplate wlt_12_7 = new WeaponLevelTemplate() { id = 12, level = 7, exp = 337, limitLevel = 61, dig = 23, luck = 49, attack = 102, def = 85, hp = 0, mp = 130, cost = 125 }; AddWeaponLevelTemplate(wlt_12_7);
        WeaponLevelTemplate wlt_12_8 = new WeaponLevelTemplate() { id = 12, level = 8, exp = 505, limitLevel = 70, dig = 25, luck = 55, attack = 119, def = 98, hp = 0, mp = 150, cost = 145 }; AddWeaponLevelTemplate(wlt_12_8);
        WeaponLevelTemplate wlt_12_9 = new WeaponLevelTemplate() { id = 12, level = 9, exp = 757, limitLevel = 79, dig = 27, luck = 61, attack = 136, def = 111, hp = 0, mp = 170, cost = 165 }; AddWeaponLevelTemplate(wlt_12_9);
        WeaponLevelTemplate wlt_12_10 = new WeaponLevelTemplate() { id = 12, level = 10, exp = 1135, limitLevel = 88, dig = 29, luck = 67, attack = 153, def = 125, hp = 0, mp = 190, cost = 185 }; AddWeaponLevelTemplate(wlt_12_10);
        WeaponLevelTemplate wlt_12_11 = new WeaponLevelTemplate() { id = 12, level = 11, exp = 1702, limitLevel = 97, dig = 31, luck = 73, attack = 170, def = 155, hp = 0, mp = 220, cost = 205 }; AddWeaponLevelTemplate(wlt_12_11);
        WeaponLevelTemplate wlt_12_12 = new WeaponLevelTemplate() { id = 12, level = 12, exp = 2553, limitLevel = 106, dig = 33, luck = 79, attack = 187, def = 185, hp = 0, mp = 250, cost = 225 }; AddWeaponLevelTemplate(wlt_12_12);
        WeaponLevelTemplate wlt_12_13 = new WeaponLevelTemplate() { id = 12, level = 13, exp = 3829, limitLevel = 115, dig = 35, luck = 85, attack = 204, def = 215, hp = 0, mp = 280, cost = 245 }; AddWeaponLevelTemplate(wlt_12_13);
        WeaponLevelTemplate wlt_12_14 = new WeaponLevelTemplate() { id = 12, level = 14, exp = 5743, limitLevel = 124, dig = 37, luck = 91, attack = 221, def = 245, hp = 0, mp = 310, cost = 265 }; AddWeaponLevelTemplate(wlt_12_14);
        WeaponLevelTemplate wlt_12_15 = new WeaponLevelTemplate() { id = 12, level = 15, exp = 8614, limitLevel = 131, dig = 39, luck = 97, attack = 238, def = 275, hp = 0, mp = 340, cost = 285 }; AddWeaponLevelTemplate(wlt_12_15);
        WeaponLevelTemplate wlt_12_16 = new WeaponLevelTemplate() { id = 12, level = 16, exp = 12921, limitLevel = 138, dig = 41, luck = 103, attack = 255, def = 305, hp = 0, mp = 370, cost = 305 }; AddWeaponLevelTemplate(wlt_12_16);
        WeaponLevelTemplate wlt_12_17 = new WeaponLevelTemplate() { id = 12, level = 17, exp = 19381, limitLevel = 145, dig = 43, luck = 109, attack = 272, def = 335, hp = 0, mp = 400, cost = 325 }; AddWeaponLevelTemplate(wlt_12_17);
        WeaponLevelTemplate wlt_12_18 = new WeaponLevelTemplate() { id = 12, level = 18, exp = 29071, limitLevel = 152, dig = 45, luck = 115, attack = 289, def = 365, hp = 0, mp = 430, cost = 345 }; AddWeaponLevelTemplate(wlt_12_18);
        WeaponLevelTemplate wlt_12_19 = new WeaponLevelTemplate() { id = 12, level = 19, exp = 43606, limitLevel = 157, dig = 47, luck = 121, attack = 306, def = 395, hp = 0, mp = 460, cost = 365 }; AddWeaponLevelTemplate(wlt_12_19);
        WeaponLevelTemplate wlt_12_20 = new WeaponLevelTemplate() { id = 12, level = 20, exp = 65409, limitLevel = 162, dig = 49, luck = 127, attack = 323, def = 425, hp = 0, mp = 490, cost = 385 }; AddWeaponLevelTemplate(wlt_12_20);
        WeaponLevelTemplate wlt_12_21 = new WeaponLevelTemplate() { id = 12, level = 21, exp = 98113, limitLevel = 167, dig = 51, luck = 133, attack = 340, def = 490, hp = 0, mp = 540, cost = 405 }; AddWeaponLevelTemplate(wlt_12_21);
        WeaponLevelTemplate wlt_12_22 = new WeaponLevelTemplate() { id = 12, level = 22, exp = 147169, limitLevel = 172, dig = 53, luck = 139, attack = 357, def = 555, hp = 0, mp = 590, cost = 425 }; AddWeaponLevelTemplate(wlt_12_22);
        WeaponLevelTemplate wlt_12_23 = new WeaponLevelTemplate() { id = 12, level = 23, exp = 220753, limitLevel = 177, dig = 55, luck = 145, attack = 374, def = 620, hp = 0, mp = 640, cost = 445 }; AddWeaponLevelTemplate(wlt_12_23);
        WeaponLevelTemplate wlt_12_24 = new WeaponLevelTemplate() { id = 12, level = 24, exp = 331129, limitLevel = 182, dig = 57, luck = 151, attack = 391, def = 685, hp = 0, mp = 690, cost = 465 }; AddWeaponLevelTemplate(wlt_12_24);
        WeaponLevelTemplate wlt_12_25 = new WeaponLevelTemplate() { id = 12, level = 25, exp = 496693, limitLevel = 185, dig = 59, luck = 157, attack = 408, def = 750, hp = 0, mp = 740, cost = 485 }; AddWeaponLevelTemplate(wlt_12_25);
        WeaponLevelTemplate wlt_12_26 = new WeaponLevelTemplate() { id = 12, level = 26, exp = 745039, limitLevel = 188, dig = 61, luck = 163, attack = 425, def = 815, hp = 0, mp = 790, cost = 505 }; AddWeaponLevelTemplate(wlt_12_26);
        WeaponLevelTemplate wlt_12_27 = new WeaponLevelTemplate() { id = 12, level = 27, exp = 1117558, limitLevel = 191, dig = 63, luck = 169, attack = 442, def = 880, hp = 0, mp = 840, cost = 525 }; AddWeaponLevelTemplate(wlt_12_27);
        WeaponLevelTemplate wlt_12_28 = new WeaponLevelTemplate() { id = 12, level = 28, exp = 1676337, limitLevel = 194, dig = 65, luck = 175, attack = 459, def = 945, hp = 0, mp = 890, cost = 545 }; AddWeaponLevelTemplate(wlt_12_28);
        WeaponLevelTemplate wlt_12_29 = new WeaponLevelTemplate() { id = 12, level = 29, exp = 2514505, limitLevel = 197, dig = 67, luck = 181, attack = 476, def = 1010, hp = 0, mp = 940, cost = 565 }; AddWeaponLevelTemplate(wlt_12_29);
        WeaponLevelTemplate wlt_12_30 = new WeaponLevelTemplate() { id = 12, level = 30, exp = 3771757, limitLevel = 200, dig = 69, luck = 187, attack = 493, def = 1075, hp = 0, mp = 990, cost = 585 }; AddWeaponLevelTemplate(wlt_12_30);

    }

    void InitWeapon()
    {
        WeaponLevelTemplate wlt_13_1 = new WeaponLevelTemplate() { id = 13, level = 1, exp = 27, limitLevel = 3, dig = 5, luck = 12, attack = 0, def = 7, hp = 0, mp = 10, cost = 5 }; AddWeaponLevelTemplate(wlt_13_1);
        WeaponLevelTemplate wlt_13_2 = new WeaponLevelTemplate() { id = 13, level = 2, exp = 40, limitLevel = 12, dig = 7, luck = 18, attack = 0, def = 17, hp = 0, mp = 30, cost = 24 }; AddWeaponLevelTemplate(wlt_13_2);
        WeaponLevelTemplate wlt_13_3 = new WeaponLevelTemplate() { id = 13, level = 3, exp = 60, limitLevel = 21, dig = 9, luck = 24, attack = 0, def = 27, hp = 0, mp = 50, cost = 43 }; AddWeaponLevelTemplate(wlt_13_3);
        WeaponLevelTemplate wlt_13_4 = new WeaponLevelTemplate() { id = 13, level = 4, exp = 90, limitLevel = 30, dig = 11, luck = 30, attack = 0, def = 37, hp = 0, mp = 70, cost = 62 }; AddWeaponLevelTemplate(wlt_13_4);
        WeaponLevelTemplate wlt_13_5 = new WeaponLevelTemplate() { id = 13, level = 5, exp = 135, limitLevel = 39, dig = 13, luck = 36, attack = 0, def = 47, hp = 0, mp = 90, cost = 81 }; AddWeaponLevelTemplate(wlt_13_5);
        WeaponLevelTemplate wlt_13_6 = new WeaponLevelTemplate() { id = 13, level = 6, exp = 202, limitLevel = 48, dig = 15, luck = 42, attack = 0, def = 57, hp = 0, mp = 110, cost = 100 }; AddWeaponLevelTemplate(wlt_13_6);
        WeaponLevelTemplate wlt_13_7 = new WeaponLevelTemplate() { id = 13, level = 7, exp = 303, limitLevel = 57, dig = 17, luck = 48, attack = 0, def = 67, hp = 0, mp = 130, cost = 119 }; AddWeaponLevelTemplate(wlt_13_7);
        WeaponLevelTemplate wlt_13_8 = new WeaponLevelTemplate() { id = 13, level = 8, exp = 454, limitLevel = 66, dig = 19, luck = 54, attack = 0, def = 77, hp = 0, mp = 150, cost = 138 }; AddWeaponLevelTemplate(wlt_13_8);
        WeaponLevelTemplate wlt_13_9 = new WeaponLevelTemplate() { id = 13, level = 9, exp = 681, limitLevel = 75, dig = 21, luck = 60, attack = 0, def = 87, hp = 0, mp = 170, cost = 157 }; AddWeaponLevelTemplate(wlt_13_9);
        WeaponLevelTemplate wlt_13_10 = new WeaponLevelTemplate() { id = 13, level = 10, exp = 1021, limitLevel = 84, dig = 23, luck = 66, attack = 0, def = 97, hp = 0, mp = 190, cost = 176 }; AddWeaponLevelTemplate(wlt_13_10);
        WeaponLevelTemplate wlt_13_11 = new WeaponLevelTemplate() { id = 13, level = 11, exp = 1531, limitLevel = 93, dig = 25, luck = 72, attack = 0, def = 127, hp = 0, mp = 220, cost = 195 }; AddWeaponLevelTemplate(wlt_13_11);
        WeaponLevelTemplate wlt_13_12 = new WeaponLevelTemplate() { id = 13, level = 12, exp = 2296, limitLevel = 102, dig = 27, luck = 78, attack = 0, def = 145, hp = 0, mp = 250, cost = 214 }; AddWeaponLevelTemplate(wlt_13_12);
        WeaponLevelTemplate wlt_13_13 = new WeaponLevelTemplate() { id = 13, level = 13, exp = 3444, limitLevel = 109, dig = 29, luck = 84, attack = 0, def = 163, hp = 0, mp = 280, cost = 233 }; AddWeaponLevelTemplate(wlt_13_13);
        WeaponLevelTemplate wlt_13_14 = new WeaponLevelTemplate() { id = 13, level = 14, exp = 5166, limitLevel = 116, dig = 31, luck = 90, attack = 0, def = 181, hp = 0, mp = 310, cost = 252 }; AddWeaponLevelTemplate(wlt_13_14);
        WeaponLevelTemplate wlt_13_15 = new WeaponLevelTemplate() { id = 13, level = 15, exp = 7749, limitLevel = 123, dig = 33, luck = 96, attack = 0, def = 199, hp = 0, mp = 340, cost = 271 }; AddWeaponLevelTemplate(wlt_13_15);
        WeaponLevelTemplate wlt_13_16 = new WeaponLevelTemplate() { id = 13, level = 16, exp = 11623, limitLevel = 130, dig = 35, luck = 102, attack = 0, def = 217, hp = 0, mp = 370, cost = 290 }; AddWeaponLevelTemplate(wlt_13_16);
        WeaponLevelTemplate wlt_13_17 = new WeaponLevelTemplate() { id = 13, level = 17, exp = 17434, limitLevel = 137, dig = 37, luck = 108, attack = 0, def = 235, hp = 0, mp = 400, cost = 309 }; AddWeaponLevelTemplate(wlt_13_17);
        WeaponLevelTemplate wlt_13_18 = new WeaponLevelTemplate() { id = 13, level = 18, exp = 26151, limitLevel = 144, dig = 39, luck = 114, attack = 0, def = 253, hp = 0, mp = 430, cost = 328 }; AddWeaponLevelTemplate(wlt_13_18);
        WeaponLevelTemplate wlt_13_19 = new WeaponLevelTemplate() { id = 13, level = 19, exp = 39226, limitLevel = 151, dig = 41, luck = 120, attack = 0, def = 271, hp = 0, mp = 460, cost = 347 }; AddWeaponLevelTemplate(wlt_13_19);
        WeaponLevelTemplate wlt_13_20 = new WeaponLevelTemplate() { id = 13, level = 20, exp = 58839, limitLevel = 156, dig = 43, luck = 126, attack = 0, def = 289, hp = 0, mp = 490, cost = 366 }; AddWeaponLevelTemplate(wlt_13_20);
        WeaponLevelTemplate wlt_13_21 = new WeaponLevelTemplate() { id = 13, level = 21, exp = 88258, limitLevel = 161, dig = 45, luck = 132, attack = 0, def = 340, hp = 0, mp = 540, cost = 385 }; AddWeaponLevelTemplate(wlt_13_21);
        WeaponLevelTemplate wlt_13_22 = new WeaponLevelTemplate() { id = 13, level = 22, exp = 132387, limitLevel = 166, dig = 47, luck = 138, attack = 0, def = 390, hp = 0, mp = 590, cost = 404 }; AddWeaponLevelTemplate(wlt_13_22);
        WeaponLevelTemplate wlt_13_23 = new WeaponLevelTemplate() { id = 13, level = 23, exp = 198580, limitLevel = 171, dig = 49, luck = 144, attack = 0, def = 440, hp = 0, mp = 640, cost = 423 }; AddWeaponLevelTemplate(wlt_13_23);
        WeaponLevelTemplate wlt_13_24 = new WeaponLevelTemplate() { id = 13, level = 24, exp = 297870, limitLevel = 176, dig = 51, luck = 150, attack = 0, def = 490, hp = 0, mp = 690, cost = 442 }; AddWeaponLevelTemplate(wlt_13_24);
        WeaponLevelTemplate wlt_13_25 = new WeaponLevelTemplate() { id = 13, level = 25, exp = 446805, limitLevel = 181, dig = 53, luck = 156, attack = 0, def = 540, hp = 0, mp = 740, cost = 461 }; AddWeaponLevelTemplate(wlt_13_25);
        WeaponLevelTemplate wlt_13_26 = new WeaponLevelTemplate() { id = 13, level = 26, exp = 670207, limitLevel = 184, dig = 55, luck = 162, attack = 0, def = 590, hp = 0, mp = 790, cost = 480 }; AddWeaponLevelTemplate(wlt_13_26);
        WeaponLevelTemplate wlt_13_27 = new WeaponLevelTemplate() { id = 13, level = 27, exp = 1005310, limitLevel = 187, dig = 57, luck = 168, attack = 0, def = 640, hp = 0, mp = 840, cost = 499 }; AddWeaponLevelTemplate(wlt_13_27);
        WeaponLevelTemplate wlt_13_28 = new WeaponLevelTemplate() { id = 13, level = 28, exp = 1507965, limitLevel = 190, dig = 59, luck = 174, attack = 0, def = 690, hp = 0, mp = 890, cost = 518 }; AddWeaponLevelTemplate(wlt_13_28);
        WeaponLevelTemplate wlt_13_29 = new WeaponLevelTemplate() { id = 13, level = 29, exp = 2261947, limitLevel = 193, dig = 61, luck = 180, attack = 0, def = 740, hp = 0, mp = 940, cost = 537 }; AddWeaponLevelTemplate(wlt_13_29);
        WeaponLevelTemplate wlt_13_30 = new WeaponLevelTemplate() { id = 13, level = 30, exp = 3392920, limitLevel = 196, dig = 63, luck = 186, attack = 0, def = 790, hp = 0, mp = 990, cost = 556 }; AddWeaponLevelTemplate(wlt_13_30);

    }

}
