using System;
using System.Windows;

namespace SARTE_Personal_DashBoard.Pages
{
    public partial class AddEditTask : Window
    {
        // Flag to determine whether we're adding or editing
        public bool IsEditing { get; set; }
        public string TaskName { get; set; }

        // Constructor for adding a new task
        public AddEditTask()
        {
            InitializeComponent();
            IsEditing = false;  // Default is adding a new task
            tbTaskNameInput.Clear();
            lblAddEdit.Content = "Enter new task name";
            this.Title = "Adding Task";
        }

        // Constructor for editing an existing task
        public AddEditTask(string existingTask)
        {
            InitializeComponent();
            IsEditing = true;  // Editing mode
            
            tbTaskNameInput.Text = existingTask;
            lblAddEdit.Content = "Enter updated task name";
            this.Title = "Editing Task";
        }

        // Method to handle the Save button click (either add or edit task)
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TaskName = tbTaskNameInput.Text;

            // Validation: Task name should not be empty
            if (string.IsNullOrEmpty(TaskName))
            {
                MessageBox.Show("Task name cannot be empty.");
                return;
            }

            // Trigger save for add or edit depending on the flag
            DialogResult = true;
            this.Close();
        }
    }
}
