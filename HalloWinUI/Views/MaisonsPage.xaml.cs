using HalloWinUI.Data;
using HalloWinUI.ViewModels.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace HalloWinUI.Views
{

    public sealed partial class MaisonsPage : Page
    {
        public MainMaisonsViewModel ViewModel { get; }

        public MaisonsPage()
        {
            InitializeComponent();
            ViewModel = new MainMaisonsViewModel(new HalloweenDataProvider());
            root.Loaded += Root_Loaded;
        }

        private void Root_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.ChargerMaisons();
        }

        private async void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.MaisonSelectionnee == null)
            {
                return;
            }

            // Affichage d'une bo�te de dialogue de confirmation de suppression
            ContentDialog dialog = new ContentDialog
            {
                Title = "Confirmer la suppression",
                Content = $"�tes-vous s�r de vouloir supprimer la maison � l'adresse :\n{ViewModel.MaisonSelectionnee.Adresse}?",
                PrimaryButtonText = "Supprimer",
                CloseButtonText = "Annuler",
                DefaultButton = ContentDialogButton.Close
            };

            dialog.XamlRoot = this.Content.XamlRoot;

            ContentDialogResult result = await dialog.ShowAsync();

            // Si l'utilisateur a cliqu� sur le bouton "Supprimer"
            if (result == ContentDialogResult.Primary)
            {
                
            }
        }
    }
}
