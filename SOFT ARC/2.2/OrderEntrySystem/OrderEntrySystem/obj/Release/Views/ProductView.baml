   M S B A M L   `   `   `  ����   OrderEntrySystem"    OrderEntrySystem.ProductView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � 	Resources   �� Source�� $ SharedResources.xaml?�%    .��� .+��� -    ��Name$ lblLocation��$��0��$��0��$��	Location:��$
��Left=�$��0,7,0,0q�$	��Top=��� -    ��Name$ txtLocation��$��2��$��0��$
��Left=�$��23��$��	1.4,7,0,0q�$	��Top=�$	��120������ *	Locations+ �� SelectedItem �� *
Location+�� -   $ lblName��$��Name:��$��0��$��2���� -    ��Name$ txtName��$��2��$��2��$
��Left=�$��23��$��1.4,5.2,0,6.2q� �� TextWrapping$
 Wrap=�$	��120������  �� Path$
 Name� �� UpdateSourceTrigger$ PropertyChanged=��� -   $ lblDescription��$��Description:��$��0��$��4���� -   $ txtDescription��$��2��$��4��$
��Left=�$��23��$��1.4,5.2,0,6.2q�$
 Wrap=�$	��120������ $ Description�$ PropertyChanged=��� -   $ lblPrice��$��Price:��$��0��$��6���� -   $ txtPrice��$��2��$��6��$
��Left=�$��23��$��1.4,5.2,0,7.8q�$
 Wrap=�$	��120������ $ Price�$ PropertyChanged=��� -	   $ lblCondition��$��
Condition:��$��0��$��8���� -
   $ cmbConditions��$��2��$��8������ *
Conditions+ �� *	Condition+�� -   $ lblCategory��$��Categories:��$��0��$��10���� -   $ cmbCategory��$��2��$��10������ *
Categories+ �� *
Category+��    HorizontalCommandsTemplate#��[  $��2��$��12������ *
Commands+	 � ColumnDefinitions	 �� $
��Auto ��� $��4 ��� $��* �
 � RowDefinitions
 �� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto ��� $��4 ��� $
��Auto �