namespace Buurmans.Common.Converters
{
	public interface IJsonConverter
	{
		T Deserialize<T>(string jsonString);

		string Serialize(object modelToConvert);
	}
}