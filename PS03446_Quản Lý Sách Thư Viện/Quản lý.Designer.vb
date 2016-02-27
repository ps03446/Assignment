<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuanLy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuanLy))
        Me.lblTieuDeQL = New System.Windows.Forms.Label()
        Me.btnThoatQL = New System.Windows.Forms.Button()
        Me.btnThemQL = New System.Windows.Forms.Button()
        Me.grbTieuDe2QL = New System.Windows.Forms.GroupBox()
        Me.ptbHinhSachQL = New System.Windows.Forms.PictureBox()
        Me.btnCapNhat = New System.Windows.Forms.Button()
        Me.btnXoa = New System.Windows.Forms.Button()
        Me.dgvXemDanhSach = New System.Windows.Forms.DataGridView()
        Me.txtTacGia = New System.Windows.Forms.TextBox()
        Me.btnTimKiemTK = New System.Windows.Forms.Button()
        Me.txtMaSachTK = New System.Windows.Forms.TextBox()
        Me.txtTenSachTK = New System.Windows.Forms.TextBox()
        Me.lblTacGia = New System.Windows.Forms.Label()
        Me.lblMaSach = New System.Windows.Forms.Label()
        Me.lblTenSach = New System.Windows.Forms.Label()
        CType(Me.ptbHinhSachQL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvXemDanhSach, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTieuDeQL
        '
        Me.lblTieuDeQL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTieuDeQL.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.lblTieuDeQL.Location = New System.Drawing.Point(17, 70)
        Me.lblTieuDeQL.Name = "lblTieuDeQL"
        Me.lblTieuDeQL.Size = New System.Drawing.Size(469, 24)
        Me.lblTieuDeQL.TabIndex = 10
        Me.lblTieuDeQL.Text = "Danh Sách"
        Me.lblTieuDeQL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnThoatQL
        '
        Me.btnThoatQL.Location = New System.Drawing.Point(535, 353)
        Me.btnThoatQL.Name = "btnThoatQL"
        Me.btnThoatQL.Size = New System.Drawing.Size(90, 23)
        Me.btnThoatQL.TabIndex = 13
        Me.btnThoatQL.Text = "Thoát"
        Me.btnThoatQL.UseVisualStyleBackColor = True
        '
        'btnThemQL
        '
        Me.btnThemQL.Location = New System.Drawing.Point(97, 353)
        Me.btnThemQL.Name = "btnThemQL"
        Me.btnThemQL.Size = New System.Drawing.Size(90, 23)
        Me.btnThemQL.TabIndex = 16
        Me.btnThemQL.Text = "Thêm"
        Me.btnThemQL.UseVisualStyleBackColor = True
        '
        'grbTieuDe2QL
        '
        Me.grbTieuDe2QL.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.grbTieuDe2QL.Location = New System.Drawing.Point(493, 54)
        Me.grbTieuDe2QL.Name = "grbTieuDe2QL"
        Me.grbTieuDe2QL.Size = New System.Drawing.Size(236, 19)
        Me.grbTieuDe2QL.TabIndex = 12
        Me.grbTieuDe2QL.TabStop = False
        Me.grbTieuDe2QL.Text = "Trang bìa"
        '
        'ptbHinhSachQL
        '
        Me.ptbHinhSachQL.BackgroundImage = CType(resources.GetObject("ptbHinhSachQL.BackgroundImage"), System.Drawing.Image)
        Me.ptbHinhSachQL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ptbHinhSachQL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ptbHinhSachQL.Location = New System.Drawing.Point(515, 70)
        Me.ptbHinhSachQL.Name = "ptbHinhSachQL"
        Me.ptbHinhSachQL.Size = New System.Drawing.Size(198, 256)
        Me.ptbHinhSachQL.TabIndex = 4
        Me.ptbHinhSachQL.TabStop = False
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(219, 353)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(75, 23)
        Me.btnCapNhat.TabIndex = 18
        Me.btnCapNhat.Text = "Cập nhật"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(329, 353)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(75, 23)
        Me.btnXoa.TabIndex = 19
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'dgvXemDanhSach
        '
        Me.dgvXemDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvXemDanhSach.Location = New System.Drawing.Point(17, 97)
        Me.dgvXemDanhSach.Name = "dgvXemDanhSach"
        Me.dgvXemDanhSach.Size = New System.Drawing.Size(469, 229)
        Me.dgvXemDanhSach.TabIndex = 20
        '
        'txtTacGia
        '
        Me.txtTacGia.Location = New System.Drawing.Point(446, 22)
        Me.txtTacGia.Name = "txtTacGia"
        Me.txtTacGia.Size = New System.Drawing.Size(132, 23)
        Me.txtTacGia.TabIndex = 34
        '
        'btnTimKiemTK
        '
        Me.btnTimKiemTK.Location = New System.Drawing.Point(584, 22)
        Me.btnTimKiemTK.Name = "btnTimKiemTK"
        Me.btnTimKiemTK.Size = New System.Drawing.Size(75, 23)
        Me.btnTimKiemTK.TabIndex = 33
        Me.btnTimKiemTK.Text = "Tìm kiếm"
        Me.btnTimKiemTK.UseVisualStyleBackColor = True
        '
        'txtMaSachTK
        '
        Me.txtMaSachTK.Location = New System.Drawing.Point(290, 22)
        Me.txtMaSachTK.Name = "txtMaSachTK"
        Me.txtMaSachTK.Size = New System.Drawing.Size(80, 23)
        Me.txtMaSachTK.TabIndex = 31
        '
        'txtTenSachTK
        '
        Me.txtTenSachTK.Location = New System.Drawing.Point(77, 22)
        Me.txtTenSachTK.Name = "txtTenSachTK"
        Me.txtTenSachTK.Size = New System.Drawing.Size(142, 23)
        Me.txtTenSachTK.TabIndex = 32
        '
        'lblTacGia
        '
        Me.lblTacGia.AutoSize = True
        Me.lblTacGia.Location = New System.Drawing.Point(392, 25)
        Me.lblTacGia.Name = "lblTacGia"
        Me.lblTacGia.Size = New System.Drawing.Size(48, 15)
        Me.lblTacGia.TabIndex = 28
        Me.lblTacGia.Text = "Tác giả:"
        '
        'lblMaSach
        '
        Me.lblMaSach.AutoSize = True
        Me.lblMaSach.Location = New System.Drawing.Point(235, 25)
        Me.lblMaSach.Name = "lblMaSach"
        Me.lblMaSach.Size = New System.Drawing.Size(54, 15)
        Me.lblMaSach.TabIndex = 29
        Me.lblMaSach.Text = "Mã sách:"
        '
        'lblTenSach
        '
        Me.lblTenSach.AutoSize = True
        Me.lblTenSach.Location = New System.Drawing.Point(14, 26)
        Me.lblTenSach.Name = "lblTenSach"
        Me.lblTenSach.Size = New System.Drawing.Size(57, 15)
        Me.lblTenSach.TabIndex = 30
        Me.lblTenSach.Text = "Tên sách:"
        '
        'frmQuanLy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 415)
        Me.Controls.Add(Me.txtTacGia)
        Me.Controls.Add(Me.btnTimKiemTK)
        Me.Controls.Add(Me.txtMaSachTK)
        Me.Controls.Add(Me.txtTenSachTK)
        Me.Controls.Add(Me.lblTacGia)
        Me.Controls.Add(Me.lblMaSach)
        Me.Controls.Add(Me.lblTenSach)
        Me.Controls.Add(Me.dgvXemDanhSach)
        Me.Controls.Add(Me.ptbHinhSachQL)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnCapNhat)
        Me.Controls.Add(Me.lblTieuDeQL)
        Me.Controls.Add(Me.btnThoatQL)
        Me.Controls.Add(Me.btnThemQL)
        Me.Controls.Add(Me.grbTieuDe2QL)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmQuanLy"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Quản lý"
        CType(Me.ptbHinhSachQL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvXemDanhSach, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTieuDeQL As System.Windows.Forms.Label
    Friend WithEvents btnThoatQL As System.Windows.Forms.Button
    Friend WithEvents btnThemQL As System.Windows.Forms.Button
    Friend WithEvents grbTieuDe2QL As System.Windows.Forms.GroupBox
    Friend WithEvents ptbHinhSachQL As System.Windows.Forms.PictureBox
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents dgvXemDanhSach As System.Windows.Forms.DataGridView
    Friend WithEvents txtTacGia As System.Windows.Forms.TextBox
    Friend WithEvents btnTimKiemTK As System.Windows.Forms.Button
    Friend WithEvents txtMaSachTK As System.Windows.Forms.TextBox
    Friend WithEvents txtTenSachTK As System.Windows.Forms.TextBox
    Friend WithEvents lblTacGia As System.Windows.Forms.Label
    Friend WithEvents lblMaSach As System.Windows.Forms.Label
    Friend WithEvents lblTenSach As System.Windows.Forms.Label
End Class
