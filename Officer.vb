Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Net
Imports System.Net.Mail

Public Class Officer
    Dim db As New Database()
    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Officer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDatas()
        LoadDepartments()
        DateTimePicker1.MaxDate = Date.Today.AddYears(-18)
        Registration.Show()
        Registration.Visible = True
        Registration.BringToFront()
        Table.Visible = False
        Table.SendToBack()
        LoadMembersData()
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim log As New Form1

        log.Show()
        Me.Hide()
    End Sub
    Private Sub LoadDepartments()
        Dim query As String = "SELECT Department FROM Customize ORDER BY Department ASC"
        Dim dt As DataTable = db.ExecuteQuery(query)

        ComboBox2.Items.Clear() ' clear existing items

        For Each row As DataRow In dt.Rows
            ComboBox2.Items.Add(row("Department").ToString())
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '====================================
        ' VALIDATION — Do not continue
        '====================================
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MsgBox("Name is required.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("Year level is required.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If ComboBox2.SelectedIndex = -1 Then
            MsgBox("Department is required.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MsgBox("Email is required.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If



        If DateTimePicker1.Value > Date.Today.AddYears(-18) Then
            MsgBox("Member must be at least 18 years old.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If


        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MsgBox("ID is required.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        '==============================================
        ' 0. COMPUTE CHANGE BEFORE SAVING
        '==============================================
        Dim membershipFee As Decimal = Val(Label11.Text)
        Dim amountPaid As Decimal = Val(TextBox4.Text)
        Dim changeAmount As Decimal = 0

        If amountPaid < membershipFee Then
            MsgBox("Amount paid is not enough.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If amountPaid > membershipFee Then
            changeAmount = amountPaid - membershipFee
            MsgBox("Change: " & changeAmount.ToString("0.00"), MsgBoxStyle.Information)
        End If

        '==============================================
        ' 1. DATABASE COMPONENT
        '==============================================
        Dim db As New Database()
        Try
            '==== CHECK IF EMAIL EXISTS (CASE-SENSITIVE) ====
            Dim checkQuery As String = "SELECT COUNT(*) FROM Members WHERE Email=@Email"
            Using conn As SqlConnection = db.GetConnection()
                Using cmd As New SqlCommand(checkQuery, conn)
                    cmd.Parameters.AddWithValue("@Email", TextBox3.Text)
                    conn.Open()
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        MsgBox("This email is already registered in the database.", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Database error: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        '==============================================
        ' 2. SEND EMAIL FIRST
        '==============================================
        Try
            Dim smtp As New SmtpClient("smtp.gmail.com", 587) With {
            .EnableSsl = True,
            .UseDefaultCredentials = False,
            .Credentials = New NetworkCredential("programmersclub.office@gmail.com", "were zymy smfo qmlt")
        }

            Dim mail As New MailMessage() With {
            .From = New MailAddress("programmersclub.office@gmail.com", "The Programmers Club – UM"),
            .Subject = "Welcome to the Programmers Club – University of Manila!"
        }
            mail.To.Add(TextBox3.Text)

            ' Save images temporarily
            Dim img1Path = IO.Path.GetTempFileName() & ".jpg"
            Dim img2Path = IO.Path.GetTempFileName() & ".jpg"
            Dim img3Path = IO.Path.GetTempFileName() & ".jpg"
            Dim img4Path = IO.Path.GetTempFileName() & ".jpg"

            If PictureBox3.Image IsNot Nothing Then PictureBox3.Image.Save(img1Path)
            If PictureBox1.Image IsNot Nothing Then PictureBox1.Image.Save(img2Path)
            If PictureBox2.Image IsNot Nothing Then PictureBox2.Image.Save(img3Path)
            If PictureBox4.Image IsNot Nothing Then PictureBox4.Image.Save(img4Path)

            Dim img1 As New LinkedResource(img1Path) With {.ContentId = "img1"}
            Dim img2 As New LinkedResource(img2Path) With {.ContentId = "img2"}
            Dim img3 As New LinkedResource(img3Path) With {.ContentId = "img3"}
            Dim img4 As New LinkedResource(img4Path) With {.ContentId = "img4"}

            Dim htmlBody As String =
          $"Dear {TextBox2.Text},<br><br>

            

You are now officially registered as a member of the <b>Programmers Club – University of Manila</b>.<br>
We’re excited to welcome you and look forward to seeing you grow your technological skills with us.<br><br>

As a new member, please take a moment to review the Club Laws, Rights, and Responsibilities:<br>
<a href='https://docs.google.com/document/d/1hcp8LWkMwz-MIcJhua27giLDEJtdZrBuhstMWRQSadA/edit?usp=drivesdk'>
THE CONSTITUITION OF THE PROGRAMMERS CLUB</a><br><br>

<b>Membership Fee:</b>Php {Label11.Text}<br>
<b>Amount Paid:</b>Php {TextBox4.Text}<br>
<b>Change:</b>Php {changeAmount.ToString("0.00")}<br><br>

We are grateful to have you with us. Welcome aboard, future innovator!<br><br>

Best regards,<br>
<b>{Label7.Text}</b><br>
{Label8.Text}–Programmers Club<br><br>

<hr>
<b></b><br>
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

            ' TRY SENDING EMAIL
            smtp.Send(mail)

        Catch ex As Exception
            MsgBox("Email sending failed. Please check the email address or your network connection." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            ' CLEAR ALL FIELDS
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            ComboBox1.SelectedIndex = -1
            ComboBox2.SelectedIndex = -1
            DateTimePicker1.Value = DateTime.Now
            Label11.Text = ""
            Label7.Text = ""
            Label8.Text = ""
            Exit Sub
        End Try

        Try
            Dim insertQuery As String = "INSERT INTO Members (ID, Name, Year, Department, Email, Payment, Birth, Position, DateJ) " &
                                "VALUES (@ID, @Name, @Year, @Department, @Email, @Payment, @Birth, @Position, @DateJ)"

            Using conn As SqlConnection = db.GetConnection()
                Using cmd As New SqlCommand(insertQuery, conn)
                    cmd.Parameters.AddWithValue("@ID", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@Name", TextBox2.Text)
                    cmd.Parameters.AddWithValue("@Year", ComboBox1.Text)
                    cmd.Parameters.AddWithValue("@Department", ComboBox2.Text)
                    cmd.Parameters.AddWithValue("@Email", TextBox3.Text)
                    cmd.Parameters.AddWithValue("@Payment", Label11.Text)
                    cmd.Parameters.Add("@Birth", SqlDbType.Date).Value = DateTimePicker1.Value.Date
                    cmd.Parameters.AddWithValue("@Position", Label7.Text)
                    cmd.Parameters.Add("@DateJ", SqlDbType.DateTime).Value = DateTime.Now

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            LoadMembersData()

            MsgBox("New Club Members is now registered in the system!", MsgBoxStyle.Information)


            ' Clear fields
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            ComboBox1.SelectedIndex = -1
            ComboBox2.SelectedIndex = -1

            ' Reset DateTimePicker safely
            DateTimePicker1.MinDate = DateTimePicker.MinimumDateTime
            DateTimePicker1.MaxDate = DateTimePicker.MaximumDateTime
            DateTimePicker1.Value = DateTime.Today



        Catch ex As Exception
            MsgBox("Database error after email sent: " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim digitsOnly As String = System.Text.RegularExpressions.Regex.Replace(TextBox1.Text, "[^\d]", "")

        If TextBox1.Text <> digitsOnly Then
            TextBox1.Text = digitsOnly
            TextBox1.SelectionStart = TextBox1.Text.Length ' keep cursor at end
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim txt As String = TextBox2.Text

        ' 1. Prevent starting with a space
        If txt.StartsWith(" ") Then
            TextBox2.Text = txt.TrimStart()
            TextBox2.SelectionStart = TextBox2.Text.Length
            Exit Sub
        End If

        ' 2. Allow letters and spaces only
        Dim filtered As String = System.Text.RegularExpressions.Regex _
        .Replace(txt, "[^a-zA-Z ]", "")

        ' 3. Prevent double spaces
        Do While filtered.Contains("  ")
            filtered = filtered.Replace("  ", " ")
        Loop

        ' 4. Auto format capitalization
        Dim words() As String = filtered.Split(" "c)
        For i As Integer = 0 To words.Length - 1
            If words(i).Length > 0 Then
                words(i) = Char.ToUpper(words(i)(0)) & words(i).Substring(1).ToLower()
            End If
        Next

        Dim formatted As String = String.Join(" ", words)

        ' 5. Update only if modified
        If TextBox2.Text <> formatted Then
            TextBox2.Text = formatted
            TextBox2.SelectionStart = TextBox2.Text.Length
        End If
    End Sub


    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> " "c Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim txt As String = TextBox3.Text.ToLower()

        ' Remove invalid characters: allow letters, digits, @, and .
        Dim filtered As String = System.Text.RegularExpressions.Regex.Replace(txt, "[^a-z0-9@.]", "")

        ' Allow only ONE @
        Dim atCount As Integer = filtered.Count(Function(c) c = "@"c)
        If atCount > 1 Then
            ' Remove extra @'s
            Dim firstAtIndex = filtered.IndexOf("@"c)
            filtered = filtered.Substring(0, firstAtIndex + 1) &
                   filtered.Substring(firstAtIndex + 1).Replace("@", "")
        End If

        ' Update only if changed
        If TextBox3.Text <> filtered Then
            TextBox3.Text = filtered
            TextBox3.SelectionStart = TextBox3.Text.Length
        End If
    End Sub


    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        Dim ch As Char = e.KeyChar

        ' Allow control keys (backspace, delete)
        If Char.IsControl(ch) Then Exit Sub

        ' Allow letters & numbers
        If Char.IsLetterOrDigit(ch) Then Exit Sub

        ' Allow only ONE @
        If ch = "@"c Then
            If TextBox3.Text.Contains("@") Then
                e.Handled = True
            End If
            Exit Sub
        End If

        ' Allow dot
        If ch = "."c Then Exit Sub

        ' Otherwise BLOCK
        e.Handled = True
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        ' Allow digits 0–9 and Backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True   ' Block other characters
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Registration.Show()
        Registration.Visible = True
        Registration.BringToFront()
        Table.Visible = False
        Table.SendToBack()




    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Table.Visible = True
        Table.Dock = DockStyle.Fill
        Table.BringToFront()
        LoadMembersData()

    End Sub

    Private Sub Table_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub LoadMembersData()
        Try
            Dim db As New Database()

            ' Show only members who joined today (optimized)
            Dim query As String = "
            SELECT ID, Name, Year, Department, Payment
            FROM Members
            WHERE [DateJ] >= CAST(GETDATE() AS DATE) 
              AND [DateJ] < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))
        "

            Dim dt As DataTable = db.ExecuteQuery(query)
            DataGridView1.DataSource = dt

            ' Set header text
            DataGridView1.Columns("ID").HeaderText = "Student ID"
            DataGridView1.Columns("Name").HeaderText = "Name"
            DataGridView1.Columns("Year").HeaderText = "Year Level"
            DataGridView1.Columns("Department").HeaderText = "Department"
            DataGridView1.Columns("Payment").HeaderText = "Membership Fee"

            ' Format Payment column as currency
            DataGridView1.Columns("Payment").DefaultCellStyle.Format = "C2"

            ' Center-align all columns
            For Each col As DataGridViewColumn In DataGridView1.Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.SortMode = DataGridViewColumnSortMode.Automatic ' Enable sorting
            Next

            ' Header style
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Row styles
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSteelBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White

            ' General settings
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.RowHeadersVisible = False
            DataGridView1.EnableHeadersVisualStyles = False
            DataGridView1.ReadOnly = True ' Optional: make it read-only

        Catch ex As Exception
            MessageBox.Show("Error loading members: " & ex.Message)
        End Try
    End Sub


    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Try
            Dim db As New Database()

            ' Get user input safely
            Dim searchText As String = TextBox5.Text.Trim().Replace("'", "''")

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

            ' Bind to DataGridView
            DataGridView1.DataSource = dt

            ' Rename columns for display
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Columns("ID").HeaderText = "Student ID"
                DataGridView1.Columns("Name").HeaderText = "  Name"
                DataGridView1.Columns("Year").HeaderText = "  Year Level"
                DataGridView1.Columns("Department").HeaderText = "Department"
                DataGridView1.Columns("Payment").HeaderText = "  Membership Fee"

                ' Center-align all columns
                For Each col As DataGridViewColumn In DataGridView1.Columns
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Next
            End If

            ' Keep aesthetic colors
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSteelBlue
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White

        Catch ex As Exception
            MessageBox.Show("Error searching members: " & ex.Message)
        End Try
    End Sub

    ' ===== GLOBAL VARIABLES FOR PRINT =====
    Private currentRow As Integer = 0
    Private currentPage As Integer = 1
    Private totalMembers As Integer = 0
    ' Add this at the top of your form class
    Private WithEvents printDocument As New Printing.PrintDocument()
    Private printPreview As New PrintPreviewDialog()


    ' ===== BUTTON CLICK TO PRINT =====
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            ' ✅ Check if DataGridView1 has rows
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("No data available to print", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Ask for print confirmation
            Dim result As DialogResult = MessageBox.Show("Do you want to print the New Club Members Report?", "Print Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then Exit Sub

            ' Reset pagination and total
            currentRow = 0
            currentPage = 1
            totalMembers = 0

            ' Show print preview
            printPreview.Document = printDocument
            printPreview.WindowState = FormWindowState.Maximized
            printPreview.PrintPreviewControl.Zoom = 1.0
            printPreview.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error while preparing print: " & ex.Message)
        End Try
    End Sub

    ' ===== PRINT PAGE EVENT =====
    Private Sub printDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles printDocument.PrintPage
        Dim g As Graphics = e.Graphics
        Dim leftMargin As Integer = e.MarginBounds.Left
        Dim topMargin As Integer = e.MarginBounds.Top
        Dim pageWidth As Integer = e.MarginBounds.Width
        Dim bottomMargin As Integer = e.MarginBounds.Bottom

        ' ===== FONTS =====
        Dim fontCompany As New Font("Segoe UI", 18, FontStyle.Bold)
        Dim fontAddress As New Font("Segoe UI", 11, FontStyle.Regular)
        Dim fontEmail As New Font("Segoe UI", 10, FontStyle.Regular)
        Dim fontTitle As New Font("Segoe UI", 14, FontStyle.Bold)
        Dim fontHeader As New Font("Segoe UI", 9, FontStyle.Bold)
        Dim fontCell As New Font("Segoe UI", 9)
        Dim fontTotal As New Font("Segoe UI", 11, FontStyle.Bold)
        Dim fontFooter As New Font("Segoe UI", 8, FontStyle.Italic)
        Dim brush As Brush = Brushes.Black
        Dim cellPadding As Integer = 4
        Dim cellHeight As Integer = 28
        Dim x As Integer = leftMargin
        Dim y As Integer = topMargin

        ' ===== LOGOS SIZE =====
        Dim logoWidth As Integer = 120
        Dim logoHeight As Integer = 120

        ' ===== BUSINESS NAME & LOGOS =====
        ' Draw PictureBox3 on left of text
        If PictureBox3.Image IsNot Nothing Then
            g.DrawImage(PictureBox3.Image, leftMargin, y, logoWidth, logoHeight)
        End If

        ' Draw PictureBox1 on right of text
        If PictureBox1.Image IsNot Nothing Then
            g.DrawImage(PictureBox1.Image, leftMargin + pageWidth - logoWidth, y, logoWidth, logoHeight)
        End If

        ' Draw business name & address centered between logos
        Dim textX As Integer = leftMargin + logoWidth
        Dim textWidth As Integer = pageWidth - (logoWidth * 2)
        g.DrawString("The Programmers Club", fontCompany, brush,
                 New RectangleF(textX, y, textWidth, 40),
                 New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
        ' Address in two lines using vbCrLf
        g.DrawString("546 Mariano V. Delos Santos Street, Sampaloc Manila," & vbCrLf & "Manila City, Philippines", fontAddress, brush,
             New RectangleF(textX, y + 40, textWidth, 40),
             New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})

        ' Email slightly below
        g.DrawString("Email: programmersclub.office@gmail.com", fontEmail, brush,
                 New RectangleF(textX, y + 82, textWidth, 25),
                 New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near})
        y += logoHeight + 10 ' Move y below logos

        ' ===== REPORT TITLE =====
        g.DrawString("New Club Members Report", fontTitle, brush,
                 New RectangleF(leftMargin, y, pageWidth, 30),
                 New StringFormat() With {.Alignment = StringAlignment.Center})
        y += 40

        ' ===== CALCULATE COLUMN WIDTHS =====
        Dim totalGridWidth As Integer = 0
        Dim colWidths(DataGridView1.Columns.Count - 1) As Integer
        For i As Integer = 0 To DataGridView1.Columns.Count - 1
            If DataGridView1.Columns(i).Visible Then
                colWidths(i) = Math.Max(90, DataGridView1.Columns(i).Width)
                totalGridWidth += colWidths(i)
            End If
        Next
        Dim scaleFactor As Double = Math.Min(1.0, pageWidth / totalGridWidth)
        For i As Integer = 0 To colWidths.Length - 1
            colWidths(i) = CInt(colWidths(i) * scaleFactor)
        Next

        ' ===== COLUMN HEADERS =====
        x = leftMargin
        For i As Integer = 0 To DataGridView1.Columns.Count - 1
            If DataGridView1.Columns(i).Visible Then
                g.FillRectangle(Brushes.LightGray, x, y, colWidths(i), cellHeight)
                g.DrawRectangle(Pens.Black, x, y, colWidths(i), cellHeight)
                g.DrawString(DataGridView1.Columns(i).HeaderText, fontHeader, brush,
                         New RectangleF(x + cellPadding, y, colWidths(i) - cellPadding * 2, cellHeight),
                         New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                x += colWidths(i)
            End If
        Next
        y += cellHeight

        ' ===== ROW DATA =====
        While currentRow < DataGridView1.Rows.Count
            Dim row As DataGridViewRow = DataGridView1.Rows(currentRow)
            If row.Visible Then
                totalMembers += 1
                x = leftMargin
                For i As Integer = 0 To DataGridView1.Columns.Count - 1
                    If DataGridView1.Columns(i).Visible Then
                        Dim cellValue As String = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString(), "")
                        g.FillRectangle(Brushes.White, x, y, colWidths(i), cellHeight)
                        g.DrawRectangle(Pens.Black, x, y, colWidths(i), cellHeight)
                        g.DrawString(cellValue, fontCell, brush,
                                 New RectangleF(x + cellPadding, y, colWidths(i) - cellPadding * 2, cellHeight),
                                 New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                        x += colWidths(i)
                    End If
                Next
                y += cellHeight

                ' PAGE BREAK
                If y + cellHeight > bottomMargin - 80 Then
                    Dim footerText As String = $"Page {currentPage}     Printed on {Date.Now:MMMM dd, yyyy hh:mm tt}"
                    g.DrawString(footerText, fontFooter, brush, leftMargin, bottomMargin + 20)
                    e.HasMorePages = True
                    currentPage += 1
                    currentRow += 1
                    Return
                End If
            End If
            currentRow += 1
        End While

        ' ===== TOTAL MEMBERS =====
        g.FillRectangle(Brushes.LightBlue, leftMargin, y, colWidths.Sum(), cellHeight)
        g.DrawRectangle(Pens.Black, leftMargin, y, colWidths.Sum(), cellHeight)
        g.DrawString($"TOTAL MEMBERS: {totalMembers}", fontTotal, brush,
         New RectangleF(leftMargin, y, colWidths.Sum(), cellHeight),
         New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        y += cellHeight

        ' ===== TOTAL FEES =====
        Dim totalFees As Decimal = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Visible Then
                Dim feeValue As Decimal
                If Decimal.TryParse(row.Cells("Payment").Value?.ToString(), feeValue) Then
                    totalFees += feeValue
                End If
            End If
        Next

        g.FillRectangle(Brushes.Goldenrod, leftMargin, y, colWidths.Sum(), cellHeight)
        g.DrawRectangle(Pens.Black, leftMargin, y, colWidths.Sum(), cellHeight)
        g.DrawString($"TOTAL FEES: ₱ {totalFees:N2}", fontTotal, Brushes.Black,
        New RectangleF(leftMargin, y, colWidths.Sum(), cellHeight),
        New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        y += cellHeight + 20

        ' ===== FOOTER =====
        Dim footerStr As String = $"Page {currentPage}      Prepared by: {Label7.Text} — {Label8.Text}      Printed on {Date.Now:MMMM dd, yyyy — hh:mm tt}"
        g.DrawString(footerStr, fontFooter, brush, leftMargin, bottomMargin + 20)

        ' RESET FOR NEXT PRINT
        e.HasMorePages = False
        currentRow = 0
        currentPage = 1
        totalMembers = 0
    End Sub

End Class