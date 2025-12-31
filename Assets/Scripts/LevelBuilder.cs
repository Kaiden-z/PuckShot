using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBuilder
{
    private IGameMode _gameMode = null;
    private SceneReference _scene = null;
    private PlayerData _playerData = null;

    public void BuildLevel()
    {
        
    }

    public LevelBuilder SetGameManager(IGameMode gameMode)
    {
        _gameMode = gameMode;
        return this;
    }

    public LevelBuilder SetScene(SceneReference scene)
    {
        _scene = scene;
        return this;
    }

    public LevelBuilder SetPlayerData(PlayerData playerData)
    {
        _playerData = playerData;
        return this;
    }
}
