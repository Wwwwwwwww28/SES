   M S B A M L   `   `   `  ���� @  <MITRA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MITRA.MachinMITRA.Machin      MITRA.Oreders.OredersPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:MITRA.Machin     -     N� Title$  OredersPage��.���  � ColumnDefinitions �� $��* ��� $	��125 �.+�&   System.Windows.Controls.DataGrid  -     Name$ нарядDataGrid��   AutoGenerateColumns .     
IsReadOnly .    EnableRowVirtualization . $��10q�   RowDetailsVisibilityMode$ VisibleWhenSelected=�$��0��   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   numberColumn��,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *
Номер+  -   	envColumn��$ Оборудование��$	 * 
 �� *+)Оборудование.Название+  -   
detaColumn��$ Дата��$	 * 
 �� *
Дата+ �� StringFormat$ {0:dd.MM.yy}��  -   
typeColumn��$ Тип��$	 * 
 �� *Шаблон.Название+  -   statusColumn��$ Статус��$	 * 
 �� *%#Состояние.Название+�  K� ZIndex$ -2��
�������$��1��$��2��.+��� -    ��Name$ 	ComboType��$��0��$��30�� �� DisplayMemberPath$ Название��$	��Top=�$��0,20,0,0q� �� SelectedItem �� *Шаблон+�� -	   $ ComboStatus��$��1��$��30��$ Название��$	��Top=�$��0,55,0,0q� �� *Состояние+�� -
    ��Name$ Search��$��2��
�������$��30��$	��Top=�$��0,90,0,0q��� -    ��Name$ 	BtnCansel��$��3��$��
Сброс��$��30��$	��Top=�$��	0,125,0,0q��� -   $ BtnAdd��$��Добавить��$
��Left=�$	��125��$��	0,0,0,110q�$��31��$��Bottom=��� -   $ BtnEdit��$ ��Редактировать��$
��Left=�$	��125��$��0,0,0,75q�$��31��$��Bottom=��� -   $ BtnDel��$��Удалить��$
��Left=�$	��125��$��0,0,0,40q�$��31��$��Bottom=�