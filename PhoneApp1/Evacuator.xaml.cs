using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.Classes;
using Microsoft.Phone.Tasks;

namespace PhoneApp1
{
    public partial class Evacuator : PhoneApplicationPage
    {
        private static Evacuators _evacuator = new Evacuators();
        public Evacuator()
        {
            InitializeComponent();
            AddEvacuatorList();
        }

        private void AddEvacuatorList()
        {
          listSelectorEvacuators.ItemsSource = _evacuator.GetEvacuators();
        }

        private void listSelectorEvacuators_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listSelectorEvacuators.SelectedItem == null)
                return;
            //var element = (FrameworkElement)sender;
            var selectedItem = listSelectorEvacuators.SelectedItem as Evacuators;
            // Navigate to the next page
            MakeCall(selectedItem.Name, selectedItem.Number);
            //NavigationService.Navigate(new Uri("/nextpage.xaml", UriKind.Relative));

            // Reset selected item to null
            listSelectorEvacuators.SelectedItem = null;
        }
        private void MakeCall(string name, string number)
        {
            var phoneTask = new PhoneCallTask
            {
                DisplayName = name,
                PhoneNumber = number
            };
            phoneTask.Show();
        }
    }
}