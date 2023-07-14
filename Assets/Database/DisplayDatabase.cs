using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using UnityEngine.UI;
using Mono.Data.Sqlite;

public class DisplayDatabase : MonoBehaviour
{
    public Text HighScore;
    public Text KillCount;
    public Text GameStatus;
    private string dbName = "URI=file:HighScore.db";
    // Start is called before the first frame update
    void Start()
    {
        DisplayData();
        DisplayKills();
        DisplayGameStatus();

    }

    public void DisplayData()
    {
        HighScore.text += "\n";
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM HighScore;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        HighScore.text += reader["Name"] + "\n";
                    reader.Close();
                }

            }
            connection.Close();
        }
    }

    public void DisplayKills()
    {
        KillCount.text += "\n";
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM HighScore;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        KillCount.text += reader["KillCount"] + "\n";
                    reader.Close();
                }

            }
            connection.Close();
        }
    }

    public void DisplayGameStatus()
    {
        GameStatus.text += "\n";
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM HighScore;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        GameStatus.text += reader["Game"] + "\n";
                    reader.Close();
                }

            }
            connection.Close();
        }
    }
}
