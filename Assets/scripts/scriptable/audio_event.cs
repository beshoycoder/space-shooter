using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveEvent", menuName = "scriptable/Event/audio_Event")]
public class audio_event :ScriptableObject
{
    private event System.Action<AudioClip> listeners;

    public void Raise(AudioClip effect)
    {
        listeners?.Invoke(effect);
    }

    public void RegisterListener(System.Action<AudioClip> listener)
    {
        listeners += listener;
    }

    public void UnregisterListener(System.Action<AudioClip> listener)
    {
        listeners -= listener;
    }
}
