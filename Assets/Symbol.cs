using TMPro;
using UnityEngine;

public class Symbol : MonoBehaviour
{
    public TextMeshProUGUI text;

    public string symbolMeaning;
    
    private void OnEnable()
    {
        text.text = symbolMeaning;
    }
}