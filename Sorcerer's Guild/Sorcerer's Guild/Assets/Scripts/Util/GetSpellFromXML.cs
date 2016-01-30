using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

public class GetSpellFromXML : MonoBehaviour
{
    private static GetSpellFromXML m_instance;

    public static GetSpellFromXML Instance
    {
        get { return m_instance; }
    }
    void Awake()
    {
        m_instance = this;
        GetXML();
    }

    private XElement xRoot;

	private void GetXML()
	{
        TextAsset xmlAsset = (TextAsset)Resources.Load("SpellBook", typeof(TextAsset));

        XDocument xDoc = XDocument.Parse(xmlAsset.text);
        
        xRoot = xDoc.Root;
    }

    private XElement LoadBook(string book)
    {
        XElement Book = GetElementByName(xRoot, book);

        return Book;
    }

    private XElement GetElementByName(XElement xEle, String name)
    {
        List<XElement> elements = xEle.Elements().ToList();
        foreach (XElement ele in elements)
        {
            if (ele.Name == name)
            {
                return ele;
            }
        }
        return null;
    }

    private XElement GetElementByID(XElement xEle, int id)
    {
        List<XElement> elements = xEle.Elements().ToList();

        foreach (XElement ele in elements)
        {
            XAttribute attribute = ele.Attribute("id");
            if (attribute.Value == id.ToString())
            {
                return ele;
            }
        }
        return null;
    }

    public SingleTarget GetSingleTargetSpell(XElement spell)
    {
        XElement Spell = spell;

        SingleTarget STspell = new SingleTarget();
        STspell.m_DamageType = (Ability.DamageType) Enum.Parse(typeof (Ability.DamageType), Spell.Element("damagetype").Value.ToString());
        STspell.m_iDamage = int.Parse(Spell.Element("damage").Value);
        STspell.m_iDoT = int.Parse(Spell.Element("dot").Value);
        STspell.m_iSelfHeal = int.Parse(Spell.Element("heal").Value);
        STspell.m_iCastTime = int.Parse(Spell.Element("casttime").Value);
        STspell.m_iCoolDown = int.Parse(Spell.Element("cooldown").Value);
        STspell.m_iSlowPercent = int.Parse(Spell.Element("slow").Value);
        STspell.m_iManaCost = int.Parse(Spell.Element("mana").Value);
        STspell.m_sDescription = Spell.Element("desc").Value;
        

        return STspell;
    }

    public AoE GetAOESpell(XElement spell)
    {
        XElement Spell = spell;

        AoE AOEspell = new AoE();
        AOEspell.m_DamageType = (Ability.DamageType)Enum.Parse(typeof(Ability.DamageType), Spell.Element("damagetype").Value.ToString());
        AOEspell.m_iDamage = int.Parse(Spell.Element("damage").Value);
        AOEspell.m_iDoT = int.Parse(Spell.Element("dot").Value);
        AOEspell.m_iHoT = int.Parse(Spell.Element("heal").Value);
        AOEspell.m_iCastTime = int.Parse(Spell.Element("casttime").Value);
        AOEspell.m_iCoolDown = int.Parse(Spell.Element("cooldown").Value);
        AOEspell.m_iSlowPercent = int.Parse(Spell.Element("slow").Value);
        AOEspell.m_iManaCost = int.Parse(Spell.Element("mana").Value);
        AOEspell.m_iRadius = int.Parse(Spell.Element("radius").Value);
        AOEspell.m_sDescription = Spell.Element("desc").Value;
        AOEspell.m_sName = Spell.Element("name").Value;

        return AOEspell;
    }

    public List<SingleTarget> SingleTargetSpellList()
    {
        XElement Book = LoadBook("STspellbook");
        List<XElement> elements = Book.Elements().ToList();
        List<SingleTarget> returnList = new List<SingleTarget>();
        foreach (XElement level in elements)
        {
            foreach (XElement spell in level.Elements())
            {
                returnList.Add(GetSingleTargetSpell(spell));   
            }
        }

        return returnList;
    }

    public List<AoE> AOESpellList()
    {
        XElement Book = LoadBook("AOEspellbook");
        List<XElement> elements = Book.Elements().ToList();
        List<AoE> returnList = new List<AoE>();
        foreach (XElement level in elements)
        {
            foreach (XElement spell in level.Elements())
            {
                returnList.Add(GetAOESpell(spell));
            }
        }

        return returnList;
    }
}
