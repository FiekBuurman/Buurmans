using System;

namespace Buurmans.Common.Interfaces;

public interface IObserverManager
{
	void Register<TValue>(Action<TValue> updateAction);
	void Unregister<TValue>(Action<TValue> updateAction);
	void NotifyChange<TValue>(TValue value);
}