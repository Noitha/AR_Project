using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SymbolController : MonoBehaviour
{
    private List<SymbolColumn> _symbolColumns = new List<SymbolColumn>();

    public List<Symbol> matchPattern = new List<Symbol>();

    public TextMeshProUGUI text;
    
    
    public void Initialize()
    {
        _symbolColumns = GetComponentsInChildren<SymbolColumn>().ToList();

        foreach (var symbolColumn in _symbolColumns)
        {
            symbolColumn.Initialize(this);
        }
    }

    public void CheckSymbolAlignment()
    {
        var correct = true;
        var i = 0;
        
        foreach (var symbolColumn in _symbolColumns)
        {
            if (matchPattern[i].symbolMeaning == symbolColumn.GetCurrentActiveSymbol().symbolMeaning)
            {
                i++;
                continue;
            }
            
            correct = false;
            break;
        }

        if (!correct)
        {
            text.text = "Incorrect";
            return;
        }

        text.text = "Correct";
    }
}