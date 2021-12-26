Imports System.Data.SqlClient
Imports System.Data
Public Class Form3
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox1.Focus()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.TextLength = 0 Then
            MessageBox.Show("ENTER PRODUCT ID")
        End If
        If TextBox2.TextLength = 0 Then
            MessageBox.Show("ENTER PRODUCT CATEGORY")
        End If
        If TextBox3.TextLength = 0 Then
            MessageBox.Show("ENTER PRODUCT NAME")
        End If
        If TextBox4.TextLength = 0 Then
            MessageBox.Show("ENTER PRODUCT COST")
        End If
        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        cn = New SqlConnection("Data Source=LAPTOP-6OHR0KQ7\SQLEXPRESS;Initial Catalog=MYDB;Integrated Security=True")
        cmd = New SqlCommand("insert into Product_Details( [PRODUCT ID] , [PRODUCT CATEGORY] , [PRODUCT NAME] , [PRODUCT COST] ) values ('" & TextBox1.Text & "' ,'" & TextBox2.Text & "' ,'" & TextBox3.Text & "' ,'" & TextBox4.Text & "')", cn)
        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MessageBox.Show(" SAVED SUCCESSFULLY ")
            Button4.PerformClick()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox1.Focus()
        Catch ex As Exception
            MessageBox.Show("ERROR ...")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.TextLength = 0 Then
            MessageBox.Show("ENTER PRODUCT ID")
        End If
        Dim cn1 As SqlConnection
        Dim cmd1 As SqlCommand
        cn1 = New SqlConnection("Data Source=LAPTOP-6OHR0KQ7\SQLEXPRESS;Initial Catalog=MYDB;Integrated Security=True")
        cmd1 = New SqlCommand("delete from Product_Details where [PRODUCT ID] = '" & TextBox1.Text & "'", cn1)
        Try
            cn1.Open()
            cmd1.ExecuteNonQuery()
            cn1.Close()
            MessageBox.Show(" DELETED SUCCESSFULLY ")
            Button4.PerformClick()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox1.Focus()
        Catch ex1 As Exception
            MessageBox.Show("ERROR ...")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim cn2 As SqlConnection
        Dim cmd2 As SqlCommand
        Dim da As SqlDataAdapter
        Dim dt As DataTable
        cn2 = New SqlConnection("Data Source=LAPTOP-6OHR0KQ7\SQLEXPRESS;Initial Catalog=MYDB;Integrated Security=True")
        da = New SqlDataAdapter
        dt = New DataTable
        cmd2 = New SqlCommand("select * from Product_Details order by [PRODUCT ID]", cn2)
        Try
            cn2.Open()
            da.SelectCommand = cmd2
            da.Fill(dt)
            cn2.Close()
            DataGridView1.DataSource = dt
        Catch ex2 As Exception
            MessageBox.Show("ERROR ...")
        End Try
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button5.PerformClick()
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
        Catch ex3 As Exception
            MessageBox.Show("ERROR ...")
        End Try
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsUpper(e.KeyChar) Or Char.IsLower(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsUpper(e.KeyChar) Or Char.IsLower(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
End Class