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
    //Criar um json para armazenar todos os dialogos de forma que não precise startar sempre de novo.

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
        Dialog.Add(new Dialoguer("Cramunhão", " Mas vejam só que dia bonito, calor por toda parte e o melhor de tudo, as almas estão limpando meu tridente."));
        Dialog.Add(new Dialoguer("Cramunhão", " Mas... peraí...Ah nãããão hoje é dia do julgamento daqueles Maluco lá. Bom fazer o que né, pelo menos só vou ter que ficar sentado na minha cadeira fingindo que eu tô ligando pra essa bagaça, de qualquer forma vão ter que ficar e ativar o modo chinês traycing pra trabalhar pra mim hahahaha."));

        Dialog.Add(new Dialoguer("Ademogado", " Pois é digníssimo, mas dessa vez eu levarei esses réus comigo e provarei que eles não cometeram crimes tão graves quanto o senhor pensa."));

        Dialog.Add(new Dialoguer("Cramunhão", " Caramba, mas tu já chegou aqui fia da mãe?"));

        Dialog.Add(new Dialoguer("Ademogado", " De fato vossa capetância"));

        Dialog.Add(new Dialoguer("Anjinho", " Eu também já estou aqui ô Pomba Gira, mas chega de ficar no lero vai, às 14:30 o E-sports lá do céu vai jogar a final do League of Angels."));
        Dialog.Add(new Dialoguer("Anjinho", " Bom vamos chamar então o primeiro réu, ele é o famoso cavaleiro templário, acusado de traição e deserção pela ordem dos cavaleiros templários, em outras palavras o famoso arregão, mas agora que ele já está aqui, podemos começar."));

        Dialog.Add(new Dialoguer("Cavaleiro", " Meus amigos eu prometo e juro pela ordem a que pertenço e que por sinal me odeia que eu sou inocente."));

        Dialog.Add(new Dialoguer("Anjinho", " Muito bem, senhor ademogado nos diga então por que deveríamos deixar esse cavaleiro bunda mole subir ao céu?"));
        //8
        //INSERIR PUZZLE 1

        Dialog.Add(new Dialoguer("Anjinho", " Puts aí é sacanagem ein men, suave pode subir no Celtangelical do pai."));
        Dialog.Add(new Dialoguer("Anjinho", " Muito bem senhor ademogado espero que esteja preparado para defender esse aqui porque vai ser pedrada pra tu."));
        Dialog.Add(new Dialoguer("Anjinho", " Esse aqui é o tenente Nunes, ele foi acusado de liberar os bandidos que foram apreendidos com drogas em troca de receber 1KG de maconha para fazer uma receita que ele alegou ser Brisanha um tipo de lasanha de maconheiro."));

        Dialog.Add(new Dialoguer("Puliça", " Eu sou inocente quem liberou os cria foi o aspira!"));

        Dialog.Add(new Dialoguer("Anjinho", " Boa sorte senhor ademogado."));
        //13
        //ISERIR PUZZLE 2

        Dialog.Add(new Dialoguer("Anjinho", " Ah pode crer, os escrivães devem ter cometido um erro então, mals ae."));
        Dialog.Add(new Dialoguer("Anjinho", " Ah seu miserável eu não sei como você faz isso kkkk, mas esse último aqui vai ser quase impossível de defender."));
        Dialog.Add(new Dialoguer("Anjinho", " O nome do último réu é Benedito, ele era um ortopedista que sempre receitava curas milagrosas para escoliose em sua clínica que eram baseadas em ervas indígenas das quais eles têm conhecimento por vir de família nativa... sei, deixa os índios saberem disso."));

        Dialog.Add(new Dialoguer("Doutor", " Eu deixei de ser médico há muito tempo, agora eu decidi me expressar e seguir o ramo de coach!"));

        Dialog.Add(new Dialoguer("Anjinho", " Nem preciso dizer que essas curas eram ridículas e nem funcionavam, mas a questão é que com essas receitas ele tirou muito dinheiro de seus pacientes em vida, me diga Ademogado por que esse homem não merece queimar nas profundezas do inferno ?"));

        //18
        //INSERIR PUZZLE 3

        Dialog.Add(new Dialoguer("Anjinho", " Entendo, isso sobrepõe todas essas acusações do réu, é impressionante que o senhor tenha conseguido defender essa galera aí e nenhum tenha ficado com o Tinhoso ali kkkk, sendo assim vocês três irão subir comigo rapeize."));
        Dialog.Add(new Dialoguer("Cramunhão", " Mas que Mer#@ ein, fez eu perder todo esse tempo da minha vida para um julgamento que ninguém se ferrou, ceis tão de brincadeira né pô, ah quer saber faz o que você quiser Anjinho, tô nem aí, vou lá gerenciar o purgatório que eu ganho mais...”"));


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
            dialogueText.text = "Eu não entendi uma palavra do que você falou, o cavaleiro fica no colo do capeta";

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
            dialogueText.text = "Virou maconheiro também fião? Não vai subi ninguém!";

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
            dialogueText.text = "Essa foi boa, o médico vai assar mais que Chester no Natal agora dotô, boa estadia no inferno!";

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

    //Configurar o momento de troca para o puzzle, além da continuação dos dialogos

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
