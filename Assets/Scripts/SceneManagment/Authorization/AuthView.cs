//using TMPro;
//using UnityEngine;

//public class AuthView : MonoBehaviour
//{
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    public TMP_InputField Usernamefield;
//    public TMP_InputField Emailfield;
//    public TMP_InputField Passwordfield;
//    public TMP_InputField Conformpassword;
//    AuthFB _authFB;
//    [SerializeField] GameObject _authFB_Reg;
//    [SerializeField] GameObject _authFB_Auth;

//    private void Awake()
//    {
//        _authFB = _authFB_Auth.GetComponent<AuthFB>();
//    }
//#region Buttons
//    void RegistrationWindowButton()
//    {
//        _authFB.RegistrationButton();
//        _authFB = _authFB_Reg.GetComponent<AuthFB>();
//    }
//    void RegistrationButton()
//    {
//        _authFB.RegisterUser(Usernamefield.text, Emailfield.text, Passwordfield.text, Conformpassword.text);
//        _authFB = _authFB_Auth.GetComponent<AuthFB>();
//    }
//    void LoginButton()
//    {
//        _authFB.LoginUser(Emailfield.text, Passwordfield.text);
//    }
//    void GoBackButton()
//    {
//        _authFB.GoBackButton();
        
//    }
//#endregion
//}
