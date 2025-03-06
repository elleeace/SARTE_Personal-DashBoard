using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SARTE_Personal_DashBoard.Pages
{
    public partial class ToDoList : Page
    {
        // List to hold the tasks
        public static List<string> tasks = new List<string>();

        public ToDoList()
        {
            InitializeComponent();
            UpdateTaskList();
        }

        // Method to update the ListBox with current tasks
        private void UpdateTaskList()
        {
            lbTasks.Items.Clear();
            foreach (var task in tasks)
            {
                lbTasks.Items.Add(task);
            }
        }

        // Method to handle Add Task button click
        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            AddEditTask atf = new AddEditTask();  // Create the AddEditTask (for adding)
            if (atf.ShowDialog() == true)  // Show form and check if Save is clicked
            {
                string taskName = atf.TaskName;
                if (!tasks.Contains(taskName))
                {
                    tasks.Add(taskName);  // Add new task to list
                    UpdateTaskList();
                }
            }
        }

        // Method to handle Edit Task button click
        private void btnEditTask_Click(object sender, RoutedEventArgs e)
        {
            // Check if there are tasks in the list
            if (lbTasks.Items.Count > 0)
            {
                // Check if a task is selected
                if (lbTasks.SelectedItem != null)
                {
                    string oldTaskName = lbTasks.SelectedItem.ToString();
                    AddEditTask atf = new AddEditTask(oldTaskName);  // Pass existing task for editing

                    if (atf.ShowDialog() == true)  // Show form and check if Save is clicked
                    {
                        string newTaskName = atf.TaskName;

                        // Update the task if the name has changed
                        if (!string.IsNullOrEmpty(newTaskName) && newTaskName != oldTaskName)
                        {
                            int index = tasks.IndexOf(oldTaskName);
                            if (index != -1)
                            {
                                tasks[index] = newTaskName;  // Replace the old task with the new one
                                UpdateTaskList();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a task to edit.");
                }
            }
            else
            {
                MessageBox.Show("There are no tasks yet.");
            }
        }

        // Method to handle Remove Task button click
        private void btnRemoveTask_Click(object sender, RoutedEventArgs e)
        {
            if (lbTasks.SelectedItem != null)
            {
                string taskName = lbTasks.SelectedItem.ToString();

                // Ask the user for confirmation before removing the task
                MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to remove the task: '{taskName}'?",
                    "Confirm Removal",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                );

                if (result == MessageBoxResult.Yes)
                {
                    tasks.Remove(taskName);  // Remove task from the list
                    UpdateTaskList();  // Update the list display
                }
            }
            else
            {
                MessageBox.Show("Please select a task to remove.");
            }
        }

    }
}
