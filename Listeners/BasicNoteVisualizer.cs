using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MidiListeners
{
    public class BasicNoteVisualizer : PianoMidiListener
    {
        public GameObject notePrefab;
        public float minNoteSize = 0.05f;
        public float maxNoteSize = 0.4f;
        public float noteGap = 0.3f;
        public Vector2 noteCenter;

        private IDictionary<int, float> notePositions;
        private IDictionary<int, GameObject> noteInstances;

        public void Start()
        {
            notePositions = new Dictionary<int, float>();
            noteInstances = new Dictionary<int, GameObject>();

            SetNotePositions();
        }

        public override void NoteOn(int note, float velocity)
        {
            base.NoteOn(note, velocity);
            SpawnNote(note, velocity);
        }

        public override void NoteOff(int note)
        {
            base.NoteOff(note);
            DestroyNote(note);
        }

        private void SetNotePositions()
        {
            float p = -1.5f;
            for (int i = 60; i <= 72; i++)
            {
                notePositions.Add(i, p);
                p += noteGap;
            }
        }

        private void SpawnNote(int note, float velocity)
        {
            if (!notePositions.ContainsKey(note))
            {
                Debug.LogWarningFormat("Note {0} doesn't have a position set", note);
                return;
            }

            if (noteInstances.ContainsKey(note))
            {
                DestroyNote(note);
            }

            var position = new Vector3(0, notePositions[note], 0);
            var noteInstance = Instantiate(notePrefab, position, Quaternion.identity);
            ChangeObjectForVelocity(ref noteInstance, velocity);

            noteInstances.Add(note, noteInstance);
        }

        private void DestroyNote(int note)
        {
            if (!noteInstances.ContainsKey(note))
            {
                Debug.LogWarningFormat("Can't destroy note {0} since it doesn't exist", note);
                return;
            }

            var noteInstance = noteInstances[note];
            noteInstances.Remove(note);
            DestroyObject(noteInstance);
        }

        private void ChangeObjectForVelocity(ref GameObject noteObject, float velocity)
        {
            var size = velocity * maxNoteSize + (1 - velocity) * minNoteSize;
            noteObject.transform.localScale = Vector3.one * size;
        }
    }
}
