using System;
using System.Windows;
using System.Windows.Controls;

namespace SARTE_Personal_DashBoard.Pages
{
    public partial class NoteDetails : Page
    {
        // Method to handle saving the note from the main page
        public Action<string, string, string> SaveNoteAction;

        public NoteDetails(string title = "", string date = "", string content = "")
        {
            InitializeComponent();

            // Prepopulate fields if editing an existing note
            tbNoteTitleInput.Text = title;
            tbNoteDateInput.Text = date;
            tbNoteContent.Text = content;

            
        }

        // Flag to track if we're in "add new" or "edit" mode
        private bool isEditing = false;

        private void btnSaveNote_Click(object sender, RoutedEventArgs e)
        {
            // If we are in "add new" mode (first click)
            if (!isEditing)
            {
                // Enable text boxes for input
                tbNoteTitleInput.IsEnabled = true;
                tbNoteDateInput.IsEnabled = true;
                tbNoteContent.IsEnabled = true;

                // Change the flag to indicate we are in "edit" mode now
                isEditing = true;

                // Update button content to reflect it's now in "edit" mode
                btnEditNote.Content = "Save Note"; // Change button text to "Save"
            }
            else
            {
                // Validate inputs before saving
                if (string.IsNullOrWhiteSpace(tbNoteTitleInput.Text) ||
                    string.IsNullOrWhiteSpace(tbNoteDateInput.Text) ||
                    string.IsNullOrWhiteSpace(tbNoteContent.Text))
                {
                    MessageBox.Show("Please fill out all fields before saving.");
                    return;
                }

                // If SaveNoteAction is assigned, invoke it with the note data
                SaveNoteAction?.Invoke(tbNoteTitleInput.Text, tbNoteDateInput.Text, tbNoteContent.Text);

                // Disable the text boxes after saving
                tbNoteTitleInput.IsEnabled = false;
                tbNoteDateInput.IsEnabled = false;
              
                tbNoteContent.IsEnabled = false;

                // Clear the fields after saving (for a new note)
                tbNoteTitleInput.Clear();
                tbNoteDateInput.Clear();
                tbNoteContent.Clear();

                // Optionally: Return to the main Notes page or perform any additional action
                // For example, navigate back or close the page

                // Reset the flag to allow for adding a new note in the future
                isEditing = false;

                // Enable the "Add" button again (if necessary)
                // Assuming you have a reference to the Add button in your page
               
            }
        }


     

    }
}
