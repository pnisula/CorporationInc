using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JokeGenerator : MonoBehaviour
{
    public string[] jokesArray;
    public string[] punchlinesArray;

    public JokesScriptableObject jokes;
    public TextMeshProUGUI jokesText;
    public GameObject jokeCanvas;
    public bool NotSoFunnyAnymore = true;    
    bool tellJoke = true;
    bool tellPunchLine = false;
    int jokeIndex = 0;
    private AudioSource jokeSounds;
    public AudioSource booing;
    public AudioSource cheer;
    bool funnyjoke;
    private Animator jokeAnimator;

    void Start()
    {
        funnyjoke = true;
        jokeSounds = GetComponent<AudioSource>();
        jokeAnimator = GameObject.FindGameObjectWithTag("Comedian").GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(tellJoke)
            StartCoroutine(NewJoke());
        if(tellPunchLine)
            StartCoroutine(NewPunchLine());        
    }

    IEnumerator NewJoke()
    {
        TellJoke();
        tellJoke = false;        
        jokesText.text = jokesArray[jokeIndex];
        jokeCanvas.SetActive(true);
        yield return new WaitForSeconds(4);
        
        jokeCanvas.SetActive(false);
        yield return new WaitForSeconds(3);

        tellPunchLine = true;
        Debug.Log("Tell Joke: "+jokeIndex);
    }
    IEnumerator NewPunchLine()
    {
        TellPunchline();
        tellPunchLine = false;
        if (NotSoFunnyAnymore)
        {
            Debug.Log("Random punchline");
            jokesText.text = punchlinesArray[RandomNumber()];
            funnyjoke = false;
        }
        else
        {
            Debug.Log("Correct punchline");
            jokesText.text = punchlinesArray[jokeIndex];
        }
        jokeCanvas.SetActive(true);
                
        yield return new WaitForSeconds(3);
        
        Debug.Log("Tell Punch Line: "+jokeIndex);        
        jokeCanvas.SetActive(false);
        ReadBook();
        jokeSounds.Play();
        if (funnyjoke)
        {
            cheer.Play();
        }
        else
        {
            booing.Play();
        }
        yield return new WaitForSeconds(6);

        if (jokeIndex < punchlinesArray.Length - 1)
        {
            jokeIndex++;
        }
        else
        {
            jokeIndex = 0;
        }
        tellJoke = true;
    }
    public int RandomNumber()
    {
        return Random.Range(0, punchlinesArray.Length - 1);        
    }
    public void TellJoke()
    {
        jokeAnimator.SetBool("TellingPunchline", false);
        jokeAnimator.SetBool("TellingJoke", true);
        jokeAnimator.SetBool("ReadingBook", false);
    }
    public void TellPunchline()
    {
        jokeAnimator.SetBool("TellingPunchline", true);
        jokeAnimator.SetBool("TellingJoke", false);
        jokeAnimator.SetBool("ReadingBook", false);
    }
    public void ReadBook()
    {
        jokeAnimator.SetBool("TellingPunchline", false);
        jokeAnimator.SetBool("TellingJoke", false);
        jokeAnimator.SetBool("ReadingBook", true);
    }
}
