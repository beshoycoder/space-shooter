using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveEvent", menuName = "scriptable/Event/float_Event")]
public class float_event : ScriptableObject
{
    private event System.Action<float> listeners;

    public void Raise(float waveNumber)
    {
        listeners?.Invoke(waveNumber);
    }

    public void RegisterListener(System.Action<float> listener)
    {
        listeners += listener;
    }

    public void UnregisterListener(System.Action<float> listener)
    {
        listeners -= listener;
    }
}
