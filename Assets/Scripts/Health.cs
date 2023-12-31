using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool haveArmor = false;
    public bool haveMagicArmor = false;
    public bool armorIsHp = false;
    public float health, maxHealth = 300;
    public float armor, maxArmor = 1;  
    public float magicArmor, maxMagicArmor = 400;


    public bool replaceWhenDead = false;
    public GameObject deadReplacement;
    public bool makeExplosion = false;
    public GameObject explosion;

    //health Bar
    public bool haveHealthBar = false;
    [SerializeField] FloatingHealthBar healthBar;
    public bool haveShaderArmor = false;
    [SerializeField] ArmorShaderDisolve armorobject;



    private void Awake()
    {   
        if(haveHealthBar)
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        if (haveShaderArmor)
        armorobject = GetComponentInChildren<ArmorShaderDisolve>();

    }


    void Start()
    {
        maxArmor = armor;
        maxHealth = health;
        maxMagicArmor = magicArmor;
        if (haveHealthBar)
        {
            //Debug.Log("healthBar");
            if(armorIsHp)
                healthBar.UpdateHealthBar(armor, maxArmor);
            else
                healthBar.UpdateHealthBar(health, maxHealth);
            if(haveMagicArmor)
                healthBar.UpdateMagicBar(magicArmor, maxMagicArmor);
            else
                healthBar.UpdateMagicBar(0, 1);
            if (haveShaderArmor)
                armorobject.SetShaderProperty(armor, maxArmor);
        }

    }


    public void Hit(float damage, float armordamage, float magicdamage)
    {   
        if (haveMagicArmor)
        {
            magicArmor -= magicdamage;
            if (haveHealthBar)
                healthBar.UpdateMagicBar(magicArmor, maxMagicArmor);
            if (magicArmor <= 0 && health == 0)
                Kill();
            else if (magicArmor <= 0)
                haveMagicArmor = false;
            
        }
        else
        {
            if (haveArmor && armorIsHp)
            {
                armor -= armordamage;
                if (haveHealthBar)
                    healthBar.UpdateHealthBar(armor, maxArmor);
                if (armor <= 0)
                    Kill();
            }
            else if (haveArmor && armorIsHp == false)
            {
                health -= damage * (1 - (armor / maxArmor));
                armor -= armordamage;
                if (haveHealthBar && armorIsHp)
                    healthBar.UpdateHealthBar(armor, maxArmor);
                if (armor <= 0)
                    haveArmor = false;
                if (health <= 0)
                    Kill();
            }
            else
            {
                health -= damage;
                
                if (health <= 0)
                Kill();
            }
            if (haveHealthBar && armorIsHp == false)       //Health bar update if armor is not Hp
                healthBar.UpdateHealthBar(health, maxHealth);
            if (haveShaderArmor)     //Disolve shader for armor
                armorobject.SetShaderProperty(armor, maxArmor);

        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Kill()
    {
        if (replaceWhenDead)
            Instantiate(deadReplacement, transform.position, transform.rotation);
        if (makeExplosion)
            Instantiate(explosion, transform.position, transform.rotation);


        Destroy(gameObject);
    }
}
