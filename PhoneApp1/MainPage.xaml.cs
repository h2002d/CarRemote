using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.Resources;
using System.Threading;

namespace PhoneApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        const int ECHO_PORT = 100;  // The Echo protocol uses port 7 in this sample
        const int QOTD_PORT = 17; // The Quote of the Day (QOTD) protocol uses port 17 in this sample
        public static SocketClient client = new SocketClient();
        public static bool isConnected = false;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Thread connectionThread = new Thread(setUpConnection);
            connectionThread.Start();
        }


        private void setUpConnection()
        {
                Dispatcher.BeginInvoke(() => connectionLabel.Text = "Pending...");
                string status = "";
                if (!isConnected)
                {
                    status = client.Connect("192.168.1.104", ECHO_PORT);
                }
                if(status.ToLower()=="success")
                {
                    Dispatcher.BeginInvoke(() => connectionLabel.Text = "Connected...");
                    Dispatcher.BeginInvoke(() => Retry_button.IsEnabled = false);
                    isConnected = true;
                }
                else
                {
                    Dispatcher.BeginInvoke(() => connectionLabel.Text = "Failed...");
                    isConnected = false;
                }
        }

        private string SendAction(string data)
        {
            string result = "";
            if (isConnected)
            {
                result = client.Send(data);
                result = client.Receive();
            }
            else
            {
                MessageBox.Show("Car is not connected");
                setUpConnection();
                result = isConnected ? SendAction(data) : "Cannot connect to car";
            }
            return result;
        }
        private void Retry_button_Click(object sender, RoutedEventArgs e)
        {
            setUpConnection();
        }

        private void btnHorn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SendAction("horn"));
        }

        private void btnLockDoors_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SendAction("lock"));
        }

        private void btnStartEngine_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SendAction("engine"));
        }

        private void btnHeadlight_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SendAction("lights"));
        }

        private void btnEmergency_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Emergency.xaml", UriKind.Relative));
        }

        private void btnInterior_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InteriorPanorama.xaml", UriKind.Relative));
        }

        #region old
        /// <summary>
        /// Handle the btnEcho_Click event by sending text to the echo server 
        /// and outputting the response
        /// </summary>
        //private void btnEcho_Click(object sender, RoutedEventArgs e)
        //{
        //    // Clear the log 
        //    ClearLog();

        //    // Make sure we can perform this action with valid data
        //    if (ValidateRemoteHost() && ValidateInput())
        //    {
        //        // Instantiate the SocketClient

        //        string result;
        //        // Attempt to connect to the echo server
        //        Log(String.Format("Connecting to server '{0}' over port {1} (echo) ...", txtRemoteHost.Text, ECHO_PORT), true);

        //        //Log(result, false);

        //        // Attempt to send our message to be echoed to the echo server
        //        Log(String.Format("Sending '{0}' to server ...", txtInput.Text), true);
        //       
        //        Log(result, false);

        //        // Receive a response from the echo server
        //        Log("Requesting Receive ...", true);
        //        result = client.Receive();
        //        Log(result, false);

        //        // Close the socket connection explicitly

        //    }

        //}

        ///// <summary>
        ///// Handle the btnEcho_Click event by receiving text from the Quote of 
        ///// the Day (QOTD) server and outputting the response 
        ///// </summary>
        //private void btnGetQuote_Click(object sender, RoutedEventArgs e)
        //{
        //    client.Close();
        //    //// Clear the log 
        //    //ClearLog();

        //    //// Make sure we can perform this action with valid data
        //    //if (ValidateRemoteHost())
        //    //{
        //    //    // Instantiate the SocketClient object
        //    //    SocketClient client = new SocketClient();

        //    //    // Attempt connection to the Quote of the Day (QOTD) server
        //    //    Log(String.Format("Connecting to server '{0}' over port {1} (Quote of the Day) ...", txtRemoteHost.Text, QOTD_PORT), true);
        //    //    string result = client.Connect(txtRemoteHost.Text, QOTD_PORT);
        //    //    Log(result, false);

        //    //    // Note: The QOTD protocol is not expecting data to be sent to it.
        //    //    // So we omit a send call in this example.

        //    //    // Receive response from the QOTD server
        //    //    Log("Requesting Receive ...", true);
        //    //    
        //    //    Log(result, false);

        //    //    // Close the socket conenction explicitly
        //    //    client.Close();
        //    //}
        //}


        //#region UI Validation
        ///// <summary>
        ///// Validates the txtInput TextBox
        ///// </summary>
        ///// <returns>True if the txtInput TextBox contains valid data, otherwise 
        ///// False.
        /////</returns>
        //private bool ValidateInput()
        //{
        //    // txtInput must contain some text
        //    if (String.IsNullOrWhiteSpace(txtInput.Text))
        //    {
        //        MessageBox.Show("Please enter some text to echo");
        //        return false;
        //    }

        //    return true;
        //}

        ///// <summary>
        ///// Validates the txtRemoteHost TextBox
        ///// </summary>
        ///// <returns>True if the txtRemoteHost contains valid data,
        ///// otherwise False
        ///// </returns>
        //private bool ValidateRemoteHost()
        //{
        //    // The txtRemoteHost must contain some text
        //    if (String.IsNullOrWhiteSpace(txtRemoteHost.Text))
        //    {
        //        MessageBox.Show("Please enter a host name");
        //        return false;
        //    }

        //    return true;
        //}
        //#endregion

        //#region Logging
        ///// <summary>
        ///// Log text to the txtOutput TextBox
        ///// </summary>
        ///// <param name="message">The message to write to the txtOutput TextBox</param>
        ///// <param name="isOutgoing">True if the message is an outgoing (client to server)
        ///// message, False otherwise.
        ///// </param>
        ///// <remarks>We differentiate between a message from the client and server 
        ///// by prepending each line  with ">>" and "<<" respectively.</remarks>
        //private void Log(string message, bool isOutgoing)
        //{
        //    string direction = (isOutgoing) ? ">> " : "<< ";
        //    txtOutput.Text += Environment.NewLine + direction + message;
        //}

        ///// <summary>
        ///// Clears the txtOutput TextBox
        ///// </summary>
        //private void ClearLog()
        //{
        //    txtOutput.Text = String.Empty;
        //}
        #endregion

    }
}