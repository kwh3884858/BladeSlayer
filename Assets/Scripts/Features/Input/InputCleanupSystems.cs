//using System;
using System.Collections.Generic;

using Entitas;

public class InputCleanupSystems : ICleanupSystem
{
	readonly IGroup<InputEntity> m_group;
	readonly List<InputEntity> m_buffer = new List<InputEntity> ();
	public InputCleanupSystems (Contexts contexts)
	{
		m_group = contexts.input.GetGroup (InputMatcher.Input);
	}

	public void Cleanup ()
	{
		foreach (InputEntity e in m_group.GetEntities (m_buffer)) {
			e.Destroy ();
		}
	}
}
