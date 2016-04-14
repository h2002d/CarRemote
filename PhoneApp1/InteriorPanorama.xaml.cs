using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Storage.Pickers;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Activation;
using Windows.Storage;

namespace PhoneApp1
{
    public partial class InteriorPanorama : PhoneApplicationPage
    {
        CoreApplicationView view;
       // static SocketClient client = new SocketClient();
       // static bool isConnected = false;

        public InteriorPanorama()
        {
            InitializeComponent();
            view = CoreApplication.GetCurrentView();
        }

        private void btnSelectSong_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker filePicker = new FileOpenPicker();

            filePicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            filePicker.ViewMode = PickerViewMode.List;
            filePicker.FileTypeFilter.Clear();
            filePicker.FileTypeFilter.Add(".mp3");
            filePicker.FileTypeFilter.Add(".wav");
            filePicker.PickSingleFileAndContinue();

            view.Activated += viewActivated; 
        }

        private void viewActivated(CoreApplicationView sender, Windows.ApplicationModel.Activation.IActivatedEventArgs args)
        {
            FileOpenPickerContinuationEventArgs args1 = args as FileOpenPickerContinuationEventArgs;

            if (args1 != null)
            {
                if (args1.Files.Count == 0) 
                    return;

                view.Activated -= viewActivated;
                StorageFile storageFile = args1.Files[0];

                MessageBox.Show(storageFile.Name);
            }
        }

        //private string SendAction(string data)
        //{
        //    string result = "";
        //    if (MainPage.isConnected)
        //    {
        //        result = MainPage.client.Send(data);
        //        result = MainPage.client.Receive();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Car is not connected");
        //        //MainPage.setUpConnection();
        //        result = MainPage.isConnected ? SendAction(data) : "Cannot connect to car";
        //    }
        //    return result;
        //}
    }
}