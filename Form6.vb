Imports System.Data.SqlClient
Imports System.Data
Public Class Form6
    Dim da2 As SqlDataAdapter
    Dim dt2 As DataTable
    Dim cmd4 As SqlCommand
    Dim cn4 As New SqlConnection
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            cn4 = New SqlConnection("Data Source=LAPTOP-6OHR0KQ7\SQLEXPRESS;Initial Catalog=MYDB;Integrated Security=True")
            da2 = New SqlDataAdapter
            dt2 = New DataTable
            cmd4 = New SqlCommand("select * from Invoice_Details order by [INVOICE NO.]", cn4)
            cn4.Open()
            da2.SelectCommand = cmd4
            da2.Fill(dt2)
            cn4.Close()
            DataGridView1.DataSource = dt2
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Catch ex9 As Exception
            MessageBox.Show("ERROR ...")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cn4 = New SqlConnection("Data Source=LAPTOP-6OHR0KQ7\SQLEXPRESS;Initial Catalog=MYDB;Integrated Security=True")
        cmd4 = New SqlCommand("delete from Invoice_Details where [INVOICE NO.] = '" & TextBox1.Text & "'", cn4)
        Try
            cn4.Open()
            cmd4.ExecuteNonQuery()
            cn4.Close()
            MessageBox.Show(" DELETED SUCCESSFULLY ")
            Button3.PerformClick()
            TextBox1.Clear()
        Catch ex1 As Exception
            MessageBox.Show("ERROR ...")
        End Try
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button3.PerformClick()
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                TextBox1.Text = row.Cells(0).Value.ToString
            End If
        Catch ex3 As Exception
            MessageBox.Show("ERROR ...")
        End Try
    End Sub
End Class