   M S B A M L   `   `   `  ����I  EUdpHost, Version=1.0.8031.17438, Culture=neutral, PublicKeyToken=nullA%clr-namespace:UdpHost.MVVM.ViewModelsUdpHost.MVVM.ViewModels  5   	   7 clr-namespace:UdpHost.MVVM.ViewsUdpHost.MVVM.Views  5   	   7 clr-namespace:UdpHost.PropertiesUdpHost.Properties  5	   	   #    UdpHost.MVVM.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   .vm%clr-namespace:UdpHost.MVVM.ViewModels  5   	   (v clr-namespace:UdpHost.MVVM.Views  5   	   /settings clr-namespace:UdpHost.Properties  5	   	     � Icon$%  pack://application:,,,/Icon.ico��5   	   $��Verdana)�5   	   $��12(�6   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�5   	   ���	#FFF3F3F3$	��400��5   	   $	��450��6    (  $CustomizedWindowWithoutNonclientArea#��[  5   	    � Title$ UdpHost��5   	   
 � Top 5   	   ��  �� Path$	 Top�$  UdpHost.Properties.AppSettings   Settings �� Source# Z  �� Mode$ TwoWay=� � Left 5   	   �� $
 Left�# Z $ TwoWay=���5   	   �� $ Width�# Z $ TwoWay=���5   	   �� $ Height�# Z $ TwoWay=�	 � 	Resources	 5      
 �� DataType/   )UdpHost.MVVM.ViewModels.ExchangeViewModel%   UdpHost.MVVM.Views.ExchangeView+   %UdpHost.MVVM.ViewModels.InfoViewModel!   UdpHost.MVVM.Views.InfoView��%�   (��       5      *, +)(�� 2     5      *, +)�� 5   
   "
  6   .R�5        5      �� 5   
   "
  6   .R�5        5      5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .	  (System.Windows.Interactivity.TriggerBase 	  Actions. 5       6
  0System.Windows.Interactivity.InvokeCommandAction
   
  Command 6$   �� $ Loaded�5!        5"   
   $ Closed��6   . 5#      
   6$   �� $ Closed�5$      .��5&      �  � RowDefinitions 5'   
   �� 5(      $��25 �6   �� 5)      .+�5,   
   �� $��0��6    �� Orientation$ 
Horizontal=�5-      $��Bottom=�5.      .+�5/      	� $��1,0,0,0q�6     TopMenuRadioButton#��[ 50      $��
Обмен��51      $��Exchange��54       d� 	IsChecked 52      �� $ RBExchangeIsChecked���53      �� *	SetView+54      	� 55      $��0,0,0,0q�6   #��[ 56      $��Инфо��57      $
��Info��59      ��58      �� *	SetView+59      5:      �� 5;   
   $��1��6   
���  ����5=      �� *CurrentView+5>      5?      