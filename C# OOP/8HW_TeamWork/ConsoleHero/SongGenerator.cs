using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHero
{
    public static class SongGenerator
    {
        public static Note[] GetNotes(string pathSong) // @"..\..\SongTextNazadNazadMomeKalino.txt"
        {
            int countOfNotes = 0;
            List<string> noteLines = new List<string>();
            //equal to the lines of the text file in the end because on every single line there is one note 
            try
            {
                StreamReader reader = new StreamReader(pathSong);
                //File successfully opened
                using (reader)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        countOfNotes++;
                        noteLines.Add(line);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("File with notes not found!");
            }

            Note[] notes = new Note[countOfNotes];
            for (int i = 0; i < notes.Length; i++)
            {
                NoteDurationEnum duration;
                NoteFrequencyToneEnum tone;
                string[] tokensNotes = noteLines[i].Split(' ');
                #region switch note
                switch (tokensNotes[0])
                {
                    case "a":
                    case "A":
                        {
                            tone = NoteFrequencyToneEnum.A;
                            break;
                        }
                    case "b":
                    case "B":
                        {
                            tone = NoteFrequencyToneEnum.B;
                            break;
                        }
                    case "c":
                    case "C":
                        {
                            tone = NoteFrequencyToneEnum.C;
                            break;
                        }
                    case "d":
                    case "D":
                        {
                            tone = NoteFrequencyToneEnum.D;
                            break;
                        }
                    case "e":
                    case "E":
                        {
                            tone = NoteFrequencyToneEnum.E;
                            break;
                        }

                    case "f":
                    case "F": 
                        {
                            tone = NoteFrequencyToneEnum.F;
                            break;
                        }
                    case "g":
                    case "G":
                        {
                            tone = NoteFrequencyToneEnum.G;
                            break;
                        }
                    case "a#":
                    case "A#":
                        {
                            tone = NoteFrequencyToneEnum.Asharp;
                            break;
                        }
                    case "A4":
                    case "a4": 
                        {
                            tone = NoteFrequencyToneEnum.A4;
                            break;
                        }
                        //B# is actually C :)
                    case "c#":
                    case "C#":
                        {
                            tone = NoteFrequencyToneEnum.Csharp;
                            break;
                        }
                    case "d#":
                    case "D#":
                        {
                            tone = NoteFrequencyToneEnum.Dsharp;
                            break;
                        }
                        //E# is F
                    case "f#":
                    case "F#": 
                        {
                            tone = NoteFrequencyToneEnum.Fsharp;
                            break;
                        }
                    case "g#":
                    case "G#":
                        {
                            tone = NoteFrequencyToneEnum.Gsharp;
                            break;
                        }
                    case "rest":
                    case "Rest":
                        {
                            tone = NoteFrequencyToneEnum.Rest;
                            break;
                        }
                    default:
                        {
                            throw new NoteConsoleHeroException("Invalid note!");
                            break;
                        }
                }
                #endregion
                #region switch duration
                switch (tokensNotes[1])
                {
                    case "1":
                        {
                            duration = NoteDurationEnum.Whole;
                            break;
                        }
                    case "1/2": 
                        {
                            duration = NoteDurationEnum.Half;
                            break;
                        }
                    case "1/4":
                        {
                            duration = NoteDurationEnum.Quarter;
                            break;
                        }
                    case "1/8":
                        {
                            duration = NoteDurationEnum.Eighth;
                            break;
                        }
                    case "1/16":
                        {
                            duration = NoteDurationEnum.Sixteenth;
                            break;
                        }
                    default: 
                        {
                            throw new NoteConsoleHeroException("Invalid duration!");
                            break;
                        }
                }
                #endregion
                notes[i] = new Note(tone,duration);
            }
            return notes;
        }
    }
}
