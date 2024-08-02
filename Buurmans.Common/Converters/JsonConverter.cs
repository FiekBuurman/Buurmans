using System;
using Buurmans.Common.Interfaces;
using Newtonsoft.Json;

namespace Buurmans.Common.Converters
{
    internal class JsonConverter(IObserverManager observerManager) : IJsonConverter
	{
		public T Deserialize<T>(string jsonString)
		{
			try
			{
				return JsonConvert.DeserializeObject<T>(jsonString);
			}
			catch (JsonException exception)
			{
				observerManager.NotifyChange(
					new Exception("Error converting JSON-string to object: ", exception));

				return default;
			}
		}

		public string Serialize(object modelToConvert)
		{
			try
			{
				var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                return JsonConvert.SerializeObject(modelToConvert, Formatting.Indented, settings);
			}
			catch (JsonException exception)
			{
				observerManager.NotifyChange(
					new Exception("Error converting object to JSON: ", exception));

				return string.Empty;
			}
		}
    }
}
