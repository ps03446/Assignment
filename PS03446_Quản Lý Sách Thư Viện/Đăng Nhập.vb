Public Class frmDangNhap
    'sự kiện click nút đăng nhập
    Private Sub btnDangNhap_Click(sender As Object, e As EventArgs) Handles btnDangNhap.Click
        'kiểm tra mật khẩu và id
        If txtTenDangNhap.Text = "admin" And txtMatKhau.Text = "admin" Then
            Me.Close()
            MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmQuanLy.MdiParent = frmTrangChu
            frmQuanLy.Show()
            frmQuanLy.BringToFront()
            frmTrangChu.tsbTrangThai.Text = "Đăng xuất"
        Else
            MessageBox.Show("Vui lòng nhập đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    'thoát form
    Private Sub btnThoatDN_Click(sender As Object, e As EventArgs) Handles btnThoatDN.Click
        Me.Close()
    End Sub


End Class