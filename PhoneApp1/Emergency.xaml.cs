using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace PhoneApp1
{
    public partial class Emergency : PhoneApplicationPage
    {
        public Emergency()
        {
            InitializeComponent();
        }

        private void btnPoliceEmergency_Click(object sender, RoutedEventArgs e)
        {
            MakeCall("Police", "094341044");
        }

        private void MakeCall(string name,string number)
        {
            var phoneTask = new PhoneCallTask
            {
                DisplayName = name,
                PhoneNumber = number
            };
            phoneTask.Show();
        }

        private void btnAmbulanceEmergency_Click(object sender, RoutedEventArgs e)
        {
            MakeCall("Ambulance", "077341044");
        }

        private void btnEvacuatorEmergency_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Evacuator.xaml", UriKind.Relative));
        }
    }
}