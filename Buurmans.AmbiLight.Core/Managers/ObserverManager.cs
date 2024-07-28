using System;
using System.Collections.Generic;
using System.Linq;
using Buurmans.AmbiLight.Core.Interfaces;

namespace Buurmans.AmbiLight.Core.Managers;

public class ObserverManager : IObserverManager
{
	private readonly List<object> _observers = [];

	public void Register<TValue>(Action<TValue> updateAction)
	{
		var genericObserver = GetObserver(updateAction);
		if (genericObserver == null)
			_observers.Add(updateAction);
	}

	public void Unregister<TValue>(Action<TValue> updateAction)
	{
		var genericObserver = GetObserver(updateAction);
		if (genericObserver != null)
			_observers.Remove(genericObserver);
	}

	public void NotifyChange<TValue>(TValue value)
	{	
		var genericObservers = GetObservers<TValue>();
		foreach (var genericObserver in genericObservers)
			genericObserver.Invoke(value);
	}

	private Action<TValue> GetObserver<TValue>(Action<TValue> action)
	{
		var genericObservers = GetObservers<TValue>();
		return genericObservers
			.FirstOrDefault(o => o.Method.Name == action.Method.Name && o.Target == action.Target);
	}

	private IEnumerable<Action<TValue>> GetObservers<TValue>()
	{
		return _observers
			.Where(a => a.GetType() == typeof(Action<TValue>))
			.Select(o => (Action<TValue>)o);
	}
}