   M S B A M L   `   `   `  ����J  FProjekat_B-Kviz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Projekat_B_KvizProjekat_B_Kviz  5   	        Projekat_B_Kviz.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Projekat_B_Kviz     5   	     � Title$  Welcome to quiz game!��5   	   $	��800��6'   $	��800��64    � 
ResizeMode$ NoResize=�6@    � Icon$H BC:\Users\PC\Desktop\4 GODINA\HCI\Projekti\Projekat_B-Kviz\Icon.jpg��5	   	   .��5      � ��5   
   �� 5       �� ImageSource$N HC:\Users\PC\Desktop\4 GODINA\HCI\Projekti\Projekat_B-Kviz\Background.jpg��6    �� Opacity$	 0.8Q�6p    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $
��Left=�6"   $	��Top=�6=    �� Orientation$ 
Horizontal=�6U   $��10q�6n   .+�5      �� -   5         ��Name$ LevelSelector��5      $��22��6.   $	��149��6:    �� 
IsEditable$
 True��6F   	 �� Text$	 Choose difficulty��6X   
 �� 
IsReadOnly$

 True��6q   ���#ffcc00.@�5      �� -   5         ��Name$ questions10��5   =   $��Easy (10 questions)��6   6=   �� 5      -   5        $ questions20��5   =   $��Hard (20 questions)��6   6=   5      �� 5      -   5        $��StartQuizButton��5      $��
Start Quiz��6,   $��27��6A   $	��150��6M   $��10q�6Y   
���E��
�������$
��Bold"�6�   5      �� 5    
   $	��Top=�6   $
��Left=�6-   $ Vertical=�6H   $��
10,163,0,0q�6_   $��2��6s   .+�5!      �� -   5         ��Name$ QuestionText��5!      $��Question will appear here��6.   $��22(�6O   $
��Bold"�6]   
�������$
��Wrap=�6�   $	��600��6�    �� TextAlignment$ Center=�6�   $��10q�6�   
���E��6�   �� 5#      -   5         ��Name$ Answer1��5#      $��Answer 1��6&   $	��300��69   $��50��6E   ���#ffb366
�������$��16(�6y   $��5q�6�   �� 5$      -   5        $ Answer2��5$      $��Answer 2��6&   $	��300��69   $��50��6E   ���#ffb366
�������$��16(�6y   $��5q�6�   �� 5%      -   5        $ Answer3��5%      $��Answer 3��6&   $	��300��69   $��50��6E   ���#ffb366
�������$��16(�6y   $��5q�6�   5&      �� 5)   
   $��Right=�6   $	��Top=�61   $��10q�6I   .+�5*      �� $��Score:��6   $��18(�6&   $
��Bold"�64   
���E��6F   �� 5+      -	   5        $ 	ScoreText��5+      $��0��6+   $��18(�64   
���E��6B   �� 5,      $��Correct answers:��6   $��18(�60   $
��Bold"�6>   
���E��6P   �� 5-      -
   5        $ 
CorrectNum��5-      $��0��6,   $��18(�65   
���E��6C   �� 5.      $��Left questions:��6   $��18(�6/   $
��Bold"�6=   
���E��6O   �� 5/      -   5        $ LeftQuestionsNum��5/      $��0��62   $��18(�6;   
���E��6I   �� 51      -   5        $��End Game��51      $	��150��6>   $��40��6J   ���#ffb366
�������$��10q�6   $
��Bold"�6�   �� 52      -   5        $��Restart game��52      $	��150��6F   $��40��6R   ���#ffb366
�������$��10q�6�   $
��Bold"�6�   �� 53      -   5        $
��Help��53      $	��150��67   $��40��6C   ���#ffb366
�������$��10q�6w   $
��Bold"�6�   54      55      56      