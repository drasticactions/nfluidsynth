﻿using System;
using NFluidsynth.Native;

namespace NFluidsynth
{
	public delegate int MidiEventHandler (byte [] data, MidiEvent evt);

	public class MidiRouter : FluidsynthObject
	{
		public MidiRouter (Settings settings, MidiEventHandler handler, byte [] eventHandlerData)
			: base (LibFluidsynth.Midi.new_fluid_midi_router (settings.Handle, (d, e) => handler (d, new MidiEvent (e)), eventHandlerData), true)
		{
		}

		protected override void OnDispose ()
		{
			LibFluidsynth.Midi.delete_fluid_midi_router (Handle);
		}

		public void SetDefaultRules ()
		{
			LibFluidsynth.Midi.fluid_midi_router_set_default_rules (Handle);
		}

		public void ClearRules ()
		{
			LibFluidsynth.Midi.fluid_midi_router_clear_rules (Handle);
		}

		public void AddRule (MidiRouterRule rule, FluidMidiRouterRuleType type)
		{
			LibFluidsynth.Midi.fluid_midi_router_add_rule (Handle, rule.Handle, type);
		}

		public void HandleMidiEvent (MidiEvent evt)
		{
			LibFluidsynth.Midi.fluid_midi_router_handle_midi_event (Handle, evt.Handle);
		}

		public void DumpPreRouter (MidiEvent evt)
		{
			LibFluidsynth.Midi.fluid_midi_router_handle_midi_event (Handle, evt.Handle);
		}

		public void DumpPostRouter (MidiEvent evt)
		{
			LibFluidsynth.Midi.fluid_midi_dump_postrouter (Handle, evt.Handle);
		}
	}
}

