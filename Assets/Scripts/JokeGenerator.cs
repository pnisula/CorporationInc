using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JokeGenerator : MonoBehaviour
{
    public JokesScriptableObject jokes;
    public TextMeshProUGUI jokesText;
    public GameObject jokeCanvas;
    public bool NotSoFunnyAnymore = true;    
    bool tellJoke = true;
    bool tellPunchLine = false;
    int jokeIndex = 0;
    private AudioSource jokeSounds;
    

    void Start()
    {
        jokeSounds = GetComponent<AudioSource>();
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
        tellJoke = false;
        jokesText.text = jokes.joke[jokeIndex];
        jokeCanvas.SetActive(true);
        yield return new WaitForSeconds(3);
        
        jokeCanvas.SetActive(false);
        yield return new WaitForSeconds(1);

        tellPunchLine = true;
        Debug.Log("Tell Joke: "+jokeIndex);
    }
    IEnumerator NewPunchLine()
    {
        tellPunchLine = false;
        if (NotSoFunnyAnymore)
        {
            Debug.Log("Random punchline");
            jokesText.text = jokes.punchLines[RandomNumber()];
        }
        else
        {
            Debug.Log("Correct punchline");
            jokesText.text = jokes.punchLines[jokeIndex];
        }
        jokeCanvas.SetActive(true);
                
        yield return new WaitForSeconds(3);
        
        Debug.Log("Tell Punch Line: "+jokeIndex);        
        jokeCanvas.SetActive(false);

        jokeSounds.Play();        

        yield return new WaitForSeconds(1);

        if (jokeIndex < jokes.joke.Length - 1)
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
        return Random.Range(0, jokes.joke.Length - 1);        
    }
}
