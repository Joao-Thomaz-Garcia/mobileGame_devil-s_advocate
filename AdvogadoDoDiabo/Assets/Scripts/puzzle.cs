using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzle : MonoBehaviour
{
    public dialogueSystem DialogS;

    public bool[] buttonBool = new bool[3];

    int correctCounter = 0;

    public Image[] spriteSwitch1 = new Image[2];
    public Image[] spriteSwitch2 = new Image[2];
    public Image[] spriteSwitch3 = new Image[2];

    private void Update()
    {

    }

    public void Switch1()
    {
        buttonBool[0] = !buttonBool[0];

        Sprite temporary = spriteSwitch1[0].sprite;

        spriteSwitch1[0].sprite = spriteSwitch1[1].sprite;
        spriteSwitch1[1].sprite = temporary;
    }
    public void Switch2()
    {
        buttonBool[1] = !buttonBool[1];


        Sprite temporary = spriteSwitch2[0].sprite;

        spriteSwitch2[0].sprite = spriteSwitch2[1].sprite;
        spriteSwitch2[1].sprite = temporary;
    }
    public void Switch3()
    {
        buttonBool[2] = !buttonBool[2];


        Sprite temporary = spriteSwitch3[0].sprite;

        spriteSwitch3[0].sprite = spriteSwitch3[1].sprite;
        spriteSwitch3[1].sprite = temporary;
    }

    public void Confirmation1()
    {
        foreach (bool BB in buttonBool)
        {
            if (BB == true)
                correctCounter++;

        }

        if (correctCounter >= 3)
        {
            DialogS.puzzleN1(true);
            correctCounter = 0;
        }
        else
        {
            DialogS.puzzleN1(false);
            //Executar frase de erro
        }
    }
    public void Confirmation2()
    {
        foreach (bool BB in buttonBool)
        {
            if (BB == true)
                correctCounter++;

        }

        if (correctCounter >= 3)
        {
            DialogS.puzzleN2(true);
            correctCounter = 0;
        }
        else
        {
            DialogS.puzzleN2(false);
            //Executar frase de erro
        }
    }
    public void Confirmation3()
    {
        foreach (bool BB in buttonBool)
        {
            if (BB == true)
                correctCounter++;

        }

        if (correctCounter >= 3)
        {
            print("if");

            DialogS.puzzleN3(true);
            correctCounter = 0;
        }
        else
        {
            print("else");
            DialogS.puzzleN3(false);
            //Executar frase de erro
        }
    }
}
