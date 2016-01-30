using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellBook : Singleton<MonoBehaviour>
{

    private List<AbilityLists> m_EarthSpells = new List<AbilityLists>();
    private List<AbilityLists> m_WaterSpells = new List<AbilityLists>();
    private List<AbilityLists> m_FireSpells = new List<AbilityLists>();

    public struct AbilityLists
    {
        private List<Ability> SingleTarget;
        private List<Ability> AOE;

        public void ConstructorAbilityLists(List<Ability> singleTarget, List<Ability> AOE)
        {
            SingleTarget = new List<Ability>();
            AOE = new List<Ability>();
            SingleTarget.AddRange(singleTarget);
            AOE.AddRange(AOE);
        }
    }
}
