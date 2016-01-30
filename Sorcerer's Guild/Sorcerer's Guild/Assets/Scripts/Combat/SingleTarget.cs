using UnityEngine;
using System.Collections;

public class SingleTarget : Ability
{
    private DamageType m_DamageType;
    private int m_iDamage;
    private int m_iDoT;
    private int m_iSelfHeal;

    public void ContructorSingleTarget(DamageType dType, int damage, int dot, int heal)
    {
        m_DamageType = dType;
        m_iDamage = damage;
        m_iDoT = dot;
        m_iSelfHeal = heal;
    }
}
