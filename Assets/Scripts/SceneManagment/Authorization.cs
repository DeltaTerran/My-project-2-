using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Auth;

public class Authorization : MonoBehaviour
{
    [SerializeField]
    GameObject _autorization, _registration;
    [SerializeField]
    TMP_InputField _emailfield, _passwordfield, _conformpassword;
    private FirebaseAuth auth;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus== DependencyStatus.Available)
            {
                auth = FirebaseAuth.DefaultInstance;
                Debug.Log("Firebase Auth инициализирован!");
            }
            else
            {
                Debug.LogError($"Firebase не удалось инициализировать: {dependencyStatus}");
            }
        });
    }
    public void RegisterUser()
    {
        string email = _emailfield.text;
        string password = _passwordfield.text;
        string conformpassword = _conformpassword.text;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
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
            _autorization.SetActive(true);
            _registration.SetActive(false);

        });
    }
    public void LoginUser()
    {
        string email = _emailfield.text;
        string password = _passwordfield.text;

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
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
            Debug.Log($"Пользователь авторизован");
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

}
