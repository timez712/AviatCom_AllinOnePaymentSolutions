<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Security_EmployeeInformation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Security_EmployeeInformation))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbCustomerInformation = New System.Windows.Forms.GroupBox()
        Me.btnRefreshData = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboRole = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.lblEmployeeLastName = New System.Windows.Forms.Label()
        Me.lblCustomerZipcode = New System.Windows.Forms.Label()
        Me.txtZipCode = New System.Windows.Forms.MaskedTextBox()
        Me.cboState = New System.Windows.Forms.ComboBox()
        Me.lblCustomerState = New System.Windows.Forms.Label()
        Me.txtCellPhone = New System.Windows.Forms.MaskedTextBox()
        Me.txtHomePhone = New System.Windows.Forms.MaskedTextBox()
        Me.txtAddress = New System.Windows.Forms.MaskedTextBox()
        Me.lblCustomerPhone_1 = New System.Windows.Forms.Label()
        Me.lblCustomerAddr1 = New System.Windows.Forms.Label()
        Me.lblCustomerFax = New System.Windows.Forms.Label()
        Me.lblEmployeeFirstName = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.MaskedTextBox()
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel1.SuspendLayout()
        Me.gbCustomerInformation.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.gbCustomerInformation)
        Me.Panel1.Controls.Add(Me.C1TrueDBGrid1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(916, 496)
        Me.Panel1.TabIndex = 0
        '
        'gbCustomerInformation
        '
        Me.gbCustomerInformation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCustomerInformation.Controls.Add(Me.btnRefreshData)
        Me.gbCustomerInformation.Controls.Add(Me.btnClear)
        Me.gbCustomerInformation.Controls.Add(Me.btnSave)
        Me.gbCustomerInformation.Controls.Add(Me.GroupBox1)
        Me.gbCustomerInformation.Controls.Add(Me.Label7)
        Me.gbCustomerInformation.Controls.Add(Me.Label6)
        Me.gbCustomerInformation.Controls.Add(Me.txtEmail)
        Me.gbCustomerInformation.Controls.Add(Me.lblEmail)
        Me.gbCustomerInformation.Controls.Add(Me.txtLastName)
        Me.gbCustomerInformation.Controls.Add(Me.txtFirstName)
        Me.gbCustomerInformation.Controls.Add(Me.lblCity)
        Me.gbCustomerInformation.Controls.Add(Me.lblEmployeeLastName)
        Me.gbCustomerInformation.Controls.Add(Me.lblCustomerZipcode)
        Me.gbCustomerInformation.Controls.Add(Me.txtZipCode)
        Me.gbCustomerInformation.Controls.Add(Me.cboState)
        Me.gbCustomerInformation.Controls.Add(Me.lblCustomerState)
        Me.gbCustomerInformation.Controls.Add(Me.txtCellPhone)
        Me.gbCustomerInformation.Controls.Add(Me.txtHomePhone)
        Me.gbCustomerInformation.Controls.Add(Me.txtAddress)
        Me.gbCustomerInformation.Controls.Add(Me.lblCustomerPhone_1)
        Me.gbCustomerInformation.Controls.Add(Me.lblCustomerAddr1)
        Me.gbCustomerInformation.Controls.Add(Me.lblCustomerFax)
        Me.gbCustomerInformation.Controls.Add(Me.lblEmployeeFirstName)
        Me.gbCustomerInformation.Controls.Add(Me.txtCity)
        Me.gbCustomerInformation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCustomerInformation.Location = New System.Drawing.Point(614, 3)
        Me.gbCustomerInformation.Name = "gbCustomerInformation"
        Me.gbCustomerInformation.Size = New System.Drawing.Size(295, 486)
        Me.gbCustomerInformation.TabIndex = 0
        Me.gbCustomerInformation.TabStop = False
        Me.gbCustomerInformation.Text = "Customer Information"
        '
        'btnRefreshData
        '
        Me.btnRefreshData.Location = New System.Drawing.Point(6, 440)
        Me.btnRefreshData.Name = "btnRefreshData"
        Me.btnRefreshData.Size = New System.Drawing.Size(87, 40)
        Me.btnRefreshData.TabIndex = 11
        Me.btnRefreshData.Text = "<< Refresh"
        Me.btnRefreshData.UseVisualStyleBackColor = True
        Me.btnRefreshData.Visible = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(99, 440)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(91, 40)
        Me.btnClear.TabIndex = 225
        Me.btnClear.TabStop = False
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(196, 440)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(86, 40)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cboStatus)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboRole)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.txtUserName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(281, 194)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Log-in"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(84, 121)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(13, 16)
        Me.Label10.TabIndex = 233
        Me.Label10.Text = "*"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"Enabled", "Disabled"})
        Me.cboStatus.Location = New System.Drawing.Point(105, 118)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(172, 24)
        Me.cboStatus.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(41, 121)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 16)
        Me.Label9.TabIndex = 231
        Me.Label9.Text = "Status"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(86, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 16)
        Me.Label8.TabIndex = 230
        Me.Label8.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(86, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 16)
        Me.Label5.TabIndex = 229
        Me.Label5.Text = "*"
        '
        'cboRole
        '
        Me.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRole.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRole.FormattingEnabled = True
        Me.cboRole.Items.AddRange(New Object() {"", "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"})
        Me.cboRole.Location = New System.Drawing.Point(105, 82)
        Me.cboRole.Name = "cboRole"
        Me.cboRole.Size = New System.Drawing.Size(172, 24)
        Me.cboRole.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(50, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 16)
        Me.Label4.TabIndex = 227
        Me.Label4.Text = "Role"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(86, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 16)
        Me.Label1.TabIndex = 226
        Me.Label1.Text = "*"
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(105, 47)
        Me.txtPassword.MaxLength = 45
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(170, 22)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.Tag = ""
        '
        'txtUserName
        '
        Me.txtUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Location = New System.Drawing.Point(105, 14)
        Me.txtUserName.MaxLength = 45
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(170, 22)
        Me.txtUserName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 223
        Me.Label2.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 222
        Me.Label3.Text = "User Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(314, 179)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 16)
        Me.Label7.TabIndex = 222
        Me.Label7.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(75, 217)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 16)
        Me.Label6.TabIndex = 221
        Me.Label6.Text = "*"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(4, 324)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(276, 22)
        Me.txtEmail.TabIndex = 5
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.BackColor = System.Drawing.Color.Transparent
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.Location = New System.Drawing.Point(2, 305)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(46, 16)
        Me.lblEmail.TabIndex = 145
        Me.lblEmail.Text = "E-Mail"
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(152, 236)
        Me.txtLastName.MaxLength = 45
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(128, 22)
        Me.txtLastName.TabIndex = 2
        Me.txtLastName.Tag = ""
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(5, 236)
        Me.txtFirstName.MaxLength = 45
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(135, 22)
        Me.txtFirstName.TabIndex = 1
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.BackColor = System.Drawing.Color.Transparent
        Me.lblCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCity.Location = New System.Drawing.Point(3, 393)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(30, 16)
        Me.lblCity.TabIndex = 142
        Me.lblCity.Text = "City"
        '
        'lblEmployeeLastName
        '
        Me.lblEmployeeLastName.AutoSize = True
        Me.lblEmployeeLastName.BackColor = System.Drawing.Color.Transparent
        Me.lblEmployeeLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployeeLastName.Location = New System.Drawing.Point(149, 217)
        Me.lblEmployeeLastName.Name = "lblEmployeeLastName"
        Me.lblEmployeeLastName.Size = New System.Drawing.Size(73, 16)
        Me.lblEmployeeLastName.TabIndex = 139
        Me.lblEmployeeLastName.Text = "Last Name"
        '
        'lblCustomerZipcode
        '
        Me.lblCustomerZipcode.AutoSize = True
        Me.lblCustomerZipcode.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomerZipcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerZipcode.Location = New System.Drawing.Point(202, 393)
        Me.lblCustomerZipcode.Name = "lblCustomerZipcode"
        Me.lblCustomerZipcode.Size = New System.Drawing.Size(27, 16)
        Me.lblCustomerZipcode.TabIndex = 135
        Me.lblCustomerZipcode.Text = "Zip"
        '
        'txtZipCode
        '
        Me.txtZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZipCode.Location = New System.Drawing.Point(205, 412)
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.Size = New System.Drawing.Size(76, 22)
        Me.txtZipCode.TabIndex = 9
        '
        'cboState
        '
        Me.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboState.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboState.FormattingEnabled = True
        Me.cboState.Items.AddRange(New Object() {"", "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"})
        Me.cboState.Location = New System.Drawing.Point(136, 412)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(64, 24)
        Me.cboState.TabIndex = 8
        '
        'lblCustomerState
        '
        Me.lblCustomerState.AutoSize = True
        Me.lblCustomerState.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomerState.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerState.Location = New System.Drawing.Point(133, 393)
        Me.lblCustomerState.Name = "lblCustomerState"
        Me.lblCustomerState.Size = New System.Drawing.Size(39, 16)
        Me.lblCustomerState.TabIndex = 131
        Me.lblCustomerState.Text = "State"
        '
        'txtCellPhone
        '
        Me.txtCellPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCellPhone.Location = New System.Drawing.Point(150, 280)
        Me.txtCellPhone.Name = "txtCellPhone"
        Me.txtCellPhone.Size = New System.Drawing.Size(130, 22)
        Me.txtCellPhone.TabIndex = 4
        '
        'txtHomePhone
        '
        Me.txtHomePhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHomePhone.Location = New System.Drawing.Point(5, 280)
        Me.txtHomePhone.Name = "txtHomePhone"
        Me.txtHomePhone.Size = New System.Drawing.Size(135, 22)
        Me.txtHomePhone.TabIndex = 3
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(6, 368)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(275, 22)
        Me.txtAddress.TabIndex = 6
        '
        'lblCustomerPhone_1
        '
        Me.lblCustomerPhone_1.AutoSize = True
        Me.lblCustomerPhone_1.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomerPhone_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerPhone_1.Location = New System.Drawing.Point(1, 261)
        Me.lblCustomerPhone_1.Name = "lblCustomerPhone_1"
        Me.lblCustomerPhone_1.Size = New System.Drawing.Size(87, 16)
        Me.lblCustomerPhone_1.TabIndex = 125
        Me.lblCustomerPhone_1.Text = "Home Phone"
        '
        'lblCustomerAddr1
        '
        Me.lblCustomerAddr1.AutoSize = True
        Me.lblCustomerAddr1.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomerAddr1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerAddr1.Location = New System.Drawing.Point(3, 349)
        Me.lblCustomerAddr1.Name = "lblCustomerAddr1"
        Me.lblCustomerAddr1.Size = New System.Drawing.Size(59, 16)
        Me.lblCustomerAddr1.TabIndex = 123
        Me.lblCustomerAddr1.Text = "Address"
        '
        'lblCustomerFax
        '
        Me.lblCustomerFax.AutoSize = True
        Me.lblCustomerFax.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomerFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerFax.Location = New System.Drawing.Point(149, 261)
        Me.lblCustomerFax.Name = "lblCustomerFax"
        Me.lblCustomerFax.Size = New System.Drawing.Size(73, 16)
        Me.lblCustomerFax.TabIndex = 118
        Me.lblCustomerFax.Text = "Cell Phone"
        '
        'lblEmployeeFirstName
        '
        Me.lblEmployeeFirstName.AutoSize = True
        Me.lblEmployeeFirstName.BackColor = System.Drawing.Color.Transparent
        Me.lblEmployeeFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployeeFirstName.Location = New System.Drawing.Point(1, 217)
        Me.lblEmployeeFirstName.Name = "lblEmployeeFirstName"
        Me.lblEmployeeFirstName.Size = New System.Drawing.Size(73, 16)
        Me.lblEmployeeFirstName.TabIndex = 112
        Me.lblEmployeeFirstName.Text = "First Name"
        '
        'txtCity
        '
        Me.txtCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.Location = New System.Drawing.Point(6, 412)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(120, 22)
        Me.txtCity.TabIndex = 7
        '
        'C1TrueDBGrid1
        '
        Me.C1TrueDBGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1TrueDBGrid1.BackColor = System.Drawing.Color.White
        Me.C1TrueDBGrid1.CaptionHeight = 17
        Me.C1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid1.Location = New System.Drawing.Point(3, 3)
        Me.C1TrueDBGrid1.Name = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TrueDBGrid1.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid1.RowHeight = 15
        Me.C1TrueDBGrid1.Size = New System.Drawing.Size(605, 486)
        Me.C1TrueDBGrid1.TabIndex = 17
        Me.C1TrueDBGrid1.Text = "C1TrueDBGrid2"
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'frm_Security_EmployeeInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 523)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(950, 550)
        Me.Name = "frm_Security_EmployeeInformation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee Information"
        Me.Panel1.ResumeLayout(False)
        Me.gbCustomerInformation.ResumeLayout(False)
        Me.gbCustomerInformation.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents gbCustomerInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents lblEmployeeLastName As System.Windows.Forms.Label
    Friend WithEvents lblCustomerZipcode As System.Windows.Forms.Label
    Friend WithEvents txtZipCode As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cboState As System.Windows.Forms.ComboBox
    Friend WithEvents lblCustomerState As System.Windows.Forms.Label
    Friend WithEvents txtCellPhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtHomePhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtAddress As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCustomerPhone_1 As System.Windows.Forms.Label
    Friend WithEvents lblCustomerAddr1 As System.Windows.Forms.Label
    Friend WithEvents lblCustomerFax As System.Windows.Forms.Label
    Friend WithEvents lblEmployeeFirstName As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboRole As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnRefreshData As System.Windows.Forms.Button
End Class
