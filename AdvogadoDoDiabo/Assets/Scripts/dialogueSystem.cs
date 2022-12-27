using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dialogueSystem : MonoBehaviour
{
    public bool isOver = false;

    public GameObject dialogueEmpty;
    public GameObject[] puzzles;

    public Text nameText;
    public Text dialogueText;

    public int i = 0;

    string lastDialogue;
    public List<Dialoguer> Dialog = new List<Dialoguer>();
    //Criar um json para armazenar todos os dialogos de forma que n�o precise startar sempre de novo.

    public List<Image> Characters = new List<Image>();


    public bool[] buttonBool = new bool[3];
    public int correctQuestions = 0;


    private void Start()
    {
        DialogueConfig();
        StartCoroutine("KnightSentence");
    }

    private void Update()
    {
        ManageCharacters();
        if (!isOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) && dialogueEmpty.activeSelf == true && i <= 18 || Input.GetTouch(0).phase == TouchPhase.Began && dialogueEmpty.activeSelf == true && i <= 18)
                i++;
        }
        else if(isOver)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetTouch(0).phase == TouchPhase.Began))
            {
                SceneManager.LoadScene(0);
            }
        }


    }

    public void DialogueConfig()
    {
        Dialog.Add(new Dialoguer("Cramunh�o", " Mas vejam s� que dia bonito, calor por toda parte e o melhor de tudo, as almas est�o limpando meu tridente."));
        Dialog.Add(new Dialoguer("Cramunh�o", " Mas... pera�...Ah n����o hoje � dia do julgamento daqueles Maluco l�. Bom fazer o que n�, pelo menos s� vou ter que ficar sentado na minha cadeira fingindo que eu t� ligando pra essa baga�a, de qualquer forma v�o ter que ficar e ativar o modo chin�s traycing pra trabalhar pra mim hahahaha."));

        Dialog.Add(new Dialoguer("Ademogado", " Pois � dign�ssimo, mas dessa vez eu levarei esses r�us comigo e provarei que eles n�o cometeram crimes t�o graves quanto o senhor pensa."));

        Dialog.Add(new Dialoguer("Cramunh�o", " Caramba, mas tu j� chegou aqui fia da m�e?"));

        Dialog.Add(new Dialoguer("Ademogado", " De fato vossa capet�ncia"));

        Dialog.Add(new Dialoguer("Anjinho", " Eu tamb�m j� estou aqui � Pomba Gira, mas chega de ficar no lero vai, �s 14:30 o E-sports l� do c�u vai jogar a final do League of Angels."));
        Dialog.Add(new Dialoguer("Anjinho", " Bom vamos chamar ent�o o primeiro r�u, ele � o famoso cavaleiro templ�rio, acusado de trai��o e deser��o pela ordem dos cavaleiros templ�rios, em outras palavras o famoso arreg�o, mas agora que ele j� est� aqui, podemos come�ar."));

        Dialog.Add(new Dialoguer("Cavaleiro", " Meus amigos eu prometo e juro pela ordem a que perten�o e que por sinal me odeia que eu sou inocente."));

        Dialog.Add(new Dialoguer("Anjinho", " Muito bem, senhor ademogado nos diga ent�o por que dever�amos deixar esse cavaleiro bunda mole subir ao c�u?"));
        //8
        //INSERIR PUZZLE 1

        Dialog.Add(new Dialoguer("Anjinho", " Puts a� � sacanagem ein men, suave pode subir no Celtangelical do pai."));
        Dialog.Add(new Dialoguer("Anjinho", " Muito bem senhor ademogado espero que esteja preparado para defender esse aqui porque vai ser pedrada pra tu."));
        Dialog.Add(new Dialoguer("Anjinho", " Esse aqui � o tenente Nunes, ele foi acusado de liberar os bandidos que foram apreendidos com drogas em troca de receber 1KG de maconha para fazer uma receita que ele alegou ser Brisanha um tipo de lasanha de maconheiro."));

        Dialog.Add(new Dialoguer("Puli�a", " Eu sou inocente quem liberou os cria foi o aspira!"));

        Dialog.Add(new Dialoguer("Anjinho", " Boa sorte senhor ademogado."));
        //13
        //ISERIR PUZZLE 2

        Dialog.Add(new Dialoguer("Anjinho", " Ah pode crer, os escriv�es devem ter cometido um erro ent�o, mals ae."));
        Dialog.Add(new Dialoguer("Anjinho", " Ah seu miser�vel eu n�o sei como voc� faz isso kkkk, mas esse �ltimo aqui vai ser quase imposs�vel de defender."));
        Dialog.Add(new Dialoguer("Anjinho", " O nome do �ltimo r�u � Benedito, ele era um ortopedista que sempre receitava curas milagrosas para escoliose em sua cl�nica que eram baseadas em ervas ind�genas das quais eles t�m conhecimento por vir de fam�lia nativa... sei, deixa os �ndios saberem disso."));

        Dialog.Add(new Dialoguer("Doutor", " Eu deixei de ser m�dico h� muito tempo, agora eu decidi me expressar e seguir o ramo de coach!"));

        Dialog.Add(new Dialoguer("Anjinho", " Nem preciso dizer que essas curas eram rid�culas e nem funcionavam, mas a quest�o � que com essas receitas ele tirou muito dinheiro de seus pacientes em vida, me diga Ademogado por que esse homem n�o merece queimar nas profundezas do inferno ?"));

        //18
        //INSERIR PUZZLE 3

        Dialog.Add(new Dialoguer("Anjinho", " Entendo, isso sobrep�e todas essas acusa��es do r�u, � impressionante que o senhor tenha conseguido defender essa galera a� e nenhum tenha ficado com o Tinhoso ali kkkk, sendo assim voc�s tr�s ir�o subir comigo rapeize."));
        Dialog.Add(new Dialoguer("Cramunh�o", " Mas que Mer#@ ein, fez eu perder todo esse tempo da minha vida para um julgamento que ningu�m se ferrou, ceis t�o de brincadeira n� p�, ah quer saber faz o que voc� quiser Anjinho, t� nem a�, vou l� gerenciar o purgat�rio que eu ganho mais...�"));


    }

    //Knight
    IEnumerator KnightSentence()
    {
        while (i < 8)
        {

            if (!(lastDialogue == Dialog[i].CharacterDialogue))
            {
                nameText.text = Dialog[i].CharacterName;
                dialogueText.text = Dialog[i].CharacterDialogue;
                //print(Dialog[i].CharacterName + "\n" + Dialog[i].CharacterDialogue);
                lastDialogue = Dialog[i].CharacterDialogue;
            }
            yield return new WaitForEndOfFrame();
        }
        dialogueEmpty.SetActive(false);
        puzzles[0].SetActive(true);

        yield break;
    }

    public void puzzleN1(bool isCorrect)
    {
        if (isCorrect == true)
        {
            dialogueEmpty.SetActive(true);
            puzzles[0].SetActive(false);

            i++;
            StartCoroutine("PoliceSentence");
        }
        else if (isCorrect == false)
        {
            dialogueEmpty.SetActive(true);
            puzzles[0].SetActive(false);

            nameText.text = "Anjinho";
            dialogueText.text = "Eu n�o entendi uma palavra do que voc� falou, o cavaleiro fica no colo do capeta";

            isOver = true;
        }
    }

    //Police
    IEnumerator PoliceSentence()
    {

        while (i < 13)
        {

            if (!(lastDialogue == Dialog[i].CharacterDialogue))
            {
                nameText.text = Dialog[i].CharacterName;
                dialogueText.text = Dialog[i].CharacterDialogue;
                lastDialogue = Dialog[i].CharacterDialogue;
            }
            yield return new WaitForEndOfFrame();
        }
        dialogueEmpty.SetActive(false);
        puzzles[1].SetActive(true);

        yield break;
    }

    public void puzzleN2(bool isCorrect)
    {
        if (isCorrect == true)
        {
            dialogueEmpty.SetActive(true);
            puzzles[1].SetActive(false);

            i++;
            StartCoroutine("DoctorSentence");
        }
        else if (isCorrect == false)
        {
            dialogueEmpty.SetActive(true);
            puzzles[1].SetActive(false);

            nameText.text = "Anjinho";
            dialogueText.text = "Virou maconheiro tamb�m fi�o? N�o vai subi ningu�m!";

            isOver = true;
        }
    }

    //Doctor
    IEnumerator DoctorSentence()
    {
        while (i < 19)
        {

            if (!(lastDialogue == Dialog[i].CharacterDialogue))
            {
                nameText.text = Dialog[i].CharacterName;
                dialogueText.text = Dialog[i].CharacterDialogue;
                lastDialogue = Dialog[i].CharacterDialogue;
            }
            yield return new WaitForEndOfFrame();
        }
        dialogueEmpty.SetActive(false);
        puzzles[2].SetActive(true);

        yield break;
    }

    public void puzzleN3(bool isCorrect)
    {
        if (isCorrect == true)
        {
            dialogueEmpty.SetActive(true);
            puzzles[2].SetActive(false);

            i++;
            StartCoroutine("Ending");
        }
        else if (isCorrect == false)
        {
            dialogueEmpty.SetActive(true);
            puzzles[2].SetActive(false);

            nameText.text = "Anjinho";
            dialogueText.text = "Essa foi boa, o m�dico vai assar mais que Chester no Natal agora dot�, boa estadia no inferno!";

            isOver = true;
        }
    }

    IEnumerator Ending()
    {
        while (i < Dialog.Count)
        {

            if (!(lastDialogue == Dialog[i].CharacterDialogue))
            {
                nameText.text = Dialog[i].CharacterName;
                dialogueText.text = Dialog[i].CharacterDialogue;
                lastDialogue = Dialog[i].CharacterDialogue;
            }
            yield return new WaitForEndOfFrame();
        }

        yield break;
    }

    //Configurar o momento de troca para o puzzle, al�m da continua��o dos dialogos

    void ManageCharacters()
    {
        foreach (Image charImage in Characters)
        {
            //if (charImage.name == Dialog[i].CharacterName)
            if (charImage.name == nameText.text)
                charImage.gameObject.SetActive(true);
            else
                charImage.gameObject.SetActive(false);
        }
    }

}

public class Dialoguer
{
    public Dialoguer(string CharacterName, string CharacterDialogue)
    {
        this.CharacterName = CharacterName;
        this.CharacterDialogue = CharacterDialogue;
    }

    public string CharacterDialogue;
    public string CharacterName;

}
