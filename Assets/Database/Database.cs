using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class Database : MonoBehaviour
{
    public string ScoreDB;
    public string GameStatus = "Not Completed";
    public InputField NameInput;
    public Text HighScoreInGame;
    private string dbName = "URI=file:HighScore.db";
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        CreateDB();
        ScoreDB = CountStateController.Score.ToString();
    }

    public void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE  TABLE IF NOT EXISTS HighScore (name VARCHAR(20), KillCount VARCHAR(20), Game VARCHAR(20));";
                command.ExecuteNonQuery();
            }
            
            connection.Close();
        }
    }
    public void AddData()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var commmand = connection.CreateCommand())
            {
                commmand.CommandText = "INSERT INTO HighScore(name,KillCount,Game) VALUES ('" + NameInput.text + "','" + ScoreDB + "','" + GameStatus + "');";
                commmand.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
