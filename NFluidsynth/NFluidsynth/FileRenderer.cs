﻿using System;
using NFluidsynth.Native;

namespace NFluidsynth
{
	public class FileRenderer : FluidsynthObject
	{
		public FileRenderer (Synth synth)
			: base (LibFluidsynth.Audio.new_fluid_file_renderer (synth.Handle), true)
		{
		}

		protected override void OnDispose ()
		{
			LibFluidsynth.Audio.delete_fluid_file_renderer (Handle);
		}

		public void ProcessBlock ()
		{
			LibFluidsynth.Audio.fluid_file_renderer_process_block (Handle);
		}
	}
}
