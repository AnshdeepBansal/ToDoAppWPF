using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace ToDoAppWPF
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();

        public MainWindow()
        {
            InitializeComponent();
            taskListBox.ItemsSource = Tasks;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTask.Text))
            {
                Tasks.Add(new TaskItem { Name = txtTask.Text, IsCompleted = false });
                txtTask.Clear();
            }
        }

        private void RemoveTask_Click(object sender, RoutedEventArgs e)
        {
            var selectedTask = taskListBox.SelectedItem as TaskItem;
            if (selectedTask != null)
            {
                Tasks.Remove(selectedTask);
            }
        }
    }

    public class TaskItem : INotifyPropertyChanged
    {
        private bool _isCompleted;
        public string Name { get; set; }

        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                _isCompleted = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCompleted)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
