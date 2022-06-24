using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Commands", menuName = "CommandsObj")]
public class Commands : ScriptableObject
{
    public Command[] commands;

    [System.Serializable]
    public class Command
    {
        public string response;
        public string[] inputs;

        public (string, string[]) GetAllInfo()
        {
            return (response, inputs);
        }
    }

    public Command[] GetAllCommands()
    {
        return commands;
    }
}
