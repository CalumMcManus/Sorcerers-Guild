using UnityEngine;
using System.Collections;

public class AoE : Ability
{
    private DamageType m_DamageType;
    private int m_iDamage;
    private int m_iDoT;
    private int m_iHoT;
    private int m_iRadius;
    private Vector3 m_iPos;

    public void ContructorAoE(DamageType dType, int damage, int dot, int heal, int radius, Vector3 pos)
    {
        m_DamageType = dType;
        m_iDamage = damage;
        m_iDoT = dot;
        m_iHoT = heal;
        m_iRadius = radius;
        m_iPos = pos;
    }
}
