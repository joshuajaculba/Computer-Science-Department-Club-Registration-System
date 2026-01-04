Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Reflection.Emit

Public Class Admin

    Dim db As New Database()

    '======================
    '  ADD RECORD
    '======================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text.Trim = "" Then
            MessageBox.Show("Please enter a department!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("Add this record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim query = "INSERT INTO Customize (Department) VALUES (@Dept)"
            Using conn = db.GetConnection
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Dept", TextBox1.Text.Trim)
                    conn.Open
                    cmd.ExecuteNonQuery
                End Using
            End Using

            LoadData
            MessageBox.Show("Saved successfully!", "Info")
            TextBox1.Clear
        End If

    End Sub

    '======================
    '  UPDATE RECORD
    '======================
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox1.Text.Trim = "" Then
            MessageBox.Show("Select a department first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("Update this department?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim selectedDept = DataGridView1.CurrentRow.Cells("Department").Value.ToString

            Dim query = "UPDATE Customize SET Department=@NewDept WHERE Department=@OldDept"
            Using conn = db.GetConnection
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@NewDept", TextBox1.Text.Trim)
                    cmd.Parameters.AddWithValue("@OldDept", selectedDept)
                    conn.Open
                    cmd.ExecuteNonQuery
                End Using
            End Using

            LoadData
            MessageBox.Show("Updated successfully!", "Info")
            TextBox1.Clear
        End If

    End Sub

    '======================
    '  DELETE RECORD
    '======================
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If TextBox1.Text.Trim = "" Then
            MessageBox.Show("Select a department first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("Delete this department?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then

            Dim selectedDept = DataGridView1.CurrentRow.Cells("Department").Value.ToString

            Dim query = "DELETE FROM Customize WHERE Department=@Dept"
            Using conn = db.GetConnection
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Dept", selectedDept)
                    conn.Open
                    cmd.ExecuteNonQuery
                End Using
            End Using

            LoadData
            MessageBox.Show("Deleted successfully!", "Info")
            TextBox1.Clear
        End If

    End Sub

    '======================
    '  LOAD DATA TO GRID
    '======================
    Private Sub LoadData()
        Dim query As String = "SELECT Department FROM Customize ORDER BY Department ASC"
        Dim dt As DataTable = db.ExecuteQuery(query)

        DataGridView1.DataSource = dt

        ' Aesthetic setup
        DataGridView1.ReadOnly = True
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Center column header
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Center cell values
        DataGridView1.DefaultCellStyle.Font = New Font("Segoe UI", 10)
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Colors
        DataGridView1.DefaultCellStyle.BackColor = Color.White
        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue
        DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black
    End Sub


    '======================
    '  FORM LOAD
    '======================
    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        SetPlaceholder()
        UpdateYearLevels()      ' Update year levels if today is Aug 3
        LoadAllMembersData()
        LoadDatas()
        clubmembers.Show()
        clubmembers.BringToFront()


    End Sub

    '======================
    '  CLICK ROW → FILL TEXTBOX
    '======================
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellClick

        If e.RowIndex >= 0 Then
            Dim row = DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("Department").Value.ToString
            Button2.Visible = True
            Button3.Visible = True
            Button4.Visible = True
            Button1.Visible = False
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = False
        Button1.Visible = True
        TextBox1.Clear

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        ' Check if TextBox2 is empty
        If TextBox2.Text.Trim = "" Then
            MessageBox.Show("Enter a number first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Ask user for confirmation
        If MessageBox.Show("Do you want to update the value?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            ' Update the single row in the table
            Dim query = "UPDATE Customize SET ID=@Value"

            Using conn = db.GetConnection
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Value", CInt(TextBox2.Text))
                    conn.Open
                    cmd.ExecuteNonQuery
                End Using
            End Using

            MessageBox.Show("Value updated successfully!", "Info")
            LoadDatas ' refresh DataGridView if needed

        Else
            MessageBox.Show("Update canceled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub LoadDatas()
        Dim query As String = "SELECT TOP 1 ID FROM Customize ORDER BY ID DESC"
        Using conn As SqlConnection = db.GetConnection()
            Using cmd As New SqlCommand(query, conn)
                conn.Open()
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    Label11.Text = result.ToString() ' now Label11 has correct value
                Else
                    Label11.Text = "0"
                End If
            End Using
        End Using
    End Sub

    '======================
    ' Set TextBox2 placeholder using Label11 text
    '======================
    Private Sub SetPlaceholder()
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            TextBox2.ForeColor = Color.Gray
            TextBox2.Text = "PHP " & Label11.Text & ".00"
        End If
    End Sub

    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        If TextBox2.ForeColor = Color.Gray Then
            TextBox2.Text = ""
            TextBox2.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        SetPlaceholder ' always update placeholder from Label11
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        SetPlaceholder
    End Sub


    Private Sub LoadAllMembersData()
        Try
            Dim db As New Database()

            ' Show all members
            Dim query As String = "
            SELECT ID, Name, Year, Department, Payment
            FROM Members
            ORDER BY Name
        "

            Dim dt As DataTable = db.ExecuteQuery(query)

            ' Bind to DataGridView2
            DataGridView2.DataSource = dt

            ' Set header text
            DataGridView2.Columns("ID").HeaderText = "Student ID"
            DataGridView2.Columns("Name").HeaderText = "Name"
            DataGridView2.Columns("Year").HeaderText = "Year Level"
            DataGridView2.Columns("Department").HeaderText = "Department"
            DataGridView2.Columns("Payment").HeaderText = "Membership Fee"

            ' Format Payment column as currency
            DataGridView2.Columns("Payment").DefaultCellStyle.Format = "C2"

            ' Center-align all columns
            For Each col As DataGridViewColumn In DataGridView2.Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.SortMode = DataGridViewColumnSortMode.Automatic
            Next

            ' Header style
            DataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver
            DataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            DataGridView2.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Row styles
            DataGridView2.RowsDefaultCellStyle.BackColor = Color.LightSteelBlue
            DataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan
            DataGridView2.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue
            DataGridView2.DefaultCellStyle.SelectionForeColor = Color.White

            ' General settings
            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView2.RowHeadersVisible = False
            DataGridView2.EnableHeadersVisualStyles = False
            DataGridView2.ReadOnly = True

        Catch ex As Exception
            MessageBox.Show("Error loading all members: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateYearLevels()
        Try
            Dim db As New Database()
            Using conn As SqlConnection = db.GetConnection()
                conn.Open()

                ' Only update if today is August 3rd
                If Date.Today.Month = 8 AndAlso Date.Today.Day = 3 Then
                    ' Update 1st → 2nd, 2nd → 3rd, 3rd → 4th
                    Dim updateQuery As String = "
                    UPDATE Members
                    SET Year = CASE 
                        WHEN Year = '1st Year' THEN '2nd Year'
                        WHEN Year = '2nd Year' THEN '3rd Year'
                        WHEN Year = '3rd Year' THEN '4th Year'
                        WHEN Year = '4th Year' THEN 'Club Alumni'
                        ELSE Year
                    END
                "
                    Using cmd As New SqlCommand(updateQuery, conn)
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating year levels: " & ex.Message)
        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Try
            Dim db As New Database()

            ' Get user input safely
            Dim searchText As String = TextBox3.Text.Trim().Replace("'", "''")

            ' SQL query: search multiple columns (case-insensitive)
            Dim query As String = "
            SELECT ID, Name, Year, Department, Payment 
            FROM Members
            WHERE 
                UPPER(ID) LIKE UPPER('%" & searchText & "%') OR
                UPPER(Name) LIKE UPPER('%" & searchText & "%') OR
                UPPER(Year) LIKE UPPER('%" & searchText & "%') OR
                UPPER(Department) LIKE UPPER('%" & searchText & "%') OR
                UPPER(Payment) LIKE UPPER('%" & searchText & "%')"

            ' Get filtered data
            Dim dt As DataTable = db.ExecuteQuery(query)

            ' Bind to DataGridView2
            DataGridView2.DataSource = dt

            ' Rename columns for display
            If DataGridView2.Columns.Count > 0 Then
                DataGridView2.Columns("ID").HeaderText = "Student ID"
                DataGridView2.Columns("Name").HeaderText = "Name"
                DataGridView2.Columns("Year").HeaderText = "Year Level"
                DataGridView2.Columns("Department").HeaderText = "Department"
                DataGridView2.Columns("Payment").HeaderText = "Membership Fee"

                ' Center-align all columns
                For Each col As DataGridViewColumn In DataGridView2.Columns
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Next
            End If

            ' Keep aesthetic colors
            DataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver
            DataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            DataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan
            DataGridView2.RowsDefaultCellStyle.BackColor = Color.LightSteelBlue
            DataGridView2.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue
            DataGridView2.DefaultCellStyle.SelectionForeColor = Color.White

        Catch ex As Exception
            MessageBox.Show("Error searching members: " & ex.Message)
        End Try
    End Sub

    Private selectedMemberID As String = "" ' Module-level variable

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Try
            ' Make sure the row index is valid
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
                selectedMemberID = row.Cells("ID").Value.ToString() ' Store the ID
            End If
        Catch ex As Exception
            MessageBox.Show("Error selecting member: " & ex.Message)
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            ' Ensure a member is selected
            If String.IsNullOrEmpty(selectedMemberID) Then
                MessageBox.Show("Please select a member to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            ' ======================================
            ' Temporary Form for termination reasons
            ' ======================================
            Dim tmpForm As New Form() With {
            .Text = "Termination Reason",
            .Size = New Size(520, 270),
            .FormBorderStyle = FormBorderStyle.FixedDialog,
            .StartPosition = FormStartPosition.CenterParent,
            .MaximizeBox = False,
            .MinimizeBox = False,
            .Font = New Font("Segoe UI", 10)
        }

            ' Create checkboxes with bold font
            Dim chk1 As New CheckBox() With {.Text = "Violation of school or Club rules", .Location = New Point(20, 20), .AutoSize = True, .Font = New Font("Segoe UI", 10, FontStyle.Bold)}
            Dim chk2 As New CheckBox() With {.Text = "Inactive status for two consecutive semesters", .Location = New Point(20, 60), .AutoSize = True, .Font = New Font("Segoe UI", 10, FontStyle.Bold)}
            Dim chk3 As New CheckBox() With {.Text = "Conduct unbecoming of a member or bringing disrepute to the Club", .Location = New Point(20, 100), .AutoSize = True, .Font = New Font("Segoe UI", 10, FontStyle.Bold)}
            Dim chk4 As New CheckBox() With {.Text = "Voluntary resignation in writing", .Location = New Point(20, 140), .AutoSize = True, .Font = New Font("Segoe UI", 10, FontStyle.Bold)}

            tmpForm.Controls.AddRange({chk1, chk2, chk3, chk4})

            ' OK button
            Dim btnOK As New Button() With {
            .Text = "OK",
            .Location = New Point(120, 170),
            .Size = New Size(100, 35),
            .DialogResult = DialogResult.OK,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .BackColor = Color.CornflowerBlue,
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
            tmpForm.Controls.Add(btnOK)

            ' Cancel button
            Dim btnCancel As New Button() With {
            .Text = "Cancel",
            .Location = New Point(260, 170),
            .Size = New Size(100, 35),
            .DialogResult = DialogResult.Cancel,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .BackColor = Color.LightGray,
            .ForeColor = Color.Black,
            .FlatStyle = FlatStyle.Flat
        }
            tmpForm.Controls.Add(btnCancel)

            tmpForm.AcceptButton = btnOK
            tmpForm.CancelButton = btnCancel

            ' Show form modally
            If tmpForm.ShowDialog() <> DialogResult.OK Then Exit Sub

            ' Get selected reasons
            Dim reasons As New List(Of String)
            If chk1.Checked Then reasons.Add(chk1.Text)
            If chk2.Checked Then reasons.Add(chk2.Text)
            If chk3.Checked Then reasons.Add(chk3.Text)
            If chk4.Checked Then reasons.Add(chk4.Text)

            If reasons.Count = 0 Then
                MessageBox.Show("Deletion unsuccessful. Please select at least one reason.", "No Reason Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            ' ======================================
            ' Fetch member info from DB
            ' ======================================
            Dim db As New Database()
            Dim memberName As String = ""
            Dim email As String = ""
            Dim label7Text As String = Label7.Text
            Dim label8Text As String = Label8.Text

            Using conn As SqlConnection = db.GetConnection()
                Using cmd As New SqlCommand("SELECT Name, Email FROM Members WHERE ID = @ID", conn)
                    cmd.Parameters.AddWithValue("@ID", selectedMemberID)
                    conn.Open()
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            memberName = reader("Name").ToString()
                            email = reader("Email").ToString()
                        End If
                    End Using
                End Using
            End Using

            ' ======================================
            ' Send termination email
            ' ======================================
            Try
                Dim smtp As New SmtpClient("smtp.gmail.com", 587) With {
                .EnableSsl = True,
                .UseDefaultCredentials = False,
                .Credentials = New NetworkCredential("programmersclub.office@gmail.com", "were zymy smfo qmlt")
            }

                Dim mail As New MailMessage() With {
                .From = New MailAddress("programmersclub.office@gmail.com", "The Programmers Club – UM"),
                .Subject = "Termination of Membership – University of Manila"
            }
                mail.To.Add(email)

                ' Save images temporarily
                Dim img1Path = IO.Path.GetTempFileName() & ".jpg"
                Dim img2Path = IO.Path.GetTempFileName() & ".jpg"
                Dim img3Path = IO.Path.GetTempFileName() & ".jpg"
                Dim img4Path = IO.Path.GetTempFileName() & ".jpg"

                If Officer.PictureBox3.Image IsNot Nothing Then Officer.PictureBox3.Image.Save(img1Path)
                If Officer.PictureBox1.Image IsNot Nothing Then Officer.PictureBox1.Image.Save(img2Path)
                If Officer.PictureBox2.Image IsNot Nothing Then Officer.PictureBox2.Image.Save(img3Path)
                If Officer.PictureBox4.Image IsNot Nothing Then Officer.PictureBox4.Image.Save(img4Path)

                Dim img1 As New LinkedResource(img1Path) With {.ContentId = "img1"}
                Dim img2 As New LinkedResource(img2Path) With {.ContentId = "img2"}
                Dim img3 As New LinkedResource(img3Path) With {.ContentId = "img3"}
                Dim img4 As New LinkedResource(img4Path) With {.ContentId = "img4"}

                ' Compose HTML body
                Dim htmlBody As String =
$"Dear {memberName},<br><br>
Your membership in the <b>Programmers Club – University of Manila</b> has been terminated for the following reason(s):<br>
<ul>{String.Join("", reasons.Select(Function(r) $"<li>{r}</li>"))}</ul><br>
We wish you the best in your future endeavors.<br><br>
Best regards,<br>
<b>{label7Text}</b><br>
{label8Text}–Programmers Club<br><br>
<hr>
<img src='cid:img1' width='150' style='margin-right:10px;' />
<img src='cid:img2' width='150' style='margin-right:10px;' />
<img src='cid:img3' width='150' style='margin-right:10px;' />
<img src='cid:img4' width='150' />
<hr>"

                Dim AV As AlternateView = AlternateView.CreateAlternateViewFromString(htmlBody, Nothing, "text/html")
                AV.LinkedResources.Add(img1)
                AV.LinkedResources.Add(img2)
                AV.LinkedResources.Add(img3)
                AV.LinkedResources.Add(img4)
                mail.AlternateViews.Add(AV)

                smtp.Send(mail)
            Catch ex As Exception
                MessageBox.Show("Email sending failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            ' ======================================
            ' Confirm deletion
            ' ======================================
            If MessageBox.Show("Are you sure you want to delete this member from the system?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Exit Sub

            ' Delete member from database
            Using conn As SqlConnection = db.GetConnection()
                Using cmd As New SqlCommand("DELETE FROM Members WHERE ID = @ID", conn)
                    cmd.Parameters.AddWithValue("@ID", selectedMemberID)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Member deleted and termination email sent successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Refresh DataGridView2
            LoadAllMembersData()
            selectedMemberID = ""

        Catch ex As Exception
            MessageBox.Show("Error during deletion process: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        customize.Visible = True
        customize.Show()
        customize.BringToFront()



    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        clubmembers.Show()
        clubmembers.BringToFront()

    End Sub
End Class

