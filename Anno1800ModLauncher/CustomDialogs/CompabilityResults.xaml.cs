using Anno1800ModLauncher.Helpers;
using MaterialDesignExtensions.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Anno1800ModLauncher.CustomDialogs
{
    public partial class CompabilityResults : MaterialWindow, INotifyPropertyChanged
    {
        private ObservableCollection<KeyValuePair<ModModel, List<ModModel>>> _results = new ObservableCollection<KeyValuePair<ModModel, List<ModModel>>>();
        public ObservableCollection<KeyValuePair<ModModel, List<ModModel>>> Results
        {
            get => _results; set
            {
                _results = value;
                OnPropertyChanged("Results");
            }
        }

        public CompabilityResults(Dictionary<ModModel, List<ModModel>> results)
        {
            foreach (KeyValuePair<ModModel, List<ModModel>> keyValuePair in results) {
                _results.Add(keyValuePair);
            }

            InitializeComponent();

            DataContext = this; 
        }


        private void Overwrite_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool? ShowDialog()
        {
            return base.ShowDialog();
        }



        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raises the PropertyChanged notification in a thread safe manner
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
