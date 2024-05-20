﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Shooting_range.Services;
using Shooting_range.Views;
using Shooting_range.Models;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Reflection;
using System.Windows.Media;

namespace Shooting_range.ViewModels
{
    public class StartMenuViewModel:INotifyPropertyChanged
    {
        #region InitializeDefauleConstructorAndINotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        static string cursorDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Cursor";
        public StartMenuViewModel()
        {
            StartMenuVisibility = new StartMenuModel();
            OpenSettingsCommand = new RelayCommand(OpenSettings);
            OpenSureExitCommand = new RelayCommand(OpenSureExit);
            BackToMenuCommand = new RelayCommand(BackToMenu);
            CloseAppCommand = new RelayCommand(CloseApp);
            OpenPlayCommand = new RelayCommand(OpenPlay);
            cursor = ($@"{cursorDirectory}\\MainCursor.cur");

            ChangeEnglishLanguageCommand = new RelayCommand(ChangeEnglishLanguage);
            ChangeUkrainianLanguageCommand = new RelayCommand(ChangeUkrainianLanguage);
            ChangeSpanishLanguageCommand = new RelayCommand(ChangeSpanishLanguage);

            OpenSoundSettingsCommand = new RelayCommand(OpenSoundSettings);
            OpenCustomizeSettingsCommand = new RelayCommand(OpenCustomizeSettings);
            OpenLanguageSettingsCommand = new RelayCommand(OpenLanguageSettings);

            SetDefaultSettingsCommand = new RelayCommand(SetDefaultSettings);

            ApplySettingsChangeCommand = new RelayCommand(ApplySettingsChange);

            TargetPathChangeAquaCommand = new RelayCommand(TargetPathChangeAqua);
            TargetPathChangeBlackCommand = new RelayCommand(TargetPathChangeBlack);
            TargetPathChangeBlueCommand = new RelayCommand(TargetPathChangeBlue);
            TargetPathChangeGreenCommand = new RelayCommand(TargetPathChangeGreen);
            TargetPathChangeOrangeCommand = new RelayCommand(TargetPathChangeOrange);
            TargetPathChangePurpleCommand = new RelayCommand(TargetPathChangePurple);
            TargetPathChangeRedCommand = new RelayCommand(TargetPathChangeRed);
            TargetPathChangeYellowCommand = new RelayCommand(TargetPathChangeYellow);

            CrosshairPathChangeFineAquaCommand = new RelayCommand(CrosshairPathChangeFineAqua);
            CrosshairPathChangeFineBlackCommand = new RelayCommand(CrosshairPathChangeFineBlack);
            CrosshairPathChangeFineBlueCommand = new RelayCommand(CrosshairPathChangeFineBlue);
            CrosshairPathChangeFineGreenCommand = new RelayCommand(CrosshairPathChangeFineGreen);
            CrosshairPathChangeFineOrangeCommand = new RelayCommand(CrosshairPathChangeFineOrange);
            CrosshairPathChangeFinePurpleCommand = new RelayCommand(CrosshairPathChangeFinePurple);
            CrosshairPathChangeFineRedCommand = new RelayCommand(CrosshairPathChangeFineRed);
            CrosshairPathChangeFineYellowCommand = new RelayCommand(CrosshairPathChangeFineYellow);

            CrosshairPathChangeDotAquaCommand = new RelayCommand(CrosshairPathChangeDotAqua);
            CrosshairPathChangeDotBlackCommand = new RelayCommand(CrosshairPathChangeDotBlack);
            CrosshairPathChangeDotBlueCommand = new RelayCommand(CrosshairPathChangeDotBlue);
            CrosshairPathChangeDotGreenCommand = new RelayCommand(CrosshairPathChangeDotGreen);
            CrosshairPathChangeDotOrangeCommand = new RelayCommand(CrosshairPathChangeDotOrange);
            CrosshairPathChangeDotPurpleCommand = new RelayCommand(CrosshairPathChangeDotPurple);
            CrosshairPathChangeDotRedCommand = new RelayCommand(CrosshairPathChangeDotRed);
            CrosshairPathChangeDotYellowCommand = new RelayCommand(CrosshairPathChangeDotYellow);

            ChangeMusicVolumeUpCommand = new RelayCommand(ChangeMusicVolumeUp);
            ChangeMusicVolumeDownCommand = new RelayCommand(ChangeMusicVolumeDown);
            ChangeSoundVolumeUpCommand = new RelayCommand(ChangeSoundVolumeUp);
            ChangeSoundVolumeDownCommand = new RelayCommand(ChangeSoundVolumeDown);

            OpenGridShotCommand = new RelayCommand(OpenGridShot);
            OpenSpyderShotCommand = new RelayCommand(OpenSpyderShot);
            OpenMotionShotCommand = new RelayCommand(OpenMotionShot);
            BackToGameModeCommand = new RelayCommand(BackToGameModeChange);
            OpenMotionShotComplexityCommand = new RelayCommand(OpenMotionShotComplexity);

            MusicInitialize();
        }
        #endregion

        #region CreateProperty

        public RelayCommand OpenSettingsCommand {  get; set; }
        public RelayCommand CloseAppCommand { get; set; }
        public RelayCommand OpenSureExitCommand {  get; set; }
        public RelayCommand BackToMenuCommand {  get; set; }
        public RelayCommand OpenPlayCommand { get; set; }

        public RelayCommand ChangeEnglishLanguageCommand { get; set; }
        public RelayCommand ChangeUkrainianLanguageCommand { get; set; }
        public RelayCommand ChangeSpanishLanguageCommand { get; set; }

        public RelayCommand OpenSoundSettingsCommand {  get; set; }
        public RelayCommand OpenCustomizeSettingsCommand {  get; set; }
        public RelayCommand OpenLanguageSettingsCommand {  get; set; }

        public RelayCommand SetDefaultSettingsCommand {  get; set; }

        public RelayCommand ApplySettingsChangeCommand {  get; set; }

        public RelayCommand TargetPathChangeAquaCommand {  get; set; }
        public RelayCommand TargetPathChangeBlackCommand {  get; set; }
        public RelayCommand TargetPathChangeBlueCommand {  get; set; }
        public RelayCommand TargetPathChangeGreenCommand {  get; set; }
        public RelayCommand TargetPathChangeOrangeCommand {  get; set; }
        public RelayCommand TargetPathChangePurpleCommand {  get; set; }
        public RelayCommand TargetPathChangeRedCommand {  get; set; }
        public RelayCommand TargetPathChangeYellowCommand {  get; set; }

        public RelayCommand CrosshairPathChangeFineAquaCommand { get; set; }
        public RelayCommand CrosshairPathChangeFineBlackCommand { get; set; }
        public RelayCommand CrosshairPathChangeFineBlueCommand { get; set; }
        public RelayCommand CrosshairPathChangeFineGreenCommand { get; set; }
        public RelayCommand CrosshairPathChangeFineOrangeCommand { get; set; }
        public RelayCommand CrosshairPathChangeFinePurpleCommand { get; set; }
        public RelayCommand CrosshairPathChangeFineRedCommand { get; set; }
        public RelayCommand CrosshairPathChangeFineYellowCommand { get; set; }

        public RelayCommand CrosshairPathChangeDotAquaCommand { get; set; }
        public RelayCommand CrosshairPathChangeDotBlackCommand { get; set; }
        public RelayCommand CrosshairPathChangeDotBlueCommand { get; set; }
        public RelayCommand CrosshairPathChangeDotGreenCommand { get; set; }
        public RelayCommand CrosshairPathChangeDotOrangeCommand { get; set; }
        public RelayCommand CrosshairPathChangeDotPurpleCommand { get; set; }
        public RelayCommand CrosshairPathChangeDotRedCommand { get; set; }
        public RelayCommand CrosshairPathChangeDotYellowCommand { get; set; }

        public RelayCommand ChangeMusicVolumeUpCommand {  get; set; }
        public RelayCommand ChangeMusicVolumeDownCommand {  get; set; }
        public RelayCommand ChangeSoundVolumeUpCommand {  get; set; }
        public RelayCommand ChangeSoundVolumeDownCommand {  get; set; }

        public RelayCommand OpenGridShotCommand {  get; set; }
        public RelayCommand OpenSpyderShotCommand {  get; set; }
        public RelayCommand OpenMotionShotCommand {  get; set; }
        public RelayCommand BackToGameModeCommand { get; set; }
        public RelayCommand OpenMotionShotComplexityCommand {  get; set; }

        private string Cursor { get; set; }
        public string cursor
        {
            get { return Cursor; }
            set
            {
                Cursor = value;
                OnPropertyChanged(nameof(Cursor));
            }
        }
        SettingsProperty settingsProperty = new SettingsProperty();
        public SettingsProperty SettingsProperty
        {
            get { return settingsProperty; }
            set
            {
                settingsProperty = value;
                OnPropertyChanged(nameof(settingsProperty));
            }
        }
        StartMenuModel startMenuVisibility = new StartMenuModel();
        public StartMenuModel StartMenuVisibility
        {
            get { return startMenuVisibility; }
            set
            {
                startMenuVisibility = value;
                OnPropertyChanged(nameof(startMenuVisibility));
            }
        }
        private bool isEnabledApplyButton {  get; set; } = false;
        public bool IsEnabledApplyButton
        {
            get { return isEnabledApplyButton; }
            set
            {
                isEnabledApplyButton = value;
                OnPropertyChanged(nameof(isEnabledApplyButton));
            }
        }
        private string ApplyLanguageChange { get; set; }
        private string TargetPathChange { get; set; }
        private string CrosshairPathChange {  get; set; }
        private int musicVolume { get; set; } = 50;
        public int MusicVolume
        {
            get { return musicVolume; }
            set
            {
                musicVolume = value;
                OnPropertyChanged(nameof(musicVolume));
            }
        }
        private int soundVolume { get; set; } = 50;
        public int SoundVolume
        {
            get { return soundVolume; }
            set
            {
                soundVolume = value;
                OnPropertyChanged(nameof(soundVolume));
            }
        }

        #region BorderProperties


        private int borderChangeLanguageEnglish { get; set; } = 0;
        public int BorderChangeLanguageEnglish {
            get 
            {
                return borderChangeLanguageEnglish;
            }
            set 
            {
                borderChangeLanguageEnglish = value;
                OnPropertyChanged(nameof(borderChangeLanguageEnglish));
            } 
        }
        private int borderChangeLanguageUkrainian { get; set; } = 0;
        public int BorderChangeLanguageUkrainian
        {
            get
            {
                return borderChangeLanguageUkrainian;
            }
            set
            {
                borderChangeLanguageUkrainian = value;
                OnPropertyChanged(nameof(borderChangeLanguageUkrainian));
            }
        }
        private int borderChangeLanguageSpanish { get; set; } = 0;
        public int BorderChangeLanguageSpanish
        {
            get
            {
                return borderChangeLanguageSpanish;
            }
            set
            {
                borderChangeLanguageSpanish = value;
                OnPropertyChanged(nameof(borderChangeLanguageSpanish));
            }
        }
        private int borderChangeTargetAqua { get; set; } = 0;
        public int BorderChangeTargetAqua
        {
            get
            {
                return borderChangeTargetAqua;
            }
            set
            {
                borderChangeTargetAqua = value;
                OnPropertyChanged(nameof(borderChangeTargetAqua));
            }
        }
        private int borderChangeTargetBlack { get; set; } = 0;
        public int BorderChangeTargetBlack
        {
            get
            {
                return borderChangeTargetBlack;
            }
            set
            {
                borderChangeTargetBlack = value;
                OnPropertyChanged(nameof(borderChangeTargetBlack));
            }
        }
        private int borderChangeTargetBlue { get; set; } = 0;
        public int BorderChangeTargetBlue
        {
            get
            {
                return borderChangeTargetBlue;
            }
            set
            {
                borderChangeTargetBlue = value;
                OnPropertyChanged(nameof(borderChangeTargetBlue));
            }
        }
        private int borderChangeTargetGreen { get; set; } = 0;
        public int BorderChangeTargetGreen
        {
            get
            {
                return borderChangeTargetGreen;
            }
            set
            {
                borderChangeTargetGreen = value;
                OnPropertyChanged(nameof(borderChangeTargetGreen));
            }
        }
        private int borderChangeTargetOrange { get; set; } = 0;
        public int BorderChangeTargetOrange
        {
            get
            {
                return borderChangeTargetOrange;
            }
            set
            {
                borderChangeTargetOrange = value;
                OnPropertyChanged(nameof(borderChangeTargetOrange));
            }
        }
        private int borderChangeTargetPurple { get; set; } = 0;
        public int BorderChangeTargetPurple
        {
            get
            {
                return borderChangeTargetPurple;
            }
            set
            {
                borderChangeTargetPurple = value;
                OnPropertyChanged(nameof(borderChangeTargetPurple));
            }
        }
        private int borderChangeTargetRed { get; set; } = 0;
        public int BorderChangeTargetRed
        {
            get
            {
                return borderChangeTargetRed;
            }
            set
            {
                borderChangeTargetRed = value;
                OnPropertyChanged(nameof(borderChangeTargetRed));
            }
        }
        private int borderChangeTargetYellow { get; set; } = 0;
        public int BorderChangeTargetYellow
        {
            get
            {
                return borderChangeTargetYellow;
            }
            set
            {
                borderChangeTargetYellow = value;
                OnPropertyChanged(nameof(borderChangeTargetYellow));
            }
        }
        private int borderChangeFineCrosshairAqua { get; set; } = 0;
        public int BorderChangeFineCrosshairAqua
        {
            get
            {
                return borderChangeFineCrosshairAqua;
            }
            set
            {
                borderChangeFineCrosshairAqua = value;
                OnPropertyChanged(nameof(borderChangeFineCrosshairAqua));
            }
        }
        private int borderChangeFineCrosshairBlack { get; set; } = 0;
        public int BorderChangeFineCrosshairBlack
        {
            get
            {
                return borderChangeFineCrosshairBlack;
            }
            set
            {
                borderChangeFineCrosshairBlack = value;
                OnPropertyChanged(nameof(borderChangeFineCrosshairBlack));
            }
        }
        private int borderChangeFineCrosshairBlue { get; set; } = 0;
        public int BorderChangeFineCrosshairBlue
        {
            get
            {
                return borderChangeFineCrosshairBlue;
            }
            set
            {
                borderChangeFineCrosshairBlue = value;
                OnPropertyChanged(nameof(borderChangeFineCrosshairBlue));
            }
        }
        private int borderChangeFineCrosshairGreen { get; set; } = 0;
        public int BorderChangeFineCrosshairGreen
        {
            get
            {
                return borderChangeFineCrosshairGreen;
            }
            set
            {
                borderChangeFineCrosshairGreen = value;
                OnPropertyChanged(nameof(borderChangeFineCrosshairGreen));
            }
        }
        private int borderChangeFineCrosshairOrange { get; set; } = 0;
        public int BorderChangeFineCrosshairOrange
        {
            get
            {
                return borderChangeFineCrosshairOrange;
            }
            set
            {
                borderChangeFineCrosshairOrange = value;
                OnPropertyChanged(nameof(borderChangeFineCrosshairOrange));
            }
        }
        private int borderChangeFineCrosshairPurple { get; set; } = 0;
        public int BorderChangeFineCrosshairPurple
        {
            get
            {
                return borderChangeFineCrosshairPurple;
            }
            set
            {
                borderChangeFineCrosshairPurple = value;
                OnPropertyChanged(nameof(borderChangeFineCrosshairPurple));
            }
        }
        private int borderChangeFineCrosshairRed { get; set; } = 0;
        public int BorderChangeFineCrosshairRed
        {
            get
            {
                return borderChangeFineCrosshairRed;
            }
            set
            {
                borderChangeFineCrosshairRed = value;
                OnPropertyChanged(nameof(borderChangeFineCrosshairRed));
            }
        }
        private int borderChangeFineCrosshairYellow { get; set; } = 0;
        public int BorderChangeFineCrosshairYellow
        {
            get
            {
                return borderChangeFineCrosshairYellow;
            }
            set
            {
                borderChangeFineCrosshairYellow = value;
                OnPropertyChanged(nameof(borderChangeFineCrosshairYellow));
            }
        }
        private int borderChangeDotCrosshairAqua { get; set; } = 0;
        public int BorderChangeDotCrosshairAqua
        {
            get
            {
                return borderChangeDotCrosshairAqua;
            }
            set
            {
                borderChangeDotCrosshairAqua = value;
                OnPropertyChanged(nameof(borderChangeDotCrosshairAqua));
            }
        }
        private int borderChangeDotCrosshairBlack { get; set; } = 0;
        public int BorderChangeDotCrosshairBlack
        {
            get
            {
                return borderChangeDotCrosshairBlack;
            }
            set
            {
                borderChangeDotCrosshairBlack = value;
                OnPropertyChanged(nameof(borderChangeDotCrosshairBlack));
            }
        }
        private int borderChangeDotCrosshairBlue { get; set; } = 0;
        public int BorderChangeDotCrosshairBlue
        {
            get
            {
                return borderChangeDotCrosshairBlue;
            }
            set
            {
                borderChangeDotCrosshairBlue = value;
                OnPropertyChanged(nameof(borderChangeDotCrosshairBlue));
            }
        }
        private int borderChangeDotCrosshairGreen { get; set; } = 0;
        public int BorderChangeDotCrosshairGreen
        {
            get
            {
                return borderChangeDotCrosshairGreen;
            }
            set
            {
                borderChangeDotCrosshairGreen = value;
                OnPropertyChanged(nameof(borderChangeDotCrosshairGreen));
            }
        }
        private int borderChangeDotCrosshairOrange { get; set; } = 0;
        public int BorderChangeDotCrosshairOrange
        {
            get
            {
                return borderChangeDotCrosshairOrange;
            }
            set
            {
                borderChangeDotCrosshairOrange = value;
                OnPropertyChanged(nameof(borderChangeDotCrosshairOrange));
            }
        }
        private int borderChangeDotCrosshairPurple { get; set; } = 0;
        public int BorderChangeDotCrosshairPurple
        {
            get
            {
                return borderChangeDotCrosshairPurple;
            }
            set
            {
                borderChangeDotCrosshairPurple = value;
                OnPropertyChanged(nameof(borderChangeDotCrosshairPurple));
            }
        }
        private int borderChangeDotCrosshairRed { get; set; } = 0;
        public int BorderChangeDotCrosshairRed
        {
            get
            {
                return borderChangeDotCrosshairRed;
            }
            set
            {
                borderChangeDotCrosshairRed = value;
                OnPropertyChanged(nameof(borderChangeDotCrosshairRed));
            }
        }
        private int borderChangeDotCrosshairYellow { get; set; } = 0;
        public int BorderChangeDotCrosshairYellow
        {
            get
            {
                return borderChangeDotCrosshairYellow;
            }
            set
            {
                borderChangeDotCrosshairYellow = value;
                OnPropertyChanged(nameof(borderChangeDotCrosshairYellow));
            }
        }
        #endregion
        #endregion

        #region StartMenuButtons
        private void BackToMenu(object sender)
        {
            OpenSmth("InitialVisibility");
        }


        private void OpenPlay(object sender)
        {
            OpenSmth("PlayVisibility");
        }


        private void OpenSettings(object sender)
        {
            OpenSmth("SettingsVisibility");
        }


        private void OpenSureExit(object sender)
        {
            OpenSmth("SureExitVisibility");
        }


        private void CloseApp(object sender)
        {
            Application.Current.Shutdown();
        }

        private void OpenSmth(string visibleParametr)
        {
            HideAll();
            switch (visibleParametr)
            {
                case "InitialVisibility":
                    StartMenuVisibility.InitialVisibility = Visibility.Visible;
                    break;
                case "PlayVisibility":
                    StartMenuVisibility.PlayVisibility = Visibility.Visible;
                    break;
                case "SettingsVisibility":
                    StartMenuVisibility.SettingsVisibility = Visibility.Visible;
                    break;
                case "SureExitVisibility":
                    StartMenuVisibility.SureExitVisibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }
        private void HideAll()
        {
            StartMenuVisibility.InitialVisibility = Visibility.Collapsed;
            StartMenuVisibility.SettingsVisibility = Visibility.Collapsed;
            StartMenuVisibility.SureExitVisibility = Visibility.Collapsed;
            StartMenuVisibility.PlayVisibility = Visibility.Collapsed;
        }
        #endregion

        #region SettingsButtons
        private void OpenSoundSettings(object sender)
        {
            OpenSomeSettings("SoundSettings");
        }
        private void OpenCustomizeSettings(object sender)
        {
            OpenSomeSettings("CustomizeSettings");
        }
        private void OpenLanguageSettings(object sender)
        {
            OpenSomeSettings("LanguageSettings");
        }
        private void OpenSomeSettings(string settings)
        {
            CloseAllSettings();
            switch (settings)
            {
                case "SoundSettings":
                    StartMenuVisibility.SoundSettings = Visibility.Visible;
                    break;
                case "CustomizeSettings":
                    StartMenuVisibility.CustomizeSettings = Visibility.Visible;
                    break;
                case "LanguageSettings":
                    StartMenuVisibility.LanguageSettings = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }
        private void CloseAllSettings()
        {
            StartMenuVisibility.SoundSettings = Visibility.Collapsed;
            StartMenuVisibility.CustomizeSettings = Visibility.Collapsed;
            StartMenuVisibility.LanguageSettings = Visibility.Collapsed;
        }
        #endregion

        #region PlayButtons
        private void OpenGridShot(object sender)
        {
            CloseGameProperties();
            startMenuVisibility.GridShotVisibility = Visibility.Visible;
        }
        private void OpenSpyderShot(object sender)
        {
            CloseGameProperties();
            startMenuVisibility.SpiderShotVisibility = Visibility.Visible;
        }
        private void OpenMotionShot(object sender)
        {
            CloseGameProperties();
            startMenuVisibility.MotionShotVisibility = Visibility.Visible;
        }
        private void OpenMotionShotComplexity(object sender)
        {
            CloseGameProperties();
            startMenuVisibility.MotionComplexityVisibility = Visibility.Visible;
        }
        private void BackToGameModeChange(object sender)
        {
            CloseGameProperties();
            startMenuVisibility.MotionComplexityVisibility = Visibility.Collapsed;
            startMenuVisibility.GameModeVisibility = Visibility.Visible;
        }
        private void CloseGameProperties()
        {
            startMenuVisibility.GridShotVisibility = Visibility.Collapsed;
            startMenuVisibility.SpiderShotVisibility = Visibility.Collapsed;
            startMenuVisibility.MotionShotVisibility = Visibility.Collapsed;
        }
        #endregion

        #region ChangeVolume
        private void ChangeMusicVolumeUp(object sender)
        {
            if (MusicVolume != 100)
            {
                ButtonClick();
                MusicVolume += 5;
                IsEnabledApplyButton = true;
            }
        }
        private void ChangeMusicVolumeDown(object sender)
        {
            if (MusicVolume != 0)
            {
                ButtonClick();
                MusicVolume -= 5;
                IsEnabledApplyButton = true;
            }
        }
        private void ChangeSoundVolumeUp(object sender)
        {
            if (SoundVolume != 100)
            {
                ButtonClick();
                SoundVolume += 5;
                IsEnabledApplyButton = true;
            }
        }



        private void ChangeSoundVolumeDown(object sender)
        {
            if (SoundVolume != 0)
            {
                ButtonClick();
                SoundVolume -= 5;
                IsEnabledApplyButton = true;
            }
        }
        private void ApplyMusicVolumeChange(int volume)
        {
            settingsProperty.MusicVolume = volume;
        }
        private void ApplySoundVolumeChange(int volume)
        {
            settingsProperty.SoundVolume = volume;
        }
        #endregion

        #region LanguageChange
        private void ChangeEnglishLanguage(object sender)
        {
            ApplyLanguageChange = "en-US";
            BorderChangeLanguageHide();
            BorderChangeLanguageEnglish = 2;
            IsEnabledApplyButton = true;
        }
        private void ChangeUkrainianLanguage(object sender)
        {
            ApplyLanguageChange = "uk-UA";
            BorderChangeLanguageHide();
            BorderChangeLanguageUkrainian = 2;
            IsEnabledApplyButton = true;
        }
        private void ChangeSpanishLanguage(object sender)
        {
            ApplyLanguageChange = "es-ES";
            BorderChangeLanguageHide();
            BorderChangeLanguageSpanish = 2;
            IsEnabledApplyButton = true;
        }
        private void ChangeLanguage(string language)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo($"{language}");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo($"{language}");

            Application.Current.Resources.MergedDictionaries.Clear();
            ResourceDictionary resdict = new ResourceDictionary()
            {
                Source = new Uri($"LanguagePack/Dictionary-{language}.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(resdict);
        }
        private void BorderChangeLanguageHide()
        {
            BorderChangeLanguageEnglish = 0;
            BorderChangeLanguageUkrainian = 0;
            BorderChangeLanguageSpanish = 0;
        }
        #endregion

        #region TargetPathChange
        private void ApplyTargetPathChange(string Path)
        {
            settingsProperty.TargetPath = Path;
        }
        private void TargetPathChangeAqua(object sender)
        {
            TargetPathChange = "../Targets/Aqua-Target.png";
            HideAllBorderTarget();
            BorderChangeTargetAqua = 2;
            isEnabledApplyButton = true;
        }
        private void TargetPathChangeBlack(object sender)
        {
            TargetPathChange = "../Targets/Black-Target.png";
            HideAllBorderTarget();
            BorderChangeTargetBlack = 2;
            IsEnabledApplyButton = true;
        }
        private void TargetPathChangeBlue (object sender)
        {
            TargetPathChange = "../Targets/Blue-Target.png";
            HideAllBorderTarget();
            BorderChangeTargetBlue = 2;
            IsEnabledApplyButton = true;
        }
        private void TargetPathChangeGreen(object sender)
        {
            TargetPathChange = "../Targets/Green-Target.png";
            HideAllBorderTarget();
            BorderChangeTargetGreen = 2;
            IsEnabledApplyButton = true;
        }
        private void TargetPathChangeOrange(object sender)
        {
            TargetPathChange = "../Targets/Orange-Target.png";
            HideAllBorderTarget();
            BorderChangeTargetOrange = 2;
            IsEnabledApplyButton = true;
        }
        private void TargetPathChangePurple(object sender)
        {
            TargetPathChange = "../Targets/Purple-Target.png";
            HideAllBorderTarget();
            BorderChangeTargetPurple = 2;
            IsEnabledApplyButton = true;
        }
        private void TargetPathChangeRed(object sender)
        {
            TargetPathChange = "../Targets/Red-Target.png";
            HideAllBorderTarget();
            BorderChangeTargetRed = 2;
            IsEnabledApplyButton = true;
        }
        private void TargetPathChangeYellow(object sender)
        {
            TargetPathChange = "../Targets/Yellow-Target.png";
            HideAllBorderTarget();
            BorderChangeTargetYellow = 2;
            IsEnabledApplyButton = true;
        }
        private void HideAllBorderTarget()
        {
            BorderChangeTargetAqua = 0;
            BorderChangeTargetBlack = 0;
            BorderChangeTargetBlue = 0;
            BorderChangeTargetGreen = 0;
            BorderChangeTargetPurple = 0;
            BorderChangeTargetOrange = 0;
            BorderChangeTargetRed = 0;
            BorderChangeTargetYellow = 0;
        }
        #endregion

        #region CrosshairPathChange
        private void ApplyCrosshairPathChange(string Path)
        {
            settingsProperty.CrosshairPath = Path;
        }
        private void CrosshairPathChangeFineAqua(object sender)
        {
            CrosshairPathChange = @"\\Fine\\AquaFineCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeFineCrosshairAqua = 2;
            IsEnabledApplyButton = true;
        }
        private void CrosshairPathChangeFineBlack(object sender)
        {
            CrosshairPathChange = @"\\Fine\\BlackFineCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeFineCrosshairBlack = 2;
            IsEnabledApplyButton = true;
        }
        private void CrosshairPathChangeFineBlue(object sender)
        {
            CrosshairPathChange = @"\\Fine\\BlueFineCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeFineCrosshairBlue = 2;
            IsEnabledApplyButton = true;
        }
        private void CrosshairPathChangeFineGreen(object sender)
        {
            CrosshairPathChange = @"\\Fine\\GreenFineCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeFineCrosshairGreen = 2;
            IsEnabledApplyButton = true;
        }
        private void CrosshairPathChangeFineOrange(object sender)
        {
            CrosshairPathChange = @"\\Fine\\OrangeFineCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeFineCrosshairOrange = 2;
            IsEnabledApplyButton = true;
        }
        private void CrosshairPathChangeFinePurple(object sender)
        {
            CrosshairPathChange = @"\\Fine\\PurpleFineCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeFineCrosshairPurple = 2;
            IsEnabledApplyButton = true;
        }
        private void CrosshairPathChangeFineRed(object sender)
        {
            CrosshairPathChange = @"\\Fine\\RedineCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeFineCrosshairRed = 2;
            IsEnabledApplyButton = true;
        }
        private void CrosshairPathChangeFineYellow(object sender)
        {
            CrosshairPathChange = @"\\Fine\\YellowFineCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeFineCrosshairYellow = 2;
            IsEnabledApplyButton = true;
        }
        private void CrosshairPathChangeDotAqua(object sender)
        {
            CrosshairPathChange = @"\\Dot\\AquaDotCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeDotCrosshairAqua = 2;
            IsEnabledApplyButton = true;
        }
        private void CrosshairPathChangeDotBlack(object sender)
        {
            CrosshairPathChange = @"\\Dot\\BlackDotCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeDotCrosshairBlack = 2;
            IsEnabledApplyButton = true;
        }
        private void CrosshairPathChangeDotBlue(object sender)
        {
            CrosshairPathChange = @"\\Dot\\BlueDotCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeDotCrosshairBlue = 2;
            IsEnabledApplyButton = true;
        }
        private void CrosshairPathChangeDotGreen(object sender)
        {
            CrosshairPathChange = @"\\Dot\\GreenDotCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeDotCrosshairGreen = 2;
            IsEnabledApplyButton = true;
        }
        private void CrosshairPathChangeDotOrange(object sender)
        {
            CrosshairPathChange = @"\\Dot\\OrangeDotCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeDotCrosshairOrange = 2;
            IsEnabledApplyButton = true;
        }
        private void CrosshairPathChangeDotPurple(object sender)
        {
            CrosshairPathChange = @"\\Dot\\PurpleDotCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeDotCrosshairPurple = 2;
            IsEnabledApplyButton = true;
        }
        private void CrosshairPathChangeDotRed(object sender)
        {
            CrosshairPathChange = @"\\Dot\\RedDotCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeDotCrosshairRed = 2;
            IsEnabledApplyButton = true;
        }
        private void CrosshairPathChangeDotYellow(object sender)
        {
            CrosshairPathChange = @"\\Dot\\YellowDotCrosshair.cur";
            HideAllBorderCrosshair();
            BorderChangeDotCrosshairYellow = 2;
            IsEnabledApplyButton = true;
        }
        private void HideAllBorderCrosshair()
        {
            BorderChangeFineCrosshairAqua = 0;
            BorderChangeFineCrosshairBlack = 0;
            BorderChangeFineCrosshairBlue = 0;
            BorderChangeFineCrosshairGreen = 0;
            BorderChangeFineCrosshairOrange = 0;
            BorderChangeFineCrosshairPurple = 0;
            BorderChangeFineCrosshairRed = 0;
            BorderChangeFineCrosshairYellow = 0;

            BorderChangeDotCrosshairYellow = 0;
            BorderChangeDotCrosshairAqua = 0;
            BorderChangeDotCrosshairBlack = 0;
            BorderChangeDotCrosshairBlue = 0;
            BorderChangeDotCrosshairGreen = 0;
            BorderChangeDotCrosshairOrange = 0;
            BorderChangeDotCrosshairPurple = 0;
            BorderChangeDotCrosshairRed = 0;
            BorderChangeDotCrosshairYellow = 0;
        }
        #endregion

        #region ApplySettingsChanges
        private void ApplySettingsChange(object sender)
        {
            if(ApplyLanguageChange!=null)
                ChangeLanguage(ApplyLanguageChange);
            BorderChangeLanguageHide();
            if(TargetPathChange!=null)
                ApplyTargetPathChange(TargetPathChange);
            if (CrosshairPathChange != null)
                ApplyCrosshairPathChange(CrosshairPathChange);
            ApplyMusicVolumeChange(MusicVolume);
            ApplySoundVolumeChange(SoundVolume);
            MainMenuMusic.Volume = (settingsProperty.MusicVolume) / 100;
            HideAllBorderTarget(); 
            HideAllBorderCrosshair();
            IsEnabledApplyButton = false;
        }
        private void SetDefaultSettings(object sender)
        {
            ChangeLanguage("en-US");
            ApplyTargetPathChange("../Targets/Aqua-Target.png");
            ApplyCrosshairPathChange(@"\\Fine\\AquaFineCrosshair.cur");
            MusicVolume = 50;
            ApplyMusicVolumeChange(50);
            SoundVolume = 50;
            ApplySoundVolumeChange(50);
            IsEnabledApplyButton = false;
        }
        #endregion

        #region MusicAndSound
        MediaPlayer ButtonClickSound; 
        MediaPlayer MainMenuMusic; 

        static string FilePath = Assembly.GetExecutingAssembly().Location;
        static string DirectionPath = System.IO.Path.GetDirectoryName(FilePath);
        static string ButtonClickPath = System.IO.Path.Combine(DirectionPath, "Sounds/SoundEffects/ButtonClick.wav");
        static string MainMenuMusicPath = System.IO.Path.Combine(DirectionPath, "Sounds/Music/MainMenuMusic.wav");

        private void ButtonClick()
        {
            ButtonClickSound = new MediaPlayer();
            ButtonClickSound.Open(new Uri(ButtonClickPath));
            ButtonClickSound.Volume = (settingsProperty.SoundVolume)/100;
            ButtonClickSound.Play();
        }
        private void MusicInitialize()
        {
            MainMenuMusic = new MediaPlayer();
            MainMenuMusic.MediaEnded += MusicEnd;
            MainMenuMusic.Open(new Uri(MainMenuMusicPath));
            MainMenuMusic.Volume = (settingsProperty.MusicVolume) / 100;
            MainMenuMusic.Play();
        }
        private void MusicEnd(object sender, EventArgs e)
        {
            MainMenuMusic.Position = TimeSpan.MinValue;
        }
        #endregion
    }
}
