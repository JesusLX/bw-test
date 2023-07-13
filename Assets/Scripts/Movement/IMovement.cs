internal interface IMovement {
    void UpdateCanMove(bool can);
    void Init(ICharacter player);
    void UpdateStats(Stats stats);
    void TryMove();
}