using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Weapon : MonoBehaviour
{
    public GameObject weaponModel;
    public GameObject playerCam;  // It is also raycast start point
    public float range = 100f;
    public float damage = 25f;
    public float armordamage = 10f;
    public float magicdamage = 50f;



    // Recoil
    public bool recoil = true;                          
    public float recoilKickBackMin = 0.1f;              
    public float recoilKickBackMax = 0.3f;              
    public float recoilRecoveryRate = 8f;

    public AudioClip fireSound;

    // F
    public bool makeMuzzleEffects = true;
    public Transform muzzleEffectsPosition;
    public GameObject muzzleEffects;

    void Start()
    {
        if (weaponModel == null)
            weaponModel = gameObject;

        if (GetComponent<AudioSource>() == null)
        {
            gameObject.AddComponent(typeof(AudioSource));
        }

        if (muzzleEffectsPosition == null)
            muzzleEffectsPosition = gameObject.transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Shoot");
            Shoot();

        }
        if (recoil)
        {
            weaponModel.transform.position = Vector3.Lerp(weaponModel.transform.position, transform.position, recoilRecoveryRate * Time.deltaTime);
            weaponModel.transform.rotation = Quaternion.Lerp(weaponModel.transform.rotation, transform.rotation, recoilRecoveryRate * Time.deltaTime);
        }

    }
    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
            Recoil();
            Health health = hit.transform.GetComponent<Health>();
            if (health != null)
            {
                health.Hit(damage, armordamage, magicdamage);
            }
        }
        
        GetComponent<AudioSource>().PlayOneShot(fireSound);

        if (makeMuzzleEffects)
        {
            GameObject muzfx = muzzleEffects;
            if (muzfx != null)
                Instantiate(muzfx, muzzleEffectsPosition.position, muzzleEffectsPosition.rotation);
        }
    }

   /* private void CreateShootFlash(Vector3 spawnPosition)
    {
        World_Sprite worldSprite = World_Sprite.Create(spawnPosition, shootFlashSprite);
    }*/
    void Recoil()
    {

        // Make sure the user didn't leave the weapon model field blank
        if (weaponModel == null)
        {
            Debug.Log("Weapon Model is null.  Make sure to set the Weapon Model field in the inspector.");
            return;
        }

        // Calculate random values for the recoil position and rotation
        float kickBack = Random.Range(recoilKickBackMin, recoilKickBackMax);
        //float kickRot = Random.Range(recoilRotationMin, recoilRotationMax);

        // Apply the random values to the weapon's postion and rotation
        weaponModel.transform.Translate(new Vector3(0, 0, -kickBack), Space.Self);
        //weaponModel.transform.Rotate(new Vector3(-kickRot, 0, 0), Space.Self);
    }
}
