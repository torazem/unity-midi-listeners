# Unity Midi Listeners
These are scripts for Unity 5, inspired by [MidiJack](https://github.com/keijiro/MidiJack)

There are two types of component scripts:

- **Listeners**, which listen for MIDI events, and

- **Runners**, which handle input and send events to the listeners, e.g. MidiKeyboardRunner lets you use your keyboard to send note signals. Runners look for all listener components on the same GameObject.
