using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerScript playerScript;
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(playerScript);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        playerScript.currentHealth = data.health;
        playerScript.points = data.points;
        //playerScript.levelPlaying = data.level;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        playerScript.transform.position = position;
    }
}
