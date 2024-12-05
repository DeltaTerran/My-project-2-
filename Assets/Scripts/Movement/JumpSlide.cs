using UnityEngine;

public class JumpSlide : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private Animator _animator;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_animator != null)
        {
            #region Windows System
            //if (Input.GetKeyDown(KeyCode.W))
            //{
            //    _animator.SetTrigger("JumpTr");
            //}
            //if (Input.GetKeyDown(KeyCode.S))
            //{
            //    _animator.SetTrigger("SlideTr");
            //}
            #endregion
        }
    }
}
