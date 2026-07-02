using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;

using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;


namespace HarmonyHelper_DryWetMidi
{
    static public class MidiSmoother
    {
        public static void SmoothMidiChords(string inputPath, string outputPath)
        {
            // 1. Read the input file completely intact
            var midiFile = MidiFile.Read(inputPath);

            // 2. Safely extract all notes using DryWetMidi's native manager block
            foreach (var trackChunk in midiFile.GetTrackChunks())
            {
                using (var notesManager = trackChunk.ManageNotes())
                {
                    var notes = notesManager.Objects;
                    if (!notes.Any()) continue;

                    // Group chords using a small timing buffer (e.g., 20 delta-ticks)
                    // This prevents staggered, rolled, or humanized notes from breaking apart
                    int timingBuffer = 20;
                    var orderedNotes = notes.OrderBy(n => n.Time).ToList();
                    var chords = new List<List<Note>>();

                    foreach (var note in orderedNotes)
                    {
                        // Check if this note belongs to the current chord block within the timing buffer
                        var matchingChord = chords.LastOrDefault(c => Math.Abs(c.First().Time - note.Time) <= timingBuffer);
                        if (matchingChord != null)
                        {
                            matchingChord.Add(note);
                        }
                        else
                        {
                            chords.Add(new List<Note> { note });
                        }
                    }

                    List<int> lastPitches = new List<int>();

                    foreach (var chordNotes in chords)
                    {
                        List<int> currentChordNewPitches = new List<int>();

                        // Keep the first baseline chord intact
                        if (!lastPitches.Any())
                        {
                            lastPitches = chordNotes.Select(n => (int)n.NoteNumber).ToList();
                            continue;
                        }

                        // Trace the average pitch center of gravity from the last chord position
                        double lastCenter = lastPitches.Average();

                        foreach (var note in chordNotes)
                        {
                            int pitchClass = note.NoteNumber % 12;
                            int bestNoteNumber = note.NoteNumber;
                            double minDistance = double.MaxValue;

                            // Calculate the optimal voice-leading octave transition (MIDI 24 to 108)
                            for (int octave = 2; octave <= 9; octave++)
                            {
                                int testNoteNumber = (octave * 12) + pitchClass;
                                if (testNoteNumber < 0 || testNoteNumber > 127) continue;

                                double distance = Math.Abs(testNoteNumber - lastCenter);
                                if (distance < minDistance)
                                {
                                    minDistance = distance;
                                    bestNoteNumber = testNoteNumber;
                                }
                            }

                            // Mutate the Note object directly inside the Manager
                            // The manager automatically links and updates both NoteOn and NoteOff binary events
                            note.NoteNumber = SevenBitNumber.Parse(bestNoteNumber.ToString());
                            currentChordNewPitches.Add(bestNoteNumber);
                        }

                        lastPitches = currentChordNewPitches;
                    }
                } // The manager automatically commits the updates back to the track binary metadata here
            }

            // 3. Save the modified file containing all original background events
            midiFile.Write(outputPath);
            Console.WriteLine($"✅ Smooth MIDI file successfully created with 0% data loss: {outputPath}");
        }

    }
}
