using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpBasic : ScriptableObject, IPowerUp
{
    public Stats stat;

    public Sprite sprite;
    public string text;

    public void Init(Image image, TextMeshProUGUI tmpText) {
        image.sprite = sprite;
        tmpText.text = text;
    }

    public Stats ApplyToStat(Stats statToApply) {
        return statToApply + this.stat;
    }

}
