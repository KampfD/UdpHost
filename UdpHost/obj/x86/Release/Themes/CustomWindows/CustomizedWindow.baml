   M S B A M L   `   `   `  ����   UdpHost2    ,UdpHost.Themes.CustomWindow.CustomizedWindowR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   CloseButton  �� 
TargetType �� 	Resources  Key  NoActiveButtonColor �� Color  ActiveButtonColor  NoActiveImageColor  ActiveImageColor �� Property �� Value �� 
TargetType �� EdgeMode  NoActiveButtonBrush �� Stretch  NoActiveImageBrush �� Triggers	 P� Property
 P� Value N� EnterActions	 �� To �� 
TargetName �� TargetProperty g� FillBehavior  AnimationDuration g� Duration N� ExitActions �� Value �� Binding �� RelativeSource �� AncestorType �� Path �� 
TargetName 	 WindowStateToggleButton �� Rect �� BeginStoryboardName ��Name 
 
HideButton ��Name F�Name  ResizeThumb ( $CustomizedWindowWithoutNonclientArea � RowDefinitions � ColumnDefinitions K� ZIndex  �� CornerRadius! J� Effect3  -System.Windows.Media.Effects.DropShadowEffect"   Color#   ShadowDepth$   
BlurRadius%   Opacity& J� OpacityMask' !� Visual( �� ElementName) d�Name* n�Name+ � Cursor   D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     %�  &	        7  7  7  7  7  7  7  7  7  7  7  7  7  7  &		 �    7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	
 i    7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	 t    &	 �    7 
 7 	 7   7  7  7  7  7  7  7  7  �� "  �� ����NoActiveButtonColor 	#00FF0000���� NoActiveButtonBrush 8   ��ActiveButtonColor 	#FFFF0000���� ActiveButtonBrush 8  ��NoActiveImageColor 	#FFCCCCCC���� NoActiveImageBrush 8  ��ActiveImageColor 	#FFFFFFFF���� ActiveImageBrush 8  E�AnimationDuration 0:0:0.2D�.���  �@^�InitialShowDelay$
 1500����  �@�ToolTip �� $��Закрыть��
���   ���  � |� .  ��  � �� �� " ��.R��� $��border��$ Aliased=�8�� ._�F� $
��path��$ Uniform=�8�� $��2��=����        �@ @ � 5  5 �@  5 � 5 @ �@B @B 	 P� 	 �@J�IsMouseOver
 .  �� .���� .���� 8  $ border��$( "Background.(SolidColorBrush.Color)�$ HoldEnd=�8  �� 8  $
 path��$$ Stroke.(SolidColorBrush.Color)�$ HoldEnd=�8 	  �� .���� .���� 8 
 $ border��$( "Background.(SolidColorBrush.Color)�$ HoldEnd=�8  �� 8  $
 path��$$ Stroke.(SolidColorBrush.Color)�$ HoldEnd=�8  �� $ Normal�� ��  �� $ WindowL�$ WindowState�.a��� $ border�� �@��CornerRadius$ 0,6,0,0���� "  d� ����NoActiveButtonColor 	#00CCCCCC���� NoActiveButtonBrush 8   ��ActiveButtonColor 	#80CCCCCC���� ActiveButtonBrush 8  ��NoActiveImageColor 	#FFCCCCCC���� NoActiveImageBrush 8  ��ActiveImageColor 	#FFFFFFFF���� ActiveImageBrush 8  E�AnimationDuration 0:0:0.2D�.���  � |� .  ��  �@^�InitialShowDelay$
 1500����  �@�ToolTip �� $��Развернуть��
���   ���  � �� �� " d�.R��� $��border��$ Aliased=�8�� ._�F� $
��path��$ Uniform=�8�� 8�� $��1����� .��B� $����M0,0                                                             M0.2,0.2 L0.2,0.8                                                             M0.2,0.8 L0.8,0.8                                                             M0.8,0.8 L0.8,0.2                                                             M1,1C��� $ 0.2,0.2 0.6,0.1� P� 	 �@d�	IsChecked$

 TrueY�. ��� $
 path�� � �� � .��B� $���� M0,0                                                                  M0.2,0.4 L0.2,0.8                                                                 M0.2,0.8 L0.6,0.8                                                                 M0.6,0.8 L0.6,0.4                                                                 M0.4,0.4 L0.4,0.2                                                                 M0.8,0.2 L0.8,0.6                                                                 M0.8,0.6 L0.6,0.6                                                                 M1,1C��� $ 0.2,0.4 0.4,0.1��� $ 0.4,0.2 0.4,0.1���  �@�ToolTip �� $"��Свернуть в окно��
���   � �� $ ActivatedStoryboard���� $ DeactivatedStoryboard��P� 	 �@d�	IsChecked$
 FalseY� �� $ ActivatedStoryboard���� $ DeactivatedStoryboard��P� 	 �@J�IsMouseOver
 .  �� $ ActivatedStoryboard��.���� .���� 8  $ border��$( "Background.(SolidColorBrush.Color)�$ HoldEnd=�8  �� 8 	 $
 path��$$ Stroke.(SolidColorBrush.Color)�$ HoldEnd=�8 
 �� 8  $
 path��$" Fill.(SolidColorBrush.Color)�$ HoldEnd=�8   �� $ DeactivatedStoryboard��.���� .���� 8  $ border��$( "Background.(SolidColorBrush.Color)�$ HoldEnd=�8  �� 8  $
 path��$$ Stroke.(SolidColorBrush.Color)�$ HoldEnd=�8  �� 8  $
 path��$" Fill.(SolidColorBrush.Color)�$ HoldEnd=�8  �� "  �� ����NoActiveButtonColor 	#00CCCCCC���� NoActiveButtonBrush 8   ��ActiveButtonColor 	#80CCCCCC���� ActiveButtonBrush 8  ��NoActiveImageColor 	#FFCCCCCC���� NoActiveImageBrush 8  ��ActiveImageColor 	#FFFFFFFF���� ActiveImageBrush 8  E�AnimationDuration 0:0:0.2D�.���  �@^�InitialShowDelay$
 1500����  �@�ToolTip �� $��Свернуть��
���   ���  � |� .  ��  � �� �� " ��.R��� $ border��$ Aliased=�8�� ._�F� $
 path��$ Uniform=�8�� $��2��+����        �@  5 � 5  5 �@B @B 	 P� 	 �@J�IsMouseOver
 .  �� .���� .���� 8  $ border��$( "Background.(SolidColorBrush.Color)�$ HoldEnd=�8  �� 8  $
 path��$$ Stroke.(SolidColorBrush.Color)�$ HoldEnd=�8 	  �� .���� .���� 8 
 $ border��$( "Background.(SolidColorBrush.Color)�$ HoldEnd=�8  �� 8  $
 path��$$ Stroke.(SolidColorBrush.Color)�$ HoldEnd=�8  �� "  n�.���  � �� �	#01FFFFFF��  � �� �� " n�.R��� #��z���� "  �.���  � ��# Z����  � ��# Z����  � ��$	 140����  � ��$ 60����  �@�AllowsTransparency . ��  �@�UseLayoutRounding . ��  � ��$ Verdana)���  � ��$ 12(���  �@�WindowStyle$
 None=���  � �� �� " �.R��  �� $��7 ��� $��7 ��� $��18 ��� $��* ��� $��7 ��� $��7 � �� $��7 ��� $��7 ��� $��* ��� $��35 ��� $��35 ��� $��28 ��� $��7 ��� $��7 �.+��� $ rootSubstrate��$��0��$��6��$��0��$��8��
������ �� $ windowBodySubstrate��$��1��$��4��$��1��$��6��$ 1��$  8��
�������!   $" 	#FF555555��$# 0Q�$$ 12Q�$	% 0.5Q��� $ 
windowBody��$��1��$��4��$��1��$��6��$ 1��$  7�����	#FF555555$��1q�$ Aliased=�#��z���� $ windowHeader��-   $��1��$��2��$��1��$��6��$ 2��$��1,1,0,0q�$  6,6,0,0�����	#FF18753E�� $ clientArtea��$��1��$��4��$��1��$��6��$��Stretch=�$��Stretch=�$ 2��& !� ' �� $( 
windowBody��._��� .u��� �� -   $��1��$��2��$��3��$ 3��$��0,1,0,0q�8��  d� $) tbChangeWindowState��-   $��1��$��2��$��4��$ 3��$��0,1,0,0q�8�� �� -   $��1��$��2��$��5��$��2��$ 3��$��0,1,1,0q�8�� n� $* 	thumbWest��-   $��2��$��2��$��0��8�� $+ SizeWE��n� $* thumbNorthWest��-   $��0��$��2��$��0��$��2��8�� $+ SizeNWSE��n� $* 
thumbNorth��-   $��0��$��2��$��4��8�� $+ SizeNS��n� $* thumbNorthEast��-   $��0��$��2��$��6��$��2��8�� $+ SizeNESW��n� $* 	thumbEast��-	   $��2��$��2��$��7��8�� $+ SizeWE��n� $* thumbSouthEast��-
   $��4��$��2��$��6��$��2��8�� $+ SizeNWSE��n� $* 
thumbSouth��-   $��6��$��2��$��4��8��	 $+ SizeNS��n� $* thumbSouthWest��-   $��4��$��2��$��0��$��2��8��
 $+ SizeNESW�� P� 	 �@�WindowState$
 	Maximized=�. ��� $ rootSubstrate�� � ��
 �   ��� $ 
windowBody�� �@��CornerRadius$ 0���� $ windowHeader�� �@��CornerRadius$ 0���� $ tbChangeWindowState�� �@d�	IsChecked$
 TrueY��� $ 	thumbWest�� � y�$ Hidden=��� $ thumbNorthWest�� � y�$ Hidden=��� $ 
thumbNorth�� � y�$ Hidden=��� $ thumbNorthEast�� � y�$ Hidden=��� $ 	thumbEast�� � y�$ Hidden=��� $ thumbSouthEast�� � y�$ Hidden=��� $ 
thumbSouth�� � y�$ Hidden=��� $ thumbSouthWest�� � y�$ Hidden=�P� 	 �@�IsActive
 .  . ��� $ 
windowBody�� � �� �	#FF777777�� $ windowBodySubstrate�� �@J�Effect   $" 	#FF555555��$# 0Q�$$ 12Q�$	% 0.3Q�P� 	 �@�
ResizeMode$
 CanMinimize=�. ��� $ tbChangeWindowState�� � {� .  