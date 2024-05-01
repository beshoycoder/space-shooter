using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveEvent", menuName = "scriptable/Event/gun_Event")]
public class weapons_event :ScriptableObject
{
    private event System.Action<gun_scriptable> listeners;

    public void Raise(gun_scriptable gun)
    {
        listeners?.Invoke(gun);
    }

    public void RegisterListener(System.Action<gun_scriptable> listener)
    {
        listeners += listener;
    }

    public void UnregisterListener(System.Action<gun_scriptable> listener)
    {
        listeners -= listener;
    }
}
