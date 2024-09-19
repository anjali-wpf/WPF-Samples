using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFGallery.ViewModels;

namespace WPFGallery.Views
{
    /// <summary>
    /// Interaction logic for CompactPage.xaml
    /// </summary>
    public partial class CompactPage : Page
    {
        private readonly Uri _compactResourceUri = new Uri("pack://application:,,,/PresentationFramework.Fluent;component/DensityStyles/Compact.xaml", UriKind.Absolute);

        public CompactPageViewModel ViewModel { get; }

        public CompactPage(CompactPageViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        private void OnStandardChecked(object sender, RoutedEventArgs e)
        {
            SizeTextBlock.Text = "Standard Size";

            // Remove the Compact theme and apply Standard theme
            RemovePageResourceDictionary(_compactResourceUri);

            // Optionally load the standard theme if necessary
            // LoadPageResourceDictionary(standardResourceUri);
        }

        private void OnCompactChecked(object sender, RoutedEventArgs e)
        {
            SizeTextBlock.Text = "Compact Size";

            // Remove the Compact theme if it exists to avoid duplication
            RemovePageResourceDictionary(_compactResourceUri);

            // Load the Compact theme
            LoadPageResourceDictionary(_compactResourceUri);
        }

        private void RemovePageResourceDictionary(Uri resourceUri)
        {
            var existingResource = Resources.MergedDictionaries
                .FirstOrDefault(rd => rd.Source == resourceUri);

            if (existingResource != null)
            {
                Resources.MergedDictionaries.Remove(existingResource);
            }
        }

        private void LoadPageResourceDictionary(Uri resourceUri)
        {
            ResourceDictionary resources = new ResourceDictionary
            {
                Source = resourceUri
            };

            Resources.MergedDictionaries.Add(resources);
        }
    }
}
