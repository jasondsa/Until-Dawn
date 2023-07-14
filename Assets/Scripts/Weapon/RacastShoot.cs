using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacastShoot : MonoBehaviour
{
    public Camera Playercamera;

    public float FireRate = 10f;
    private float timeBetweenNextShot;
    public float Damage = 20f;

    [SerializeField]
    float damageEnemy = 10f;


    // this is ammo area
    [Header("Ammo Management")]
    public int ammocount = 25;
    public int availableammo = 1000;
    public int maxAmmo = 25;
    public Animator anim;
    public Text currentammotext;

    void Update()
    {
        currentammotext.text = ammocount.ToString();

        if (Input.GetKeyDown(KeyCode.R) && ammocount <= maxAmmo)
        {
            anim.SetBool("Reload", true);
            anim.SetBool("Shoot", false);
        }
        if (ammocount <= 0)
        {
            anim.SetBool("Reload", true);
            anim.SetBool("Shoot", false);
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= timeBetweenNextShot)
        {
            timeBetweenNextShot = Time.time + 1f / FireRate;
            anim.SetBool("Shoot", true);
            weapon();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("Shoot", false);
        }
    }

    void weapon()
    {
        ammocount--;
        RaycastHit hit;
        if (Physics.Raycast(Playercamera.transform.position, Playercamera.transform.forward, out hit))
        {
            if (hit.transform.tag == "Enemy")
            {
                EnemyHealth enemyHealthScript = hit.transform.GetComponent<EnemyHealth>();
                enemyHealthScript.DeductHealth(damageEnemy);
            }
        }
    }

    public void Reload()
    {
        ammocount = maxAmmo;
        availableammo = availableammo - maxAmmo + ammocount;
        anim.SetBool("Reload", false);
    }
}