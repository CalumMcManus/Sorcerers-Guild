using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellBook : MonoBehaviour
{
    private static SpellBook m_instance;

    public static SpellBook Instance
    {
        get { return m_instance; }
    }
    void Awake()
    {
        m_instance = this;
    }


    private AbilityLists m_ArcaneSpells;
    private AbilityLists m_EarthSpells;
    private AbilityLists m_WaterSpells;
    private AbilityLists m_FireSpells;

    public struct AbilityLists
    {
        public List<SingleTarget> SingleTarget;
        public List<AoE> AOE;

        public AbilityLists(List<SingleTarget> singleTarget, List<AoE> AoE)
        {
            SingleTarget = new List<SingleTarget>();
            AOE = new List<AoE>();
            SingleTarget.AddRange(singleTarget);
            AOE.AddRange(AoE);
        }
    }

   

    void Start()
    {
        PopulateSpellLists();
    }

    private void PopulateSpellLists()
    {
        List<SingleTarget> SingleTargetSpells = new List<SingleTarget>();
        List<AoE> AOESpells = new List<AoE>();
        SingleTargetSpells.AddRange(GetSpellFromXML.Instance.SingleTargetSpellList());
        AOESpells.AddRange(GetSpellFromXML.Instance.AOESpellList());

        List<SingleTarget> ElementSingleTarget = new List<SingleTarget>();
        List<AoE> ElementAOESpells = new List<AoE>();

        string sElement = "arcane";
        string outString = string.Empty; 
        for (int i = 0; i < 4; i++)
        {
            
            foreach (SingleTarget ability in SingleTargetSpells)
            {
                if (sElement.Equals(ability.m_DamageType.ToString()))
                {
                    ElementSingleTarget.Add(ability);
                }
                
            }

            foreach (AoE ability in AOESpells)
            {
                if (sElement.Equals(ability.m_DamageType.ToString()))
                {
                    ElementAOESpells.Add(ability);
                }

            }

            AbilityLists abilityLists = new AbilityLists(ElementSingleTarget, ElementAOESpells);

            switch (i)
            {
                case 0:
                    m_ArcaneSpells = abilityLists;
                    sElement = "earth";
                    break;
                case 1:
                    m_EarthSpells = abilityLists;
                    sElement = "water";
                    break;
                case 2:
                    m_WaterSpells = abilityLists;
                    sElement = "fire";
                    break;
                case 3:
                    m_FireSpells = abilityLists;
                    break;
            }
            ElementSingleTarget = new List<SingleTarget>();
            ElementAOESpells = new List<AoE>();
        }
    }
}
