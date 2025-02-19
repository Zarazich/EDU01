using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public List<AudioClip> Clips;
    public AudioSource AS;
    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();

    }

    public void SetClip(int clipIndex)
    {
        AS.clip = Clips[clipIndex];
        AS.Play();
    }
}
