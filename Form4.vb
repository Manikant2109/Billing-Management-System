Imports System.Data.SqlClient
Imports System.Data
Public Class Form4
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim cn3 As SqlConnection
        Dim cmd3 As SqlCommand
        Dim da1 As SqlDataAdapter
        Dim dt1 As DataTable
        cn3 = New SqlConnection("Data Source=LAPTOP-6OHR0KQ7\SQLEXPRESS;Initial Catalog=MYDB;Integrated Security=True")
        da1 = New SqlDataAdapter
        dt1 = New DataTable
        cmd3 = New SqlCommand("select * from Product_Details order by [PRODUCT ID]", cn3)
        Try
            cn3.Open()
            da1.SelectCommand = cmd3
            da1.Fill(dt1)
            cn3.Close()
            DataGridView1.DataSource = dt1
        Catch ex4 As Exception
            MessageBox.Show("ERROR ...")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                TextBox1.Text = row.Cells(0).Value.ToString
                TextBox2.Text = row.Cells(1).Value.ToString
                TextBox3.Text = row.Cells(2).Value.ToString
                TextBox4.Text = row.Cells(3).Value.ToString
            End If
        Catch ex5 As Exception
            MessageBox.Show("ERROR ...")
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox5.TextLength = 0 Then
            MessageBox.Show("ENTER QUANTITY")
        Else
            Try
                TextBox6.Text = Val(TextBox5.Text) * Val(TextBox4.Text)
                ListView1.Items.Add(New ListViewItem(New String() {TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text}))
                Dim TotalSum As Double = 0
                Dim TempNode As ListViewItem
                Dim TempDbl As Double
                For Each TempNode In ListView1.Items
                    If Double.TryParse(TempNode.SubItems.Item(4).Text, TempDbl) Then
                        TotalSum += TempDbl
                    End If
                Next
                Label10.Text = TotalSum
            Catch ex6 As Exception
                MessageBox.Show("ERROR ...")
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button6.PerformClick()
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Char.IsUpper(e.KeyChar) Or Char.IsLower(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            For Each i As ListViewItem In ListView1.SelectedItems
                ListView1.Items.Remove(i)
            Next
            Dim TotalSum As Double = 0
            Dim TempNode As ListViewItem
            Dim TempDbl As Double
            For Each TempNode In ListView1.Items
                If Double.TryParse(TempNode.SubItems.Item(4).Text, TempDbl) Then
                    TotalSum += TempDbl
                End If
            Next
            Label10.Text = TotalSum
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
        Catch ex7 As Exception
            MessageBox.Show("ERROR ...")
        End Try
    End Sub
End Class