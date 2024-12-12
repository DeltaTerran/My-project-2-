using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using System;
using Firebase.Extensions;
using static GM;
public class FirebaseManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static FirebaseManager Instance { get; private set; }
    public FirebaseAuth Auth { get; private set; }

    public DatabaseReference dbReference { get; private set; }
    public FirebaseDatabase Database { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeFirebase();
    }
    //void Start()
    //{
    //    DontDestroyOnLoad (this.gameObject);
    //}

    private void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                Auth = FirebaseAuth.DefaultInstance;
                Database = FirebaseDatabase.DefaultInstance;
                dbReference = FirebaseDatabase.DefaultInstance.RootReference;
                //Debug.Log("Firebase initialized successfully!");
            }
            else
            {
                //Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
            }
        });
    }
    public void LoadLeaderboard()
    {
        Instance.dbReference.Child("leaderboard").OrderByChild("score").LimitToLast(10).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                foreach (DataSnapshot child in snapshot.Children)
                {
                    string name = child.Child("name").Value.ToString();
                    int score = int.Parse(child.Child("score").Value.ToString());
                    //Debug.Log($"Name: {name}, Score: {score}");
                }
            }
            else
            {
                //Debug.LogError("Failed to load leaderboard: " + task.Exception);
            }

        });
    }
    public void AddPlayerToLeaderboard(string userId, string name, int score)
    {
        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(name))
        {
            //Debug.LogError("User ID or name is null or empty!");
            return;
        }
        if (dbReference == null)
        {
            //Debug.LogError("Database reference is not initialized!");
            return;
        }

        //dbReference.Child("leaderboard").Child(userId).SetRawJsonValueAsync(JsonUtility.ToJson(new PlayerData(name, score))).ContinueWithOnMainThread(task =>
        dbReference.Child("leaderboard").Child(userId).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            DataSnapshot snapshot = task.Result;
            if (task.IsCompleted)
            {
                if (snapshot.Exists)
                {
                    int currentScore = int.Parse(snapshot.Child("score").Value.ToString());
                    if (score > currentScore)
                    {
                        UpdateLeaderboardEntry(userId, name, score);
                    }
                }
                else
                {
                    UpdateLeaderboardEntry(userId, name, score);
                }
                
            }
        });
    }

    private void UpdateLeaderboardEntry(string userId, string name, int score)
    {
        PlayerData playerData = new PlayerData(name, score);
        string json = JsonUtility.ToJson(playerData);

        dbReference.Child("leaderboard").Child(userId).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
        {

        });
    }

    class PlayerData
    {
        public string name;
        public int score;

        public PlayerData(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

}
