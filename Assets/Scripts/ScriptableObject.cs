using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/JokesScriptableObject", order = 1)]
public class JokesScriptableObject : ScriptableObject
{
    public string[] joke;
    public string[] punchLines;
}