   M S B A M L   `   `   `  ����@  <MITRA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MITRA.MachinMITRA.Machin  5          MITRA.Equip.EquipPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:MITRA.Machin     5      -   5          N� Title$  	EquipPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��125 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ материалDataGrid��5         AutoGenerateColumns .     
IsReadOnly .    EnableRowVirtualization . $��10q�6}      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   $��0��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        номерColumn��,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��5   Q   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6`   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6:   �� *ID+6`     5      -   5        должностьColumn��$ Название��5   [   $
	 Auto 6m   
 6>   �� *Название+6m     5      -   5        кабинетColumn��$ Кол-во��5   W   $
	 Auto 6g   
 6<   �� *Кол_во+6g   5      � 5   
    K� ZIndex$ -2��6   
�������$��1��63   $��2��6C   .+�5      �� -   5         ��Name$ Search��5   )   
�������$��0,20,0,0q�6^   $��30��6p   $	��Top=�6|   �� 5      -   5         ��Name$ 	BtnCansel��5   %   $��
Сброс��6   $��0,55,0,0q�69   $��30��6c   $	��Top=�6o   �� 5      -   5        $ BtnAdd��5   (   $��Добавить��6   $
��Left=�69   $	��125��6T   $��	0,0,0,110q�6u   $��31��6�   $��Bottom=�6�   �� 5      -	   5        $ BtnEdit��5   -   $ ��Редактировать��6   $
��Left=�6?   $	��125��6Z   $��0,0,0,75q�6|   $��31��6�   $��Bottom=�6�   �� 5      -
   5        $ BtnDel��5   '   $��Удалить��6   $
��Left=�68   $	��125��6S   $��0,0,0,40q�6t   $��31��6�   $��Bottom=�6�   5      5!      5"      