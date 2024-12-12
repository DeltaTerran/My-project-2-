using TMPro;
using UnityEngine;

public class HighScoreEntry : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] public TMP_Text _score;
    
    public void Initialize(string name, int score)
    {
        _name.text = name;
        _score.text = score.ToString();
    }
}
