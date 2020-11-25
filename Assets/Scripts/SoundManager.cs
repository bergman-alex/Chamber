using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip hitSound;
    static AudioSource source;

    void Start()
    {
    	hitSound = Resources.Load<AudioClip>("Hitmarker");
    	source = GetComponent<AudioSource>();
    }

    public static void PlaySound(string sound)
    {
    	switch (sound)
    	{
    		case "playerHit":
    			source.PlayOneShot(hitSound);
    			break;
    	}
    }
}
