using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace NaiveMediaPlayer
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MediaPlayer myPlayer = new MediaPlayer();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var openPicker = new FileOpenPicker();

            openPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.VideosLibrary;
            openPicker.FileTypeFilter.Add(".mp4");
            openPicker.FileTypeFilter.Add(".mp3");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                var mediaSource = MediaSource.CreateFromStorageFile(file);
                Title.Text = file.Name;
                myPlayer.Source = mediaSource;
                mediaSimple.SetMediaPlayer(myPlayer);
                if (file.FileType == ".mp3")
                {
                    //Todo 播放音频时显示专辑封面旋转
                    //可通过 Ellipse 实现
                }
            }
        }
    }
}
