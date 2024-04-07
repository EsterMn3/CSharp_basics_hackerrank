/*In this challenge, the task is to implement a class called NotesStore. The class will manage a collection of notes, with each note having a state and a name. Valid states for notes are 'completed',
"active', and 'others'. All other states are invalid.
The class must have the following methods:
1. AddNote(state, namel: adds a note with the given name (string) and state (string) to the collection. In addition to that:
﻿﻿If the passed name is empty, then it throws an Exception with the message Name cannot be empty'.
﻿﻿If the passed name is non-empty but the given state is not a valid state for a note, then it throws an Exception with the message
Invalid state (state)
2. GetNotes(state) returns a list of note names with the given state (string) added so far. The names are returned in the order the corresponding notes were added. In addition to that:
if the given state is not a valid note state, then it throws an Exception with the message Invalid state (states
• IF no note is found in this state, it returns an empty list
Note: The state names are case-sensitive.*/

using System;

using System.Collections.Generic;
using System.IO;

namespace Solution
{
    public class Note
    {
        public string state;
        public string name;
    }

    public class NotesStore
    {
        List<Note> notes;
        
        public NotesStore()
        {
            notes = new List<Note>();
        }
        
        public void AddNote(string state, string name)
        {
            if (name.Length == 0)
            {
                throw new Exception("Name cannot be empty");
            }
            else if (!isValid(state))
            {
                throw new Exception($"Invalid state {state}");
            }
            else
            {
                Note note = new Note();
                note.name = name;
                note.state = state;
                notes.Add(note);
            }
        }

        public List<string> GetNotes(string state)
        {
            if (!isValid(state))
            {
                throw new Exception($"Invalid state {state}");
            }

            List<string> noteNames = notes
                .Where(note => note.state == state)
                .Select(note => note.name)
                .ToList();

            return noteNames;
        }

        public bool isValid(string state)
        {
            switch (state)
            {
                case "completed":
                case "active":
                case "others":
                    return true;
                default:
                    return false;
            
        }
    }
    } 

    public class Solution
    {
        public static void Main() 
        {
            var notesStoreObj = new NotesStore();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++) {
                var operationInfo = Console.ReadLine().Split(' ');
                try
                {
                    if (operationInfo[0] == "AddNote")
                        notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
                    else if (operationInfo[0] == "GetNotes")
                    {
                        var result = notesStoreObj.GetNotes(operationInfo[1]);
                        if (result.Count == 0)
                            Console.WriteLine("No Notes");
                        else
                            Console.WriteLine(string.Join(",", result));
                    } else {
                        Console.WriteLine("Invalid Parameter");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}