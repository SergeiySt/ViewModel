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
using System.Windows;
using System.Windows.Input;

namespace StudentViewModel.VirtualModel
{
   internal class StudentViewModel2 : INotifyPropertyChanged
    {
        private string conect = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        
        private string surname;
        private string name;
        private int age;
        private int id;
        private ObservableCollection<Student> students;
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
        public string SSurName
        {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged(nameof(SSurName));
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

        public ObservableCollection<Student> Students
        {
            get { return students; }
            set
            {
                if (students != value)
                {
                    students = value;
                    OnPropertyChanged(nameof(Students));
                }
            }
        }

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
  
        public StudentViewModel2()
        {
            LoadStudent();
        }

        private void LoadStudent()
        {
            var studentDataBase = new StudentDataBase(conect);

            Students = new ObservableCollection<Student>(studentDataBase.SelectedStudents());

            AddStudentCommand = new RelayCommand(AddStudent);
            UpdateStudentCommand = new RelayCommand(UpdateStudent);
            RemoveStudentCommand = new RelayCommand(DeleteStudent);
        }

        public RelayCommand AddStudentCommand { get; private set; }
        public RelayCommand UpdateStudentCommand { get; private set; }
        public RelayCommand RemoveStudentCommand { get; private set; }


        private void AddStudent()
        {
            var studentDataBase = new StudentDataBase(conect);

            if (SelectedStudent == null)
            {
                MessageBox.Show("Виберіть студента.", "Увага", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (studentDataBase.IsStudentExist(SelectedStudent.SSurName, SelectedStudent.SName))
            {
                MessageBox.Show("Студент із таким ім'ям та прізвищем вже існує", "Увага", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            studentDataBase.AddStudent(SelectedStudent.SSurName, SelectedStudent.SName, SelectedStudent.SAge);

            LoadStudent();
        }

        private void UpdateStudent()
        {
            var studentDataBase = new StudentDataBase(conect);

            if (SelectedStudent == null)
            {
                MessageBox.Show("Виберіть студента.", "Увага", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            studentDataBase.UpdateStudent(SelectedStudent.id_student, SelectedStudent.SSurName, SelectedStudent.SName, SelectedStudent.SAge);
           
            LoadStudent();
        }

        private void DeleteStudent()
        {
            var studentDataBase = new StudentDataBase(conect);

            if (SelectedStudent == null)
            {
                MessageBox.Show("Виберіть студента.", "Увага", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageBox.Show("Ви точно хочете видалити студента?", "Попередження", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                studentDataBase.DeleteStudent(SelectedStudent.id_student);
                MessageBox.Show("Успішно видалено", "Успішно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            LoadStudent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
