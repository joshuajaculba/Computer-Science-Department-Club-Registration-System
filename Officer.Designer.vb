<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Officer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Officer))
        Panel1 = New Panel()
        Button5 = New Button()
        Button4 = New Button()
        Button3 = New Button()
        Label10 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Button2 = New Button()
        PictureBox1 = New PictureBox()
        Registration = New Panel()
        Table = New Panel()
        Button7 = New Button()
        Button6 = New Button()
        TextBox5 = New TextBox()
        DataGridView1 = New DataGridView()
        PictureBox4 = New PictureBox()
        PictureBox2 = New PictureBox()
        DateTimePicker1 = New DateTimePicker()
        Label12 = New Label()
        Label11 = New Label()
        Button1 = New Button()
        TextBox4 = New TextBox()
        TextBox3 = New TextBox()
        ComboBox2 = New ComboBox()
        ComboBox1 = New ComboBox()
        TextBox2 = New TextBox()
        TextBox1 = New TextBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Label5 = New Label()
        Label13 = New Label()
        PictureBox3 = New PictureBox()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Registration.SuspendLayout()
        Table.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.Info
        Panel1.Controls.Add(Button5)
        Panel1.Controls.Add(Button4)
        Panel1.Controls.Add(Button3)
        Panel1.Controls.Add(Label10)
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Location = New Point(-1, -1)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(200, 542)
        Panel1.TabIndex = 0
        ' 
        ' Button5
        ' 
        Button5.BackColor = Color.Gold
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Font = New Font("Times New Roman", 18.0F, FontStyle.Bold, GraphicsUnit.Point)
        Button5.Location = New Point(0, 438)
        Button5.Name = "Button5"
        Button5.Size = New Size(200, 36)
        Button5.TabIndex = 24
        Button5.Text = "ADMIN" & vbCrLf
        Button5.UseVisualStyleBackColor = False
        Button5.Visible = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.Coral
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Times New Roman", 18.0F, FontStyle.Bold, GraphicsUnit.Point)
        Button4.Location = New Point(0, 494)
        Button4.Name = "Button4"
        Button4.Size = New Size(200, 36)
        Button4.TabIndex = 23
        Button4.Text = "SIGN-OUT" & vbCrLf & vbCrLf
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.Aqua
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
        Button3.Location = New Point(0, 371)
        Button3.Name = "Button3"
        Button3.Size = New Size(200, 49)
        Button3.TabIndex = 22
        Button3.Text = "NEW MEMBER RECORDS" & vbCrLf
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Noto Serif Armenian", 9.749998F, FontStyle.Bold, GraphicsUnit.Point)
        Label10.Location = New Point(40, 270)
        Label10.Name = "Label10"
        Label10.Size = New Size(41, 18)
        Label10.TabIndex = 21
        Label10.Text = "Time"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Noto Serif Armenian", 9.749998F, FontStyle.Bold, GraphicsUnit.Point)
        Label9.Location = New Point(40, 255)
        Label9.Name = "Label9"
        Label9.Size = New Size(41, 18)
        Label9.TabIndex = 20
        Label9.Text = "Date "
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Noto Serif Armenian", 18.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label8.Location = New Point(79, 177)
        Label8.Name = "Label8"
        Label8.Size = New Size(102, 33)
        Label8.TabIndex = 19
        Label8.Text = "Officer"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Noto Serif Armenian", 18.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label7.Location = New Point(23, 222)
        Label7.Name = "Label7"
        Label7.Size = New Size(86, 33)
        Label7.TabIndex = 18
        Label7.Text = "Name"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Noto Serif Armenian", 18.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(23, 177)
        Label6.Name = "Label6"
        Label6.Size = New Size(49, 33)
        Label6.TabIndex = 17
        Label6.Text = "Hi "
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Aqua
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
        Button2.Location = New Point(0, 304)
        Button2.Name = "Button2"
        Button2.Size = New Size(200, 49)
        Button2.TabIndex = 17
        Button2.Text = "MEMBER REGISTRATION"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(4, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(189, 162)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' Registration
        ' 
        Registration.BackColor = SystemColors.AppWorkspace
        Registration.Controls.Add(Table)
        Registration.Controls.Add(PictureBox4)
        Registration.Controls.Add(PictureBox2)
        Registration.Controls.Add(DateTimePicker1)
        Registration.Controls.Add(Label12)
        Registration.Controls.Add(Label11)
        Registration.Controls.Add(Button1)
        Registration.Controls.Add(TextBox4)
        Registration.Controls.Add(TextBox3)
        Registration.Controls.Add(ComboBox2)
        Registration.Controls.Add(ComboBox1)
        Registration.Controls.Add(TextBox2)
        Registration.Controls.Add(TextBox1)
        Registration.Controls.Add(Label4)
        Registration.Controls.Add(Label3)
        Registration.Controls.Add(Label2)
        Registration.Controls.Add(Label1)
        Registration.Controls.Add(Label5)
        Registration.Controls.Add(Label13)
        Registration.Controls.Add(PictureBox3)
        Registration.Location = New Point(198, -1)
        Registration.Name = "Registration"
        Registration.Size = New Size(721, 542)
        Registration.TabIndex = 1
        ' 
        ' Table
        ' 
        Table.BackColor = SystemColors.ActiveCaption
        Table.Controls.Add(Button7)
        Table.Controls.Add(Button6)
        Table.Controls.Add(TextBox5)
        Table.Controls.Add(DataGridView1)
        Table.Location = New Point(0, 0)
        Table.Name = "Table"
        Table.Size = New Size(721, 543)
        Table.TabIndex = 31
        ' 
        ' Button7
        ' 
        Button7.BackColor = Color.Gold
        Button7.FlatStyle = FlatStyle.Flat
        Button7.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
        Button7.Location = New Point(294, 478)
        Button7.Name = "Button7"
        Button7.Size = New Size(200, 49)
        Button7.TabIndex = 26
        Button7.Text = "SEND TO ADMINISTRATORS" & vbCrLf
        Button7.UseVisualStyleBackColor = False
        ' 
        ' Button6
        ' 
        Button6.BackColor = Color.DodgerBlue
        Button6.FlatStyle = FlatStyle.Flat
        Button6.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
        Button6.Location = New Point(505, 478)
        Button6.Name = "Button6"
        Button6.Size = New Size(200, 49)
        Button6.TabIndex = 25
        Button6.Text = "PRINT" & vbCrLf
        Button6.UseVisualStyleBackColor = False
        ' 
        ' TextBox5
        ' 
        TextBox5.Font = New Font("Linux Libertine Display G", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox5.Location = New Point(23, 34)
        TextBox5.MaxLength = 40
        TextBox5.Multiline = True
        TextBox5.Name = "TextBox5"
        TextBox5.PlaceholderText = "Members Records....."
        TextBox5.Size = New Size(313, 35)
        TextBox5.TabIndex = 1
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(23, 91)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(684, 381)
        DataGridView1.TabIndex = 0
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(7, 312)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(104, 91)
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.TabIndex = 29
        PictureBox4.TabStop = False
        PictureBox4.Visible = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(7, 13)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(104, 91)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 25
        PictureBox2.TabStop = False
        PictureBox2.Visible = False
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Font = New Font("Linux Libertine Display G", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        DateTimePicker1.Location = New Point(264, 312)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(358, 31)
        DateTimePicker1.TabIndex = 26
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Noto Serif Armenian", 9.749998F, FontStyle.Bold, GraphicsUnit.Point)
        Label12.Location = New Point(67, 420)
        Label12.Name = "Label12"
        Label12.Size = New Size(183, 18)
        Label12.TabIndex = 25
        Label12.Text = "joshuajaculba@gmail.com"
        Label12.Visible = False
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Noto Serif Armenian", 9.749998F, FontStyle.Bold, GraphicsUnit.Point)
        Label11.Location = New Point(194, 387)
        Label11.Name = "Label11"
        Label11.Size = New Size(22, 18)
        Label11.TabIndex = 25
        Label11.Text = "10"
        Label11.Visible = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Tomato
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.Location = New Point(308, 438)
        Button1.Name = "Button1"
        Button1.Size = New Size(286, 49)
        Button1.TabIndex = 16
        Button1.Text = "REGISTER"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' TextBox4
        ' 
        TextBox4.Font = New Font("Linux Libertine Display G", 24.0F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox4.Location = New Point(266, 369)
        TextBox4.MaxLength = 7
        TextBox4.Multiline = True
        TextBox4.Name = "TextBox4"
        TextBox4.PlaceholderText = "PHP 0.00"
        TextBox4.Size = New Size(358, 44)
        TextBox4.TabIndex = 10
        TextBox4.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox3
        ' 
        TextBox3.Font = New Font("Linux Libertine Display G", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox3.Location = New Point(265, 264)
        TextBox3.MaxLength = 50
        TextBox3.Multiline = True
        TextBox3.Name = "TextBox3"
        TextBox3.PlaceholderText = "e.g. comscie@gmail.com"
        TextBox3.Size = New Size(358, 35)
        TextBox3.TabIndex = 9
        ' 
        ' ComboBox2
        ' 
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.Font = New Font("Linux Libertine Display G", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(265, 217)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(356, 32)
        ComboBox2.TabIndex = 8
        ' 
        ' ComboBox1
        ' 
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.Font = New Font("Linux Libertine Display G", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"1st Year", "2nd Year", "3rd Year", "4th Year", "5th Year"})
        ComboBox1.Location = New Point(265, 167)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(356, 32)
        ComboBox1.TabIndex = 7
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Linux Libertine Display G", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox2.Location = New Point(263, 122)
        TextBox2.MaxLength = 40
        TextBox2.Multiline = True
        TextBox2.Name = "TextBox2"
        TextBox2.PlaceholderText = "e.g. Juan Dela Cruz"
        TextBox2.Size = New Size(358, 35)
        TextBox2.TabIndex = 6
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Linux Libertine Display G", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox1.Location = New Point(263, 75)
        TextBox1.MaxLength = 7
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "2XXXXXX"
        TextBox1.Size = New Size(358, 35)
        TextBox1.TabIndex = 3
        TextBox1.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Noto Serif Armenian", 18.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.Location = New Point(95, 215)
        Label4.Name = "Label4"
        Label4.Size = New Size(170, 33)
        Label4.TabIndex = 14
        Label4.Text = "Department:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Noto Serif Armenian", 18.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(115, 166)
        Label3.Name = "Label3"
        Label3.Size = New Size(151, 33)
        Label3.TabIndex = 13
        Label3.Text = "Year Level:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Noto Serif Armenian", 18.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.Location = New Point(119, 123)
        Label2.Name = "Label2"
        Label2.Size = New Size(146, 33)
        Label2.TabIndex = 12
        Label2.Text = "Full Name:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Noto Serif Armenian", 18.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(113, 77)
        Label1.Name = "Label1"
        Label1.Size = New Size(158, 33)
        Label1.TabIndex = 11
        Label1.Text = "Student ID: "
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Noto Serif Armenian", 18.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.Location = New Point(66, 266)
        Label5.Name = "Label5"
        Label5.Size = New Size(205, 33)
        Label5.TabIndex = 15
        Label5.Text = "Email Address: "
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Noto Serif Armenian", 18.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label13.Location = New Point(126, 310)
        Label13.Name = "Label13"
        Label13.Size = New Size(145, 33)
        Label13.TabIndex = 27
        Label13.Text = "Birthdate: "
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(7, 110)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(229, 213)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 28
        PictureBox3.TabStop = False
        PictureBox3.Visible = False
        ' 
        ' Officer
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(917, 538)
        Controls.Add(Registration)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Name = "Officer"
        StartPosition = FormStartPosition.CenterScreen
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Registration.ResumeLayout(False)
        Registration.PerformLayout()
        Table.ResumeLayout(False)
        Table.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Registration As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label13 As Label
    Public WithEvents Label11 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Table As Panel
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents DataGridView1 As DataGridView
End Class
