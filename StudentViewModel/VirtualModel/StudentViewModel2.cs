using StudentViewModel.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentViewModel.VirtualModel
{
   internal class StudentViewModel2 : INotifyPropertyChanged
    {
        private string conect = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        
        MainWindow mainWindow = new MainWindow();
        private string surname;
        private string name;
        private int age;
        private int id;
        //private ObservableCollection<Student> students;
        private Student selectedStudent;

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        public string SSurname
        {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged(nameof(SSurname));
                }
            }
        }

        public string SName
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(SName));
                }
            }
        }

        public int SAge
        {
            get { return age; }
            set
            {
                if (age != value)
                {
                    age = value;
                    OnPropertyChanged(nameof(SAge));
                }
            }
        }

        //public ObservableCollection<Student> Students
        //{
        //    get { return students; }
        //    set
        //    {
        //        if (students != value)
        //        {
        //            students = value;
        //            OnPropertyChanged(nameof(Students));
        //        }
        //    }
        //}

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                if (selectedStudent != value)
                {
                    selectedStudent = value;
                    OnPropertyChanged(nameof(SelectedStudent));
                }
            }
        }

        public ICommand AddStudentCommand { get; set; }
        public ICommand RemoveStudentCommand { get; set; }
        public ICommand UpdateStudentCommand { get; set; }

        public StudentViewModel2()
        {
            // Инициализация команд
            AddStudentCommand = new RelayCommand(AddStudent);
            RemoveStudentCommand = new RelayCommand(DeleteStudent);
            UpdateStudentCommand = new RelayCommand(UpdateStudent);

            LoadStudent();
        }

        private void LoadStudent()
        {
            var studentDataBase = new StudentDataBase(conect);
            
            mainWindow.listBoxStudent.Items.Clear();
            mainWindow.listBoxStudent.ItemsSource = studentDataBase.SelectedStudents();
            mainWindow.listBoxStudent.DataContext = studentDataBase;
        }
        private void AddStudent()
        {
            var studentDataBase = mainWindow.listBoxStudent.DataContext as StudentDataBase;
            if(studentDataBase != null)
            {
                studentDataBase.AddStudent(SSurname, SName, SAge);
                mainWindow.listBoxStudent.ItemsSource = studentDataBase.SelectedStudents();
            }
        }

        private void UpdateStudent()
        {
            var studetDataBase = mainWindow.listBoxStudent.DataContext as StudentDataBase;
            if(studetDataBase != null && selectedStudent != null)
            {
                studetDataBase.UpdateStudent(Id, SSurname, SName, SAge);
                mainWindow.listBoxStudent.ItemsSource = studetDataBase.SelectedStudents();
            }
        }

        private void DeleteStudent()
        {
            var studetDataBase = mainWindow.listBoxStudent.DataContext as StudentDataBase;
            if (studetDataBase != null && mainWindow.listBoxStudent.SelectedItem != null)
            {
                studetDataBase.DeleteStudent(SelectedStudent.id_student);
                mainWindow.listBoxStudent.ItemsSource = studetDataBase.SelectedStudents();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
