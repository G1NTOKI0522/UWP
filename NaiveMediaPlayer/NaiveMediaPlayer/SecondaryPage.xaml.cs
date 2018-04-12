using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace NaiveMediaPlayer
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SecondaryPage : Page
    {
        public SecondaryPage()
        {
            this.InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /*
            var mediaSource = MediaSource.CreateFromUri(new Uri("http://www.neu.edu.cn/indexsource/neusong.mp3"));
            Title.Text = mediaSource.Uri.ToString();
            Title.Text = Title.Text.Substring(Title.Text.LastIndexOf('/')+1);
            myPlayer.Source = mediaSource;
            mediaSimple.SetMediaPlayer(myPlayer);
            */
            String myUrl = input1.Text.ToString();
            if (myUrl == "") input1.Header = "Please input the Url";
            else
            {
                var mediaSource = MediaSource.CreateFromUri(new Uri(myUrl));
                MediaPlayer myPlayer = new MediaPlayer();
                //Title.Text = mediaSource.Uri.ToString();
                //Title.Text = Title.Text.Substring(Title.Text.LastIndexOf('/') + 1);
                myPlayer.Source = mediaSource;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window.Current.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window.Current.Close();
        }
    }
}
