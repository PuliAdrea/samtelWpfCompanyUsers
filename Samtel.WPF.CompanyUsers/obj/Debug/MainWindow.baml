   M S B A M L   `   `   `  ����  Samtel.WPF.CompanyUsers(    "Samtel.WPF.CompanyUsers.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Gestión de Usuarios��5   	   $	��500��6%   $	��900��62   ���#F0F0F0.��5      � $��20q�6    � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $
��2.5* �6   .+�5   
   �� $��0��6   $��0��6"   $��10q�62   $	��Top=�6>   .+�5      �� $��Nombre��6   $
��Bold"�6%   �� 5      -   5         ��Name$ txtFirsName��5      $��0,0,0,10q�6+   $��5q�6=   $	��250��6I   �� 5      $��Apellido��6   $
��Bold"�6'   �� 5      -   5        $ txtLastName��5      $��0,0,0,10q�6+   $��5q�6=   $	��250��6I   �� 5      $��Correo Electrónico��6   $
��Bold"�61   �� 5      -   5        $ txtEmail��5      $��0,0,0,10q�6(   $��5q�6:   $	��250��6F   �� 5      $��	Teléfono��6   $
��Bold"�6'   �� 5       -   5        $ txtPhone��5       $��0,0,0,10q�6(   $��5q�6:   $	��250��6F   �� 5"      -   5        $��Guardar usuario��5"      $	��150��5#      $��30��6!   $
��Left=�6-   ���#4CAF50
�������$��0,10,0,0q�5$   =   5%      &   System.Windows.Controls.DataGrid  5(   
   -   5          Name$ dgUser��5(      $��0��6#   $��1��60   $��2��5)         AutoGenerateColumns . $��10q�6?   $��Stretch=�5+      $��Stretch=�6/      AlternatingRowBackground
 �����5,      �� 5/   
   $��1��6   $��0��6"    �� Orientation$ 
Horizontal=�62   $
��Left=�6K   $��10q�6f   .+�50      �� -   5        $��Editar usuario��50      $	��120��51      $��30��6!   ���#2196F3
�������$��0,0,10,0q�6U   �� 52      -   5        $��Gestionar Departamentos��52      $	��180��53      $��30��6!   ���#FFC107
�������6B   54      55      56      