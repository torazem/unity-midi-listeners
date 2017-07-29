using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using System;

namespace MidiListeners
{
    public class MidiKeyboardRunner : MidiRunnerBase
    {
        public int minOctave = 1;
        public int maxOctave = 8;

        [Tooltip("Between 0 and 1")]
        public float minVelocity = 0.1f;
        [Tooltip("Between 0 and 1")]
        public float maxVelocity = 0.9f;
        public float velocityChange = 0.1f;

        private float keyboardVelocity = 0.5f;
        private int keyboardOctave = 4;

        public void Start()
        {
            ConnectMidiListenerComponents();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Plus) ||
                Input.GetKeyDown(KeyCode.KeypadPlus) ||
                Input.GetKeyDown(KeyCode.UpArrow))
            {
                ChangeVelocity(1);
            }

            if (Input.GetKeyDown(KeyCode.Minus) ||
                Input.GetKeyDown(KeyCode.KeypadMinus) ||
                Input.GetKeyDown(KeyCode.DownArrow))
            {
                ChangeVelocity(-1);
            }

            if (Input.GetKeyDown(KeyCode.PageUp) ||
                Input.GetKeyDown(KeyCode.RightArrow))
            {
                ChangeOctave(1);
            }

            if (Input.GetKeyDown(KeyCode.PageDown) ||
                Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ChangeOctave(-1);
            }

            HandleKeyboardNoteEvent(NotePitchType.C, KeyCode.Alpha1, KeyCode.Keypad1);
            HandleKeyboardNoteEvent(NotePitchType.D, KeyCode.Alpha2, KeyCode.Keypad2);
            HandleKeyboardNoteEvent(NotePitchType.E, KeyCode.Alpha3, KeyCode.Keypad3);
            HandleKeyboardNoteEvent(NotePitchType.F, KeyCode.Alpha4, KeyCode.Keypad4);
            HandleKeyboardNoteEvent(NotePitchType.G, KeyCode.Alpha5, KeyCode.Keypad5);
            HandleKeyboardNoteEvent(NotePitchType.A, KeyCode.Alpha6, KeyCode.Keypad6);
            HandleKeyboardNoteEvent(NotePitchType.B, KeyCode.Alpha7, KeyCode.Keypad7);
        }

        private void HandleKeyboardNoteEvent(NotePitchType pitch, KeyCode key, KeyCode altKey)
        {
            var note = GetMidiNoteNumber(pitch, keyboardOctave);

            if (Input.GetKeyDown(key) || Input.GetKeyDown(altKey))
            {
                noteOnDelegate(note, keyboardVelocity);
            }

            if (Input.GetKeyUp(key) || Input.GetKeyUp(altKey))
            {
                noteOffDelegate(note);
            }
        }

        private void ChangeOctave(int change)
        {
            keyboardOctave += change;
            if (keyboardOctave < minOctave) keyboardOctave = minOctave;
            if (keyboardOctave > maxOctave) keyboardOctave = maxOctave;
        }

        private void ChangeVelocity(int change)
        {
            keyboardVelocity += change * velocityChange;
            if (keyboardVelocity < minVelocity) keyboardVelocity = minVelocity;
            if (keyboardVelocity > maxVelocity) keyboardVelocity = maxVelocity;
        }

        private int GetMidiNoteNumber(NotePitchType pitch, int octave = 4)
        {
            return (octave + 1) * 12 + (int)pitch;
        }
    }
}
