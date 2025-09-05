using System;
using UnityEngine;
using UnityEngine.UI;

public class ClueManager : MonoBehaviour
{
    //делегаты
    public static Action<string> ClueEvent;
    public static Action disableClueEvent;

    [SerializeField] private Text textClue;

    private Animator anim;
    private int activeClue;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        ClueEvent += DisplayClue;
        disableClueEvent += DisableClue;
    }

    private void OnDisable()
    {
        ClueEvent -= DisplayClue;
        disableClueEvent -= DisableClue;
    }

    private void DisplayClue(string text)
    {
        textClue.text = text;
        anim.SetInteger("StateIdle", ++activeClue);
    }

    private void DisableClue()
    {
        anim.SetInteger("StateIdle", --activeClue);
    }
}
