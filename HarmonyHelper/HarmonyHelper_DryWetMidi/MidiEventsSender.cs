using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;

using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;

namespace HarmonyHelper_DryWetMidi
{
    /// <summary>
    /// https://melanchall.github.io/drywetmidi/articles/devices/Output-device.html
    /// </summary>
    public class MidiEventsSender : IDisposable
    {
        private OutputDevice _outputDevice;
        private bool disposedValue;
        SevenBitNumber VOLUME_PLAY = (SevenBitNumber)127;
        SevenBitNumber VOLUME_ZERO = (SevenBitNumber)0;

        #region Construction
        public MidiEventsSender()
        {
            this.Init();
        }

        void Init()
        {
            const string DEVICE_NAME = "Microsoft GS Wavetable Synth";

            var devices = OutputDevice.GetAll().ToList();
            foreach (var device in devices)
            {
                Debug.WriteLine($"Device: {device.Name}");
            }

            _outputDevice = OutputDevice.GetByName(DEVICE_NAME);
            _outputDevice.EventSent += OnEventSent;
            _outputDevice.PrepareForEventsSending();
        }

        #endregion

        public void Play(Note n)
        {
            var noteOnEvent = new NoteOnEvent(n.ToMidiNoteNumber(), VOLUME_PLAY);
            _outputDevice.SendEvent(noteOnEvent);
        }
        public void Stop(Note n)
        {
            var noteOffEvent = new NoteOffEvent(n.ToMidiNoteNumber(), VOLUME_ZERO);
            _outputDevice.SendEvent(noteOffEvent);
        }

        public void Play(Chord chord)
        {
            try
            {
                foreach (var n in chord.Notes)
                {
                    var noteOnEvent = new NoteOnEvent(n.ToMidiNoteNumber(), VOLUME_PLAY);
                    try
                    {
                        _outputDevice.SendEvent(noteOnEvent);
                    }
                    catch (ObjectDisposedException ex)
                    {
                        throw;
                    }
                    catch (ArgumentNullException ex)
                    {
                        throw;
                    }
                    catch (MidiDeviceException ex)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        var bex = ex.GetBaseException();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                var bex = ex.GetBaseException();
                throw;
            }
        }

        public void Stop(Chord chord)
        {
            foreach (var n in chord.Notes)
            {
                var noteOffEvent = new NoteOffEvent();
                noteOffEvent.NoteNumber = n.ToMidiNoteNumber();
                _outputDevice.SendEvent(noteOffEvent);
            }
        }

        public void TurnAllNotesOff()
        {
            _outputDevice.TurnAllNotesOff();
        }

        private void OnEventSent(object sender, MidiEventSentEventArgs e)
        {
            var midiDevice = (MidiDevice)sender;
            Debug.WriteLine($"Event sent to '{midiDevice.Name}' at {DateTime.Now}: {e.Event}");
            Task.Delay(10).Wait(); 
            new object();
        }

        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _outputDevice?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MidiEventsSender()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }//class
}//ns
