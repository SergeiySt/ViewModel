   M S B A M L   `   `   `  ����K  GStudentViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:StudentViewModelStudentViewModel  5   	   !    StudentViewModel.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:StudentViewModel     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ 
MainWindow��5	   	   $	��450��6   $	��709��6)    � WindowStartupLocation$ CenterScreen=�65    � Icon$ /student_.ico��6Z   .��5
      � .+�5   
   �� -   5         ��Name$ listBoxStudent��5      $	��NaN��6*   $��
10,49,0,10q�67   $	��320��6K   $
��Left=�6�   ��6W   �� *
Students+ �� SelectedItem 6y   �� *SelectedStudent+��5      �� 5      .R�5      �� $��5q�6!   .+�5      �� $��0��6@   ��6$   �� *
id_student+6@   �� 5      $��18(�6$   $
��Bold"�6L   ��62   �� *
SSurName+6L   �� 5      ��6$   �� *SName+�� 5      ��6$   �� *SAge+5      5      5      �� 5   
   $��Студенти:��6   $
��Left=�6$   $��	10,10,0,0q�6?   $	��Top=�6R   $��18(�6j   $
��Bold"�6x   ���	#FF21880C6�   �� 5   
   $��Ім'я:��6   $��
396,88,0,0q�6    $	��Top=�64   $��22(�6L    J� RenderTransformOrigin$ 0.885,-0.063&�6Z   $
��Left=�6   $��52��6�   �� 5   
   $��Прізвище:��6   $��
335,49,0,0q�6$   $	��Top=�68   $��22(�6P   $
��Left=�6^   $	��113��6y   �� 5   
   $��Вік:��6   $��404,127,0,0q�6   $	��Top=�64   $��22(�6L   $
��Left=�6Z   $��44��6u   �� 5   
   $��458,53,24,0q�6a    �� TextWrapping$
 Wrap=�6v   $	��Top=�6�   $��22(�6�   ���	#FF2923EF��6   �� *SelectedStudent.SSurName+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��458,92,24,0q�6^   $
 Wrap=�6s   $	��Top=�6�   ���	#FF2923EF$��22(�6�   ��6   �� *SelectedStudent.SName+$ PropertyChanged=�6�   �� 5   
   $��458,131,24,0q�6]   $
 Wrap=�6s   $	��Top=�6�   ���	#FF2923EF$��22(�6�   ��6   �� *SelectedStudent.SAge+$ PropertyChanged=�6�   �� 5!   
   $��Додати��68   $
��Left=�6I   $��342,363,0,0q�6d   $��94��6y   $��16(�6�   $��36��6�   $	��Top=�6�   ��6   �� *AddStudentCommand+6�   �� 5"   
   $��Видалити��6;   $��605,363,10,0q�6N   $��16(�6d   $��36��6r   $	��Top=�6~   ��6   �� *RemoveStudentCommand+6~   �� 5#   
   $��Оновити��6<   $
��Left=�6N   $��470,363,0,0q�6i   $��92��6~   $��16(�6�   $��36��6�   $	��Top=�6�   ��6   �� *UpdateStudentCommand+6�   �� 5$   
   $	��147��6   $��342,192,19,0q�6   $	��Top=�63   $��/pngwssm.png��6K   $��UniformToFill=�6a   5%      5&      