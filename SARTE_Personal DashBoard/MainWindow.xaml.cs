using SARTE_Personal_DashBoard.Pages;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SARTE_Personal_DashBoard
{
    public partial class MainWindow : Window
    {
        // Declare pages as properties
        ToDoList ToDoListPage { get; set; }
        Favorites FavoritesPage { get; set; }
        Notes NotesPage { get; set; }
        Media MediaPage { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            // Initialize pages once
            ToDoListPage = new ToDoList();
            FavoritesPage = new Favorites();
            NotesPage = new Notes();
            MediaPage = new Media();
        }

        // Handle ToDo List button click
        private void btnToDoList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = ToDoListPage;  // Set the content to ToDoListPage
        }

        // Handle Media button click
        private void btnMedia_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = MediaPage;  // Set the content to MediaPage
        }

        // Handle Favorites button click
        private void btnFavs_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = FavoritesPage;  // Set the content to FavoritesPage
        }

        // Handle Notes button click
        private void btnNotes_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = NotesPage;  // Set the content to NotesPage
        }

        private void btnNHome_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = null;
        }
    }
}
