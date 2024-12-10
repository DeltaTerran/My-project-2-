using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");
        float templateHight = 20f;
        int number = 0;
        entryTemplate.gameObject.SetActive(false);
        //for (int i = 0; i < 10; i++)
        //{
        //    Transform entryTransform = Instantiate(entryTemplate, entryContainer);
        //    RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        //    entryRectTransform.anchoredPosition = new Vector2(0, -templateHight * i);
        //    entryTransform.gameObject.SetActive(true);

        //    //entryTransform.Find("NameLabel").GetComponent<TMP_Text>().text = i.ToString();
        //}
        FirebaseManager.Instance.dbReference.Child("leaderboard").OrderByChild("score").LimitToLast(10).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                foreach (DataSnapshot child in snapshot.Children)
                {
                    string name = child.Child("name").Value.ToString();
                    int score = int.Parse(child.Child("score").Value.ToString());
                    number++;

                    Transform entryTransform = Instantiate(entryTemplate, entryContainer);
                    RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
                    entryRectTransform.anchoredPosition = new Vector2(0, -templateHight * number);
                    entryTransform.gameObject.SetActive(true);


                    entryTransform.Find("NameLabel").GetComponent<TMP_Text>().text = name;
                    entryTransform.Find("ScoreLabel").GetComponent<TMP_Text>().text = score.ToString();
                    

                }
            }
            else
            {
                //Debug.LogError("Failed to load leaderboard: " + task.Exception);
            }

        });

    }
}
