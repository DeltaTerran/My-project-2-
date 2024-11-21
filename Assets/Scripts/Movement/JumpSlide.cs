using UnityEngine;

public class JumpSlide : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_animator != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _animator.SetTrigger("JumpTr");
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                _animator.SetTrigger("SlideTr");
            }
        }
    }
}
