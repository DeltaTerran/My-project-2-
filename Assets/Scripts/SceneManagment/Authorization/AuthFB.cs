using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase.Database;
using System.Collections.Generic;
using System.Collections;

public class AuthFB : MonoBehaviour
{
    [SerializeField]
    GameObject _autorization, _registration, _loadingscreen;
    [SerializeField]
    TMP_InputField _usernamefield, _emailfield, _passwordfield, _conformpassword;
    [SerializeField] TMP_Text _wrongLabel;
    //public FirebaseAuth Auth;
    //private DatabaseReference _databaseReference;

    void Start()
    {
        StartCoroutine(WaitForFirebaseInitialization());

        //if (FirebaseManager.Instance !=null)
        //{
        //    Debug.Log("Firebase exists");
        //}
        //if (FirebaseManager.Instance.Auth.CurrentUser != null)
        //{
        //    Debug.Log("User already logged in");
        //    SceneManager.LoadScene("Game");
        //}
        //else
        //{
        //    _autorization.SetActive(true);
        //}

        //FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        //{
        //    var dependencyStatus = task.Result;
        //    if (dependencyStatus == DependencyStatus.Available)
        //    {
        //        //Auth = FirebaseAuth.DefaultInstance;
        //        //_databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        //        //
        //
        //        ("Firebase Auth ���������������!");
        //    }
        //    else
        //    {
        //        Debug.LogError($"Firebase �� ������� ����������������: {dependencyStatus}");
        //    }
        //});

    }
    //public void RegisterUser(string username, string email, string password, string conformpassword)
    public void RegisterUser()
    {
        string username = _usernamefield.text;
        string email = _emailfield.text;
        string password = _passwordfield.text;
        string conformpassword = _conformpassword.text;

        FirebaseManager.Instance.Auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (password != conformpassword)
            {
                _wrongLabel.text = "Passwords are not the same";
                return;
            }
            if (password.Length < 6)
            {
                _wrongLabel.text = "Password is too weak";
                return;
            }
            if (task.IsCanceled)
            {
                _wrongLabel.text = "Account with this email already exists";
                return;
            }
            if (task.IsFaulted)
            {
                //Debug.LogError("������ ��� �����������: " + task.Exception);
                _wrongLabel.text = "Email is badly formated";
                return;
            }
            //Debug.Log("������������ ������");

            AuthResult authResult = task.Result;
            FirebaseUser newUser = authResult.User;

            UserProfile profile = new UserProfile { DisplayName = username };
            newUser.UpdateUserProfileAsync(profile).ContinueWith(updateTask =>
            {
                if (updateTask.IsCanceled || updateTask.IsFaulted)
                {
                    //Debug.LogError("������ ���������� �������: " + updateTask.Exception);
                    return;
                }

                // ��������� �������������� ������ � Realtime Database
                //SaveUsernameToDatabase(newUser.UserId, username);
            });
            
            _autorization.SetActive(true);
            _registration.SetActive(false);

        });
    }
    //void SaveUsernameToDatabase(string userId, string username)
    //{
    //    Dictionary<string, object> userData = new Dictionary<string, object>
    //    {
    //        {"username", username }
    //    };
    //    _databaseReference.Child("users").Child("userId").SetValueAsync(userData).ContinueWith(task =>
    //    {
    //        if (task.IsCanceled)
    //        {
    //            Debug.LogError("������ ���������� ������ ������������: " + task.Exception);
    //            return;
    //        }
    //        if (task.IsFaulted)
    //        {
    //            Debug.LogError("������ ���������� ������ ������������: " + task.Exception);
    //            return;
    //        }
    //        Debug.Log($"������������ ������� ��������������� � username: {username}");
    //    });
    //}
    //public void LoginUser(string email, string password)
    public void LoginUser()
    {

        string email = _emailfield.text;
        string password = _passwordfield.text;

        FirebaseManager.Instance.Auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                _wrongLabel.text = "����������� ��������.";
                return;
            }
            if (task.IsFaulted)
            {
                _wrongLabel.text = "Username/Password is Incorrect";
                return;
            }
            
            
            //Debug.Log("������������ �����������");
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

    //public void GetUserName(string userID)
    //{
    //    _databaseReference.Child("users").Child(userID).GetValueAsync().ContinueWith(task =>
    //    {
    //        if (task.IsCanceled || task.IsFaulted)
    //        {
    //            Debug.LogError("������ ��������� username: " + task.Exception);
    //            return;
    //        }

    //        if (task.Result.Value != null)
    //        {
    //            DataSnapshot snapshot = task.Result;
    //            string username = snapshot.Child("username").Value.ToString();
    //            Debug.Log("��� ������������: " + username);
    //        }
    //        else
    //        {
    //            Debug.Log("������������ �� ������.");
    //        }
    //    });
    //}
    private IEnumerator WaitForFirebaseInitialization()
    {
        while (!FirebaseManager.Instance.IsInitialized)
        {
            yield return null; // ��� ���������� �����, ���� FirebaseManager �� �������� �������������
        }

        if (FirebaseManager.Instance.Auth.CurrentUser != null)
        {
            Debug.Log("User already logged in");
            SceneManager.LoadScene("Game");
        }
        else
        {
            _autorization.SetActive(true);
            _loadingscreen.SetActive(false);
        }
    }
}
