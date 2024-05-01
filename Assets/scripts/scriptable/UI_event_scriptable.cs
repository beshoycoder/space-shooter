using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveEvent", menuName = "scriptable/Event/UI_Event")]
public class UI_event_scriptable : ScriptableObject
{
    private event System.Action<Sprite> listeners;

    public void Raise(Sprite waveNumber)
    {
        listeners?.Invoke(waveNumber);
    }

    public void RegisterListener(System.Action<Sprite> listener)
    {
        listeners += listener;
    }

    public void UnregisterListener(System.Action<Sprite> listener)
    {
        listeners -= listener;
    }
}
