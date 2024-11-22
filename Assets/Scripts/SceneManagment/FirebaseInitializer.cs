using Firebase;
using Firebase.Extensions;
using UnityEngine;

public class FirebaseInitializer : MonoBehaviour
{
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                Debug.Log("Firebase успешно инициализирован!");
            }
            else
            {
                Debug.LogError($"Не удалось инициализировать Firebase: {task.Result}");
            }
        });
    }
}
