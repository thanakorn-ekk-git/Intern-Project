using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameSceneManager sceneManager;
    private void Awake()
    {
        Instance ??= this;
        if (this != Instance)
        {
            DestroyImmediate(gameObject);
        }
    }

    //Options
    public void NewGame()
    {
        // TODO : load game scene with new player data
        sceneManager.LoadScene("GameScene");
        // TODO : initialize new player data and game state
    }
    public void LoadGame()
    {
        // TODO: load game scene where player saved with saved player data
        sceneManager.LoadScene("GameScene");
    }
    public void SaveGame()
    {
        // TODO: save player and game state data(current level, player stats)
    }
    public void RestartGame()
    {
        // TODO : reload current game scene with lastest saved player data
    }
    public void NextLevel()
    {
        // TODO : load next level scene with current player data
    }
    public void ExitGame()
    {
        // TODO : add pop-up confirmation dialog before quitting
        Application.Quit();
    }
    public void MainMenu()
    {
        // TODO : load main menu scene
    }
    public void PauseGame()
    {
        // TODO : pause time and show pause menu
    }
    public void ResumeGame()
    {
        // TODO : resume time and hide pause menu
    }

    ///Game Events(Player)
    public void OnPlayerDeath()
    {
        // TODO : show game over screen with restart and main menu options
    }
    public void OnPlayerLevelUp()
    {
        // TODO : notify player of level up and show 2 options of skills to choose from
    }
    public void SelectSkill()
    {
        // TODO : VVVVV
        // if (active skills >2 )
        // { ReplaceSkill() }
        // else { AddSkill() }
    }
    public void ActivatePerk()
    {
        // TODO : activate perk effect 
    }
    public void EnhancePerk()
    {
        // TODO : enhance perk effect
    }
    public void RestAtHub()
    {
        // TODO : restore player health and mana, reset cooldowns, set respawn point
    }

    //Game Events(Level)
    public void OnLevelBossDeath()
    {
        // TODO : next level gate opens, show navigation hint to next level
    }
    public void OnEnterMonsterRoom()
    {
        // TODO : spawn enemies and trigger combat state
    }
    public void OnEnterTreasureRoom()
    {
        // TODO : spawn enemies and trigger treasure room state
        // if (enemies are cleared)
        // { SpawnTreasure(); }
    }
    public void OnEnterBossRoom()
    {
        // TODO : spawn boss and trigger boss fight state
        // if (Boss.isAlive == true)
        // { Player.cannotExit = true }
    }
    public void OnEnterHub()
    {
        // TODO : trigger hub state(set to passive state)
    }

}
