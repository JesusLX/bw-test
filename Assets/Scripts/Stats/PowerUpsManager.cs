using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : Singleton<PowerUpsManager>
{
    [SerializeField]private List<PowerUpBasic> powerUpBasics = new List<PowerUpBasic>();
    public List<IPowerUp> powerUps = new List<IPowerUp>();
    public List<PowerUpCard> UIPowerUpCards = new List<PowerUpCard>();
    public PowerUpCard cardPrefab;

    private void Start() {

        powerUps.AddRange(powerUpBasics);
    }

    [ContextMenu("Test/Init")]
    public void LetsSelect() {
        List<IPowerUp> gotten = new List<IPowerUp> (); 
        for (int i = 0; i < UIPowerUpCards.Count; i++) {
            IPowerUp powerUp = powerUps[Random.Range(0, powerUps.Count - 1)];
            UIPowerUpCards[i].Init(powerUp);
            gotten.Add(powerUp);
            powerUps.Remove(powerUp);
        }
        gotten.ForEach(x => { if (x.IsReutilizable) powerUps.Add(x); });
    }
}
