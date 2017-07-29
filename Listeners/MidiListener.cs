using MidiJack;
using UnityEngine;

namespace MidiListeners
{
    public class MidiListener : MonoBehaviour
    {
        public virtual void NoteOn(int note, float velocity)
        {
        }

        public virtual void NoteOff(int note)
        {
        }

        public virtual void Knob(int knobNumber, float knobValue)
        {
        }
    }
}