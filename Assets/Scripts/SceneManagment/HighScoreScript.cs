using System.Collections.Generic;
using Firebase.Database;
using Firebase.Extensions;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    [SerializeField] private HighScoreEntry _highScoreEntryPrefab;
    [SerializeField] private Transform _container;
    void Start()
    {
        
        FirebaseManager.Instance.dbReference.Child("leaderboard").OrderByChild("score").LimitToLast(10).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                List<KeyValuePair<string, int>> highScores = new List<KeyValuePair<string, int>>();
                foreach (DataSnapshot child in snapshot.Children)
                {
                    string name = child.Child("name").Value.ToString();
                    int score = int.Parse(child.Child("score").Value.ToString());
                    highScores.Add(new KeyValuePair<string, int>(name, score));
                    //var highScoreEntry = Instantiate(_highScoreEntryPrefab, _container);
                    //highScoreEntry.Initialize(name, score);

                }
                highScores.Sort((x, y) => y.Value.CompareTo(x.Value));

                foreach (var entry in highScores)
                {
                    var highScoreEntry = Instantiate(_highScoreEntryPrefab, _container);
                    highScoreEntry.Initialize(entry.Key, entry.Value);
                }
            }
            else
            {
                //Debug.LogError("Failed to load leaderboard: " + task.Exception);
            }

        });

        
    }
}
