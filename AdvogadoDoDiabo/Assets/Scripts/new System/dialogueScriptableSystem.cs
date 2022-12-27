using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueScriptableSystem : MonoBehaviour
{
    /// <summary>
    /// MUDAR MODO DE IDIOMAS
    /// AJUSTAR PARA OS DIALOGOS FUNCIONAREM
    /// FINALIZAR DIALOGOS EM X PONTO E ABRIR PUZZLE
    /// ADICIONAR DIALOGOS DE ERRO E CONTINUA��O MESMO QUE VOC� DEFENDA ERRADO
    /// MOSTRAR LETRA POR LETRA(Posso fazer com uma coroutine) E SE APERTAR ESPA�O TUDO APARECE DIRETO
    /// ADICIONAR CR�DITOS
    /// 
    /// </summary>
    public dialogue dialog;

    public string LastDialog;
    public bool isPlaying = true;

    public int dialogueRange;

    void Start()
    {
        StartCoroutine(DialogueCoroutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (isPlaying)
                dialogueRange++;
            else if (dialogueRange - 1 > dialog.CharDialogues.Count)
            {
                print("END");
            }
            else
            {
                dialogueRange++;
                StartCoroutine(DialogueCoroutine());
            }
        }
    }

    private IEnumerator DialogueCoroutine()
    {
        isPlaying = true;
        while (isPlaying)
        {
            if (dialog.CharDialogues[dialogueRange].Equals("**"))
            {
                isPlaying = false;
                yield break;
            }

            print(dialog.CharDialogues[dialogueRange].Substring(0, dialog.CharDialogues[dialogueRange].IndexOf("*")) +
                "\n " + dialog.CharDialogues[dialogueRange].Substring(dialog.CharDialogues[dialogueRange].IndexOf("*") + 2));
            yield return new WaitForEndOfFrame();
        }
        yield break;
    }
}
