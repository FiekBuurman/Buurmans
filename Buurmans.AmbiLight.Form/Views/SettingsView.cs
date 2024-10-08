﻿using System;
using System.Collections.Generic;
using System.Linq;
using Buurmans.AmbiLight.Core.Models;
using Buurmans.AmbiLight.Form.Interfaces;
using Buurmans.Common.Controls;
using Buurmans.Common.Enums;
using Buurmans.Common.Extensions;
using Buurmans.Common.Views;
using Buurmans.Mqtt.Models;

namespace Buurmans.AmbiLight.Form.Views
{
	internal partial class SettingsView : BaseView, ISettingsView
	{
		private readonly ISettingsViewModel _settingsViewModel;

		public SettingsView(ISettingsViewModel settingsViewModel)
		{
			_settingsViewModel = settingsViewModel;
			InitializeComponent();
		}

		private void SettingsView_Load(object sender, EventArgs e)
		{
			_settingsViewModel.Init(this);
			CreateLogLevelTypeComboBoxItems();
			_settingsViewModel.LoadSettings();
		}

		private void CreateLogLevelTypeComboBoxItems()
		{
			foreach (var logLevel in Enum.GetValues(typeof(LogLevelType)))
			{
				LogLevelTypeComboBox.Items.Add(logLevel);
			}
		}

		public void LoadSettings(AmbiLightConfigurationSettingsModel settingsModel) => SetUserInputFromSettingsModel(settingsModel);

		private void SaveSettingsButton_Click(object sender, EventArgs e)
		{
			var settingsModel = CreateSettingsModelFromUserInput();
			_settingsViewModel.SaveSettingsButtonPressed(settingsModel);
		}

		private void ResetSettingsButton_Click(object sender, EventArgs e) => _settingsViewModel.ResetSettingsButtonPressed();

		private AmbiLightConfigurationSettingsModel CreateSettingsModelFromUserInput()
		{
			return new AmbiLightConfigurationSettingsModel
            {
				PixelSkipSteps = (int)PixelSkipStepsNumericUpDown.Value,
				DelayInMilliseconds = (int)DelayInMillisecondsNumericUpDown.Value,
				UseAccurateColors = useAccurateColorsCheckBox.Checked,
				LogLevel = (LogLevelType)LogLevelTypeComboBox.SelectedItem,
				ColorSettingModels = GetColorSettingsModels(),
				MqttConfigurationSettingsModel = CreateMqttSettingsModelFromUserInput()
			};
		}

		private MqttConfigurationSettingsModel CreateMqttSettingsModelFromUserInput()
		{
			return new MqttConfigurationSettingsModel
            {
				BrokerUrl = BrokerTextBox.Text,
				Port = (int)PortNumericUpDown.Value,
				Timeout = (int)TimeoutNumericUpDown.Value,
				ClientId = ClientIdTextBox.Text,
				UserName = UserNameTextBox.Text,
				Password = PasswordTextBox.Text,
				Topic = TopicTextBox.Text
			};
		}

		private void SetUserInputFromSettingsModel(AmbiLightConfigurationSettingsModel settingsModel)
		{
			PixelSkipStepsNumericUpDown.Value = settingsModel.PixelSkipSteps;
			DelayInMillisecondsNumericUpDown.Value = settingsModel.DelayInMilliseconds;
			LogLevelTypeComboBox.SelectedItem = settingsModel.LogLevel;
			useAccurateColorsCheckBox.Checked = settingsModel.UseAccurateColors;
			CreateColorSettingCheckBoxPanel(settingsModel.ColorSettingModels);
			SetUserInputFromMqttSettingsModel(settingsModel.MqttConfigurationSettingsModel);
		}

		private void SetUserInputFromMqttSettingsModel(MqttConfigurationSettingsModel mqttSettings)
		{
			BrokerTextBox.Text = mqttSettings.BrokerUrl;
			PortNumericUpDown.Value = mqttSettings.Port;
			TimeoutNumericUpDown.Value = (decimal)mqttSettings.Timeout >= 10 ? (decimal)mqttSettings.Timeout : 10;
			ClientIdTextBox.Text = mqttSettings.ClientId;
			UserNameTextBox.Text = mqttSettings.UserName;
			PasswordTextBox.Text = mqttSettings.Password;
			TopicTextBox.Text = mqttSettings.Topic;
		}

		private void CreateColorSettingCheckBoxPanel(IReadOnlyList<AmbiLightColorSettingModel> colorSettingModels)
		{
			ColorSettingsPanel.Controls.Clear();
			var columns = ColorSettingsPanel.ColumnCount;
			for (var i = 0; i < colorSettingModels.Count; i++)
			{
				var colorSettingModel = colorSettingModels[i];
				var checkBox = CreateColorCheckBox(colorSettingModel);

				var row = i / columns;
				var column = i % columns;

				ColorSettingsPanel.Controls.Add(checkBox, column, row);
			}
		}

		private static ColorCheckBox CreateColorCheckBox(AmbiLightColorSettingModel colorSettingModel)
		{
			var color = colorSettingModel.Color;
			var checkBox = new ColorCheckBox(color)
			{
				Checked = colorSettingModel.Allowed
			};

			return checkBox;
		}

		private List<AmbiLightColorSettingModel> GetColorSettingsModels()
		{
			var checkedColors = new List<AmbiLightColorSettingModel>();

			foreach (var checkBox in ColorSettingsPanel.Controls.OfType<ColorCheckBox>())
			{
				checkedColors.Add(new AmbiLightColorSettingModel
                {
					Allowed = checkBox.Checked,
					Color = checkBox.Color
				});
			}
			return checkedColors;
		}

		private void SelectAllColorsButton_Click(object sender, EventArgs e) => this.ToggleColorCheckBoxes(true);

		private void SelectNoneColorsButton_Click(object sender, EventArgs e) => this.ToggleColorCheckBoxes(false);

        private void TestMqttButton_Click(object sender, EventArgs e)
        {
			var mqttSettingsModel = CreateMqttSettingsModelFromUserInput();
			_settingsViewModel.TestMqttSettingsButtonPressed(mqttSettingsModel);
		}

        private void LogLevelTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			LogLevelDescriptionLabel.Text = ((LogLevelType)LogLevelTypeComboBox.SelectedItem).GetDescription();
		}
    }
}