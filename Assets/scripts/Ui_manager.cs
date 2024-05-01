using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui_manager : MonoBehaviour
{
    [Header("event channels")]
    public int_Event waveStartEvent;
    public int_Event waveEndEvent;
    [Header("score channel")]
    [SerializeField] private int_Event score;
    [Header("health")]
    [SerializeField] private float_event health;
    [Header("current_gun")]
    [SerializeField] private UI_event_scriptable gun;

    public Image health_ui;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI scoreText;
    public Image current_weapon;
    private int total_score=0;

    void OnEnable()
    {
        waveStartEvent.RegisterListener(OnWaveStart);
        waveEndEvent.RegisterListener(OnWaveEnd);
        score.RegisterListener(onScoreUpdate);
        health.RegisterListener(uPdateHealth);
        gun.RegisterListener(UpdateGun);
    }

    void OnDisable()
    {
        waveStartEvent.UnregisterListener(OnWaveStart);
        waveEndEvent.UnregisterListener(OnWaveEnd);
        score.UnregisterListener(onScoreUpdate);
        health.UnregisterListener(uPdateHealth);
        gun.UnregisterListener(UpdateGun);
    }

    void OnWaveStart(int waveNumber)
    {
        waveText.text = "Wave " + waveNumber + " in progress...";
    }

    void OnWaveEnd(int waveNumber)
    {
        waveText.text = "Wave " + waveNumber + " completed!";
    }

    void onScoreUpdate(int points)
    {
        total_score += points;
        scoreText.text = "score:" + total_score;
    }
    void uPdateHealth(float amount) 
    {
        health_ui.fillAmount =amount;
    }

    private void UpdateGun(Sprite current)
    {
        current_weapon.sprite = current;
    }

}
