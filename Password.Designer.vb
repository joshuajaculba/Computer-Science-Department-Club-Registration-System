<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Password
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Password))
        PictureBox1 = New PictureBox()
        Button1 = New Button()
        TextBox2 = New TextBox()
        TextBox1 = New TextBox()
        CheckBox1 = New CheckBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(108, -4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(241, 212)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 6
        PictureBox1.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Aqua
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.Location = New Point(101, 337)
        Button1.Name = "Button1"
        Button1.Size = New Size(241, 49)
        Button1.TabIndex = 11
        Button1.Text = "Change Password"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Linux Libertine Display G", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox2.Location = New Point(69, 263)
        TextBox2.MaxLength = 20
        TextBox2.Multiline = True
        TextBox2.Name = "TextBox2"
        TextBox2.PlaceholderText = "Confirmation Password"
        TextBox2.Size = New Size(313, 35)
        TextBox2.TabIndex = 10
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Linux Libertine Display G", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox1.Location = New Point(69, 211)
        TextBox1.MaxLength = 40
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "New Password"
        TextBox1.Size = New Size(313, 35)
        TextBox1.TabIndex = 9
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(269, 310)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(113, 19)
        CheckBox1.TabIndex = 12
        CheckBox1.Text = "Show Passwords"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Password
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(454, 417)
        Controls.Add(CheckBox1)
        Controls.Add(Button1)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Password"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Password"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents CheckBox1 As CheckBox
End Class
