   M S B A M L   `   `   `  ����@  <MITRA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MITRA.MachinMITRA.Machin  5          MITRA.Machin.MachineAdd   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:MITRA.Machin     5        N� Title$  
MachineAdd��5	      .��5
      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��Название��6   $��30��6$   $	��100��60   �� 5   
   $��Тип��6   $��1��6   $��30��6,   $	��100��68   �� 5   
   $��1��6,   $��30��6<   $��0,0,10,0q�6H   $��2��6Z   ��6   �� *Название+6Z   �� 5   
   -   5         ��Name$ 	ComboPost��5   f   $��1��6=   $��1��6M   $��30��6Z    �� DisplayMemberPath$ Название��6�    �� SelectedItem 6   �� *!Тип_оборудования+6�   �� 5   
   -   5         ��Name$ typeadd��5      $��2��6"   $��1��62   $��10q�6?   $��30��6K   .��5      �� $��/res/wing.png��6   $��25��6+   $��25��66   5      5      �� 5    
   -   5        $��BtnAdd��5    o   $��Сохранить��6   $��3��6%   $��9��69   $��0��6F   $	��200��6W   $��25��6c   6}   � 5!   
    K� ZIndex$ -2��6   
�������$��9��63   $��3��6@   5#      5$      