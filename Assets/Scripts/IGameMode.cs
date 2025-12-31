public interface IGameMode
{
    void Initialize();

    void UpdateGameMode(float deltaTime);

    void StartGame();
    
    void EndGame();
}
