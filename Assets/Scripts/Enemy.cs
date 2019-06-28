using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] GameObject enemyDamageFX;
    [SerializeField] Transform parent;

    [SerializeField] float PerHit = 50;

    [SerializeField] float startEnemyHelth = 100;
    [SerializeField] private float enemyHelth; // Enemy's Health

    [Header("Unity Stuff")]
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        AddBoxCollider();

        enemyHelth = startEnemyHelth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }


    private void OnParticleCollision(GameObject other)
    {

        enemyHelth = enemyHelth - PerHit;

        healthBar.fillAmount = enemyHelth / startEnemyHelth;

        enemyDamageFX.SetActive(true);
        //print("Damage the Enemy");
        //Destroy(gameObject);
        // Score

        if (enemyHelth <= 1)
        {
            enemyDeathFX.SetActive(true);
            GameObject fx = Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
            fx.transform.parent = parent;
            Destroy(gameObject);
            //print("Death the Enemy");
        }

    }


}
