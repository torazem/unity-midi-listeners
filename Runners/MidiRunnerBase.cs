using UnityEngine;

namespace MidiListeners
{
    public class MidiRunnerBase : MonoBehaviour
    {
        public delegate void NoteOnDelegate(int note, float velocity);
        public delegate void NoteOffDelegate(int note);
        public delegate void KnobDelegate(int knobNumber, float knobValue);

        public NoteOnDelegate noteOnDelegate { get; set; }
        public NoteOffDelegate noteOffDelegate { get; set; }
        public KnobDelegate knobDelegate { get; set; }

        protected void ConnectMidiListenerComponents()
        {
            foreach (var component in GetComponents<MidiListener>())
            {
                Debug.LogFormat("Connecting Midi Listener: {0}", component);
                noteOnDelegate += component.NoteOn;
                noteOffDelegate += component.NoteOff;
                knobDelegate += component.Knob;
            }
        }
    }
}