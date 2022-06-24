using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class CommandInput : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Commands commands;
    [SerializeField] TextMeshProUGUI linesContent;
    [SerializeField] TextMeshProUGUI linesText;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioSourceMain;

    [SerializeField] List<string> commandLines;

    void Update()
    {
        if(Input.anyKeyDown)
        {
            audioSourceMain.pitch = Random.Range(0.95f, 1.2f);
        }
    }

    /* once the Player presses Enter or deselects the Input Field while
     * it is currently selected, run Enter() which adds a new line on the 
     * lineText and adds the content of which you just typed to lineContent.
     */

    public void Enter(string playerInput)
    {
        if(playerInput != "")
        {
            commandLines.Add(playerInput);
            var commandList = commands.GetAllCommands();
            string spaceForLine = new string(' ', commandLines.Count.ToString().Length - 1);

            linesText.text += "\n" + commandLines.Count + ".|";
            linesContent.text += "\n" + spaceForLine + commandLines[commandLines.Count - 1];

            /* loops through all the Command(s), a Command just
             * contains one response (string) and multiple
             * inputs (string[]).
             */

            for (int i = 0; i < commands.GetAllCommands().Length; i++)
            {
                foreach (string input in commandList[i].inputs) // loops through all of the inputs
                {
                    if (input == playerInput.Trim()) // if one of the inputs match what the player typed, respond
                    {
                        commandLines.Add(commandList[i].response);

                        linesText.text += "\n";
                        linesContent.text += "\n<color=#00FF00><b>" + spaceForLine + commandLines[commandLines.Count - 1] + "</color=#00FF00></b>";

                        audioSource.pitch = Random.Range(0.9f, 1.2f);
                        audioSource.Play();

                        break;
                    }
                }
            }
        }
    }
    
    // just clears the Input Field.
    public void Clear()
    {
        inputField.text = "";
    }
}
