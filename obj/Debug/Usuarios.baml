   M S B A M L   `   `   `  ����E  ABiblioteca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Biblioteca
Biblioteca  5   	       Biblioteca.Usuarios   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Biblioteca     5   	   -   5          � Title$  Usuarios��5   	   $	��600��6   $	��800��6'   .��5	      � .+�5
   
   �� -   5         ��Name$ LblNome��5
      $
��Nome��6!   $��Center=�60   $��0,10,0,0q�6M   $	��Top=�6_   $	��780��6w   $
��Bold"�6�   $��26��6�   $��8(�6�   �� 5   
   -   5         ��Name$ TxtNome��5      $��Center=�6#   $��0,36,0,0q�6@    �� TextWrapping$
 Wrap=�6R   $	��Top=�6f   $	��780��6~   $��26��6�   $��8(�6�   �� 5   
   -   5        $ 
LblUsuario��5      $��Usuario��6$   $��Center=�66   $��0,67,0,0q�6S   $	��Top=�6e   $	��780��6}   $
��Bold"�6�   $��26��6�   $��8(�6�   �� 5   
   -   5        $ 
TxtUsuario��5      $��Center=�6&   $��0,93,0,0q�6C   $
 Wrap=�6U   $	��Top=�6i   $	��780��6�   $��27��6�   $��8(�6�   �� 5   
   -   5         ��Name$ 
BtnInserir��5      $��Inserir��6%   $
��Left=�67   $��
10,292,0,0q�6R   $	��Top=�6f   $��30��6~   $	��130��6�   $��8(�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ 
BtnExcluir��5      $��Excluir��6%   $
��Left=�67   $��140,292,0,0q�6R   $	��Top=�6g   $��30��6   $	��130��6�   $��8(�6�   $
��Bold"�6�   {�.  6�   �� 5   
   -   5        $ BtnLocalizar��5      $��	Localizar��6'   $
��Left=�6;   $��270,292,0,0q�6V   $	��Top=�6k   $��30��6�   $	��130��6�   $��8(�6�   $
��Bold"�6�   6�   �� 5   
   -	   5        $ 
BtnAlterar��5      $��Alterar��6%   $
��Left=�67   $��400,292,0,0q�6R   $	��Top=�6g   $��30��6   $	��130��6�   $��8(�6�   $
��Bold"�6�   {�.  6�   &   System.Windows.Controls.DataGrid  5   
   -
   5          Name$ 
DgUsuarios��5         AutoGenerateColumns .  $��10,327,10,10q�6C   $	��NaN��6Y      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Id+  5      $
	 Nome��6%   
 63   �� *Nome+  5      $	 Usuario��6%   
 66   �� *
Usuario1+5      �� 5   
   -   5        $ LblSenha��5      $��Senha��6"   $��Center=�62   $��	0,124,0,0q�6O   $	��Top=�6b   $	��780��6z   $
��Bold"�6�   $��26��6�   $��8(�6�   G� 5   
   -   5         G�Name$ TxtSenha��5      $��Center=�6)   $��	0,150,0,0q�6F   $	��Top=�6Y   $	��780��6q   $��27��6}   $��8(�6�   �� 5   
   -   5        $ LblConfirmarSenha��5      $��Confirmar a senha��6+   $��Center=�6G   $��	0,182,0,0q�6d   $	��Top=�6w   $	��780��6�   $
��Bold"�6�   $��26��6�   $��8(�6�   G� 5   
   -   5        $ TxtConfirmarSenha��5      $��Center=�62   $��	0,208,0,0q�6O   $	��Top=�6b   $	��780��6z   $��27��6�   $��8(�6�   �� 5   
   -   5        $ 	BtnSalvar��5      $��Salvar��6$   $
��Left=�65   $��530,292,0,0q�6P   $	��Top=�6e   $��30��6}   $	��130��6�   $��8(�6�   $
��Bold"�6�   {�.  6�   �� 5   
   -   5        $ BtnCancelar��5      $��Cancelar��6&   $
��Left=�69   $��660,292,0,0q�6T   $	��Top=�6i   $��30��6�   $	��130��6�   $��8(�6�   $
��Bold"�6�   {�.  6�   5      5       