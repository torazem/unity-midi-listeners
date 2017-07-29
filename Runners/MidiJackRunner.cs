using MidiJack;

namespace MidiListeners
{
    public class MidiJackRunner : MidiRunnerBase
    {
        public void Start()
        {
            ConnectMidiListenerComponents();

            MidiMaster.noteOnDelegate += MidiJackNoteOn;
            MidiMaster.noteOffDelegate += MidiJackNoteOff;
            MidiMaster.knobDelegate += MidiJackKnob;
        }

        private void MidiJackNoteOn(MidiChannel channel, int note, float velocity)
        {
            noteOnDelegate(note, velocity);
        }

        private void MidiJackNoteOff(MidiChannel channel, int note)
        {
            noteOffDelegate(note);
        }

        private void MidiJackKnob(MidiChannel channel, int knobNumber, float knobValue)
        {
            knobDelegate(knobNumber, knobValue);
        }
    }
}
