Imports System.Data.SqlClient
Imports System.Data
Public Class Form5
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString("E BILLING SYSTEM", New Font("Arial", 30, FontStyle.Bold), Brushes.Black, New Point(250, 30))
        e.Graphics.DrawString("-------------------------------------------------------------------------------------", New Font("Arial", 30), Brushes.Black, New Point(0, 80))
        e.Graphics.DrawString("-------------------------------------------------------------------------------------", New Font("Arial", 30), Brushes.Black, New Point(0, 90))
        e.Graphics.DrawString("NAME :" + TextBox3.Text, New Font("Arial", 20, FontStyle.Bold), Brushes.Black, New Point(20, 150))
        e.Graphics.DrawString("BILL NO. :" + TextBox1.Text, New Font("Arial", 20, FontStyle.Bold), Brushes.Black, New Point(20, 210))
        e.Graphics.DrawString("DATE :" + TextBox2.Text, New Font("Arial", 20, FontStyle.Bold), Brushes.Black, New Point(20, 270))
        e.Graphics.DrawString("TOTAL AMOUNT :" + Label7.Text, New Font("Arial", 20, FontStyle.Bold), Brushes.Black, New Point(20, 330))
        e.Graphics.DrawString("-------------------------------------------------------------------------------------", New Font("Arial", 30), Brushes.Black, New Point(0, 380))
        e.Graphics.DrawString("-------------------------------------------------------------------------------------", New Font("Arial", 30), Brushes.Black, New Point(0, 390))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form4.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.TextLength = 0 Then
            MessageBox.Show("ENTER INVOICE NO.")
        End If
        If TextBox2.TextLength = 0 Then
            MessageBox.Show("ENTER INVOICE DATE")
        End If
        If TextBox3.TextLength = 0 Then
            MessageBox.Show("ENTER COSTUMER NAME")
        End If
        If ComboBox1.Text.Length = 0 Then
            MessageBox.Show("ENTER PAYMENT MODE")
        End If
        Dim cn3 As SqlConnection
        Dim cmd3 As SqlCommand
        cn3 = New SqlConnection("Data Source=LAPTOP-6OHR0KQ7\SQLEXPRESS;Initial Catalog=MYDB;Integrated Security=True")
        cmd3 = New SqlCommand("insert into Invoice_Details( [INVOICE NO.] , [INVOICE DATE] , [COSTUMER NAME] , [PAYMENT MODE] , [AMOUNT] ) values ('" & TextBox1.Text & "' ,'" & TextBox2.Text & "' ,'" & TextBox3.Text & "' ,'" & ComboBox1.Text & "' , '" & Label7.Text & "')", cn3)
        Try
            cn3.Open()
            cmd3.ExecuteNonQuery()
            MessageBox.Show(" SAVED SUCCESSFULLY ...")
            cn3.Close()
        Catch ex8 As Exception
            MessageBox.Show("ERROR ...")
        End Try
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim discount As Integer
        discount = ((((Val(Form4.Label10.Text)) * (Val(Form4.TextBox7.Text))) / 100))
        Label7.Text = Val(Form4.Label10.Text) - discount
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsUpper(e.KeyChar) Or Char.IsLower(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsUpper(e.KeyChar) Or Char.IsLower(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsUpper(e.KeyChar) Or Char.IsLower(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

End Class