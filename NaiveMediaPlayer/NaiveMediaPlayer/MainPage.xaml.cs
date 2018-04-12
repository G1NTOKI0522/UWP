using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
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
                //myPlayer = myPlayer;
                mediaSimple.SetMediaPlayer(myPlayer);
                if (file.FileType == ".mp3")
                {
                    //Todo 播放音频时显示专辑封面旋转
                    //可通过 Ellipse 实现
                }
            }
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            choice.IsPaneOpen = true;
            //var mediaSource = MediaSource.CreateFromUri(new Uri("http://www.neu.edu.cn/indexsource/neusong.mp3"));

            //new a window to choose the way on playing file.
            // but cannot transe the value of player QAQ 
            /* 
            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 0;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                frame.Navigate(sourcePageType: typeof(SecondaryPage));
                Window.Current.Content = frame;
                // You have to activate the window in order to show it later.
                Window.Current.Activate();

                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
            */

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            choice.IsPaneOpen = false;
            String inputU = inputUrl.Text.ToString();
            if (inputU == "") return;
            var mediaSource = MediaSource.CreateFromUri(new Uri(inputU));

            Title.Text = mediaSource.Uri.ToString();
            Title.Text = Title.Text.Substring(Title.Text.LastIndexOf('/') + 1);
            myPlayer.Source = mediaSource;
            mediaSimple.SetMediaPlayer(myPlayer);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            choice.IsPaneOpen = false;
            String inputU = inputUrl.Text.ToString();
            if (inputU == "") return;
            var myfolder = KnownFolders.MusicLibrary;
            String fileName = inputU.Substring(inputU.LastIndexOf('/') + 1);
            StorageFile cacheFile = await myfolder.CreateFileAsync(fileName,CreationCollisionOption.ReplaceExisting);
           
            var download = new BackgroundDownloader().CreateDownload(new Uri(inputU), cacheFile);
            await download.StartAsync();

            var cacheMediaSource = MediaSource.CreateFromStorageFile(cacheFile);
            myPlayer.Source = cacheMediaSource;
            mediaSimple.SetMediaPlayer(myPlayer);
            Title.Text = fileName;
        }
    }
}
