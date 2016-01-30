using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats m_instance;

    public static PlayerStats Instance
    {
        get { return m_instance; }
    }
    void Awake()
    {
        m_instance = this;
    }

    private Ability.DamageType m_DamageType = Ability.DamageType.arcane;
    public Ability.DamageType DamageType { get { return m_DamageType; } set { m_DamageType = value; } }

    private int m_iMaxHealth = 50;
    public int MaxHealth { get { return m_iMaxHealth; } set { m_iMaxHealth = value; } }
    private int m_iCurrentHealth = 50;
    public int CurrentHealth { get { return m_iCurrentHealth; } set { m_iCurrentHealth = value; } }

    private int m_iMaxMana = 50;
    public int MaxMana { get { return m_iMaxMana; } set { m_iMaxMana = value; } }
    private int m_iCurrentMana = 50;
    public int CurrentMana { get { return m_iCurrentMana; } set { m_iCurrentMana = value; } }

    private int m_iMaxExp = 25;
    private int m_iCurrentExp = 0;
    public int Exp {get { return m_iCurrentExp; } set { m_iCurrentExp = value; } }

    private int m_iLevel = 1;




    public void ModifyHealth(int healthChange)
    {
        CurrentHealth += healthChange;
        Mathf.Clamp(m_iCurrentHealth, -1, MaxHealth);
        if (m_iCurrentHealth <= 0)
        {
            //DEATH AND DESTRUCTION ASFIHSRIG#

        }
    }

    public void ModifyMana(int manachange)
    {
        CurrentMana += manachange;
        Mathf.Clamp(m_iCurrentHealth, -1, MaxMana);

    }

    public void ModifyExp(int expchange)
    {
        Exp += expchange;
        if (Exp >= 25) 
        { //level up! 
            m_iCurrentExp = 0;
        }

    }
    public IEnumerator ManaRegen()
    {
        while(true)
        {
            if (m_iCurrentMana < m_iMaxMana)
            {
                CurrentMana += 2;
            }
            yield return new WaitForSeconds(3);
        }

       
        
    }

    






}
