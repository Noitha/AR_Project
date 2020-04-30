using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SymbolController : MonoBehaviour
{
    
    private List<SymbolColumn> _symbolColumns = new List<SymbolColumn>();
    
    public List<Symbol> matchPattern1 = new List<Symbol>();
    public List<Symbol> matchPattern2 = new List<Symbol>();
    public List<Symbol> matchPattern3 = new List<Symbol>();

    public TextMeshProUGUI text;
    public TextMeshProUGUI myDebugText;

    public int GameState = 0;
    public Camera myCamera;
    
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

        List<Symbol> symbols;
        
        switch (GameState)
        {
            case 0:
            {
                symbols = matchPattern1;
                break;
            }
            case 1:
            {
                symbols = matchPattern2;
                break;
            }
            case 2:
            {
                symbols = matchPattern3;
                break;
            }
            default:
            {
                symbols = matchPattern1;
                break;
            }
        }

        foreach (var symbolColumn in _symbolColumns)
        {
            if (symbols.Contains(symbolColumn.GetCurrentActiveSymbol()))
            {
                continue;
            }
            
            correct = false;
            break;
        }

        if (!correct)
        {
            text.text = GameState + " Incorrect";
            return;
        }

        text.text =  GameState + " Correct";
    }
    
    private void Update()
    {
        _symbolColumns[1].GetCurrentActiveSymbol().transform.position =
            myCamera.transform.position + myCamera.transform.forward;
        
        if (Input.touchCount == 0)
        {
            return;
        }

        var touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began)
        {
            return;
        }

        if (!Physics.Raycast(myCamera.ScreenPointToRay(touch.position), out var hit, 10))
        {
            return;
        }

        if (!hit.transform.CompareTag("Symbol"))
        {
            return;
        }

        var symbol = hit.transform.GetComponent<Symbol>();

        if (!symbol.isChangeable)
        {
            return;
        }

        myDebugText.text = symbol.Index.ToString();
        symbol.SymbolColumn.Next();
    }
}