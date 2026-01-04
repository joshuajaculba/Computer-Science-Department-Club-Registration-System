Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Create new instance of Officer form
        Dim off As New Officer

        ' Set the location of Button4 on that instance
        off.Button4.Location = New Point(0, 438)

        ' Show the Officer form
        off.Show()

        ' Hide the current form
        Me.Hide()
    End Sub


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim add As New Admin
        add.Show()
        Me.Hide()
    End Sub
End Class
