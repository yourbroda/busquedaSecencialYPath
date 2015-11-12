
Public Class Form1
    Dim funcion As New Funciones
    Dim direccion As String = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Vista XML"
        Label2.Text = "Consulta"
        Button2.Text = "Buscar XML"
        Button1.Text = "Realizar Consulta"


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        RichTextBox2.Text = funcion.Consulta(direccion, TextBox1.Text)


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        direccion = Ruta()
        RichTextBox1.Text = funcion.lecturaSecu(direccion)

    End Sub
    Private Function Ruta() As String 'Funcion de busqueda de archivo
        Dim file As New OpenFileDialog
        Dim rut As String = " "
        file.Filter = "Tipo de arcivo *|*"
        file.FileName = "Archivo de programa"
        If (file.ShowDialog = 1) Then
            rut = file.FileName
        End If
        Return rut
    End Function
End Class
