using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool haveArmor = false;
    public bool haveMagicArmor = false;

    public float health = 300;
    public float armor = 1;
    public float magicArmor = 400;
    private float maxarmor;

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
            if(haveArmor == true)
            {
                health -= damage * (1-(armor / maxarmor));
                armor -= armordamage;
                if (armor <= 0)
                haveArmor = false;
                

            }
            else
            health -= damage;
            if (health <= 0)
            {
                //kill object
                Destroy(gameObject);
            }
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
