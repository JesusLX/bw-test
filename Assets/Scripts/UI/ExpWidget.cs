using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpWidget : MonoBehaviour
{
    public Slider expSlider;

    private void Start() {
        FindObjectOfType<Player>().OnExperienceChanged.AddListener(UpdateExperience);
    }

    public void Init() {
        expSlider.value = 0;
    }

    public void UpdateExperience(Stats.LevelST levelST) {
        expSlider.value = levelST.Experience / FindObjectOfType<LevelManager>().ExpNeeded;
    }
}
