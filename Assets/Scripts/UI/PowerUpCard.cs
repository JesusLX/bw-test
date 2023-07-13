using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PowerUpCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public Image image;
    public TextMeshProUGUI description;
    public Stats stats;

    [Header("DoTween")]
    [SerializeField] private float scaleFactor = 1.1f;
    private RectTransform rectTransform;
    private Vector3 originalScale;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }
    public void Init(IPowerUp powerUp) {
        image.sprite = powerUp.Image;
        description.text = powerUp.Description;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAA");
        rectTransform.DOScale(originalScale * scaleFactor, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        rectTransform.DOScale(originalScale, 0.2f);
    }
}
