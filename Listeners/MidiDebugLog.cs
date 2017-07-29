using System;
using UnityEngine;

namespace MidiListeners
{
    public class MidiDebugLog : MidiListener
    {
        public override void NoteOn(int note, float velocity)
        {
            if (velocity == 0) return;
            Debug.Log(string.Format("ON: Note {0}, Velocity {1}", note, velocity));
        }

        public override void NoteOff(int note)
        {
            Debug.Log(string.Format("OFF: Note {0}", note));
        }

        public override void Knob(int knobNumber, float knobValue)
        {
            Debug.Log(string.Format("KNOB: Knob {0}, Value {1}", knobNumber, knobValue));
        }
    }
}
