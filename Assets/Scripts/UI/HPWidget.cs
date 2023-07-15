using bw_test.ParticlesPool;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HPWidget : MonoBehaviour {
    public Slider slider;
    public TextMeshProUGUI currentHp;
    public TextMeshProUGUI maxHp;
    public Stats.HealthST health;


    private void Start() {
        Player player = FindObjectOfType<Player>();
        player.OnStatsChanged.AddListener(OnStatsChange);
    }
    private void OnEnable() {
      

    }
    private void OnDisable() {

    }
    public void Init() {
        Player player = FindObjectOfType<Player>();
        health = player.Stats.Health;
        SetData(health);
    }
    public void OnStatsChange(Stats stats) {
        SetData(stats.Health);
    }

    public void SetData(Stats.HealthST Health) {
        maxHp.text = Health.MaxHealth.ToString();
        currentHp.text = Health.CurrentHealth.ToString();
        slider.value = Health.CurrentHealth / Health.MaxHealth;
    }
}
