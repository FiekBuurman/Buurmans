namespace Buurmans.Common.Interfaces
{
	public interface IBaseConfigurationProvider<T> where T : class
	{
		T GetSettings();
		void SaveSettings(T settingsModel);
	}
}