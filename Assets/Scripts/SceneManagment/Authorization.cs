using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase.Database;
using System.Collections.Generic;

public class Authorization : MonoBehaviour
{
    [SerializeField]
    GameObject _autorization, _registration;
    [SerializeField]
    TMP_InputField _usernamefield, _emailfield, _passwordfield, _conformpassword;
    private FirebaseAuth auth;
    private DatabaseReference _databaseReference;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus== DependencyStatus.Available)
            {
                auth = FirebaseAuth.DefaultInstance;
                _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
                //Debug.Log("Firebase Auth инициализирован!");
            }
            else
            {
                Debug.LogError($"Firebase не удалось инициализировать: {dependencyStatus}");
            }
        });
    }
    public void RegisterUser()
    {
        string username = _usernamefield.text;
        string email = _emailfield.text;
        string password = _passwordfield.text;
        string conformpassword = _conformpassword.text;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (password != conformpassword)
            {
                Debug.LogError("Ваши пароли не совпадают");
                return;
            }
            if (task.IsCanceled)
            {
                Debug.LogError("Регистрация отменена.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("Ошибка при регистрации: " + task.Exception);
                return;
            }
            Debug.Log("Пользователь создан");

            AuthResult authResult = task.Result;
            FirebaseUser newUser = authResult.User;

            UserProfile profile = new UserProfile { DisplayName = username };
            newUser.UpdateUserProfileAsync(profile).ContinueWith(updateTask =>
            {
                if (updateTask.IsCanceled || updateTask.IsFaulted)
                {
                    Debug.LogError("Ошибка обновления профиля: " + updateTask.Exception);
                    return;
                }

                // Сохраняем дополнительные данные в Realtime Database
                SaveUsernameToDatabase(newUser.UserId, username);
            });
            _autorization.SetActive(true);
            _registration.SetActive(false);

        });
    }
    void SaveUsernameToDatabase(string userId, string username)
    {
        Dictionary<string, object> userData = new Dictionary<string, object>
        {
            {"username", username }
        };
        _databaseReference.Child("users").Child("userId").SetValueAsync(userData).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("Ошибка сохранения данных пользователя: " + task.Exception);
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("Ошибка сохранения данных пользователя: " + task.Exception);
                return;
            }
            Debug.Log($"Пользователь успешно зарегистрирован с username: {username}");
        });
    }
    public void LoginUser()
    {
        
        string email = _emailfield.text;
        string password = _passwordfield.text;

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("Авторизация отменена.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("Ошибка при авторизации: " + task.Exception);
                return;
            }
            
            
            Debug.Log("Пользователь авторизован");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("Game");


        });
    }
    public void RegistrationButton()
    {
        _autorization.SetActive(false);
        _registration.SetActive(true);
    }
    public void GoBackButton()
    {
        _autorization.SetActive(true);
        _registration.SetActive(false);
    }
    
    public void GetUserName(string userID)
    {
        _databaseReference.Child("users").Child(userID).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError("Ошибка получения username: " + task.Exception);
                return;
            }

            if (task.Result.Value != null)
            {
                DataSnapshot snapshot = task.Result;
                string username = snapshot.Child("username").Value.ToString();
                Debug.Log("Имя пользователя: " + username);
            }
            else
            {
                Debug.Log("Пользователь не найден.");
            }
        });
    }
}
