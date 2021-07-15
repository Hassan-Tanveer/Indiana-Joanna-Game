using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //public int level;
    public int health;
    public int points;
    public int level;
    public float[] position;

    public PlayerData(PlayerScript playerScript)
    {
        health = playerScript.currentHealth;
        points = playerScript.points;
        //level = playerScript.levelPlaying;

        position = new float[3];
        position[0] = playerScript.transform.position.x;
        position[1] = playerScript.transform.position.y;
        position[2] = playerScript.transform.position.z;
    }
}
