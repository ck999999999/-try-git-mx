using System.Collections;
using System.Collections.Generic;

public class MuGongTemplate
{
    public int id;
    public string name;
    public int charType;
    public string des;
    public int maxLevel;
    public Dictionary<int, MuGongLevel> muGongLevel = new Dictionary<int, MuGongLevel>();
}
public class MuGongLevel
{
    public int muGongId;
    public int level;
    public int limitLevel;
    public int cost;
    public int gold;
    public int mp;
    public float effectVal;
    public int seed;
    //public float rate;
    //public int indexEffectVal;
    //const int len = 24;
    //public float[] arrayEffectVal=new float[len];
    //public float GetRndEffectVal()
    //{
    //    if(0== arrayEffectVal)
    //    indexEffectVal++;
    //    if (indexEffectVal == len  ) indexEffectVal = 0;

    //    return arrayEffectVal[indexEffectVal];
    //}
}
