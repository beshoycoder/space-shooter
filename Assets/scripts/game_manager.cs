using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//idea //
// make the wave based on the number of enemies that respawns 
//in each wave the number of enemies increase (wave_number * number of enemies)

public class WaveManager : MonoBehaviour
{
    public int_Event waveStartEvent;
    public int_Event waveEndEvent;

    private int currentWave = 0;

    void Start()
    {
        StartNextWave();
    }

    void StartNextWave()
    {
        currentWave++;

        
        waveStartEvent.Raise(currentWave);

        
        Invoke("EndWave", 5f);
    }

    void EndWave()
    {

       
        waveEndEvent.Raise(currentWave);

      
        Invoke("StartNextWave", 3f);
    }
}

