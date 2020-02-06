using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string nextScene;
    public string spawnPoint;

    public void LoadNextScene()
    {
        GameManager.Instance.spawnPoint = spawnPoint;
        GameManager.Instance.playerData.SavePlayerEquipment();
        SceneManager.LoadScene(nextScene);
    }
}
