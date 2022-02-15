using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrail : MonoBehaviour
{
    MeleeWeaponTrail weaponTrail;
    Transform sword;

    public GameObject hitPoint;
    public GameObject slashThreeEffectPrefab;
    public Transform slashThreePoint;

    public AudioSource audioSource;

    public AudioClip[] swordsHitSoundFX;
    public AudioClip earthHitSound;
    public AudioClip jiaoHanSheng;


    // Start is called before the first frame update
    void Awake()
    {
        sword = GameObject.Find("Sword").transform;
        weaponTrail = sword.gameObject.GetComponent<MeleeWeaponTrail>();

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SlashOneWeaponTrailStart(bool show)
    {
        if(show)
        {
            weaponTrail.Emit = true;
            hitPoint.SetActive(true);
            audioSource.PlayOneShot(swordsHitSoundFX[0]);
        }
    }

    void SlashOneWeaponTrailEnd(bool end)
    {
        if (end)
        {
            weaponTrail.Emit = false;
            hitPoint.SetActive(false);
            
        }
    }

    void SlashTwoWeaponTrailStart(bool show)
    {
        if (show)
        {
            weaponTrail.Emit = true;
            hitPoint.SetActive(true);
            audioSource.PlayOneShot(swordsHitSoundFX[1]);
        }
    }

    void SlashTwoWeaponTrailEnd(bool end)
    {
        if (end)
        {
            weaponTrail.Emit = false;
            hitPoint.SetActive(false);

        }
    }

    void SlashThreeWeaponTrailStart(bool show)
    {
        if (show)
        {
            weaponTrail.Emit = true;
            hitPoint.SetActive(true);
            audioSource.PlayOneShot(jiaoHanSheng);
        }
    }

    void SlashThreeWeaponTrailEnd(bool end)
    {
        if (end)
        {
            weaponTrail.Emit = false;
            hitPoint.SetActive(false);

        }
    }

    void SlashThreeEffect(bool show)
    {
        if(show)
        {
            Instantiate(slashThreeEffectPrefab,slashThreePoint.position,slashThreePoint.rotation);
            audioSource.PlayOneShot(earthHitSound);
        }
    }
}
