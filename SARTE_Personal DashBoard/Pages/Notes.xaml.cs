using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SARTE_Personal_DashBoard.Pages
{
    public partial class Notes : Page
    {
        // List to hold the notes
        private List<Note> notes = new List<Note>();

        public Notes()
        {
            InitializeComponent();

            // Clear any default items from ListBox if present
            lbNotes.ItemsSource = null;

            // Sample notes (initializing only when the page is created)
            notes.Add(new Note("Note 1", "01/01/2023", "This is the content of note 1."));
            notes.Add(new Note("Note 2", "01/02/2023", "This is the content of note 2."));
            notes.Add(new Note("Note 3", "01/03/2023", "This is the content of note 3."));

            // Populate the ListBox with notes
            lbNotes.ItemsSource = notes;

            
        }

        private void btnAddNote_Click(object sender, RoutedEventArgs e)
        {
            // Create a new NoteDetails page for adding a new note
            var noteDetailsPage = new NoteDetails();

            // Disable the Edit button and enable Save button when adding a note
            btnAddNote.IsEnabled = false; // Disable Add button while editing
            noteDetailsPage.btnEditNote.Content = "Save"; // Show Save button
            noteDetailsPage.tbNoteTitleInput.IsEnabled = true;
            noteDetailsPage.tbNoteDateInput.IsEnabled = true;
            noteDetailsPage.tbNoteContent.IsEnabled = true;

            // Pass the SaveNewNote method to the NoteDetails page
            noteDetailsPage.SaveNoteAction = SaveNewNote;

            // Display the NoteDetails page inside the Frame
            NotesFrame.Content = noteDetailsPage;
        }

        private void SaveNewNote(string title, string date, string content)
        {
            // Add new note when saved
            var newNote = new Note(title, date, content);
            notes.Add(newNote);

            // Refresh the ListBox with the updated list
            lbNotes.ItemsSource = null;
            lbNotes.ItemsSource = notes; // Refresh the ListBox
        }

        private void lbNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enable Add button and disable Edit button if item is selected
            if (lbNotes.SelectedItem != null)
            {
                var selectedNote = (Note)lbNotes.SelectedItem;

                // Display note details in the Frame for editing
                NoteDetails noteDetailsPage = new NoteDetails();
                
                noteDetailsPage = new NoteDetails(selectedNote.Title, selectedNote.Date, selectedNote.Content)
                {
                    SaveNoteAction = (title, date, content) =>
                    {
                        // Update the note when it's saved

                      

                        selectedNote.Title = title;
                        selectedNote.Date = date;
                        selectedNote.Content = content;

                        noteDetailsPage.tbNoteContent.IsEnabled = false;
                        noteDetailsPage.tbNoteDateInput.IsEnabled = false;
                        noteDetailsPage.tbNoteTitleInput.IsEnabled = false;



                        // Refresh the ListBox with the updated list
                        lbNotes.ItemsSource = null;
                        lbNotes.ItemsSource = notes;  // Refresh the ListBox
                    }
                };

                NotesFrame.Content = noteDetailsPage;
                btnAddNote.IsEnabled = true; // Enable Add button while editing
            }
        }
    }
}
