using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [Header("General")] 
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float ProjectileSpeed = 10f;
    [SerializeField] float ProjectileLifeTime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;
    
    [Header("AI")]
    [SerializeField]bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minFiringRate = 0.2f;

    [HideInInspector]public bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine =  StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            // Debug.Log("aaaa");
            // StopAllCoroutines();
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    float RandomFiringRate()
    {
        // float rate = Random.Range(firingRate, firingTime);

        // return Mathf.Clamp(rate, minFiringRate, float.MaxValue);
        // return rate;
        // float rate = Random.Range(firingRate, firingTime);
        float rate = Random.Range(baseFiringRate - firingRateVariance, firingRateVariance + baseFiringRate);
        return Mathf.Clamp(rate, minFiringRate, float.MaxValue);
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instance =  Instantiate(projectilePrefab, 
                                                transform.position, 
                                                Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * ProjectileSpeed;
            }

            audioPlayer.PlayShootingClip();

            Destroy(instance, ProjectileLifeTime);
            yield return new WaitForSeconds(RandomFiringRate());
        }
    }
}
