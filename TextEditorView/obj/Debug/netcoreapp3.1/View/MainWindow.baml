   M S B A M L   `   `   `  ����I  ETextEditorView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TextEditorView.ViewTextEditorView.View  5   	   $    TextEditorView.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:TextEditorView.View     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$	  Vim��5	   	   $	��200��6   $	��100��6%   $	��730��64   $	��530��6@    � Icon$ /View/MainWindowFoto.jpg��6M    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.New��5      6>     5   
   -   5        $ ApplicationCommands.Open��5      6>     5   
   -   5        $ ApplicationCommands.Save��5      6>     5   
   -   5        $  ApplicationCommands.SaveAs��5      6>    � 	Resources 5         OnOffToggleImageStyle �� 
TargetType �� Triggers P� Property P� Value	 �� Property
 �� Value  	FolderImg  
SpecialImg  SettImg  
Proccessor��%�  &	        &	 �     &	 '    &	 V    &	 �    �� 5   
   " d�6.    5      P� 5       �@d�	IsChecked$
 TrueY�6/   . �5      �� 	 � ��

 �   �63   5      P� 5       �@d�	IsChecked$ FalseY�6/   . �5      �� 	 � ��
 �	#ffdadada64   5      5      �� 5   
   $��/View/FotoFolder.jpg��6"   �� 5   
   $��/View/FotoSpecial.jpg��6#   �� 5   
   $��/View/settings.png��6    �� 5   
   $��/View/Proccessor.jpg��6#   5      .��5!      � -   5         �Name$ MainGrid��5!      ���	#ffdadada � RowDefinitions 5"   
   �� 5#      $
��Auto �6   �� 5$      $
��Auto �6   �� 5%      .+�5(   
   � $��2��6    � ColumnDefinitions 5)      �� 5*      $
��Auto �6#   �� 5+      �� 5,      $
��Auto �6#   .+�5/      � $��1��6   $��1��6     50      �� 51      $
��Auto �6$   �� 52      .+�55      �� -   5         ��Name$ ButtonsChangeFlowDoc��55   (   $��0��6   $
��Auto=�6F   ��56      �� 57      .R�58      �  K� IsItemsHost$
 True��6(   59      ��5;      �� 5<      " ��6    .�5=      �� 	 � ��$
 0q�68   �� 5>      	 � |�$
 False��6:   5?      5A      �� 5C      $��1��6   $��7q�6&   
�������$��Stretch=�6D   $��Stretch=�6`    �� CornerRadius$ 20��6~    J� Effect 5D      3  -System.Windows.Media.Effects.DropShadowEffect  5E         
BlurRadius$ 50Q�6+      Color$ 	LightGray��6;      ShadowDepth$ 0Q�6M   ._�5H      � -   5         5I      �� 5J      �� 5K      $
��Auto �6,   .+�5M      �� -   5         ��Name$ Text_Container��5M   '   $��0��6?   $��Stretch=�6L   $��Stretch=�6h   $��
15 15 15 0q�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   �� 5N      -	   5         ��Name$ File_Path_Text��5N   $   $��1��6=   $��Right=�6J   $��0 0 15 0q�6f   5O      5Q      5S      � 5U      -
   5        $ LeftWorkPanel��5U      $��0��6*    5V      �� 5W      �� 5X      $
��Auto �6'   .+�5[      � $��0��6    5\      �� 5]      $��40 �6(   �� 5^      $��40 �6(   �� 5_      $��40 �6(   �� 5`      $��40 �6(   .+�5c      d� -   5         d�Name$ Button_Folder��5c   #   #��[  6>   #��[ 6m   $��0��6�   $��0��6�   $	��Top=�6�    d� 	IsChecked$ FalseY�6�   6�   d� 5d      -   5        $ Button_Special��5d   #   #��[  6>   #��[ 6m   $��0��6�   $��1��6�   $	��Top=�6�   $ FalseY�6�   6�   d� 5f      -   5        $ Button_Proccessor��5f   #   #��[  6>   #��[ 6m   $��0��6�   $��2��6�   $	��Top=�6�   $ FalseY�6�   6�   5g      5k      5m      5q      5r      