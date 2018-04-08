using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Player  {
    //public PlayerAttribteLogic attributeData=new PlayerAttribteLogic();
    public string name;//昵称
    public int id;//唯一id
    public string guid;//本地生成的guid
    public DateTime bornDateTime;//创建时间
    public long totalOnlineSecond;//在线时长
    public string deviceId;
    public string lastIp;

    //宝石,金币,矿币
    public int gen;
    public long gold;
    public float bitCoin;

    public float maxHP;//最大血量，动态
    public float maxMP;//最大法力，动态
    public float hp;
    public float mp;
    public int atk;//攻击力
    public int def;//防御力
    public int fireRate;//攻击频率,间隔时间
    public int hpRestoreRate;//回血
    public int mpRestoreRate;//回蓝
    public long exp;//当前经验
    public long nextExp ;//下一级经验,0表示不能再升级
    public int level = 1;
    public int remainSp = 0;
    public int str;//等级才能触发变更
    public int strExt;//扩展,由玩家自己操作迩来
    public int dex;
    public int dexExt;
    public int vit;
    public int vitExt;
    public int brain;
    public int brainExt;

    public int charType;

    public int skillId;
    public int skillLevel;
    public int skillId1;
    public int skillLevel1;
    public int skillId2;
    public int skillLevel2;
    public int skillId3;
    public int skillLevel3;
    public int skillId4;
    public int skillLevel4;

    public int wing;
    public int wingLevel;
    public int wingExp;

    public int heart;
    public int heartLevel;
    public int heartExp;

    public int weapon;
    public int weaponLevel;
    public int weaponExp;

    public int dig;
    public int lucky;

    public int totalKill;
    public int skillKill;
    public int phyKill;
    public double totalTimes;

    public int power ;

    public int GetPower()
    {
        return power;
    }

    public int GetStr()
    {
        return str + strExt;
    }
    public int GetDex()
    {
        return dex + dexExt;
    }
    public int GetVit()
    {
        return vit + vitExt;
    }
    public int GetBrain()
    {
        return brain + brainExt;
    }
    public bool IsFullMP()
    {
        return mp == maxMP;
    }
    public void RestoreHP(float val)
    {
        if (maxHP == hp) return;

        val = val * hpRestoreRate;
        hp =hp + val;
        if (hp > maxHP) hp = maxHP;
    }
    public void RestoreMP(float val)
    {
        if (maxMP == mp) return;
        val = val * mpRestoreRate;
        mp = mp + val;
        if (mp > maxMP) mp = maxMP;
    }
    public void Reset()
    {

        //宝石,金币,矿币
        gen = 0;
        gold = 0;
        bitCoin = 0;
        
        maxHP = 0;//最大血量，动态
        maxMP = 0;//最大法力，动态
        hp = 0;
        mp = 0;
        atk = 0;//攻击力
        def = 0;//防御力
        fireRate = 0;//攻击频率,间隔时间
        hpRestoreRate = 0;//回血
        mpRestoreRate = 0;//回蓝
        exp = 0;//当前经验
        nextExp = 0;//下一级经验,0表示不能再升级
        level = 1;
        remainSp = 0;
        str = 0;//等级才能触发变更
        strExt = 0;//扩展,由玩家自己操作迩来
        dex = 0;
        dexExt = 0;
        vit = 0;
        vitExt = 0;
        brain = 0;
        brainExt = 0;

        charType = 0;

        skillId = 0;
        skillLevel = 0;
        skillId1 = 0;
        skillLevel1 = 0;
        skillId2 = 0;
        skillLevel2 = 0;
        skillId3 = 0;
        skillLevel3 = 0;
        skillId4 = 0;
        skillLevel4 = 0;

        wing = 0;
        wingLevel = 0;
        wingExp = 0;

        heart = 0;
        heartLevel = 0;
        heartExp = 0;

        weapon = 0;
        weaponLevel = 0;
        weaponExp = 0;

        dig = 0;
        lucky = 0;

        power = 0;
        phyKill = 0;
        skillKill = 0;
        totalKill = 0;
        totalOnlineSecond = 0;
        totalTimes = 0;
    }
    //public void AddWeaponExp(int wingep,int heartep,int weaponep,bool skillAtk,bool isLuck,bool isSupperLuck)
    public void AddWeaponExp( bool skillAtk, bool isLuck, bool isSupperLuck)
    {
        if (isSupperLuck)
        {
            //int rnd = UnityEngine.Random.Range(5, 15);
            for (int i = 0; i < 8; i++)
            {
                this.wingExp++;
                this.heartExp++;
                this.weaponExp++;
            }
        }

        if (isLuck)
        {
            //int rnd = UnityEngine.Random.Range(2, 7);
            for (int i = 0; i < 5; i++)
            {
                this.wingExp++;
                this.heartExp++;
                this.weaponExp++;
            }
        }

        if (skillAtk)
        {
            //this.wingExp += wingep;
            this.heartExp++;
            //this.weaponExp += weaponep;
        }
        else
        {
            this.wingExp++;
            //this.heartExp += heartep;
            this.weaponExp++;
        }
    }

}
//仅用于计算综合属性,所有计算,基于当前角色所处于的等级属性,不分先后,
public class PlayerAttribteLogic
{
    //等级关联的属性值,任何道具,不能引起基本属性变更
    public int level_hp;
    public int level_mp;
    public int level_atk;       //攻击力
    public int level_def;       //防御力
    public int level_dig;       //挖矿能力
    public int level_luckey;    //幸运值
    public int level_hpRestoreRate;//回血
    public int level_mpRestoreRate;//回蓝

    //技能导致的属性变更
    public int skill_hp;
    public int skill_mp;
    public int skill_atk;
    public int skill_def;
    public int skill_dig;
    public int skill_luckey;
    public int skill_hpRestoreRate;//回血
    public int skill_mpRestoreRate;//回蓝

    //奇物导致的属性变更
    public int weapon_hp;
    public int weapon_mp;
    public int weapon_atk;
    public int weapon_def;
    public int weapon_dig;
    public int weapon_luckey;
    public int weapon_hpRestoreRate;//回血
    public int weapon_mpRestoreRate;//回蓝

    //道具导致的临时附加,带时效的
    public int item_hp;
    public int item_mp;
    public int item_atk;
    public int item_def;
    public int item_dig;
    public int item_luckey;
    public int item_hpRestoreRate;//回血
    public int item_mpRestoreRate;//回蓝

    //破防
    //public int level_decDef = 0;
    //public int skill_decDef = 0;
    public int weapon_decDef ;
    //public int item_decDef = 0;

    public void Clear()
    {
        level_hp = 0;
        level_mp = 0;
        level_atk = 0;       //攻击力
        level_def = 0;       //防御力
        level_dig = 0;       //挖矿能力
        level_luckey = 0;    //幸运值

        //技能导致的属性变更
        skill_hp = 0;
        skill_mp = 0;
        skill_atk = 0;
        skill_def = 0;
        skill_dig = 0;
        skill_luckey = 0;

        //奇物导致的属性变更
        weapon_hp = 0;
        weapon_mp = 0;
        weapon_atk = 0;
        weapon_def = 0;
        weapon_dig = 0;
        weapon_luckey = 0;

        //道具导致的临时附加,带时效的
        item_hp = 0;
        item_mp = 0;
        item_atk = 0;
        item_def = 0;
        item_dig = 0;
        item_luckey = 0;

        //level_decDef = 0;
        //skill_decDef = 0;
        weapon_decDef = 0;
        //item_decDef=0;

        item_hpRestoreRate = 0;//回血
        item_mpRestoreRate = 0;//回蓝

    }

    public int GetTotalHp()
    {
        return level_hp + skill_hp + weapon_hp + item_hp;
    }
    public int GetTotalMp()
    {
        return level_mp + skill_mp + weapon_mp + item_mp;
    }
    public int GetTotalAtk()
    {
        return level_atk + skill_atk + weapon_atk + item_atk;
    }
    public int GetTotalDef()
    {
        return level_def + skill_def + weapon_def + item_def;
    }
    public int GetTotalPower()
    {
        return GetTotalAtk() + weapon_decDef ;
    }
    public int GetTotalDig()
    {
        return level_dig + skill_dig + weapon_dig + item_dig;
    }
    public int GetTotalLuckey()
    {
        return level_luckey + skill_luckey + weapon_luckey + item_luckey;
    }
    public int GetTotalRestoreHp()
    {
        return level_hpRestoreRate + skill_hpRestoreRate + weapon_hpRestoreRate + item_hpRestoreRate;
    }
    public int GetTotalRestoreMp()
    {
        return level_mpRestoreRate + skill_mpRestoreRate + weapon_mpRestoreRate + item_mpRestoreRate;
    }
}

