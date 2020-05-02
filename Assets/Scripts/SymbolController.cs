using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SymbolController : MonoBehaviour
{
    private List<SymbolColumn> _symbolColumns = new List<SymbolColumn>();

    public ParticleSystem bookCoverParticleSystem;
    public TextMeshPro solutionText;
    public TextMeshProUGUI feedbackText;
    
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

        var correctSymbols = new List<Symbol>();
        
        foreach (var symbolColumn in _symbolColumns)
        {
            var activeColumnSymbol = symbolColumn.GetCurrentActiveSymbol();
            
            if (symbols.Contains(activeColumnSymbol))
            {
                correctSymbols.Add(activeColumnSymbol);
                continue;
            }
            
            correct = false;
            break;
        }

        if (!correct)
        {
            text.text = GameState + " Incorrect";
        }
        else
        {
            StartCoroutine(Solved(correctSymbols));
        }
    }

    private IEnumerator Solved(List<Symbol> correctSymbols)
    {
        feedbackText.text = "Congratulations! Riddle solved.";
        
        foreach (var nonHighlightedSymbol in correctSymbols)
        {
            nonHighlightedSymbol.Highlight(true);
        }
        
        yield return new WaitForSeconds(3);

        foreach (var highlightedSymbol in correctSymbols)
        {
            highlightedSymbol.Highlight(false);
        }
        
        GameState++;
        
        feedbackText.text = "Moving to the " + GameState + 1 +" Riddle";
        
        text.text =  GameState + " Correct";
        Color color = Color.clear;
        if (GameState == 1)
        {
            color = Color.red;
            solutionText.text = "A??";
        }

        if (GameState == 2)
        {
            color = Color.green;
            solutionText.text = "AB?";
        }

        if (GameState > 2)
        {
            color = Color.black;
            solutionText.text = "ABC";
        }

        ParticleSystem.MainModule newMain = bookCoverParticleSystem.main;
        newMain.startColor = new ParticleSystem.MinMaxGradient(color);
        
        yield return new WaitForSeconds(1);
        
        feedbackText.text = "Good luck!";
        
        yield return new WaitForSeconds(1);
        
        feedbackText.text = "";
    }

    private void Update()
    {
        _symbolColumns[1].transform.position = myCamera.transform.position + myCamera.transform.forward;
        
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

       // myDebugText.text = symbol.Index.ToString();
        symbol.SymbolColumn.Next();
    }
}