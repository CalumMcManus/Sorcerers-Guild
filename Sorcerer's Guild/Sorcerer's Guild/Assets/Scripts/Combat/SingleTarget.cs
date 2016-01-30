using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class SingleTarget : Ability
{
    private DamageType m_DamageType;
    private int m_iDamage;
    private int m_iDoT;
    private int m_iSelfHeal;
    private int m_iCastTime;
    private int m_iCoolDown;
    private int m_iSlowPercent;

    public void ContructorSingleTarget(DamageType dType, int damage, int dot, int heal, int casttime, int cooldown, int slowPercent)
    {
        m_DamageType = dType;
        m_iDamage = damage;
        m_iDoT = dot;
        m_iSelfHeal = heal;
        m_iCastTime = casttime;
        m_iCoolDown = cooldown;
        m_iSlowPercent = slowPercent;
    }
}
