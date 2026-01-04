<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OTP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OTP))
        PictureBox1 = New PictureBox()
        Button1 = New Button()
        TextBox2 = New TextBox()
        TextBox1 = New TextBox()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(103, -4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(241, 212)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Aqua
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.Location = New Point(109, 302)
        Button1.Name = "Button1"
        Button1.Size = New Size(241, 49)
        Button1.TabIndex = 8
        Button1.Text = "Verify Email"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Linux Libertine Display G", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox2.Location = New Point(71, 244)
        TextBox2.MaxLength = 20
        TextBox2.Multiline = True
        TextBox2.Name = "TextBox2"
        TextBox2.PlaceholderText = "One-Time Password"
        TextBox2.Size = New Size(313, 35)
        TextBox2.TabIndex = 7
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Linux Libertine Display G", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox1.Location = New Point(71, 244)
        TextBox1.MaxLength = 40
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "Registered Email"
        TextBox1.Size = New Size(313, 35)
        TextBox1.TabIndex = 6
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Aqua
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point)
        Button2.Location = New Point(85, 302)
        Button2.Name = "Button2"
        Button2.Size = New Size(142, 49)
        Button2.TabIndex = 9
        Button2.Text = "Verify Code"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.Aqua
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point)
        Button3.Location = New Point(233, 302)
        Button3.Name = "Button3"
        Button3.Size = New Size(142, 49)
        Button3.TabIndex = 10
        Button3.Text = "Re-Send Code"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.Red
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point)
        Button4.Location = New Point(233, 302)
        Button4.Name = "Button4"
        Button4.Size = New Size(142, 49)
        Button4.TabIndex = 11
        Button4.Text = "60"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' OTP
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(454, 417)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "OTP"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OTP"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
End Class
