   M S B A M L   `   `   `  ����   OrderEntrySystem#    OrderEntrySystem.CustomerView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � 	Resources   �� Source�� $ SharedResources.xaml?�%    .��� .+��� -    ��Name$ lblFirstName��$��0��$��0��$��First Name:��$
��Left=�$��0,7,0,0q�$	��Top=��� -    ��Name$ txtFirstName��$��2��$��0��$
��Left=�$��23��$��	1.4,7,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��120������  �� Path$ 	FirstName� �� UpdateSourceTrigger$ PropertyChanged=��� -   $ lblLastName��$��
Last Name:��$��0��$��2���� -   $ txtLastName��$��2��$��2��$
��Left=�$��23��$��1.4,5.2,0,6.2q�$
 Wrap=�$	��120������ $ LastName�$ PropertyChanged=��� -   $ lblPhone��$��Phone:��$��0��$��4���� -   $ txtPhone��$��2��$��4��$
��Left=�$��23��$��1.4,5.2,0,6.2q�$
 Wrap=�$	��120������ $ Phone�$ PropertyChanged=��� -   $ lblEmail��$��Email:��$��0��$��6���� -   $ txtEmail��$��2��$��6��$
��Left=�$��23��$��1.4,5.2,0,7.8q�$
 Wrap=�$	��120������ $ Email�$ PropertyChanged=��� -	   $ 
lblAddress��$��Address:��$��0��$��8���� -
   $ 
txtAddress��$��2��$��8��$
��Left=�$��23��$��1.4,5.2,0,7.8q�$
 Wrap=�$	��120������ $ Address�$ PropertyChanged=��� -   $ lblCity��$��City:��$��0��$��10���� -   $ txtCity��$��2��$��10��$
��Left=�$��23��$��1.4,5.2,0,7.8q�$
 Wrap=�$	��120������ $
 City�$ PropertyChanged=��� -   $ lblState��$��State:��$��0��$��12���� -   $ txtState��$��2��$��12��$
��Left=�$��23��$��1.4,5.2,0,7.8q�$
 Wrap=�$	��120������ $ State�$ PropertyChanged=���    HorizontalCommandsTemplate#��[  $��2��$��14������ *
Commands+ � ColumnDefinitions �� $
��Auto ��� $��4 ��� $��* � � RowDefinitions �� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto �