using UnityEngine;
using System.Collections;

public class EnemyStats : Singleton<MonoBehaviour>
{

    private int m_iMaxHealth = 50;
    public int MaxHealth { get { return m_iMaxHealth; } set { m_iMaxHealth = value; } }
    private int m_iCurrentHealth = 50;
    public int CurrentHealth { get { return m_iCurrentHealth; } set { m_iCurrentHealth = value; } }



    public void ModifyHealth(int healthChange)
    {
        CurrentHealth += healthChange;
        Mathf.Clamp(m_iCurrentHealth, -1, MaxHealth);
        if (m_iCurrentHealth <= 0)
        {
            //DEATH AND DESTRUCTION ASFIHSRIG#

        }


    }
}