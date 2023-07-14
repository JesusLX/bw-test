using bw_test.ParticlesPool;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PowerUpWidget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public Image image;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public IPowerUp powerUp;
    public string selectedPSKey;

    [Header("DoTween")]
    [SerializeField] private float scaleFactor = 1.1f;
    private RectTransform rectTransform;
    private Vector3 originalScale;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
        GetComponent<Button>().onClick.AddListener(OnSelected);
    }
    public void Init(IPowerUp powerUp) {
        title.text = powerUp.Title;
        image.sprite = powerUp.Image;
        description.text = powerUp.Description;
        this.powerUp = powerUp;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        rectTransform.DOScale(originalScale * scaleFactor, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        rectTransform.DOScale(originalScale, 0.2f);
    }

    public void OnSelected() {
        PSManager.instance.Play(selectedPSKey, FindObjectOfType<Camera>().transform, Vector3.forward*2, Quaternion.identity);
        FindObjectOfType<Player>().AddPowerUp(powerUp);
        UIManager.instance.Hide(UIManager.instance.LevelUpPanel);
    }
}
