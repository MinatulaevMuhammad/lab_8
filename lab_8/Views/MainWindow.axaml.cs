using Avalonia.Controls;
using lab_8.Models;

namespace lab_8.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            this.FindControl<MenuItem>("NewKanbanBoard").Click += delegate
            {
                var context = this.DataContext as lab_8.ViewModels.MainWindowViewModel; 
                context.clear();                                                        
            };

            
            this.FindControl<MenuItem>("SaveKanbanBoard").Click += async delegate
            {
                var dialog_window = new SaveFileDialog().ShowAsync(this.VisualRoot as MainWindow);  

                string path = await dialog_window;  

                var context = this.DataContext as lab_8.ViewModels.MainWindowViewModel; 

                if (path != null)
                {
                    context.saveBoardInFile(path);
                }
            };

            
            this.FindControl<MenuItem>("LoadKanbanBoard").Click += async delegate
            {
                var dialog_window = new OpenFileDialog().ShowAsync(this.VisualRoot as MainWindow);  

                string[] path = await dialog_window;        

                var context = this.DataContext as lab_8.ViewModels.MainWindowViewModel; 

                if (path != null)
                {
                    context.loadBoardFromFile(path[0]);
                }
            };

            
            this.FindControl<MenuItem>("ExitKanbanBoard").Click += delegate
            {
                this.Close();
            };

            
            this.FindControl<MenuItem>("WhoDone").Click += async delegate
            {
                await new AboutWindow().ShowDialog(this.VisualRoot as MainWindow);
            };
        }

        public async void addImage(Task task)
        {
            var dialog_window = new OpenFileDialog().ShowAsync(this.VisualRoot as MainWindow);  

            var path = await dialog_window; 

            if (path != null)
            {
                task.setImage(path[0]);
            }
        }
    }
}