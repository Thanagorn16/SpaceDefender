using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Shooting")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

    public void PlayShootingClip()
    {
        if(shootingClip != null) //check if the audio is attached
        {
            PlayClip(shootingClip, shootingVolume);

            // AudioSource.PlayClipAtPoint(shootingClip, 
            //                             Camera.main.transform.position,
            //                             shootingVolume);
        }
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);

        // AudioSource.PlayClipAtPoint(damageClip,
        //                             Camera.main.transform.position,
        //                             damageVolume);
    }

    void PlayClip(AudioClip clip, float volum) //we create this method to make things easier
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPos, volum);
    }
}
