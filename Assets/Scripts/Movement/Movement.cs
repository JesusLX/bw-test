using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Movement : MonoBehaviour, IMovement, ITimeAffected {

    [SerializeField] internal Stats.MovementST stats;
    [SerializeField] internal bool canMove = false;

    private void OnEnable() {
        OnEnableEvents();
    }
    private void OnDisable() {
        OnDisableEvents();
    }

  

    virtual public void Init(ICharacter player) {
        
    }

    virtual public void TryMove() {
        
    }

    virtual public void UpdateCanMove(bool can) {
        canMove = can;
    }

    virtual public void UpdateStats(Stats stats) {
        this.stats = stats.Movement;
    }

    internal virtual void OnEnableEvents() {
        AttachTimeEvents();

    }
    internal virtual void OnDisableEvents() {
        DetachTimeEvents();
    }

    #region ITimeAffected
    public void OnPlayTimeStarts() {
        UpdateCanMove(true);
    }

    public void OnPlayTimeRestore() {
        UpdateCanMove(true);
    }

    public void OnPlayTimeStops() {
        UpdateCanMove(false);
    }

    public void AttachTimeEvents() {
        TimeManager.instance.OnPlayTimeStart.AddListener(OnPlayTimeStarts);
        TimeManager.instance.OnPlayTimeStop.AddListener(OnPlayTimeStops);
        TimeManager.instance.OnPlayTimeRestore.AddListener(OnPlayTimeRestore);
    }

    public void DetachTimeEvents() {
        TimeManager.instance.OnPlayTimeStart.RemoveListener(OnPlayTimeStarts);
        TimeManager.instance.OnPlayTimeStop.RemoveListener(OnPlayTimeStops);
        TimeManager.instance.OnPlayTimeRestore.RemoveListener(OnPlayTimeRestore);
    }

    #endregion
}
