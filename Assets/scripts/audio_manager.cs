using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_manager : MonoBehaviour
{
    [SerializeField] private AudioSource[] sources;
    [SerializeField] private AudioClip[] theme_songs;
    [SerializeField] private audio_event effects;
    private void OnEnable()
    {
        effects.RegisterListener(playEffect);
    }
    private void OnDisable()
    {
        effects.UnregisterListener(playEffect);
    }
    void Start()
    {
       StartCoroutine( play_theme());
    }

    private IEnumerator play_theme()
    {
        for (int i = 0; i < theme_songs.Length;) 
        {
            sources[0].clip = theme_songs[i];
            sources[0].Play();
            yield return new WaitForSeconds(theme_songs[i].length);
            i++;
            if (i == theme_songs.Length)
            {
                i = 0;
            }



        }
      
    }
    private void playEffect(AudioClip clip)
    {
        sources[1].clip = clip;
        sources[1].Play();
    }

}
