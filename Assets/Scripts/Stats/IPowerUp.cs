using TMPro;
using UnityEngine.UI;

public interface IPowerUp {
    public Stats ApplyToStat(Stats statToApply);
    void Init(Image image, TextMeshProUGUI tmpText);
}