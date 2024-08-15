using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManger : MonoBehaviour
{
    public string PlayerName;
    public string HighScorePlayerName;
    public int HighScore;
    public static GameManger Instance;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string HighScorePlayerName;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.HighScorePlayerName = PlayerName;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);
        Debug.Log($"SaveHighScore: {json}");
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {   
        string path = Application.persistentDataPath + "/savefile.json";
        // File.Delete(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScorePlayerName = data.HighScorePlayerName;
            HighScore = data.HighScore;
            Debug.Log($"LoadScore: {json}");
        }
    }
}
