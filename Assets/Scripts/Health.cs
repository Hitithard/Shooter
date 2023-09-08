using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool haveArmor = false;
    public bool haveMagicArmor = false;
    public bool armorIsHp = false;

    public float health = 300;
    public float armor = 1;
    public float magicArmor = 400;
    private float maxarmor;

    public bool replaceWhenDead = false;
    public GameObject deadReplacement;
    public bool makeExplosion = false;
    public GameObject explosion;

    void Start()
    {
       maxarmor = armor;
    }


    public void Hit(float damage, float armordamage, float magicdamage)
    {   
        if(haveMagicArmor == true)
        {
            magicArmor -= magicdamage;
            if (magicArmor <= 0)
            haveMagicArmor = false;
            
        }
        else
        {
            if (haveArmor == true && armorIsHp == false)
            {
                health -= damage * (1 - (armor / maxarmor));
                armor -= armordamage;
                if (armor <= 0)
                    haveArmor = false;
            }
            else if (haveArmor == true && armorIsHp == true)
            {
                armor -= armordamage;
                if (armor <= 0)
                    Kill();
            }
            else
            {
                health -= damage;
                if (health <= 0)
                Kill();
            }
                
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
