   M S B A M L   `   `   `  ���� @  <MITRA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MITRA.MachinMITRA.Machin      MITRA.Machin.MachinePage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:MITRA.Machin     -     N� Title$  MachinePage��.���  � ColumnDefinitions �� $��* ��� $	��125 �.+�&   System.Windows.Controls.DataGrid  -     Name$&  оборудованиеDataGrid��   AutoGenerateColumns .     
IsReadOnly .    EnableRowVirtualization . $��10q�   RowDetailsVisibilityMode$ VisibleWhenSelected=�$��0��   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   номерColumn��,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *ID+  -   должностьColumn��$ Название��$
	 Auto 
 �� *Название+  -   кабинетColumn��$ Тип��$
	 Auto 
 �� *20Тип_оборудования.Название+�  K� ZIndex$ -2��
�������$��1��$��2��.+��� -    ��Name$ Search��
�������$��0,20,0,0q�$��30��$	��Top=��� -    ��Name$ 	ComboType��$��30��$��0,55,0,0q� �� DisplayMemberPath$ Название��$	��Top=� �� SelectedItem �� *20Тип_оборудования.Название+�� -    ��Name$ 	BtnCansel��$��
Сброс��$��0,90,0,0q�$��30��$	��Top=��� -	   $ BtnAdd��$��Добавить��$
��Left=�$	��125��$��	0,0,0,110q�$��31��$��Bottom=��� -
   $ BtnEdit��$ ��Редактировать��$
��Left=�$	��125��$��0,0,0,75q�$��31��$��Bottom=��� -   $ BtnDel��$��Удалить��$
��Left=�$	��125��$��0,0,0,40q�$��31��$��Bottom=�