using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WaveEvent", menuName = "scriptable/Event/int_Event")]
public class int_Event : ScriptableObject
{
    private event System.Action<int> listeners;

    public void Raise(int waveNumber)
    {
        listeners?.Invoke(waveNumber);
    }

    public void RegisterListener(System.Action<int> listener)
    {
        listeners += listener;
    }

    public void UnregisterListener(System.Action<int> listener)
    {
        listeners -= listener;
    }
}
