using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    [SerializeField]private List<PowerUpBasic> powerUpBasics = new List<PowerUpBasic>();
    public List<IPowerUp> powerUps = new List<IPowerUp>();
    public List<PowerUpWidget> UIPowerUpCards = new List<PowerUpWidget>();
    public PowerUpWidget cardPrefab;

    private void Awake() {
        if(powerUps.Count == 0) {
            powerUps.AddRange(powerUpBasics);
        }
    }


    [ContextMenu("Test/Init")]
    public void LetsSelect() {
        List<IPowerUp> gotten = new List<IPowerUp> (); 
        for (int i = 0; i < UIPowerUpCards.Count; i++) {
            var index = Random.Range(0, powerUps.Count - 1);
            Debug.Log("INDEX " + index);
            IPowerUp powerUp = powerUps[index];
            UIPowerUpCards[i].Init(powerUp);
            gotten.Add(powerUp);
            powerUps.Remove(powerUp);
        }
        gotten.ForEach(x => { if (x.IsReutilizable) powerUps.Add(x); });
    }
}
